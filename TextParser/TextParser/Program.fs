// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.


open System;
open Newtonsoft;
open System.Runtime.Serialization;
open Types
open ActualTestExamType



[<EntryPoint>]
let main argv = 
    printfn "%A" argv

    //let filePath = @"K:\Personal\TestText\C#Test.txt"
    
    //let filePath = @"K:\personal\testText\Essentials of Developing Windows Store Apps Using C#.txt";

    let filePath = @"C:\Projects\test pdfs\70-496.txt";
    //let filePath = @"C:\Projects\test pdfs\aws-associatev8.0.txt";

    //let filePath = argv.[0]

    let outputfile, contents = ActualTestExamType.ParseActualTest (filePath)

    //let outputfile, contents = ExamBibleParser.ParseTest filePath 



    System.IO.File.WriteAllText(outputfile, contents)



    0 // return an integer exit code
