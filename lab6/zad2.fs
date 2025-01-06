open System

let isPalindrome (input: string) =
    let processedInput = input.Replace(" ", "").ToLower()
    processedInput = new String(processedInput.ToCharArray() |> Array.rev)

[<EntryPoint>]
let main argv =
    printfn "Podaj ciąg znaków:"
    let userInput = Console.ReadLine()
    if isPalindrome userInput then
        printfn "Ciąg \"%s\" jest palindromem." userInput
    else
        printfn "Ciąg \"%s\" nie jest palindromem." userInput
    0