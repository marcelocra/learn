module Anagram

let findAnagrams (sources: string list) (target: string) =
    let lower = target.ToLower()

    let sameLengthAsLowercase =
        sources
        |> List.filter (fun x -> x.Length = lower.Length && x.ToLower() <> target.ToLower())

    if sameLengthAsLowercase.Length = 0 then
        []
    else
        let count str =
            str
            |> Seq.filter (fun x -> x.ToString().Trim() <> "")
            |> Seq.countBy (fun x -> System.Char.ToLower(x))
            |> Seq.sort

        let targetCount = count target

        let isAnagram (toCheck: string) =
            (Seq.compareWith Operators.compare (count toCheck) targetCount) = 0

        sameLengthAsLowercase |> List.filter isAnagram

(*
    Testing grounds!

    // Testing the count function.
    let count str =
        str
        |> Seq.filter (fun x -> x.ToString().Trim() <> "")
        |> Seq.countBy (fun x -> System.Char.ToLower(x))
        |> Seq.sort

    Seq.compareWith Operators.compare (count "hey") (count "eyh")

    // No anagrams.
    let candidates = [ "hello"; "world"; "zombies"; "pants" ]
    findAnagrams candidates "diaper"

    // Anagrams.
    let candidates = [ "hey"; "eyh"; "hahaha" ]
    findAnagrams candidates "ehy"

*)
