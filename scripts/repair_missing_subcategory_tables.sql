CREATE TABLE IF NOT EXISTS "RetreatSubcategories" (
    "Id" uuid NOT NULL,
    "RetreatId" uuid NOT NULL,
    "Slug" character varying(64) NOT NULL,
    "SortOrder" integer NOT NULL,
    "IsActive" boolean NOT NULL,
    CONSTRAINT "PK_RetreatSubcategories" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_RetreatSubcategories_Retreats_RetreatId"
        FOREIGN KEY ("RetreatId") REFERENCES "Retreats" ("Id") ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS "YagyaSubcategories" (
    "Id" uuid NOT NULL,
    "YagyaId" uuid NOT NULL,
    "Slug" character varying(64) NOT NULL,
    "SortOrder" integer NOT NULL,
    "IsActive" boolean NOT NULL,
    CONSTRAINT "PK_YagyaSubcategories" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_YagyaSubcategories_Yagyas_YagyaId"
        FOREIGN KEY ("YagyaId") REFERENCES "Yagyas" ("Id") ON DELETE CASCADE
);

CREATE INDEX IF NOT EXISTS "IX_RetreatSubcategories_RetreatId"
    ON "RetreatSubcategories" ("RetreatId");

CREATE INDEX IF NOT EXISTS "IX_YagyaSubcategories_YagyaId"
    ON "YagyaSubcategories" ("YagyaId");