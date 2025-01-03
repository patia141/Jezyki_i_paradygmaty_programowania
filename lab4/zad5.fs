open System

let pustyStan = [" "; " "; " "; " "; " "; " "; " "; " "; " "]

let wyswietlPlansze (plansza: string list) =
    printfn "%s | %s | %s" (plansza.[0]) (plansza.[1]) (plansza.[2])
    printfn "---+---+---"
    printfn "%s | %s | %s" (plansza.[3]) (plansza.[4]) (plansza.[5])
    printfn "---+---+---"
    printfn "%s | %s | %s" (plansza.[6]) (plansza.[7]) (plansza.[8])

let sprawdzWygrana (plansza: string list) =
    let zwyciestwa = [
        [0; 1; 2]; [3; 4; 5]; [6; 7; 8]; // wiersze
        [0; 3; 6]; [1; 4; 7]; [2; 5; 8]; // kolumny
        [0; 4; 8]; [2; 4; 6]             // przekątne
    ]
    zwyciestwa
    |> List.tryFind (fun [a; b; c] -> plansza.[a] = plansza.[b] && plansza.[b] = plansza.[c] && plansza.[a] <> " ")
    |> Option.map (fun _ -> true) 
    |> Option.defaultValue false

let sprawdzRemis (plansza: string list) =
    not (List.contains " " plansza)

let wykonajRuchGracza (plansza: string list) =
    printfn "Podaj numer pola (1-9):"
    let wybor = Console.ReadLine()
    match Int32.TryParse(wybor) with
    | true, numer when numer >= 1 && numer <= 9 && plansza.[numer - 1] = " " ->
        let nowaPlansza = List.mapi (fun i x -> if i = numer - 1 then "X" else x) plansza
        Some(nowaPlansza)
    | _ ->
        printfn "Nieprawidłowy ruch. Spróbuj ponownie."
        None

let wykonajRuchKomputera (plansza: string list) =
    let pustePozycje = plansza |> List.mapi (fun i x -> if x = " " then Some(i) else None) |> List.choose id
    if pustePozycje.Length > 0 then
        let losowaPozycja = pustePozycje.[Random().Next(pustePozycje.Length)]
        let nowaPlansza = List.mapi (fun i x -> if i = losowaPozycja then "O" else x) plansza
        Some(nowaPlansza)
    else
        None

let rec gra (plansza: string list) (czyGracz: bool) =
    wyswietlPlansze plansza

    if sprawdzWygrana plansza then
        printfn "Wygrał %s!" (if czyGracz then "gracz" else "komputer")
    elif sprawdzRemis plansza then
        printfn "Remis!"
    else
        if czyGracz then
            match wykonajRuchGracza plansza with
            | Some(nowaPlansza) -> 
                if sprawdzWygrana nowaPlansza then
                    printfn "Wygrał gracz!"
                elif sprawdzRemis nowaPlansza then
                    printfn "Remis!"
                else
                    gra nowaPlansza false //zmieniam turę na komputer
            | None -> gra plansza czyGracz
        else
            printfn "Ruch komputera:"
            match wykonajRuchKomputera plansza with
            | Some(nowaPlansza) -> 
                if sprawdzWygrana nowaPlansza then
                    printfn "Wygrał komputer!"
                elif sprawdzRemis nowaPlansza then
                    printfn "Remis!"
                else
                    gra nowaPlansza true //zmieniam turę na gracza
            | None -> gra plansza czyGracz

//rozpoczęcie gry
gra pustyStan true