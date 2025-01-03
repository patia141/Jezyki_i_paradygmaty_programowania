open System

let kursyWymiany = Map.ofList [
    ("PLN", 1.0)
    ("USD", 0.26)
    ("EUR", 0.22)
    ("GBP", 0.19)
]

let przeliczWalute kwota walutaPoczatkowa walutaDocelowa =
    let kwotaWPLN = kwota / kursyWymiany.[walutaPoczatkowa]
    kwotaWPLN * kursyWymiany.[walutaDocelowa]


[<EntryPoint>]
let main argv =
    printfn "Podaj kwotę do przeliczenia: "
    let kwotaStr = Console.ReadLine()
    printfn "Podaj walutę źródłową (np. PLN, USD, EUR, GBP): "
    let walutaPoczatkowa = Console.ReadLine().ToUpper()
    printfn "Podaj walutę docelową (np. PLN, USD, EUR, GBP): "
    let walutaDocelowa = Console.ReadLine().ToUpper()

    let kwota = float kwotaStr

    if kursyWymiany.ContainsKey(walutaPoczatkowa) && kursyWymiany.ContainsKey(walutaDocelowa) then
        let przeliczonaKwota = przeliczWalute kwota walutaPoczatkowa walutaDocelowa
        printfn "Przeliczona kwota: %f %s" przeliczonaKwota walutaDocelowa
    else
        printfn "Jedna z podanych walut nie jest obsługiwana."


    0