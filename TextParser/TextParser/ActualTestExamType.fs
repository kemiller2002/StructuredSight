module ActualTestExamType


open System;
open Newtonsoft;
open System.Runtime.Serialization;
open Types

let FindQuestion = new System.Text.RegularExpressions.Regex("^[A-Z]\.")
 
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
            
            | h when h.Contains("Answer:") -> 
                (t, [QuestionParts.Answer h])      
                
            | h when h.Contains("Explanation:") -> 
                (t, [QuestionParts.Explanation h])

            | h when FindQuestion.IsMatch(h) -> 
                let l, q = RetrieveQuestion t

                let distractors = 
                    h 
                    |> addSeperator "A." 
                    |> addSeperator "B." 
                    |> addSeperator "C." 
                    |> addSeperator "D." 
                    |> addSeperator "E."
                    |> fun x-> x.Split([|seperator|], System.StringSplitOptions.RemoveEmptyEntries)
                    |> Seq.map(fun x->QuestionParts.Distractor x)
                    |> Seq.toList
                    |> List.append q

                
                (l, distractors)
          


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


let ParseAnswer (answer:string) = answer.Replace("Explanation", "").Trim().Split(',')

let MakeDistractorEntry (answers: char seq)(data: string) = 
    let originalPosition = data.Trim() |> Seq.head
    let text = data |> Seq.skip(2) |> fun x-> String.Join("", x)
    let answer = Seq.contains originalPosition answers

    {Text = text; Answer = answer;  OriginalPosition = originalPosition; FullText = text}

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




type SectionDesignation = Header | Questions



let rec GetSubSectionContents (lines:string list)(comparer:string -> bool) = 

        if Seq.isEmpty lines then 
            ([],[])
        else 
            match lines.Head.Trim() with 
            | h when comparer h -> ([], lines)
            | h -> let d, c = GetSubSectionContents (lines.Tail) (comparer)
                   (h :: d, c)



let rec CreateSections (lines:string list) =

    let lookQuestion = LookFor "question"
    let lookTopic = LookFor "topic"


    let lookType = 
        match lines.Head.Trim() with 
        | h when lookTopic h -> (SectionDesignation.Header, lookQuestion)
        | h when lookQuestion h -> (SectionDesignation.Questions, lookTopic)

    let section, predicate = lookType
    let sectionPart, remainingLines = GetSubSectionContents(lines) predicate

    let sectionPartWithDesignation = 
        if section = SectionDesignation.Header then SectionBreakdown.Header sectionPart 
        else SectionBreakdown.Questions sectionPart    

    if(Seq.isEmpty remainingLines) then 
        [sectionPartWithDesignation]
    else
        sectionPartWithDesignation :: CreateSections(remainingLines)

let ParseQuestion (list : string list) = 
    ParseLine list [] |> Seq.map (Unpack) |> Seq.where(fun q -> not <| Seq.isEmpty q.Distractors)

let MapParts(section: SectionBreakdown) = 
    match section with 
    | SectionBreakdown.Header(h) -> SectionBreakdownParsed.Header <| String.Join(System.Environment.NewLine, h)
    | SectionBreakdown.Questions(q) -> q |> Seq.toList |> ParseQuestion |> SectionBreakdownParsed.Question


let ConvertSectionPartToArray (sections: SectionBreakdownParsed list) = 
    if List.isEmpty sections then (Seq.empty<Question>, List.empty<SectionBreakdownParsed>)
    else 
        match sections.Head with 
        | SectionBreakdownParsed.Question(q) -> (q, sections.Tail)
        | SectionBreakdownParsed.Header(h) -> (Seq.empty<Question>, sections.Tail) 

let rec MakeSectionBreakdown(sections: SectionBreakdownParsed list) = 
    if List.isEmpty sections then []
    else 
        let section, remainingSections = 
            match sections.Head with 
            | SectionBreakdownParsed.Header(h) -> 
                        let questions, remainingSections = ConvertSectionPartToArray sections.Tail
                        ({Header = h; Questions = questions }, remainingSections)
            | SectionBreakdownParsed.Question(q) -> 
                        ({Header = ""; Questions = q}, sections.Tail)

        section :: MakeSectionBreakdown remainingSections



let ParseActualTest (filePath:string) = 

    let parts = filePath.Split('\\') 
    let name = parts |> Seq.last
    let path = parts |> Seq.take(parts.Length - 1) |> (fun x->String.Join("\\", x))
    let outputName = name.Split('.') |> (fun x-> x.[0] + ".json")

    let fileContents = System.IO.File.ReadAllLines filePath; 

    let list = fileContents |> Array.toList

    let sections = CreateSections list |> Seq.map MapParts |> Seq.toList;

    let sectionsWithQuestions = MakeSectionBreakdown sections

    let contents = Json.JsonConvert.SerializeObject(sectionsWithQuestions, Json.Formatting.Indented)
    let outputfile = sprintf "%s\%s"path outputName

    (outputfile,contents)