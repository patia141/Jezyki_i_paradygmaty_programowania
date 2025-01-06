//nalezy wprowadzac "imię; nazwisko; wiek" ENTER "imię; nazwisko; wiek" ENTER ...
open System.Globalization

let capitalize (text: string) =
    CultureInfo.InvariantCulture.TextInfo.ToTitleCase(text.ToLower())


let przeksztalcTekst (text: string) =
    match text.Split(';') |> Array.map (fun x -> x.Trim()) with
    | [| imie; nazwisko; wiek |] ->
        let imieFormatted = capitalize imie
        let nazwiskoFormatted = capitalize nazwisko
        sprintf "%s, %s (%s lat)" nazwiskoFormatted imieFormatted wiek
    | _ -> "Niepoprawny format danych"


let main () =
    printfn "Wprowadź dane w formacie 'imię; nazwisko; wiek'. Wpisz pustą linię, aby zakończyć"
    
    let rec odczytajTekst acc =
        printf "Wpisz: "
        let input = System.Console.ReadLine()
        if input = "" then acc
        else odczytajTekst (input :: acc)
    
    let tekst = odczytajTekst [] 
    let przeksztalconyTekst = tekst |> List.map przeksztalcTekst
    printfn "\nPrzetworzone dane:"
    przeksztalconyTekst |> List.iter (printfn "%s")

main ()