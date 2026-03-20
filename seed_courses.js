// Seed courses: Медитация + Женская Йога via production API
// Использование: node seed_courses.js [API_URL] [PASSWORD]
// Пример:        node seed_courses.js https://api.medisha.space admin123
// По умолчанию:  http://localhost:5293 / admin123

const BASE_URL = process.argv[2] || 'http://localhost:5293';
const PASSWORD = process.argv[3] || 'admin123';

const MEDITATION_ID = '22222222-2222-2222-2222-222222222202';
const YOGA_ID       = '22222222-2222-2222-2222-222222222203';

// Module IDs
const M_MOD = {
  1: 'ee000000-0000-0000-0000-000000000201',
  2: 'ee000000-0000-0000-0000-000000000202',
  3: 'ee000000-0000-0000-0000-000000000203',
  4: 'ee000000-0000-0000-0000-000000000204',
  5: 'ee000000-0000-0000-0000-000000000205',
  6: 'ee000000-0000-0000-0000-000000000206',
};
const Y_MOD = {
  1: 'ff000000-0000-0000-0000-000000000301',
  2: 'ff000000-0000-0000-0000-000000000302',
  3: 'ff000000-0000-0000-0000-000000000303',
  4: 'ff000000-0000-0000-0000-000000000304',
};

async function login() {
  const res = await fetch(`${BASE_URL}/api/auth/login`, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify({ username: 'admin', password: PASSWORD }),
  });
  const { token } = await res.json();
  return token;
}

