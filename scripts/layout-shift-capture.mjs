/**
 * Headless layout-shift capture (PerformanceObserver) — JSON artifact for CI, same signal class as toolbar CLS lists.
 */
import { chromium } from "playwright";
import { readFileSync, writeFileSync } from "node:fs";
import { fileURLToPath } from "node:url";
import { dirname, join } from "node:path";

const root = join(dirname(fileURLToPath(import.meta.url)), "..");
const quality = JSON.parse(readFileSync(join(root, "quality-urls.json"), "utf8"));
const base = (process.env.QUALITY_BASE_URL || quality.baseUrl).replace(/\/$/, "");
const paths = quality.paths;

const maxClsPerUrl = Number(process.env.LAYOUT_SHIFT_MAX_CLS ?? "0.25");
const failOnOver = process.env.LAYOUT_SHIFT_FAIL !== "0";

async function collectForPage(page, url) {
  await page.goto(url, { waitUntil: "domcontentloaded", timeout: 120000 });
  await page.waitForTimeout(800);
  await page.evaluate(() => {
    window.__ylCls = [];
    const po = new PerformanceObserver((list) => {
      for (const e of list.getEntries()) {
        if (e.hadRecentInput) continue;
        window.__ylCls.push({
          value: e.value,
          startTime: e.startTime,
        });
      }
    });
    try {
      po.observe({ type: "layout-shift", buffered: true });
    } catch {
      /* older chromium */
    }
  });
  await page.mouse.wheel(0, 1200);
  await page.waitForTimeout(1200);
  await page.mouse.wheel(0, -600);
  await page.waitForTimeout(600);
  const entries = await page.evaluate(() => {
    try {
      return window.__ylCls ?? [];
    } catch {
      return [];
    }
  });
  const cls = entries.reduce((s, e) => s + (e.value || 0), 0);
  return { url, cls, entries };
}

const browser = await chromium.launch({ headless: true });
const context = await browser.newContext({ viewport: { width: 1365, height: 900 } });
const page = await context.newPage();

const results = [];
let worst = 0;
for (const path of paths) {
  const url = `${base}${path}`;
  try {
    const r = await collectForPage(page, url);
    results.push(r);
    if (r.cls > worst) worst = r.cls;
    console.log(`layout-shift: ${url}  CLS(sum)=${r.cls.toFixed(4)}  events=${r.entries.length}`);
  } catch (e) {
    console.error(`layout-shift FAIL ${url}`, e.message);
    results.push({ url, cls: -1, error: String(e.message), entries: [] });
  }
}

await browser.close();

const outPath = join(root, "layout-shifts-report.json");
writeFileSync(outPath, JSON.stringify({ generatedAt: new Date().toISOString(), results }, null, 2), "utf8");
console.log("\nWrote", outPath);

const bad = results.filter((r) => r.cls > maxClsPerUrl);
if (failOnOver && bad.length) {
  console.error(`::error::Layout shift CLS exceeded ${maxClsPerUrl} on:`, bad.map((b) => b.url).join(", "));
  process.exit(1);
}
