[void][System.Reflection.Assembly]::LoadWithPartialName("System.Configuration")

if ([System.IntPtr]::Size -eq 4) { "32-bit" } else { "64-bit" }

$PSVersionTable

[System.Configuration.ConfigurationManager]::AppSettings.AllKeys | foreach {$_}

[System.Configuration.ConfigurationManager]::ConnectionStrings | foreach {$_}
