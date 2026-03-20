// Bulk translate all RU entity content to EN/UK
// Usage: node translate_content.js [API_URL] [PASSWORD]
// Default: https://api.medisha.space / admin123

import translate from 'google-translate-api-x';

const BASE_URL = process.argv[2] || 'https://api.medisha.space';
const PASSWORD = process.argv[3] || 'admin123';

// ── Entity registry ──
const ENTITIES = [
  // Courses
  { type: 'Course', id: '22222222-2222-2222-2222-222222222201', label: 'Pranayama' },
  { type: 'Course', id: '22222222-2222-2222-2222-222222222202', label: 'Meditation' },
  { type: 'Course', id: '22222222-2222-2222-2222-222222222203', label: 'Yoga' },
  // Pranayama modules
  { type: 'CourseModule', id: 'dd000000-0000-0000-0000-000000000101', label: 'Prana M1' },
  { type: 'CourseModule', id: 'dd000000-0000-0000-0000-000000000102', label: 'Prana M2' },
  { type: 'CourseModule', id: 'dd000000-0000-0000-0000-000000000103', label: 'Prana M3' },
  { type: 'CourseModule', id: 'dd000000-0000-0000-0000-000000000104', label: 'Prana M4' },
  // Meditation modules
  { type: 'CourseModule', id: 'dd000000-0000-0000-0000-000000000201', label: 'Med M1' },
  { type: 'CourseModule', id: 'dd000000-0000-0000-0000-000000000202', label: 'Med M2' },
  { type: 'CourseModule', id: 'dd000000-0000-0000-0000-000000000203', label: 'Med M3' },
  { type: 'CourseModule', id: 'dd000000-0000-0000-0000-000000000204', label: 'Med M4' },
  // Yoga modules  
  { type: 'CourseModule', id: 'dd000000-0000-0000-0000-000000000301', label: 'Yoga M1' },
  { type: 'CourseModule', id: 'dd000000-0000-0000-0000-000000000302', label: 'Yoga M2' },
  { type: 'CourseModule', id: 'dd000000-0000-0000-0000-000000000303', label: 'Yoga M3' },
  { type: 'CourseModule', id: 'dd000000-0000-0000-0000-000000000304', label: 'Yoga M4' },
  // Consultations
  { type: 'Consultation', id: '33333333-3333-3333-3333-333333333301', label: 'Energy' },
  { type: 'Consultation', id: '33333333-3333-3333-3333-333333333302', label: 'Ayurveda' },
  { type: 'Consultation', id: '33333333-3333-3333-3333-333333333303', label: 'Spirituality' },
  // Retreat
  { type: 'Retreat', id: '11111111-1111-1111-1111-111111111111', label: 'Montenegro' },
];

// Fields that contain image URLs — copy as-is, don't translate
const IMAGE_FIELDS = new Set([
  'ImageUrl', 'PresentationImage1Url', 'PresentationImage2Url', 'InstructorImageUrl',
]);

const TARGET_LANGS = ['en', 'uk'];
const LANG_MAP = { en: 'en', uk: 'uk' }; // google-translate codes

// ── Helpers ──

async function login() {
  const res = await fetch(`${BASE_URL}/api/auth/login`, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify({ username: 'admin', password: PASSWORD }),
  });
  if (!res.ok) throw new Error(`Login failed: ${res.status}`);
  const { token } = await res.json();
  return token;
}

async function getAllTranslations(token, entityType, entityId) {
  const res = await fetch(`${BASE_URL}/api/translations/${entityType}/${entityId}/all`, {
    headers: { Authorization: `Bearer ${token}` },
  });
  if (!res.ok) throw new Error(`GET translations failed: ${res.status}`);
  return res.json();
}

async function putTranslation(token, data) {
  const res = await fetch(`${BASE_URL}/api/translations/entity`, {
    method: 'PUT',
    headers: {
      Authorization: `Bearer ${token}`,
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(data),
  });
  if (!res.ok) {
    const text = await res.text();
    console.error(`  PUT FAILED ${res.status}: ${text.substring(0, 200)}`);
    return false;
  }
  return true;
}

// Translate text preserving structure separators (|, ~, \n)
async function translateText(text, targetLang) {
  if (!text || !text.trim()) return text;

  // For pipe-separated values (Benefits), translate each item
  if (text.includes('|') && !text.includes('<')) {
    const parts = text.split('|');
    const translated = [];
    for (const part of parts) {
      // Handle ForWhom format: Title~Text
      if (part.includes('~')) {
        const [title, ...rest] = part.split('~');
        const tTitle = await translateSingle(title.trim(), targetLang);
        const tRest = rest.join('~').trim();
        const tText = tRest ? await translateSingle(tRest, targetLang) : '';
        translated.push(`${tTitle}~${tText}`);
      } else {
        translated.push(await translateSingle(part.trim(), targetLang));
      }
    }
    return translated.join('|');
  }

  // For HTML content, translate as-is (google-translate handles HTML)
  if (text.includes('<p>') || text.includes('<br>')) {
    return translateSingle(text, targetLang);
  }

  // Plain text 
  return translateSingle(text, targetLang);
}

async function translateSingle(text, targetLang) {
  if (!text || !text.trim()) return text;
  try {
    const result = await translate(text, { from: 'ru', to: targetLang });
    return result.text;
  } catch (err) {
    console.error(`  Translation error (${targetLang}): ${err.message}`);
    // Retry once after delay
    await sleep(2000);
    try {
      const result = await translate(text, { from: 'ru', to: targetLang });
      return result.text;
    } catch {
      console.error(`  Retry also failed, keeping original`);
      return text;
    }
  }
}

const sleep = ms => new Promise(r => setTimeout(r, ms));

// ── Main ──

async function main() {
  console.log(`\n=== Bulk translate RU → EN/UK at ${BASE_URL} ===\n`);

  const token = await login();
  console.log('✓ Logged in\n');

  let totalPut = 0;
  let totalSkipped = 0;

  for (const entity of ENTITIES) {
    console.log(`\n── ${entity.type}: ${entity.label} (${entity.id}) ──`);

    const all = await getAllTranslations(token, entity.type, entity.id);
    const ruTranslations = all.filter(t => t.language === 'ru');

    if (ruTranslations.length === 0) {
      console.log('  No RU translations found, skipping');
      continue;
    }

    console.log(`  Found ${ruTranslations.length} RU fields`);

    for (const ru of ruTranslations) {
      for (const lang of TARGET_LANGS) {
        // Check if translation already exists
        const existing = all.find(t => t.field === ru.field && t.language === lang);
        if (existing && existing.value && existing.value.trim()) {
          totalSkipped++;
          continue;
        }

        const isImage = IMAGE_FIELDS.has(ru.field);
        let value;

        if (isImage) {
          value = ru.value; // Copy image URLs as-is
          process.stdout.write(`  [${lang}] ${ru.field} → copy image ... `);
        } else {
          process.stdout.write(`  [${lang}] ${ru.field} → translating ... `);
          value = await translateText(ru.value, LANG_MAP[lang]);
          // Rate limit: 300ms between translation calls
          await sleep(300);
        }

        const ok = await putTranslation(token, {
          entityType: entity.type,
          entityId: entity.id,
          field: ru.field,
          language: lang,
          value,
        });

        console.log(ok ? 'OK' : 'FAILED');
        totalPut++;
      }
    }
  }

  console.log(`\n=== Done! PUT: ${totalPut}, Skipped (already exists): ${totalSkipped} ===\n`);
}

main().catch(err => {
  console.error('Fatal:', err);
  process.exit(1);
});
