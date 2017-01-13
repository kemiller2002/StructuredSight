module Types

open System;
open Newtonsoft;
open System.Runtime.Serialization;

let Join (seperator:string) (items : string seq) = System.String.Join(seperator, items)
let JoinNewLine (items) = Join System.Environment.NewLine items

[<DataContract>]
type Distractor = 
    {
        [<field: DataMember(Name="text")>]Text : string; 
        [<field: DataMember(Name="answer")>]Answer : bool; 
        [<field: DataMember(Name="originalPosition")>]OriginalPosition:char;
        FullText : string
    }

type QuestionParts =
| Header of string
| Text of string
| Distractor of string 
| Answer of string
| Explanation of string


[<DataContract>] 
type Question = 
    {
        [<field: DataMember(Name="header")>]Header:string; 
        [<field: DataMember(Name="question")>]Question:string; 
        [<field: DataMember(Name="answer")>]Answer:char seq; 
        [<field: DataMember(Name="distractors")>]Distractors:Distractor seq
    }

[<DataContract>]
type Section = 
    { 
        [<field: DataMember(Name="header")>]Header : string;  
        [<field: DataMember(Name="questions")>]Questions : Question seq
    }


let AddCustomSeperator(seperator:char)(findInString:string)(searchString:string) = 
    searchString.Replace(findInString, seperator.ToString() + findInString);

type SectionRawData = {Header: string seq; question : string seq}


type RawDataType = 
    | Header of string seq
    | Questions of string seq


let LookFor (word:string)(search:string) = 
    search.StartsWith(word,  System.StringComparison.OrdinalIgnoreCase)

type SectionBreakdown =
| Header of string seq
| Questions of string seq

type SectionBreakdownParsed = 
| Header of string
| Question of Question seq
