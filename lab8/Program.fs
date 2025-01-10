open System
open System.Collections.Generic

//definicja listy łączonej
//zad 1
type LinkedList<'T> =
    | Empty 
    | Node of 'T * LinkedList<'T>

//modul zawierajacy funkcje do zadan
module LinkedList =
    //utworzenie listy na podstawie elementow podanych od usera
    let rec fromList =
        function
        | [] -> Empty
        | x :: xs -> Node(x, fromList xs)

    //funkcja do wyswietlania listy
    let rec printList list =
        match list with 
        | Empty -> ()
        | Node(value, next) ->
            printf "%A " value //%A - wyswietlenie dowolnego typu
            printList next

    //zad 2 - suma elementow
    let rec sumList =
        function
        | Empty -> 0
        | Node(x, xs) -> x + sumList xs

    //zad 3 - max, min elementy
    let rec findMinMax list =
        match list with
        | Empty -> failwith "Lista jest pusta, brak elementów do porównania"
        | Node(value, tail) ->
            let rec helper currentMin currentMax remaining =
                match remaining with
                | Empty -> (currentMin, currentMax)
                | Node(v, t) ->
                    let newMin = min currentMin v
                    let newMax = max currentMax v
                    helper newMin newMax t
            helper value value tail

    //zad 4 - odwrocenie kolejnosci elementow listy
    let rec reverse list =
        let rec helper acc list =
            match list with
            | Empty -> acc
            | Node(value, next) -> helper (Node(value, acc)) next
        helper Empty list

    //zad 5 - czy zawiera element
    let rec contains value list =
        match list with
        | Empty -> false
        | Node(v, next) -> if v = value then true else contains value next

    //zad 6 - indeks wartosci
    let rec findIndex value list =
        let rec helper index list =
            match list with
            | Empty -> None
            | Node(v, next) -> if v = value then Some index else helper (index + 1) next
        helper 0 list


    //zad 7 - ile wystapien danego elementu
    let rec countOccurrences value list =
        match list with
        | Empty -> 0
        | Node(v, next) -> (if v = value then 1 else 0) + countOccurrences value next

    //=================koniec modulu=================

module LinkedListExtensions = 
    open LinkedList

    //zad 8 - laczenie dwoch list
    let rec append list1 list2 =
        match list1 with
        | Empty -> list2
        | Node(value, next) -> Node(value, append next list2)

    //zad 9 - porownaj listy
    let rec compareLists list1 list2 =
        match (list1, list2) with
        | (Empty, Empty) -> Empty
        | (Empty, _) | (_, Empty) -> failwith "Listy mają różne długości"
        | (Node(v1, next1), Node(v2, next2)) ->
            Node(v1 > v2, compareLists next1 next2)

    //zad 10 - elementy spelniajace okreslony warunek
    let rec filter predicate list =
        match list with
        | Empty -> Empty
        | Node(value, next) ->
            if predicate value then
                Node(value, filter predicate next)
            else
                filter predicate next

    //zad 11 - usuwanie duplikatow
    let rec removeDuplicates list =
        let rec helper seen list =
            match list with
            | Empty -> Empty
            | Node(value, next) ->
                if LinkedList.contains value seen then
                    helper seen next
                else
                    Node(value, helper (Node(value, seen)) next)
        helper Empty list

    //zad 12 - dzielenie listy ze wzgledu na warunki
    let rec partition predicate list =
        let rec helper yes no list =
            match list with
            | Empty -> (yes, no)
            | Node(value, next) ->
                if predicate value then
                    helper (Node(value, yes)) no next
                else
                    helper yes (Node(value, no)) next
        let (yes, no) = helper Empty Empty list
        (LinkedList.reverse yes, LinkedList.reverse no)

    //=================koniec modulu=================


//funkcja do wczytywania elementow z klawiatury
let rec readUserList() =
    printf "Podaj elementy listy oddzielone spacją: "
    let input = Console.ReadLine()
    let items =
        input.Split(' ')
        |> Array.choose (fun x->
            match Int32.TryParse(x) with
            | (true, v) -> Some v
            | _ -> None )
        |> Array.toList
    LinkedList.fromList items
    

