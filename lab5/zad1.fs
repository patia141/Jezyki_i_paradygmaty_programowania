//funkcja rekurencyjna
let rec fibRec n = 
    if n <= 0 then 0
    elif n = 1 then 1
    else fibRec (n - 1) + fibRec (n - 2)

//let wynik = fibRec 10
//printfn "Fib 10 = %d" wynik 

//funkcja rekurencyjna ogonowa
let fibTailRec n =
    let rec aux n a b = 
        if n <= 0 then a
        elif n = 1 then b
        else aux (n - 1) b (a + b)
    aux n 0 1 //n-pierwszy parametr, 0 1 - warunki graniczne

let wynik = fibTailRec 10
printfn "Fib 10 = %d" wynik