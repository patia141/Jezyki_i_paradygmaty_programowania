open System
open System.Collections.Generic

type Konto = {
    NumerKonta: string
    Saldo: float
}

let utworzKonto nrKonta saldoPoczatkowe = {
    NumerKonta = nrKonta
    Saldo = saldoPoczatkowe
}

let zdeponuj konto kwota = 
    { konto with Saldo = konto.Saldo + kwota }

let wyplacSrodki konto kwota = 
    if konto.Saldo >= kwota then
        { konto with Saldo = konto.Saldo - kwota }
    else
        printfn "Brak środków na koncie"
        konto

let wyswietlSaldo konto =
    printfn "Saldo konto o nr %s wynosi: %f" konto.NumerKonta konto.Saldo

//do menu
let menuUtworzKonto (konta: Dictionary<string, Konto>) =
    printfn "Podaj numer konta:"
    let nrKonta = Console.ReadLine()
    if konta.ContainsKey(nrKonta) then
        printfn "Konto z tym numerem już istnieje"
    else
        printfn "Podaj saldo początkowe:"
        match Double.TryParse(Console.ReadLine()) with
        | true, saldoPocz -> 
            let konto = utworzKonto nrKonta saldoPocz
            konta.[nrKonta] <- konto
            printfn "Konto zostało utworzone."
        | _ -> printfn "Nieprawidłowa kwota."

let menuDepozyt (konta: Dictionary<string, Konto>) =
    printfn "Podaj numer konta:"
    let nrKonta = Console.ReadLine()
    match konta.TryGetValue(nrKonta) with
    | true, konto ->
        printfn "Podaj kwotę do zdeponowania:"
        match Double.TryParse(Console.ReadLine()) with
        | true, kwota ->
            konta.[nrKonta] <- zdeponuj konto kwota
            printfn "Depozyt zakończony"
        | _ -> printfn "Nieprawidłowa kwota"
    | _ -> printfn "Konto nie istnieje"

let menuWyplata (konta: Dictionary<string, Konto>) =
    printfn "Podaj numer konta:"
    let nrKonta = Console.ReadLine()
    match konta.TryGetValue(nrKonta) with
    | true, konto ->
        printfn "Podaj kwotę do wypłaty:"
        match Double.TryParse(Console.ReadLine()) with
        | true, kwota ->
            if kwota <= konto.Saldo then
                konta.[nrKonta] <- wyplacSrodki konto kwota
            else
                printfn "Nie ma wystarczających środków na koncie"
        | _ -> printfn "Nieprawidłowa kwota"
    | _ -> printfn "Konto nie istnieje"

let menuSaldo (konta: Dictionary<string, Konto>) =
    printfn "Podaj numer konta:"
    let nrKonta = Console.ReadLine()
    match konta.TryGetValue(nrKonta) with
    | true, konto -> wyswietlSaldo konto
    | _ -> printfn "Konto nie istnieje"


[<EntryPoint>]
let main argv =
    let konta = Dictionary<string, Konto>()

    let rec menu () =
        printfn "\nMenu"
        printfn "1. Utwórz konto"
        printfn "2. Depotyzuj środki na konto"
        printfn "3. Wypłać środki"
        printfn "4. Wyświetl saldo"
        printfn "5. Wyjście"

        match Console.ReadLine() with
        | "1" -> menuUtworzKonto konta; menu()
        | "2" -> menuDepozyt konta; menu()
        | "3" -> menuWyplata konta; menu()
        | "4" -> menuSaldo konta; menu()
        | "5" -> printfn "Wyjście"
        | _ ->
            printfn "Nieprawidłowa opcja"
            menu()

    menu()
    0