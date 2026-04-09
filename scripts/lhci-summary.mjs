/**
 * Prints URL × performance × accessibility × CLS from .lighthouseci LHR JSON (for GitHub Actions log).
 */
import { readdirSync, readFileSync, statSync } from "node:fs";
import { join } from "node:path";

const roots = [".lighthouseci", "lighthouse-ci-reports"];

function walk(dir, acc = []) {
  try {
    if (!statSync(dir, { throwIfNoEntry: false })?.isDirectory()) return acc;
    for (const name of readdirSync(dir)) {
      const p = join(dir, name);
      const st = statSync(p);
      if (st.isDirectory()) walk(p, acc);
      else if (name.endsWith(".json") && name.includes("lhr")) {
        try {
          const j = JSON.parse(readFileSync(p, "utf8"));
          acc.push({ file: p, lhr: j });
        } catch {
          /* skip */
        }
      }
    }
  } catch {
    /* missing */
  }
  return acc;
}

const all = [];
for (const r of roots) walk(r, all);

if (all.length === 0) {
  console.log("lhci-summary: no LHR JSON found under .lighthouseci or lighthouse-ci-reports");
  process.exit(0);
}

console.log("\n=== Lighthouse summary (URL | perf | a11y | CLS) ===\n");
for (const { lhr } of all) {
  const url = lhr.finalUrl ?? lhr.requestedUrl ?? "?";
  const perf = lhr.categories?.performance?.score;
  const a11y = lhr.categories?.accessibility?.score;
  const cls = lhr.audits?.["cumulative-layout-shift"]?.numericValue;
  const perfS = perf == null ? "—" : (perf * 100).toFixed(0);
  const a11yS = a11y == null ? "—" : (a11y * 100).toFixed(0);
  const clsS = cls == null ? "—" : cls.toFixed(4);
  console.log(`${url}\n  performance: ${perfS}  accessibility: ${a11yS}  CLS: ${clsS}`);
  const failed = Object.values(lhr.audits ?? {}).filter(
    (a) => a.score !== null && a.score < 1 && a.scoreDisplayMode !== "informative"
  );
  const top = failed
    .filter((a) => a.id?.includes("contrast") || a.id?.includes("heading") || a.id?.includes("layout"))
    .slice(0, 6)
    .map((a) => a.id);
  if (top.length) console.log("  related audits:", top.join(", "));
}
console.log("");
