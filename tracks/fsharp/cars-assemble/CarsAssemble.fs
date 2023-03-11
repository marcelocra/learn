module CarsAssemble

let successRate (speed: int): float =
    match speed with
        | 0 -> 0
        | t when t <= 4 -> 1
        | t when t <= 8 -> 0.9
        | 9 -> 0.8
        | 10 -> 0.77
        | _ -> failwith "Speed not allowed"

let productionRatePerHour (speed: int): float =
    (float speed) * successRate(speed) * 221.0

let workingItemsPerMinute (speed: int): int =
    int (productionRatePerHour(speed) / 60.0)
