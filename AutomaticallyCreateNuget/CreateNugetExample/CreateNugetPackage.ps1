Param(
    [string] $projectPath,
    [string] $projectFileExt,
    [string] $targetPath,
    [string] $targetName,
    [string] $configurationName

)

$nuspecFilePath = "$projectPath.nuspec"

$nuget = "C:\Utilities\Nuget\NuGet.exe"

[xml]$nuspecContent = switch ([System.IO.File]::Exists($nuspecFilePath)) 
{
  $false { 
           Write-Host "nuspec file not found at: $projectPath. Creating"
           & $nuget spec $projectPath | Write-Host 
           [xml]$file = Get-Content $nuspecFilePath

           $metaData = $file.package.metadata 
           $metaData.id = $targetName
              
           $metaData.RemoveChild($metaData.SelectSingleNode("licenseUrl")) | Out-Null
           $metaData.RemoveChild($metaData.SelectSingleNode("projectUrl")) | Out-Null 
           $metaData.RemoveChild($metaData.SelectSingleNode("iconUrl")) | Out-Null 

           $file
          }
    $true   {Get-Content $nuspecFilePath}
    
}

$assembly = [System.Reflection.Assembly]::LoadFile($targetPath)

$assemblyVersion = $assembly.GetName().Version.ToString()

Write-Host "Setting assembly version to: $assemblyVersion"

$nuspecContent.package.metadata.version = $assemblyVersion

$nuspecContent.Save($nuspecFilePath)

& $nuget pack $projectPath -IncludeReferencedProjects -Properties Configuration=$configurationName
