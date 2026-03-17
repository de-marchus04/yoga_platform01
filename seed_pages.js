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
    
    const aboutId = "44444444-4444-4444-4444-444444444401";
    const contactsId = "44444444-4444-4444-4444-444444444402";

    const data = [
        // About page fields (ru)
        { entityType: "SitePage", entityId: aboutId, language: "ru", field: "MetaTitle", value: "О нас | Yoga.Life Enterprise" },
        { entityType: "SitePage", entityId: aboutId, language: "ru", field: "HeroTitle", value: "О создателях" },
        { entityType: "SitePage", entityId: aboutId, language: "ru", field: "HeroSubtitle", value: "Yoga.Life Enterprise — это пространство, где встречаются традиция и современность, практика и трансформация." },
        { entityType: "SitePage", entityId: aboutId, language: "ru", field: "HeroImageUrl", value: "https://images.unsplash.com/photo-1506126613408-eca07ce68773?auto=format&fit=crop&w=1600&q=80" },
        { entityType: "SitePage", entityId: aboutId, language: "ru", field: "Founder1Role", value: "Автор методик · Инструктор · 15+ лет практики" },
        { entityType: "SitePage", entityId: aboutId, language: "ru", field: "Founder1Name", value: "Ольга Шалетина" },
        { entityType: "SitePage", entityId: aboutId, language: "ru", field: "Founder1Text1", value: "Ольга начала путь йоги в 20 лет — и с тех пор не останавливалась. За 15+ лет практики и преподавания она разработала авторские программы оздоровления через дыхание, которые прошли более 300 студентов." },
        { entityType: "SitePage", entityId: aboutId, language: "ru", field: "Founder1Text2", value: "Специализация — пранаяма, йога-нидра и работа с хроническим стрессом. Её классы сочетают строгость традиции с теплотой живого присутствия." },
        { entityType: "SitePage", entityId: aboutId, language: "ru", field: "Founder1ImageUrl", value: "https://images.unsplash.com/photo-1544367567-0f2fcb009e0b?auto=format&fit=crop&w=600&q=80" },
        { entityType: "SitePage", entityId: aboutId, language: "ru", field: "Founder2Role", value: "Учитель · Духовный наставник · 25+ лет опыта" },
        { entityType: "SitePage", entityId: aboutId, language: "ru", field: "Founder2Name", value: "Александр Украинцев" },
        { entityType: "SitePage", entityId: aboutId, language: "ru", field: "Founder2Text1", value: "Александр изучает йогу и ведическую философию более 25 лет. Он провёл свыше 40 ретритов в России, Европе и Азии, а его наставничество глубоко уходит корнями в традицию крийя-йоги." },
        { entityType: "SitePage", entityId: aboutId, language: "ru", field: "Founder2Text2", value: "Его подход — не набор техник, а целостный путь: от физического тела к самому тонкому. Каждый ретрит под его руководством становится точкой отсчёта новой жизни." },
        { entityType: "SitePage", entityId: aboutId, language: "ru", field: "Founder2ImageUrl", value: "https://images.unsplash.com/photo-1566753323558-f4e0952af115?auto=format&fit=crop&w=600&q=80" },
        { entityType: "SitePage", entityId: aboutId, language: "ru", field: "Founder3Role", value: "Создатель платформы · Разработчик" },
        { entityType: "SitePage", entityId: aboutId, language: "ru", field: "Founder3Name", value: "Дмитрий Державин" },
        { entityType: "SitePage", entityId: aboutId, language: "ru", field: "Founder3Text1", value: "Дмитрий создал технологическую основу Yoga.Life Enterprise — систему, которая объединяет учителей и студентов со всего мира в единое пространство практики и роста." },
        { entityType: "SitePage", entityId: aboutId, language: "ru", field: "Founder3Text2", value: "Его видение: технологии должны служить духовному развитию, а не отвлекать от него. Платформа строится на принципах простоты, красоты и функциональности." },
        { entityType: "SitePage", entityId: aboutId, language: "ru", field: "Founder3ImageUrl", value: "https://images.unsplash.com/photo-1529385360753-af0119f7cbe7?auto=format&fit=crop&w=600&q=80" },
        { entityType: "SitePage", entityId: aboutId, language: "ru", field: "Phil1Title", value: "Присутствие" },
        { entityType: "SitePage", entityId: aboutId, language: "ru", field: "Phil1Text", value: "Каждая практика начинается с момента здесь и сейчас. Мы создаём пространство, где тело и ум обретают покой." },
        { entityType: "SitePage", entityId: aboutId, language: "ru", field: "Phil2Title", value: "Традиция" },
        { entityType: "SitePage", entityId: aboutId, language: "ru", field: "Phil2Text", value: "Наши методики уходят корнями в многовековые практики йоги, аюрведы и ведической философии." },
        { entityType: "SitePage", entityId: aboutId, language: "ru", field: "Phil3Title", value: "Трансформация" },
        { entityType: "SitePage", entityId: aboutId, language: "ru", field: "Phil3Text", value: "Мы не просто учим асанам — мы помогаем переосмыслить жизнь через осознанное движение, дыхание и тишину." },

        // Contacts page fields (ru)
        { entityType: "SitePage", entityId: contactsId, language: "ru", field: "MetaTitle", value: "Контакты | Yoga.Life Enterprise" },
        { entityType: "SitePage", entityId: contactsId, language: "ru", field: "HeroTitle", value: "Контакты" },
        { entityType: "SitePage", entityId: contactsId, language: "ru", field: "HeroSubtitle", value: "Выберите удобный способ связи — мы отвечаем быстро." },
        { entityType: "SitePage", entityId: contactsId, language: "ru", field: "HeroImageUrl", value: "https://images.unsplash.com/photo-1544367567-0f2fcb009e0b?auto=format&fit=crop&w=1600&q=80" },
        { entityType: "SitePage", entityId: contactsId, language: "ru", field: "TelegramDesc", value: "Самый быстрый способ связаться с нами. Отвечаем в течение часа." },
        { entityType: "SitePage", entityId: contactsId, language: "ru", field: "TelegramUrl", value: "https://t.me/yogalife_enterprise" },
        { entityType: "SitePage", entityId: contactsId, language: "ru", field: "TelegramHandle", value: "@yogalife_enterprise" },
        { entityType: "SitePage", entityId: contactsId, language: "ru", field: "WhatsAppDesc", value: "Голосовые и текстовые сообщения. Удобно для развёрнутых вопросов." },
        { entityType: "SitePage", entityId: contactsId, language: "ru", field: "WhatsAppUrl", value: "https://wa.me/79000000000" },
        { entityType: "SitePage", entityId: contactsId, language: "ru", field: "WhatsAppPhone", value: "+7 (900) 000-00-00" },
        { entityType: "SitePage", entityId: contactsId, language: "ru", field: "InstagramDesc", value: "Следите за нашими практиками, ретритами и вдохновляющим контентом." },
        { entityType: "SitePage", entityId: contactsId, language: "ru", field: "InstagramUrl", value: "https://instagram.com/yogalife_enterprise" },
        { entityType: "SitePage", entityId: contactsId, language: "ru", field: "InstagramHandle", value: "@yogalife_enterprise" },
        { entityType: "SitePage", entityId: contactsId, language: "ru", field: "YouTubeUrl", value: "https://youtube.com/@yogalife_enterprise" },
        { entityType: "SitePage", entityId: contactsId, language: "ru", field: "YouTubeHandle", value: "@yogalife_enterprise" }
    ];

    for (let d of data) {
        process.stdout.write(`Uploading ${d.entityId} [${d.field}] ... `);
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
