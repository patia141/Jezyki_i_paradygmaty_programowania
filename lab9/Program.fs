//proceduralne

//zad 1
(*
let obliczSume(n: int) =
    if n < 0 then 
        printfn "podaj liczbę większą od 0" //liczymy tylko dodatnie
        0
    else
        [1..n] |> List.sum //tworzymy listę od 1 do n i sumujemy jej elementy za pomocą "sum"

let wynik = obliczSume 3
printfn "Wynik: %d" wynik
*)

//zad 2
(*
let czyLiczbaPierwsza n =
    if n < 2 then false
    else
        let limit = int(sqrt(float n))
        let rec sprawdzDzielniki d =
            if d > limit then true
            elif n % d = 0 then false
            else sprawdzDzielniki (d+1)
        sprawdzDzielniki 2

let wynik = czyLiczbaPierwsza 4
printfn "Wynik: %A" wynik
*)

//zad 3
(*
open System 

let rec pobierzUczniow uczniowie =
    printfn "Podaj imie ucznia: "
    let name = Console.ReadLine()

    printfn "Podaj oceny ucznia: "
    let ocenyInput = Console.ReadLine()
    let oceny =
        ocenyInput.Split(' ')
        |> Array.choose (fun x -> 
            match Int32.TryParse(x) with
            | (true, v) when v >= 1 && v <= 6 -> Some v
            | _ -> None)
        |> Array.toList

    let nowiUczniowie = uczniowie @ [(name, oceny)]

    printfn "Czy chcesz dodać kolejnego ucznia? (t/n)"
    let odpowiedz = Console.ReadLine()

    if odpowiedz.ToLower() = "t" then
        pobierzUczniow nowiUczniowie
    else
        nowiUczniowie


let uczniowie = pobierzUczniow []

printfn "\nRaport:"
for (name, oceny) in uczniowie do
    printfn "\nImię: %s" name
    printfn "Oceny: %A" oceny
*)

//zad 4 - sortowanie bez 'sort'
(*
let bubbleSort (lista: int list) =
    let array = lista |> List.toArray
    let n = Array.length array

    for i in 0 .. n - 2 do
        for j in 0 .. n - 2 do
            if array[j] > array[j+1] then
                let temp = array[j]
                array[j] <- array[j+1]
                array[j+1] <- temp

    array |> Array.toList

let liczby = [8; 9; 2; 5; 10; 3; 5]
let posortowane = bubbleSort liczby
printfn "Przed posortowaniem: %A" liczby
printfn "Po posortowaniu: %A" posortowane
*)

//zad 5
(*
open System
open System.IO

let analizuj sciezka =
    File.ReadAllText(sciezka)
    |> fun tekst ->
        tekst.ToLower()
        |> Seq.filter (fun c -> Char.IsLetterOrDigit(c) || Char.IsWhiteSpace(c))
        |> String.Concat
    |> fun tekst -> tekst.Split([| ' '; '\t'; '\n'; '\r'|], StringSplitOptions.RemoveEmptyEntries)
    |> Array.countBy id
    |> Array.sortByDescending snd //sortuje malejaco wg liczby wystapien

let zapiszRaport raport sciezkaRaportu =
    File.WriteAllLines(sciezkaRaportu, raport |> Array.map (fun(slowo, liczba) -> $"{slowo}: {liczba}"))

[<EntryPoint>]
let main argv =
    printfn "Podaj sciezke pliku: "
    let sciezka = Console.ReadLine()
    let wynik = analizuj sciezka

    printfn "Podaj sciezke do zapisu raportu: "
    let sciezkaRaportu = Console.ReadLine()
    zapiszRaport wynik sciezkaRaportu
    printfn "Raport zostal zapisany w %s" sciezkaRaportu

    0
*)

//funkcyjne

//zad 6 - silnia
(*
let rec silnia n =
    if n = 0 || n = 1 then 1
    else n * silnia (n-1)

printfn "Silnia: %d" (silnia 6)
*)

//zad 7 - na wielkie litery wszystko
(*
let naWielkie (slowa: string list) =
    slowa |> List.map (fun slowo -> slowo.ToUpper())

let slowa = ["kotek"; "Kicia"; "KoCuR"; "KASIA"]
let wynik = naWielkie slowa
printfn "Wynik: %A" wynik
*)

//zad 8 - NWD
(*
//moj
let rec NWD a b =
    if a = b then a
    elif a > b then NWD (a - b) b
    else NWD a (b - a)

//chat
let rec NWD_chat a b =
    if b = 0 then a
    else NWD b (a % b)

printfn "NWD: %d" (NWD 48 18)
*)

//zad 9 - lista slow na liste ich dlugosci
(*
let dlugoscSlow (slowa: string list) =
    slowa |> List.map (fun slowo -> slowo.Length)

let slowa = ["kotek"; "kot"; "koteczek"; "a"]
let wynik = dlugoscSlow slowa
printfn "Wynik: %A" wynik
*)

//zad 10 - kalkulator
(*
open System

let rec kalkulator (wyrazenie: string) =
    let usunSpacje (str: string) = str.Replace(" ","")

    let oblicz a b operator =
        match operator with
        | '+' -> a+b
        | '-' -> a-b
        | '*' -> a*b
        | '/' -> a/b
        | _ -> failwith "Nieznany operator"

    let rec obliczNawiasy (expr: string) =
        let start = expr.LastIndexOf('(')
        if start = -1 then expr
        else
            let koniec = expr.IndexOf(')', start)
            let podwyrazenie = expr.Substring(start+1, koniec-start-1)
            let wartosc = kalkulator podwyrazenie
            let nowyExpr = expr.Substring(0, start) + wartosc.ToString() + expr.Substring(koniec+1)
            obliczNawiasy nowyExpr

    let obliczWyrazenie expr =
        let elementy = System.Text.RegularExpressions.Regex.Split(expr, @"([\+\-\*/])")
        let mutable wynik = Double.Parse(elementy.[0])
        let mutable i = 1
        while i < elementy.Length do
            let operator = elementy[i].[0]
            let liczba = Double.Parse(elementy.[i+1])
            wynik <- oblicz wynik liczba operator
            i <- i+2
        wynik

    obliczWyrazenie (usunSpacje (obliczNawiasy wyrazenie))


//uzycie
let wyrazenie = "(2+3) * (1 + 1)"
let wynik = kalkulator wyrazenie
printfn "%s = %A" wyrazenie wynik
*)

//zad 11

let rec zbiorPotegowy (lista: int list) =
    match lista with
    | [] -> [[]]
    | x :: xs ->
        let podzbiory = zbiorPotegowy xs
        podzbiory @ (podzbiory |> List.map (fun podzbior -> x :: podzbior))


//uzycie
let lista = [1;2;3]
let wynik = zbiorPotegowy lista
printfn "Zbiór potęgowy: %A" wynik