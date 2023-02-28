module Anagram

let findAnagrams (sources: string list) (target: string) =
    let lower = target.ToLower()

    let sameLength =
        sources
        |> List.filter (fun x -> x.Length = lower.Length && x.ToLower() <> target.ToLower())

    if sameLength.Length = 0 then
        []
    else
        let count str =
            str
            |> Seq.filter (fun x -> x.ToString().Trim() <> "")
            |> Seq.countBy (fun x -> System.Char.ToLower(x))
            |> Seq.sort

        let targetCount = Map(count target)

        let isAnagram (toCheck: string) = Map(count toCheck) = targetCount

        sameLength |> List.filter isAnagram


(*

    let candidates = [ "hello"; "world"; "zombies"; "pants" ]
    findAnagrams candidates "diaper"


*)
