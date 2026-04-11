$lines = Get-Content c:\home\dmitrij\yoga_platform01\Yoga.Api\Data\AppDbContext.cs
$idx = 0
for ($i=0; $i -lt $lines.Count; $i++) { if ($lines[$i] -match 'private static void SeedData') { $idx = $i; break } }
if ($idx -gt 0) {
    $lines = $lines[0..($idx-1)]
    $lines += '}'
}
$lines = $lines -replace '^\s*SeedData\(.*', ''
Set-Content c:\home\dmitrij\yoga_platform01\Yoga.Api\Data\AppDbContext.cs $lines
