$path = "D:\dev\EntityFramework"

function IsIncluded($name)
{
  $exclude = "*\obj\Debug*", "*\bin\Debug*", "*\Properties"
  $mathes = $exclude | Where-Object {$name -like $_}
  $mathes.Count -eq 0
}

Get-ChildItem $path -Directory -Recurse `
 | Where-Object {$_.GetDirectories().Count -eq 0} `
 | Where-Object {$_.GetFiles().Count -eq 0} `
 | Where-Object {IsIncluded $_.FullName} `
 | Format-Wide -Property FullName -Column 1