let rec permutacje list =
    match list with
    | [] -> [[]]
    | _ ->
        list
        |> List.collect (fun x ->
            let rest = List.filter ((<>) x) list
            permutacje rest |> List.map (fun perm -> x :: perm))


let liczby = [1; 2; 3]
let perm = permutacje liczby
printfn "Permutacje listy %A to:" liczby
perm |> List.iter (printfn "%A")
