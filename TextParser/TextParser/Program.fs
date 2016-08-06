// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.


open System;
open Newtonsoft;


type Distractor = {Text : string; Answer : bool; OriginalPosition:char}

type QuestionParts =
| Header of string
| Text of string
| Distractor of string 
| Answer of string


type Question = {Header:string; Question:string; Answer:char seq; Distractors:Distractor seq}

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
                let l, q = RetrieveQuestion t

                let distractors = 
                    h 
                    |> addSeperator "A." 
                    |> addSeperator "B." 
                    |> addSeperator "C." 
                    |> addSeperator "D." 
                    |> fun x-> x.Split([|seperator|], System.StringSplitOptions.RemoveEmptyEntries)
                    |> Seq.map(fun x->QuestionParts.Distractor x)
                    |> Seq.toList
                    |> List.append q

                
                (l, distractors)
          
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

let MakeDistractorEntry (answers: char seq)(data: string) = 
    let originalPosition = data.Trim() |> Seq.head
    let text = data |> Seq.skip(2) |> fun x-> String.Join("", x)
    let answer = Seq.contains originalPosition answers

    {Text = text; Answer = answer;  OriginalPosition = originalPosition}

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
            |> fun x-> x.Split([|' '|], System.StringSplitOptions.RemoveEmptyEntries)
            |> Seq.map (fun x-> x.[0])

    let distractors = 
            question 
            |> List.choose(fun x -> match x with QuestionParts.Distractor(i) -> Some(i) | _-> None) 
            |> List.map(MakeDistractorEntry answer)

    {Header = header; Question = questionText; Distractors = distractors; Answer = answer}

[<EntryPoint>]
let main argv = 
    printfn "%A" argv

    let filePath = @"K:\Personal\TestText\C#Test.txt"
    let parts = filePath.Split('\\') 
    let name = parts |> Seq.last
    let path = parts |> Seq.take(parts.Length - 1) |> (fun x->String.Join("\\", x))
    let outputName = name.Split('.') |> (fun x-> x.[0] + ".json")

    let fileContents = System.IO.File.ReadAllLines filePath; 

    let list = fileContents |> Array.toList

    let questions = ParseLine list [] |> Seq.map (Unpack)

    let contents = Json.JsonConvert.SerializeObject(questions)

    System.IO.File.WriteAllText(path + outputName, contents)




    0 // return an integer exit code
