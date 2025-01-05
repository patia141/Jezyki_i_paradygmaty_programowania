//rekurencyjnie
let rec hanoiRec n source target auxiliary =
    if n = 1 then
        printfn "Przesuń tarczę z %s do %s" source target
    else
        hanoiRec (n - 1) source auxiliary target
        printfn "Przesuń tarczę z %s do %s" source target
        hanoiRec (n - 1) auxiliary target source

printfn "Rekurencyjnie:"
hanoiRec 3 "A" "C" "B"

//iteracyjnie
let hanoiIter n source target auxiliary =
    let ruchy = (1 <<< n) - 1
    let slupki = [| source; auxiliary; target |]
    let stosy = Array.init 3 (fun _ -> [])

    stosy.[0] <- List.init n (fun i -> n - i)

    let przesunDysk zeSlupka naSlupek =
        let dysk = List.head stosy.[zeSlupka] //pobranie gornej tarczy
        stosy.[zeSlupka] <- List.tail stosy.[zeSlupka] //usuniecie tarczy ze slupka zrodlowego
        stosy.[naSlupek] <- dysk :: stosy.[naSlupek] //dodanie tarczy na cel
        printfn "Przesuń tarczę %d z %s do %s" dysk slupki.[zeSlupka] slupki.[naSlupek]

    for move in 1..ruchy do
        let fromPeg = (move &&& move - 1) % 3
        let toPeg = ((move ||| move - 1) + 1) % 3
        przesunDysk fromPeg toPeg

printfn "\nIteracyjnie:"
hanoiIter 3 "A" "C" "B"
