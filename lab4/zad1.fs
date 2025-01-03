open System


type User = {
    Weight: float
    Height: float
}

let calculateBMI (user: User) =
    let HeigthMeters = user.Height / 100.0
    let bmi = user.Weight / (HeigthMeters ** 2)
    bmi

let getCategoryBMI bmi = 
    match bmi with
    | x when x < 18.5 -> "Niedowaga"
    | x when x >= 18.5 && x < 24.9 -> "Prawidłowa waga"
    | x when x >= 25.0 && x < 29.9 -> "Nadwaga"
    | _ -> "Błędne dane"

//main
[<EntryPoint>]
let main argv =
    printfn "Podaj wagę w kg "
    let weigthInput = Console.ReadLine()
    printfn "Podaj wzrost "
    let heigthInput = Console.ReadLine()

    //konwersja danych
    let weigth =
        match Double.TryParse(weigthInput) with
        | (true, value) -> value
        | _ -> 
            printfn "Niepoprawna waga"
            0.0

    let heigth =
        match Double.TryParse(heigthInput) with
        | (true, value) -> value
        | _ -> 
            printfn "Niepoprawny wzrost"
            0.0

    if weigth > 0.0 && heigth > 0.0 then
        let user = {Weight = weigth; Height = heigth}
        let BMI = calculateBMI user
        let category = getCategoryBMI BMI
        printfn "BMI wynosi: %.2f" BMI
        printfn "Kategoria BMI: %s" category
    else
        printfn "Podano nieprawidłowe dane"

    0 //koneic main, zwrócenie wartości 0, exit code

