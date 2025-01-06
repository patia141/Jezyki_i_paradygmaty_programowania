let removeDuplicates words =
    words |> List.distinct

let main () =
    printf "Wprowadź tekst: "
    let input = System.Console.ReadLine()
    
    let slowa = input.Split(' ') |> Array.toList
    let unikalneSlowa = removeDuplicates slowa
    printfn "Unikalne słowa: %A" unikalneSlowa

main ()