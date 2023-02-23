module Isogram

open System

let isIsogram (str: string) =
    let oneSpaceOrHyphen =
        System.Text.RegularExpressions.Regex.Replace(str.ToLower(), "[- ]", "")

    ((set oneSpaceOrHyphen).Count) = (oneSpaceOrHyphen.Length)

isIsogram "lumberjacks"
isIsogram "background"
isIsogram "downstream"
isIsogram "six-year-old"
isIsogram "isograms"
isIsogram "Alphabet"
isIsogram "alphAbet"

let isIsogram2 (str: string) =
    str
    |> Seq.filter Char.IsLetter
    |> Seq.countBy Char.ToLower
    |> Seq.forall (fun count -> snd count = 1)

let str1 = "downstreamO"
let str2 = "six-year-old"
let str3 = "isograms"
let str4 = "Alphabet"

isIsogram2 str1
isIsogram2 str2
isIsogram2 str3
isIsogram2 str4
