Param(
    [string] $projectPath,
    [string] $projectFileExt,
    [string] $targetPath,
    [string] $targetName
)

$nuspecFilePath = "$projectPath.nuspec"

$nuget = "C:\Utilities\Nuget\NuGet.exe"

[xml]$nuspecContent = switch ([System.IO.File]::Exists($nuspecFilePath)) 
{
    $false  {  Write-Host "nuspec file not found at: $projectPath. Creating"
               & $nuget spec $projectPath | Write-Host 
               [xml]$file = Get-Content $nuspecFilePath

               $file.package.metadata.id = $targetName
               
               $file.package.metadata.RemoveChild($file.package.metadata.SelectSingleNode("licenseUrl")) | Out-Null
               $file.package.metadata.RemoveChild($file.package.metadata.SelectSingleNode("projectUrl")) | Out-Null 
               $file.package.metadata.RemoveChild($file.package.metadata.SelectSingleNode("iconUrl")) | Out-Null 

               $file
            }
    $true   {Get-Content $nuspecFilePath}
    
}

$assemblyVersion = [System.Reflection.Assembly]::LoadFile($targetPath).GetName().Version.ToString()

Write-Host "Setting assembly version to: $assemblyVersion"

$nuspecContent.package.metadata.version = $assemblyVersion

$nuspecContent.Save($nuspecFilePath)

& $nuget pack $projectPath -IncludeReferencedProjects
