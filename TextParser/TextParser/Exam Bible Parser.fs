module ExamBibleParser

open System
open Types
open System.Text
open System.Text.RegularExpressions
open Newtonsoft


let FindQuestion = new System.Text.RegularExpressions.Regex("^[A-Z]\.")


let rec ParseQuestion (text:string seq) = 
        if Seq.isEmpty text then 
            Seq.empty
        else 

            let head = (Seq.head text).Trim()
            let tail = Seq.tail text

            let entry = 
                match head with 
                | t when FindQuestion.IsMatch(t) ->
                    [|QuestionParts.Distractor(t)|]
                | t when t.StartsWith("Answer") -> 
                    let answers = head.Split(':').[1].Trim() //Answer: ACD
                    
                    answers.ToCharArray() |> 
                    Seq.map(fun x->QuestionParts.Answer(x.ToString())) |> 
                    Seq.toArray
                | t when t.Contains("Your Partner of IT Exam visit - http://www.exambible.com") -> Array.empty
                | t -> [|QuestionParts.Text (t)|]
                

            seq {
                yield! entry
                
                yield! ParseQuestion tail
            }


let MakeDistractor (answers:char seq)(text:string) = 

    let originalPosition = (text.Trim().[0])
    
    let isAnswer = Seq.exists (fun x-> x = originalPosition) answers 

    {
        Distractor.Answer = isAnswer; 
        Distractor.OriginalPosition = originalPosition;
        Distractor.Text = text.Substring(2).Trim();
        Distractor.FullText = text
    }
        

let ConvertToQuestion (parts:QuestionParts seq) = 
    let question = 
        parts |> 
        Seq.choose(fun x-> match x with | QuestionParts.Text(t) -> Some(t) | _ -> None) |>
        (fun x->String.Join(System.Environment.NewLine, x))

    let answers = 
        parts |> 
        Seq.choose(fun x-> match x with | QuestionParts.Answer(t) -> Some(t) | _ -> None) |>
        Seq.map(fun x->x.[0])

    let distractors = 
        parts |> 
        Seq.choose(fun x-> match x with | QuestionParts.Distractor(t) -> Some(t) | _ -> None) |>
        Seq.map (fun x-> MakeDistractor answers x) |>
        Seq.toArray

    {
        Question.Header = "";
        Question.Question = question;
        Question.Distractors = distractors;
        Question.Answer = answers
    }


let SplitOnCarriageReturn (text:string) = 
    let splitEntries = [|"\n"; "\r\n"|]

    text.Split(splitEntries, StringSplitOptions.RemoveEmptyEntries)

    
let ParseTest (filePath:string) = 
    
      let fileContents = System.IO.File.ReadAllText (filePath)

      //at this moment, the tests do not have this as a seperator, this will need to be added at 
      //the beginning of each question (done through regex replace.
      //this should be added, but don't have time right now. 
      let questionArray = 
        fileContents.Split('~') |> 
        Seq.map(SplitOnCarriageReturn) |> 
        Seq.map ParseQuestion  |> 
        Seq.map ConvertToQuestion |>
        Seq.toArray


      let sections = [|{Section.Header = ""; Questions = questionArray}|]
      let contents = Json.JsonConvert.SerializeObject(sections, Json.Formatting.Indented)

      (filePath + ".json",contents)