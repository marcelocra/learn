module ValentinesDay

// TODO: please define the 'Approval' discriminated union type
type Approval =
    | Yes
    | No
    | Maybe

// TODO: please define the 'Cuisine' discriminated union type
type Country =
    | Korean
    | Turkish

// TODO: please define the 'Genre' discriminated union type
type Genre =
    | Crime
    | Horror
    | Romance
    | Thriller

// TODO: please define the 'Activity' discriminated union type
type Activity =
    | BoardGame
    | Chill
    | Movie of Genre
    | Restaurant of Country
    | Walk of int

let rateActivity (activity: Activity) : Approval =
    match activity with
    | BoardGame -> No
    | Chill -> No
    | Movie genre ->
        match genre with
        | Crime -> No
        | Horror -> No
        | Romance -> Yes
        | Thriller -> No
    | Restaurant country ->
        match country with
        | Korean -> Yes
        | Turkish -> Maybe
    | Walk distance ->
        match distance with
        | 1
        | 2 -> Yes
        | 3
        | 4 -> Maybe
        | _ -> No
