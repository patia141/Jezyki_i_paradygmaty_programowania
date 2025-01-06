open System

let wordCount (text: string) =
    text.Split([|' '; '.'; ','; '\n'|], StringSplitOptions.RemoveEmptyEntries).Length
    
let charCount (text: string) =
    text |> Seq.filter (fun c -> not (Char.IsWhiteSpace(c))) |> Seq.length

[<EntryPoint>]
let main argv =
    printf "Podaj tekst: "
    let input = Console.ReadLine()
    let countWord = wordCount input
    let countChar = charCount input

    printfn "Liczba słów: %d" countWord
    printfn "Liczba znaków bez spacji: %d" countChar
    0 