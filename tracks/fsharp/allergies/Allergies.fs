module Allergies

open System


// TODO: define the Allergen type
type Allergen =
    | Eggs
    | Peanuts
    | Shellfish
    | Strawberries
    | Tomatoes
    | Chocolate
    | Pollen
    | Cats


let rec allergicTo codedAllergies allergen =
    // match codedAllergies with
    // | i when i < 0 -> false
    // | 0 -> true
    let i = match allergen with
        | Eggs -> 1
        | Peanuts -> 2
        | Shellfish -> 4
        | Strawberries -> 8
        | Tomatoes -> 16
        | Chocolate -> 32
        | Pollen -> 64
        | Cats -> 128

    | i when i >= 256 -> allergicTo (i - 256) allergen
    | i when i >= 128 && i < 256 -> allergicTo (codedAllergies - 128) allergen
    | i when i >= 64 && i < 128 -> allergicTo (codedAllergies - 64) allergen
    | i when i >= 32 && i < 64 -> allergicTo (codedAllergies - 32) allergen
    | i when i >= 16 && i < 32 -> allergicTo (codedAllergies - 16) allergen
    | i when i >= 8 && i < 16 -> allergicTo (codedAllergies - 8) allergen
    | i when i >= 4 && i < 8 -> allergicTo (codedAllergies - 4) allergen
    | i when i >= 2 && i < 4 -> allergicTo (codedAllergies - 2) allergen
    | i when i >= 1 && i < 2 -> allergicTo (codedAllergies - 1) allergen

let list codedAllergies =
    failwith "You need to implement this function."




allergicTo 1 Allergen.Eggs = true
