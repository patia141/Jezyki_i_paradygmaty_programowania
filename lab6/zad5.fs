let findLongestWord (text: string) =
    let words = text.Split([|' '; '\t'; '\n'|], System.StringSplitOptions.RemoveEmptyEntries)
    if words.Length = 0 then
        None
    else
        words
        |> Array.maxBy (fun word -> word.Length)
        |> fun longestWord -> Some(longestWord, longestWord.Length)


let main () =
    printfn "Podaj tekst:"
    let input = System.Console.ReadLine()

    match findLongestWord input with
    | Some(word, length) ->
        printfn "Najdłuższe słowo: %s" word
        printfn "Długość najdłuższego słowa: %d" length
    | None ->
        printfn "Nie podano żadnych słów"

main ()