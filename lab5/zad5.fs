//rekurencyjne
let rec quicksortRec = function
    | [] -> []
    | x::xs -> 
        let smaller = quicksortRec [for y in xs do if y <= x then yield y]
        let bigger = quicksortRec [for y in xs do if y > x then yield y]
        smaller @ [x] @ bigger


//iteracyjne
let quicksortIterative lst =
    let stack = System.Collections.Generic.Stack<(int list)>()
    let mutable result = []
    stack.Push(lst)
    while stack.Count > 0 do
        let lst = stack.Pop()
        match lst with
        | [] -> ()
        | [x] -> result <- x :: result
        | x::xs ->
            let smaller = [for y in xs do if y <= x then yield y]
            let bigger = [for y in xs do if y > x then yield y]
            stack.Push(bigger)
            stack.Push([x])
            stack.Push(smaller)
    result |> List.rev


//wyniki
let liczby = [8; 3; 7; 4; 2; 9; 1]
let posortowaneRec = quicksortRec liczby
let posortowaneIter = quicksortIterative liczby

printfn "Rekurencyjnie:\t %A" posortowaneRec
printfn "\nIteracyjnie:\t %A" posortowaneIter