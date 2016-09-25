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
type Section = { Header : string;  Questions : Question seq}

let AddCustomSeperator(seperator:char)(findInString:string)(searchString:string) = 
    searchString.Replace(findInString, seperator.ToString() + findInString);
 
let rec RetrieveQuestion(lines : string list) = 
    let seperator = '~'
    let addSeperator = AddCustomSeperator seperator
    match lines with 
    | [] -> ([], [])
    | h::t -> 
            let hTrimmed = h.Trim().Replace("\"Pass Any Exam. Any Time.\"","").Replace("- www.actualtests.com", "")


            match hTrimmed with 
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


type SectionRawData = {Header: string seq; question : string seq}
type RawDataType = 
    | Header of string seq
    | Questions of string seq


let rec GetSubSectionContents (lines:string list)(comparer:string -> bool) = 
         let data,contents  = 
            match lines.Head with 
            | h when comparer h -> ([""], lines.Tail)
            | _ -> GetSubSectionContents (lines.Tail) (comparer)

         (lines.Head :: data, contents)

let rec CreateSections (lines:string list) =
    match lines.Head with 
    | h when h.StartsWith("topic",System.StringComparison.OrdinalIgnoreCase) -> 
        let head = 

    | h when h.StartsWith("question", System.StringComparison.OrdinalIgnoreCase) -> ""
    | _ -> "" 


[<EntryPoint>]
let main argv = 
    printfn "%A" argv

    //let filePath = @"K:\Personal\TestText\C#Test.txt"
    
    let filePath = "@K:\personal\testText\Essentials of Developing Windows Store Apps Using C#.txt";

    let parts = filePath.Split('\\') 
    let name = parts |> Seq.last
    let path = parts |> Seq.take(parts.Length - 1) |> (fun x->String.Join("\\", x))
    let outputName = name.Split('.') |> (fun x-> x.[0] + ".json")

    let fileContents = System.IO.File.ReadAllLines filePath; 

    let list = fileContents |> Array.toList

    let sections = CreateSections list;

    let questions = ParseLine list [] |> Seq.map (Unpack) |> Seq.where(fun q -> not <| Seq.isEmpty q.Distractors)

    let contents = Json.JsonConvert.SerializeObject(questions, Json.Formatting.Indented)

    System.IO.File.WriteAllText(path + outputName, contents)




    0 // return an integer exit code
