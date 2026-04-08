#!/usr/bin/env python3
"""Inject Api.PublicBaseUrl into Blazor wwwroot appsettings.json (HTTPS, trailing slash normalized)."""
from __future__ import annotations

import json
import sys
from pathlib import Path


def main() -> None:
    if len(sys.argv) != 3:
        print(
            "Usage: inject_public_api_url.py <path/to/appsettings.json> <https://api.example.com>",
            file=sys.stderr,
        )
        sys.exit(2)
    path = Path(sys.argv[1])
    raw = sys.argv[2].strip()
    if not raw.startswith("https://"):
        print("Error: API base URL must be an absolute https:// origin.", file=sys.stderr)
        sys.exit(1)
    normalized = raw.rstrip("/") + "/"
    data = json.loads(path.read_text(encoding="utf-8"))
    data.setdefault("Api", {})["PublicBaseUrl"] = normalized
    path.write_text(json.dumps(data, ensure_ascii=False, indent=2) + "\n", encoding="utf-8")


if __name__ == "__main__":
    main()
