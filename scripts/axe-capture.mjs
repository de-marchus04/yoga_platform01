/**
 * Run axe-core in Playwright on each quality-urls path; log violations; optional fail on serious.
 */
import { chromium } from "playwright";
import AxeBuilder from "@axe-core/playwright";
import { readFileSync, writeFileSync } from "node:fs";
import { fileURLToPath } from "node:url";
import { dirname, join } from "node:path";

const root = join(dirname(fileURLToPath(import.meta.url)), "..");
const quality = JSON.parse(readFileSync(join(root, "quality-urls.json"), "utf8"));
const base = (process.env.QUALITY_BASE_URL || quality.baseUrl).replace(/\/$/, "");
const failOnSerious = process.env.AXE_FAIL_SERIOUS !== "0";

const browser = await chromium.launch({ headless: true });
const context = await browser.newContext({ viewport: { width: 1365, height: 900 } });
const summary = [];

for (const path of quality.paths) {
  const url = `${base}${path}`;
  const page = await context.newPage();
  try {
    await page.goto(url, { waitUntil: "domcontentloaded", timeout: 120000 });
    await page.waitForTimeout(1000);
    const results = await new AxeBuilder({ page }).analyze();
    const serious = results.violations.filter((v) => v.impact === "serious");
    const moderate = results.violations.filter((v) => v.impact === "moderate");
    summary.push({
      url,
      violations: results.violations.length,
      serious: serious.length,
      moderate: moderate.length,
      ids: results.violations.map((v) => v.id),
      violationsDetail: results.violations.map((v) => ({
        id: v.id,
        impact: v.impact,
        help: v.help,
        targets: v.nodes.slice(0, 5).map((n) => n.target.join(" ")),
      })),
    });
    console.log(`axe: ${url}  violations=${results.violations.length} serious=${serious.length}`);
    for (const v of results.violations.slice(0, 8)) {
      console.log(`  - [${v.impact}] ${v.id}: ${v.help}`);
    }
  } catch (e) {
    console.error(`axe FAIL ${url}`, e.message);
    summary.push({ url, error: e.message });
  } finally {
    await page.close();
  }
}

await browser.close();

const out = join(root, "axe-report.json");
writeFileSync(out, JSON.stringify({ generatedAt: new Date().toISOString(), summary }, null, 2), "utf8");
console.log("Wrote", out);

if (failOnSerious && summary.some((s) => (s.serious ?? 0) > 0)) {
  console.error("::error::Axe reported serious violations (set AXE_FAIL_SERIOUS=0 to warn only)");
  process.exit(1);
}
