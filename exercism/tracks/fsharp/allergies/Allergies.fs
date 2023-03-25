module Allergies

open System


type Allergen =
    | Eggs
    | Peanuts
    | Shellfish
    | Strawberries
    | Tomatoes
    | Chocolate
    | Pollen
    | Cats

// let i = match allergen with
//     | Eggs -> 1
//     | Peanuts -> 2
//     | Shellfish -> 4
//     | Strawberries -> 8
//     | Tomatoes -> 16
//     | Chocolate -> 32
//     | Pollen -> 64
//     | Cats -> 128


let list codedAllergies =
    let rec helper (codedAllergies: int) (allergens: Allergen list) : Allergen list option =
        match codedAllergies with
        | i when i >= 256 -> helper (i - 256) allergens
        | i when i >= 128 && i < 256 -> helper (codedAllergies - 128) (Cats :: allergens)
        | i when i >= 64 && i < 128 -> helper (codedAllergies - 64) (Pollen :: allergens)
        | i when i >= 32 && i < 64 -> helper (codedAllergies - 32) (Chocolate :: allergens)
        | i when i >= 16 && i < 32 -> helper (codedAllergies - 16) (Tomatoes :: allergens)
        | i when i >= 8 && i < 16 -> helper (codedAllergies - 8) (Strawberries :: allergens)
        | i when i >= 4 && i < 8 -> helper (codedAllergies - 4) (Shellfish :: allergens)
        | i when i >= 2 && i < 4 -> helper (codedAllergies - 2) (Peanuts :: allergens)
        | i when i >= 1 && i < 2 -> helper (codedAllergies - 1) (Eggs :: allergens)
        | i when i = 0 -> Some allergens
        | _ -> None


    match helper codedAllergies [] with
    | Some allergens -> allergens
    | None -> []

let allergicTo codedAllergies allergen =

    match list codedAllergies with
    | [] -> false
    | elems -> elems |> List.contains allergen
