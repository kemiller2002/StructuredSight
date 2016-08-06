// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.


open System;


type Distractor = {Text : string; Answer : bool}

type QuestionParts =
| Header of string
| Text of string
| Distractor of string 
| Answer of string


type Question = {Header:string; Question:string; Answer:string; Distractors:string seq}

let AddCustomSeperator(seperator:char)(findInString:string)(searchString:string) = 
    searchString.Replace(findInString, seperator.ToString() + findInString);
 
let rec RetrieveQuestion(lines : string list) = 
    let seperator = '~'
    let addSeperator = AddCustomSeperator seperator
    match lines with 
    | [] -> ([], [])
    | h::t -> 
            match h.Trim() with 
            | h when h.Contains("QUESTION NO") -> 
                let l, q = RetrieveQuestion t
                (l, QuestionParts.Header(h) :: q)            
                
            | h when h.StartsWith("A.") || h.StartsWith("B.") || h.StartsWith("C.") || h.StartsWith("D.") -> 
                let sH = 
                    h 
                    |> addSeperator "A." 
                    |> addSeperator "B." 
                    |> addSeperator "C." 
                    |> addSeperator "D." 
                    |> fun x-> x.Split(seperator)

                let l, q = RetrieveQuestion t
                (l, QuestionParts.Distractor(h) :: q)
          
            | h when h.Contains("Answer") -> 
                (t, [QuestionParts.Answer h])

            | h -> 
                let l, q = RetrieveQuestion t
                (l, QuestionParts.Text(h) :: q)


let rec ParseLine (lines:string list) (questions: QuestionParts list list) = 
    let l, q = RetrieveQuestion lines

    let newQuestionSequence = q :: questions 

    match l with 
    | [] -> newQuestionSequence
    | l -> ParseLine l newQuestionSequence

 
type SearchType = Header | Text | Answer | Distractor

(*
let rec GetValue (question:QuestionParts) (part:SearchType) (foundItems:QuestionParts list) =   
    let newList = match question with 
        | QuestionParts.Answer(a) -> 
        
            if SearchType.Header = part then
                a :: foundItems
            else foundItems 
        
               
*)

let Join (seperator:string) (items : string seq) = System.String.Join(seperator, items)
let JoinNewLine (items) = Join System.Environment.NewLine items

let ParseAnswer (answer:string) = answer.Replace("Explanation", "").Trim().Split(',')

let Unpack (question:QuestionParts list) = 
    let header = 
        question 
            |> List.choose(fun x -> match x with QuestionParts.Header(i) -> Some(i) | _-> None) 
            |> JoinNewLine
    let questionText = 
        question 
            |> List.choose(fun x -> match x with QuestionParts.Text(i) -> Some(i) | _-> None) 
            |> JoinNewLine 
    let answer = 
            question 
            |> List.choose(fun x -> match x with QuestionParts.Answer(i) -> Some(i) | _-> None)
            |> List.map ParseAnswer
            |> List.toArray
            |> Array.collect(fun x->x)
            |> Join " "
            |> fun x-> x.Replace("Answer:", "").Replace(":", "").Trim()

    let distractors = 
            question 
            |> List.choose(fun x -> match x with QuestionParts.Distractor(i) -> Some(i) | _-> None) 


    {Header = header; Question = questionText; Distractors = distractors; Answer = answer}

[<EntryPoint>]
let main argv = 
    printfn "%A" argv

    let filePath = @"K:\Personal\TestText\C#Test.txt"

    let fileContents = System.IO.File.ReadAllLines filePath; 

    let list = fileContents |> Array.toList

    let questions = ParseLine list [] |> Seq.map (Unpack)






    0 // return an integer exit code
