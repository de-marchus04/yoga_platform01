/**
 * Merges quality-urls.json paths into Lighthouse CI config (writes lighthouserc.ci.json).
 */
import { readFileSync, writeFileSync } from "node:fs";
import { fileURLToPath } from "node:url";
import { dirname, join } from "node:path";

const root = join(dirname(fileURLToPath(import.meta.url)), "..");
const quality = JSON.parse(readFileSync(join(root, "quality-urls.json"), "utf8"));
/** With staticDistDir, LHCI expects paths like "/" and "/retreats" (see Lighthouse CI docs). */
const urls = quality.paths.map((p) => (p.startsWith("/") ? p : `/${p}`));

const lhci = JSON.parse(readFileSync(join(root, "lighthouserc.json"), "utf8"));
lhci.ci = lhci.ci ?? {};
lhci.ci.collect = lhci.ci.collect ?? {};
lhci.ci.collect.url = urls;

writeFileSync(join(root, "lighthouserc.ci.json"), JSON.stringify(lhci, null, 2) + "\n", "utf8");
console.log("Wrote lighthouserc.ci.json with", urls.length, "URLs");
