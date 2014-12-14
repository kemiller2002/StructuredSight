Param(
    [string] $projectPath,
    [string] $projectFileExt,
    [string] $targetPath,
    [string] $targetName,
    [switch] $suppressExitCode 
)

$nuspecFilePath = "$projectPath.nuspec"

$nuget = "C:\Utilities\Nuget\NuGet.exe"

[xml]$nuspecContent = switch ([System.IO.File]::Exists($nuspecFilePath)) 
{
    $false  {  Write-Host "nuspec file not found at: $projectPath. Creating"
               & $nuget spec $projectPath | Write-Host 
               [xml]$file = Get-Content $nuspecFilePath
               $file.package.metadata.id = $targetName
               $file.Save($nuspecFilePath)

               $file
            }
    $true   {[xml]$file = Get-Content $nuspecFilePath}
    
}


$assemblyVersion = [System.Reflection.Assembly]::LoadFile($targetPath).GetName().Version

$nuspecContent.package.metadata.version = $assemblyVersion.ToString()

$nuspecContent.Save($nuspecFilePath)

#& $nuget pack $nuspecFilePath

if( ($Error.Count > 0) -and !$suppressExitCode){
        Write-Host "Errors found"
        [System.Environment]::Exit(1)
}
