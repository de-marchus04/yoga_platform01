# Платформа Yoga.Life — архитектура и публичная витрина

Монорепозиторий содержит три проекта:

| Проект | Тип | Описание |
|---|---|---|
| `Yoga.Api` | ASP.NET Core 8 Web API | Backend, БД PostgreSQL через EF Core |
| `Yoga.Client` | Blazor WASM | Публичный фронтенд + встроенный Admin CMS |
| `Yoga.Shared` | .NET 8 Class Library | DTOs и модели, общие для обоих |

## Публичная витрина

Маршруты `/`, `/courses`, `/courses/{slug}`, `/consultations`, `/consultations/{slug}`, `/retreats`, `/retreats/{slug}`, `/yagyas`, `/yagyas/{slug}`, `/about`, `/contacts`, `/privacy`, `/terms`.

Контент загружается из API. Страница рендерится на клиенте (WASM), SEO — серверный pre-render не используется (SPA).

Раздел заявок: `POST /api/leads` — сохраняет заявку в БД, уведомление через Telegram bot.

## Admin CMS

Маршруты `/admin/*` — встроены в `Yoga.Client`, защищены cookie-сессией в API.

Основные разделы:

- **Dashboard** — сводная статистика активных и черновых записей
- **Courses / Consultations / Retreats / Yagyas** — CRUD с вложенным редактором полей на всех языках (uk / ru / en)
- **Site Pages** — структурные страницы сайта (home, about, contacts и др.)
- **Media** — загрузка файлов по файлу или по URL
- **Leads** — тriage завяок (new / contacted / closed) с заметками
- **Translations** — покрытие переводов по разделам + поиск/редакт. UI-строк

### Draft / Publish workflow

Каждая единица контента (Course, Consultation, Retreat, Yagya, SitePage) имеет флаги:

- `IsActive` — виден ли раздел на публичной витрине
- `IsDraft` — находится ли в состоянии черновика

Правила публикации:
- **Save as Draft** → `IsDraft = true`, `IsActive` не меняется
- **Publish** → `IsDraft = false`, `IsActive = true`
- Публичные контроллеры фильтруют: `.Where(x => x.IsActive && !x.IsDraft)`
- Раздел `/admin/preview/{section}/{slug}` позволяет просматривать черновик перед публикацией

## Мигрирование схемы

Миграции находятся в `Yoga.Api/Migrations/`. Применяются автоматически при старте через `Database.Migrate()`.

Цепочка миграций:
1. `InitialCreate`
2. `AddEventDates`
3. `RemoveLegacySeedsAndHardenBootstrap`
4. `AddMediaAndLeadTriage`
5. `AddDraftWorkflow`

Для добавления новой миграции:
```
dotnet ef migrations add <Имя> --project Yoga.Api --startup-project Yoga.Api
```

## Переменные окружения (ключевые)

| Переменная | Назначение |
|---|---|
| `ConnectionStrings__DefaultConnection` | PostgreSQL connection string |
| `Security__AllowedOrigins__0` | CORS origin для публичного фронтенда |
| `AdminPortal__JwtSecret` | JWT-секрет для admin сессий (мин. 32 символа) |
| `AdminPortal__EnableSeedAdminEndpoint` | `true` только при первом запуске для создания admin-аккаунта |
| `AdminCms__EnableSampleContentBootstrap` | `true` только для dev — создаёт тестовый контент |
| `Telegram__BotToken` / `Telegram__ChatId` | Оповещения о новых заявках |

