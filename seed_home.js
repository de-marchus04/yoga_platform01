const http = require('http');

async function seed() {
    console.log("Logging in...");
    const loginRes = await fetch("http://localhost:5293/api/auth/login", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ username: "admin", password: "admin123" })
    });
    const { token } = await loginRes.json();
    console.log("Token obtained!");

    const baseUrl = "http://localhost:5293/api/translations/entity";
    const homeId = "44444444-4444-4444-4444-444444444403";

    const data = [
        { entityType: "SitePage", entityId: homeId, language: "ru", field: "MetaTitle", value: "Yoga.Life | Авторские Ретриты" },
        { entityType: "SitePage", entityId: homeId, language: "ru", field: "MetaDescription", value: "Эксклюзивные авторские ретриты и программы обучения. Погружение в тишину и возврат к себе." },
        
        { entityType: "SitePage", entityId: homeId, language: "ru", field: "HeroEyebrow", value: "Yoga · Life · Enterprise" },
        { entityType: "SitePage", entityId: homeId, language: "ru", field: "HeroTitle", value: "Возврат" },
        { entityType: "SitePage", entityId: homeId, language: "ru", field: "HeroSubtitle", value: "к себе" },
        { entityType: "SitePage", entityId: homeId, language: "ru", field: "HeroText", value: "Авторские ретриты и программы обучения. Погружение в тишину, практики осознанности и полное обновление." },
        { entityType: "SitePage", entityId: homeId, language: "ru", field: "HeroImage", value: "https://images.unsplash.com/photo-1544367567-0f2fcb009e0b?auto=format&fit=crop&w=1400&q=80" },

        { entityType: "SitePage", entityId: homeId, language: "ru", field: "Stats1Label", value: "Ретритов" },
        { entityType: "SitePage", entityId: homeId, language: "ru", field: "Stats1Value", value: "12+" },
        { entityType: "SitePage", entityId: homeId, language: "ru", field: "Stats2Label", value: "Участников" },
        { entityType: "SitePage", entityId: homeId, language: "ru", field: "Stats2Value", value: "300+" },
        { entityType: "SitePage", entityId: homeId, language: "ru", field: "Stats3Label", value: "Стран" },
        { entityType: "SitePage", entityId: homeId, language: "ru", field: "Stats3Value", value: "5" },
        { entityType: "SitePage", entityId: homeId, language: "ru", field: "Stats4Label", value: "Лет практики" },
        { entityType: "SitePage", entityId: homeId, language: "ru", field: "Stats4Value", value: "8" },

        { entityType: "SitePage", entityId: homeId, language: "ru", field: "Dir1Title", value: "Курсы" },
        { entityType: "SitePage", entityId: homeId, language: "ru", field: "Dir1Text", value: "Пранаяма, медитация, йога — системные программы для углублённой практики в любом темпе." },
        { entityType: "SitePage", entityId: homeId, language: "ru", field: "Dir1LinkText", value: "Смотреть курсы →" },
        { entityType: "SitePage", entityId: homeId, language: "ru", field: "Dir2Title", value: "Консультации" },
        { entityType: "SitePage", entityId: homeId, language: "ru", field: "Dir2Text", value: "Индивидуальный разбор по энергетике, аюрведе и духовным практикам с личным куратором." },
        { entityType: "SitePage", entityId: homeId, language: "ru", field: "Dir2LinkText", value: "Записаться →" },
        { entityType: "SitePage", entityId: homeId, language: "ru", field: "Dir3Title", value: "Ретриты" },
        { entityType: "SitePage", entityId: homeId, language: "ru", field: "Dir3Text", value: "Выездные программы в Черногории, Индии и других локациях. От 7 до 21 дня полного погружения." },
        { entityType: "SitePage", entityId: homeId, language: "ru", field: "Dir3LinkText", value: "Все ретриты →" },

        { entityType: "SitePage", entityId: homeId, language: "ru", field: "QuoteText", value: "«Йога — это не то, что вы делаете на коврике.<br/>Это то, кем вы становитесь — за его пределами.»" },
        { entityType: "SitePage", entityId: homeId, language: "ru", field: "QuoteAuthor", value: "— Yoga.Life" },
        { entityType: "SitePage", entityId: homeId, language: "ru", field: "QuoteBackgroundImage", value: "https://images.unsplash.com/photo-1518609878373-06d740f60d8b?auto=format&fit=crop&w=1600&q=80" },

        { entityType: "SitePage", entityId: homeId, language: "ru", field: "Format1Title", value: "Онлайн" },
        { entityType: "SitePage", entityId: homeId, language: "ru", field: "Format1Text", value: "Практикуйте из любой точки мира. Живые сессии, записи, индивидуальная обратная связь от куратора в вашем ритме." },
        { entityType: "SitePage", entityId: homeId, language: "ru", field: "Format1Cta", value: "Онлайн-курсы" },
        { entityType: "SitePage", entityId: homeId, language: "ru", field: "Format1Image", value: "https://images.unsplash.com/photo-1593811167562-9cef47bfc4d7?auto=format&fit=crop&w=800&q=80" },
        
        { entityType: "SitePage", entityId: homeId, language: "ru", field: "Format2Title", value: "Офлайн" },
        { entityType: "SitePage", entityId: homeId, language: "ru", field: "Format2Text", value: "Живое присутствие и глубокое взаимодействие. Ретриты и интенсивы в сакральных местах силы." },
        { entityType: "SitePage", entityId: homeId, language: "ru", field: "Format2Cta", value: "Ретриты и выезды" },
        { entityType: "SitePage", entityId: homeId, language: "ru", field: "Format2Image", value: "https://images.unsplash.com/photo-1528319725582-ddc096101511?auto=format&fit=crop&w=800&q=80" },

        { entityType: "SitePage", entityId: homeId, language: "ru", field: "Review1Quote", value: "«После ретрита в Черногории я впервые за несколько лет почувствовала, что тело и голова — в одном месте. Это был настоящий перезапуск.»" },
        { entityType: "SitePage", entityId: homeId, language: "ru", field: "Review1Author", value: "Анна К." },
        { entityType: "SitePage", entityId: homeId, language: "ru", field: "Review1Program", value: "Ретрит «Черногория, сентябрь»" },
        { entityType: "SitePage", entityId: homeId, language: "ru", field: "Review2Quote", value: "«Курс по пранаяме изменил моё отношение к дыханию и к жизни в целом. Простые техники, которые работают каждый день.»" },
        { entityType: "SitePage", entityId: homeId, language: "ru", field: "Review2Author", value: "Михаил Р." },
        { entityType: "SitePage", entityId: homeId, language: "ru", field: "Review2Program", value: "Курс «Пранаяма: базовый»" },
        { entityType: "SitePage", entityId: homeId, language: "ru", field: "Review3Quote", value: "«Индивидуальная консультация по аюрведе дала мне план на год вперёд — питание, режим, практики. Всё чётко и без лишней эзотерики.»" },
        { entityType: "SitePage", entityId: homeId, language: "ru", field: "Review3Author", value: "Светлана В." },
        { entityType: "SitePage", entityId: homeId, language: "ru", field: "Review3Program", value: "Консультация «Аюрведа»" }
    ];

    for (let d of data) {
        process.stdout.write(`Uploading [${d.field}] ... `);
        const res = await fetch(baseUrl, {
            method: "PUT",
            headers: { 
                "Authorization": `Bearer ${token}`,
                "Content-Type": "application/json" 
            },
            body: JSON.stringify(d)
        });
        if (res.ok) console.log("OK");
        else console.log("FAILED", res.status);
    }
}

seed().catch(console.error);
