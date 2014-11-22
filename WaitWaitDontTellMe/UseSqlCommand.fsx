open System
open System.Diagnostics

let proc= new System.Diagnostics.Process()

proc.StartInfo.FileName                 <- @"C:\Program Files\Microsoft SQL Server\110\Tools\Binn\SqlCmd.exe";
proc.StartInfo.RedirectStandardError    <- true;
proc.StartInfo.RedirectStandardOutput   <- true;
proc.StartInfo.UseShellExecute          <- false;
proc.StartInfo.Arguments                <- @"-S ""localhost\sqlexpress"" -E -Q ""PRINT 'HELLO WORLD' 
GO 
PRINT 'Hello again'"""

proc.Start();

proc.WaitForExit Int32.MaxValue 

let errorMessage = proc.StandardError.ReadToEnd();
proc.WaitForExit();

let outputMessage = proc.StandardOutput.ReadToEnd();
proc.WaitForExit();


printfn "%s" errorMessage
printfn "%s" outputMessage