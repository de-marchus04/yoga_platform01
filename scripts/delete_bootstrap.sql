DELETE FROM "Translations" WHERE "EntityType" = 'CourseLesson' AND "EntityId" IN (
  SELECT cl."Id" FROM "CourseLessons" cl
  JOIN "CourseModules" cm ON cl."CourseModuleId" = cm."Id"
  JOIN "Courses" c ON cm."CourseId" = c."Id" WHERE c."Slug" = 'sacred-breath'
);
DELETE FROM "Translations" WHERE "EntityType" = 'CourseModule' AND "EntityId" IN (
  SELECT cm."Id" FROM "CourseModules" cm
  JOIN "Courses" c ON cm."CourseId" = c."Id" WHERE c."Slug" = 'sacred-breath'
);
DELETE FROM "Translations" WHERE "EntityType" = 'Course' AND "EntityId" IN (
  SELECT "Id" FROM "Courses" WHERE "Slug" = 'sacred-breath'
);
DELETE FROM "CourseLessons" WHERE "CourseModuleId" IN (
  SELECT cm."Id" FROM "CourseModules" cm
  JOIN "Courses" c ON cm."CourseId" = c."Id" WHERE c."Slug" = 'sacred-breath'
);
DELETE FROM "CourseModules" WHERE "CourseId" IN (SELECT "Id" FROM "Courses" WHERE "Slug" = 'sacred-breath');
DELETE FROM "Courses" WHERE "Slug" = 'sacred-breath';

DELETE FROM "Translations" WHERE "EntityType" = 'Consultation' AND "EntityId" IN (
  SELECT "Id" FROM "Consultations" WHERE "Slug" = 'clarity-session'
);
DELETE FROM "Consultations" WHERE "Slug" = 'clarity-session';

DELETE FROM "Translations" WHERE "EntityType" = 'RetreatSubcategory' AND "EntityId" IN (
  SELECT s."Id" FROM "RetreatSubcategories" s
  JOIN "Retreats" r ON s."RetreatId" = r."Id" WHERE r."Slug" = 'mountain-reset'
);
DELETE FROM "Translations" WHERE "EntityType" = 'Retreat' AND "EntityId" IN (
  SELECT "Id" FROM "Retreats" WHERE "Slug" = 'mountain-reset'
);
DELETE FROM "RetreatSubcategories" WHERE "RetreatId" IN (SELECT "Id" FROM "Retreats" WHERE "Slug" = 'mountain-reset');
DELETE FROM "Retreats" WHERE "Slug" = 'mountain-reset';

DELETE FROM "Translations" WHERE "EntityType" = 'YagyaSubcategory' AND "EntityId" IN (
  SELECT s."Id" FROM "YagyaSubcategories" s
  JOIN "Yagyas" y ON s."YagyaId" = y."Id" WHERE y."Slug" = 'new-moon-fire'
);
DELETE FROM "Translations" WHERE "EntityType" = 'Yagya' AND "EntityId" IN (
  SELECT "Id" FROM "Yagyas" WHERE "Slug" = 'new-moon-fire'
);
DELETE FROM "YagyaSubcategories" WHERE "YagyaId" IN (SELECT "Id" FROM "Yagyas" WHERE "Slug" = 'new-moon-fire');
DELETE FROM "Yagyas" WHERE "Slug" = 'new-moon-fire';

SELECT 'Courses' AS tbl, COUNT(*) FROM "Courses"
UNION ALL SELECT 'Consultations', COUNT(*) FROM "Consultations"
UNION ALL SELECT 'Retreats', COUNT(*) FROM "Retreats"
UNION ALL SELECT 'Yagyas', COUNT(*) FROM "Yagyas";
