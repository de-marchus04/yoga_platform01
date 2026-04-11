import re

with open('c:/home/dmitrij/yoga_platform01/Yoga.Api/Data/AppDbContext.cs', 'r', encoding='utf-8') as f:
    text = f.read()

# Remove specific HasData calls for entities we don't want seeded
pattern = r"modelBuilder\.Entity<(?P<entity>Course|CourseModule|CourseLesson|Consultation|Retreat|RetreatSubcategory|Yagya|YagyaSubcategory)>\(\)\.HasData\([^)]+\);"
text = re.sub(pattern, "// Seed removed for \g<entity>", text)

with open('c:/home/dmitrij/yoga_platform01/Yoga.Api/Data/AppDbContext.cs', 'w', encoding='utf-8') as f:
    f.write(text)
