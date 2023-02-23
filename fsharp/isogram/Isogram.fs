module Isogram

let isIsogram (str: string) =
    let oneSpaceOrHyphen =
        System.Text.RegularExpressions.Regex.Replace(str.ToLower(), "[- ]", "")

    ((set oneSpaceOrHyphen).Count) = (oneSpaceOrHyphen.Length)

isIsogram "lumberjacks"
isIsogram "background"
isIsogram "downstream"
isIsogram "six-year-old"
isIsogram "isograms"
isIsogram "isograms"
isIsogram "Alphabet"
isIsogram "alphAbet"
