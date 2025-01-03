open System

let iloscSlow (text: string) =
    text.Split([| ' '; '\t'; '\n' |], StringSplitOptions.RemoveEmptyEntries)
    |> Array.length

let iloscZnakow (text: string) =
    text.Replace(" ", "").Length

let najczestszeSlowo (text: string) =
    let slowa = 
        text.Split([| ' '; '\t'; '\n' |], StringSplitOptions.RemoveEmptyEntries)
    
    slowa 
    |> Seq.groupBy id
    |> Seq.map (fun (slowo, wystapienia) -> slowo, Seq.length wystapienia)
    |> Seq.maxBy snd


[<EntryPoint>]
let main argv =
    printfn "Podaj tekst:"
    let inputText = Console.ReadLine()

    if String.IsNullOrWhiteSpace(inputText) then
        printfn "Podano pusty tekst"
    else
        let ileSlow = iloscSlow inputText
        let ileZnakow = iloscZnakow inputText
        let najczSlowo, ileRazy = najczestszeSlowo inputText

        printfn "Liczba słów: %d" ileSlow
        printfn "Liczba znaków: %d" ileZnakow
        printfn "Najczęściej występujące słowo: \"%s\" (wystąpień: %d)" najczSlowo ileRazy

    0