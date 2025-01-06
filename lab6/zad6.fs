open System

let replaceWord (text: string) (searchWord: string) (replacement: string) =
    text.Replace(searchWord, replacement)

let main () =
    printfn "Podaj tekst:"
    let originalText = Console.ReadLine()

    if String.IsNullOrWhiteSpace(originalText) then
        printfn "Nie podano tekstu"
    else
        printf "Podaj słowo do wyszukania: "
        let searchWord = Console.ReadLine()

        if String.IsNullOrWhiteSpace(searchWord) then
            printfn "Nie podano słowa do wyszukania"
        else
            printf "Podaj słowo, na które chcesz zamienić: "
            let replacement = Console.ReadLine()

            let modifiedText = replaceWord originalText searchWord replacement
            printfn "\nZmieniony tekst:"
            printfn "%s" modifiedText

main ()