let rec mainLoop currentList =
    printfn "\nMenu:"
    printfn "1. Wyświetl listę"
    printfn "2. Dodaj elementy do listy"
    printfn "3. Policz sumę elementów"
    printfn "4. Znajdź minimalny i maksymalny element"
    printfn "5. Odwróć listę"
    printfn "6. Sprawdź, czy element znajduje się w liście"
    printfn "7. Znajdź indeks wartości"
    printfn "8. Połącz dwie listy"
    printfn "9. Porównaj dwie listy"
    printfn "10. Filtruj elementy według warunku"
    printfn "11. Usuń duplikaty z listy"
    printfn "12. Podziel listę na dwie części według warunku"
    printfn "0. Wyjdź z programu"

    printf "Wybierz opcję: "
    match Console.ReadLine() with
    | "1" ->
        printf "Elementy listy: "
        LinkedList.printList currentList
        mainLoop currentList

    | "2" ->
        let newList = readUserList()
        let mergedList = LinkedListExtensions.append currentList newList
        printfn "Lista zaktualizowana"
        mainLoop mergedList

    | "3" ->
        let sum = LinkedList.sumList currentList
        printfn "Suma elementów listy: %d" sum
        mainLoop currentList

    | "4" ->
        try
            let (min, max) = LinkedList.findMinMax currentList
            printfn "Minimalny element: %d, Maksymalny element: %d" min max
        with
        | _ -> printfn "Lista jest pusta"
        mainLoop currentList

    | "5" ->
        let reversedList = LinkedList.reverse currentList
        printfn "Lista po odwróceniu: "
        LinkedList.printList reversedList
        mainLoop reversedList

    | "6" ->
        printf "Podaj wartość do sprawdzenia: "
        let value = Console.ReadLine() |> int
        let contains = LinkedList.contains value currentList
        if contains then
            printfn "Wartość %d znajduje się w liście" value
        else
            printfn "Wartość %d nie została znaleziona w liście" value
        mainLoop currentList

    | "7" ->
        printf "Podaj wartość do znalezienia: "
        let value = Console.ReadLine() |> int
        match LinkedList.findIndex value currentList with
        | Some index -> printfn "Wartość %d znajduje się na indeksie %d" value index
        | None -> printfn "Wartość %d nie została znaleziona" value
        mainLoop currentList

    | "8" ->
        printfn "Podaj drugą listę do połączenia"
        let secondList = readUserList()
        let combinedList = LinkedListExtensions.append currentList secondList
        printfn "Listy zostały połączone. Nowa lista: "
        LinkedList.printList combinedList
        mainLoop combinedList

    | "9" ->
        printfn "Podaj drugą listę do porównania"
        let secondList = readUserList()
        try
            let result = LinkedListExtensions.compareLists currentList secondList
            printfn "Porównanie (true = pierwszy element większy): "
            LinkedList.printList result
        with
        | _ -> printfn "Listy mają różne długości"
        mainLoop currentList

    | "10" ->
        printf "Podaj wartość graniczną dla filtrowania: "
        let threshold = Console.ReadLine() |> int
        let predicate x = x > threshold
        let filteredList = LinkedListExtensions.filter predicate currentList
        printfn "Lista po filtrowaniu (x > %d):" threshold
        LinkedList.printList filteredList
        mainLoop currentList

    | "11" ->
        let updatedList = LinkedListExtensions.removeDuplicates currentList
        printfn "Lista po usunięciu duplikatów: "
        LinkedList.printList updatedList
        mainLoop updatedList

    | "12" ->
        printf "Podaj wartość graniczną dla podziału: "
        let threshold = Console.ReadLine() |> int
        let predicate x = x > threshold
        let (yesList, noList) = LinkedListExtensions.partition predicate currentList
        printfn "Elementy spełniające warunek (x > %d):" threshold
        LinkedList.printList yesList
        printfn "\nElementy niespełniające warunku (x <= %d):" threshold
        LinkedList.printList noList
        mainLoop currentList

    | "0" -> 
        printfn "Wyjście z programu"

    | _ ->
        printfn "Nieznana opcja. Spróbuj ponownie"
        mainLoop currentList

[<EntryPoint>]
let main argv =
    printfn "Podaj początkową listę elementów (lub wciśnij Enter, aby rozpocząć z pustą listą):"

    let userList = readUserList()
    mainLoop userList

    0


(*
let Head =
    function
    | Empty -> failwith "Nie można pobrać głowy z listy pustej"
    | Node(Head,_) -> Head

let Tail =
    function
    | Empty -> failwith "Nie można pobrać ogona z listy pustej"
    | Node(Tail,_) -> Tail

let addHead value list =
    Node(value, list)

let rec printList list =
    match list with 
    | Empty -> ()
    | Node(value, next) ->
        printf "%A " value //%A - wyswietlenie dowolnego typu
        printList next

let rec numberElements =
    function
    | Empty -> 0
    | Node(_, Tail) -> numberElements Tail + 1
    *)

(*
[<EntryPoint>]
let main argv =
    let mutable userList = LinkedList.Empty

    userList <- readUserList()
    
    printf "\nElementy listy:\t"
    LinkedList.printList userList

    let suma = LinkedList.sumList userList
    printf "\nSuma elementow listy: %d" suma

    (*
    let list1 = Empty
    let list2 = addHead 1 list1
    let list3 = addHead 2 list2
    let list4 = addHead 3 list3

    printList list4

    let ilosc = numberElements list4
    printf "\n%d" ilosc *)

    0 *)