async function putCourse(token, id, slug, sortOrder, moduleIds, courseId) {
  const modules = moduleIds.map((mid, i) => ({
    id: mid,
    courseId: courseId,
    sortOrder: i + 1,
    lessons: [],
  }));
  const course = {
    id,
    slug,
    sortOrder,
    isActive: true,
    isOnline: false,
    isOffline: false,
    modules,
  };
  const res = await fetch(`${BASE_URL}/api/courses/${id}`, {
    method: 'PUT',
    headers: {
      'Authorization': `Bearer ${token}`,
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(course),
  });
  if (res.ok || res.status === 204) {
    console.log(`✓ Course ${slug} modules created`);
  } else {
    const text = await res.text();
    console.log(`✗ Course ${slug} FAILED ${res.status}: ${text.substring(0, 200)}`);
  }
}

async function putTranslation(token, data) {
  process.stdout.write(`  [${data.entityType}/${data.field}] ... `);
  const res = await fetch(`${BASE_URL}/api/translations/entity`, {
    method: 'PUT',
    headers: {
      'Authorization': `Bearer ${token}`,
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(data),
  });
  if (res.ok) console.log('OK');
  else console.log(`FAILED ${res.status}`);
}

async function seed() {
  console.log(`\n=== Seeding courses at ${BASE_URL} ===\n`);

  const token = await login();
  console.log('✓ Logged in\n');

  // ------------------------------------------
  // 1. Create modules structure
  // ------------------------------------------
  console.log('--- Creating module structures ---');
  await putCourse(token, MEDITATION_ID, 'meditation', 2,
    Object.values(M_MOD), MEDITATION_ID);
  await putCourse(token, YOGA_ID, 'yoga', 3,
    Object.values(Y_MOD), YOGA_ID);

  // ------------------------------------------
  // 2. Meditation translations
  // ------------------------------------------
  console.log('\n--- Meditation: course fields ---');
  const meditationCourse = [
    { entityType: 'Course', entityId: MEDITATION_ID, language: 'ru', field: 'Title',
      value: 'Медитация' },
    { entityType: 'Course', entityId: MEDITATION_ID, language: 'ru', field: 'Subtitle',
      value: 'Практика осознанного присутствия' },
    { entityType: 'Course', entityId: MEDITATION_ID, language: 'ru', field: 'Eyebrow',
      value: 'Онлайн-курс' },
    { entityType: 'Course', entityId: MEDITATION_ID, language: 'ru', field: 'Description',
      value: 'Медитация — это практический навык работы с вниманием и состоянием ума. Другими словами, это практика осознанного присутствия.\n\nТы учишься:\nзамечать свои мысли, эмоции и ощущения\nне «залипать» в них\nвозвращать внимание в настоящий момент\n\nЧаще всего это делают через фокус на дыхании, теле или звуках.\n\nМедитация тренирует «наблюдателя», который:\nвидит мысли\nно не вовлекается в них\n\nЭто связано с процессами в мозге, изучаемыми в нейронауке.' },
    { entityType: 'Course', entityId: MEDITATION_ID, language: 'ru', field: 'Benefits',
      value: 'Снижение стресса и тревожности|Улучшение качества сна|Развитие устойчивости внимания|Управление эмоциями и состояниями|Осознанность в повседневной жизни' },
    { entityType: 'Course', entityId: MEDITATION_ID, language: 'ru', field: 'ImageUrl',
      value: 'https://images.unsplash.com/photo-1508672019048-805c876b67e2?auto=format&fit=crop&w=1600&q=80' },
    { entityType: 'Course', entityId: MEDITATION_ID, language: 'ru', field: 'Duration',
      value: '6–8 недель' },
    { entityType: 'Course', entityId: MEDITATION_ID, language: 'ru', field: 'Level',
      value: 'Для всех уровней' },
    { entityType: 'Course', entityId: MEDITATION_ID, language: 'ru', field: 'Format',
      value: 'Онлайн / Офлайн' },
    { entityType: 'Course', entityId: MEDITATION_ID, language: 'ru', field: 'Schedule',
      value: '5–6 дней в неделю. 10 мин в начале → до 30 мин к концу курса' },
    { entityType: 'Course', entityId: MEDITATION_ID, language: 'ru', field: 'ForWhom',
      value: 'Начинающим~Тем, кто хочет впервые освоить практику медитации в безопасной и понятной среде|При стрессе и тревоге~Тем, кто ищет проверенные инструменты для управления эмоциональным состоянием|Для углубления практики~Практикующим йогу или пранаяму и желающим дополнить опыт медитацией' },
    { entityType: 'Course', entityId: MEDITATION_ID, language: 'ru', field: 'CtaHeading',
      value: 'Начните практику сегодня' },
    { entityType: 'Course', entityId: MEDITATION_ID, language: 'ru', field: 'CtaText',
      value: 'Оставьте заявку — мы расскажем о ближайшем потоке и ответим на все вопросы.' },
  ];
  for (const t of meditationCourse) await putTranslation(token, t);

  console.log('\n--- Meditation: modules ---');
  const meditationModules = [
    { id: M_MOD[1], title: 'Модуль 1. Введение в медитацию',
      desc: 'Цель: понять, что такое медитация и зачем она нужна (1 неделя)\n\nТемы:\nЧто такое медитация — не «очистка ума», а наблюдение\nПольза: стресс, внимание, эмоции\nОсновы дыхания и осознанности\nРазвенчание мифов\n\nПрактика:\n5–10 минут в день: наблюдение за дыханием\nПростая техника: «вдох–выдох–заметил отвлечение–вернулся»' },
    { id: M_MOD[2], title: 'Модуль 2. Концентрация и внимание',
      desc: 'Цель: развить устойчивость внимания (1–2 недели)\n\nТемы:\nФокус внимания и отвлечения\nКак работает ум — блуждание мыслей\nОсновы осознанности\n\nПрактика:\n10–15 минут: фокус на дыхании и звуках\nСчёт дыханий (1–10)\nОтслеживание отвлечений без осуждения' },
    { id: M_MOD[3], title: 'Модуль 3. Работа с мыслями',
      desc: 'Цель: научиться не вовлекаться в поток мыслей (1 неделя)\n\nТемы:\nМысли ≠ факты\nНаблюдение за мышлением\nТехника «ярлыков» (мысль, эмоция, воспоминание)\n\nПрактика:\n15 минут: наблюдение мыслей\nПрактика «облака»: мысли приходят и уходят' },
    { id: M_MOD[4], title: 'Модуль 4. Эмоции и принятие',
      desc: 'Цель: научиться проживать эмоции без подавления (1–2 недели)\n\nТемы:\nПрирода эмоций\nРеакция vs осознанный отклик\nСамосострадание\n\nПрактика:\nМедитация на чувства в теле\nТехника R.A.I.N. (Распознать, Допустить, Исследовать, Взрастить)\n15–20 минут ежедневно' },
    { id: M_MOD[5], title: 'Модуль 5. Медитация в жизни',
      desc: 'Цель: интегрировать практику в повседневность (1 неделя)\n\nТемы:\nОсознанность в действии\nМедитация вне подушки\nПривычки и дисциплина\n\nПрактика:\nОсознанная ходьба\nОсознанное питание\n«Микро-паузы» в течение дня' },
    { id: M_MOD[6], title: 'Модуль 6. Продвинутая практика',
      desc: 'Цель: углубление опыта (1–2 недели)\n\nТемы:\nОткрытое наблюдение\nБезобъектная медитация\n\nПрактика:\n20–30 минут\nЧередование техник\nСамостоятельные сессии' },
  ];
  for (const m of meditationModules) {
    await putTranslation(token, { entityType: 'CourseModule', entityId: m.id, language: 'ru', field: 'Title', value: m.title });
    await putTranslation(token, { entityType: 'CourseModule', entityId: m.id, language: 'ru', field: 'Description', value: m.desc });
  }

  // ------------------------------------------
  // 3. Yoga translations
  // ------------------------------------------
  console.log('\n--- Yoga: course fields ---');
  const yogaCourse = [
    { entityType: 'Course', entityId: YOGA_ID, language: 'ru', field: 'Title',
      value: 'Женская йога' },
    { entityType: 'Course', entityId: YOGA_ID, language: 'ru', field: 'Subtitle',
      value: 'Баланс тела, дыхания и разума' },
    { entityType: 'Course', entityId: YOGA_ID, language: 'ru', field: 'Eyebrow',
      value: 'Авторский курс' },
    { entityType: 'Course', entityId: YOGA_ID, language: 'ru', field: 'Description',
      value: 'Йога — это обширное понятие, объединяющее множество практик, результатом которых является единение со своим истинным сознанием.\n\nПроще говоря, йога — это не только упражнения, а целая система для улучшения физического и психического состояния.\n\nОсновные элементы йоги:\nАсаны — физические позы, развивающие гибкость, силу и баланс\nПранаяма — дыхательные техники для контроля энергии и успокоения ума\nМедитация — практика концентрации и внутреннего покоя\n\nЗанимаясь йогой ты сможешь:\nулучшить здоровье и осанку\nснизить стресс и тревожность\nповысить концентрацию\nнайти внутреннее равновесие' },
    { entityType: 'Course', entityId: YOGA_ID, language: 'ru', field: 'Benefits',
      value: 'Улучшение гормонального баланса|Работа с женским здоровьем|Снижение стресса и тревожности|Развитие мягкости, гибкости и осознанности|Укрепление связи с телом' },
    { entityType: 'Course', entityId: YOGA_ID, language: 'ru', field: 'ImageUrl',
      value: 'https://images.unsplash.com/photo-1571019613454-1cb2f99b2d8b?auto=format&fit=crop&w=1600&q=80' },
    { entityType: 'Course', entityId: YOGA_ID, language: 'ru', field: 'Duration',
      value: '4 недели' },
    { entityType: 'Course', entityId: YOGA_ID, language: 'ru', field: 'Level',
      value: 'Для начинающих' },
    { entityType: 'Course', entityId: YOGA_ID, language: 'ru', field: 'Format',
      value: 'Онлайн / Офлайн' },
    { entityType: 'Course', entityId: YOGA_ID, language: 'ru', field: 'Schedule',
      value: '5–6 дней в неделю. Занятия до 60 минут. Затем 1–2 раза в неделю в общей группе' },
    { entityType: 'Course', entityId: YOGA_ID, language: 'ru', field: 'ForWhom',
      value: 'Женщинам~Всем, кто хочет улучшить гормональный баланс, снизить стресс и найти гармонию с телом|Начинающим~Тем, кто не практиковал йогу или только начинает: всё объяснено, темп мягкий|Для восстановления~Тем, кто переживает усталость, выгорание или хочет наладить связь с собой' },
    { entityType: 'Course', entityId: YOGA_ID, language: 'ru', field: 'CtaHeading',
      value: 'Начните путь к гармонии' },
    { entityType: 'Course', entityId: YOGA_ID, language: 'ru', field: 'CtaText',
      value: 'Оставьте заявку — Ольга расскажет о ближайшем потоке и ответит на все вопросы.' },
    { entityType: 'Course', entityId: YOGA_ID, language: 'ru', field: 'InstructorName',
      value: 'Ольга Шалетина' },
    { entityType: 'Course', entityId: YOGA_ID, language: 'ru', field: 'InstructorBio',
      value: 'Йога-тренер с 15-летним стажем и телесный терапевт (10 лет практики). Специализируется на женской йоге, работе с телом и гормональным балансом. Ведёт занятия для женских групп онлайн и офлайн.' },
  ];
  for (const t of yogaCourse) await putTranslation(token, t);

  console.log('\n--- Yoga: modules ---');
  const yogaModules = [
    { id: Y_MOD[1], title: 'Неделя 1. Знакомство с телом и мягкое включение',
      desc: 'Цель: расслабление, снятие напряжения, мягкий старт\n\nПранаяма: 5–10 минут + разминка суставов\n\nАсаны:\nБаласана (поза ребёнка)\nКошка-корова\nСупта Баддха Конасана\nЛёгкие наклоны сидя\n\nФокус:\nУчимся чувствовать тело\nУбираем напряжение в тазу и пояснице' },
    { id: Y_MOD[2], title: 'Неделя 2. Работа с тазовой областью',
      desc: 'Цель: улучшение кровообращения и мягкая активация женских органов\n\nПранаяма с акцентом на живот\n\nАсаны:\nБаддха Конасана (бабочка)\nВыпады (Анджанеясана)\nПоза голубя (мягкая вариация)\nПоза моста (Сету Бандхасана)\n\nФокус:\nРаскрытие тазобедренных суставов\nУлучшение циркуляции\nРабота с зажимами' },
    { id: Y_MOD[3], title: 'Неделя 3. Гормональный баланс и энергия',
      desc: 'Цель: стабилизация внутреннего состояния\n\nПранаяма: спокойное дыхание через нос\n\nАсаны:\nВипарита Карани (ноги вверх)\nБхуджангасана (поза кобры)\nПоза воина II\nНаклоны вперёд\n\nФокус:\nБаланс энергии\nСнижение тревожности\nПоддержка гормональной системы' },
    { id: Y_MOD[4], title: 'Неделя 4. Глубокое расслабление и интеграция',
      desc: 'Цель: восстановление, гармония, закрепление результата\n\nМедитация: 5–15 минут + дыхательные практики\n\nАсаны:\nШавасана (глубокое расслабление)\nСупта Баддха Конасана\nЛёгкие скрутки\nМягкие растяжки\n\nФокус:\nВосстановление нервной системы\nОсознанность\nЗакрепление привычки регулярной практики' },
  ];
  for (const m of yogaModules) {
    await putTranslation(token, { entityType: 'CourseModule', entityId: m.id, language: 'ru', field: 'Title', value: m.title });
    await putTranslation(token, { entityType: 'CourseModule', entityId: m.id, language: 'ru', field: 'Description', value: m.desc });
  }

  console.log('\n✅ Seed complete!');
}

seed().catch(err => { console.error(err); process.exit(1); });
