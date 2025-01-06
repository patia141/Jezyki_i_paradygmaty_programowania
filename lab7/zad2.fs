open System

type BankAccount(accountNumber: string, initialBalance: decimal) =
    member val AccountNumber = accountNumber with get
    member val Balance = initialBalance with get, set

    member this.Deposit(amount: decimal) =
        if amount <= 0m then
            printfn "Kwota wpłaty musi być większa niż 0"
        else
            this.Balance <- this.Balance + amount
            printfn "Wpłacono %A. Aktualne saldo: %A" amount this.Balance

    member this.Withdraw(amount: decimal) =
        if amount <= 0m then
            printfn "Kwota wypłaty musi być większa niż 0"
        elif amount > this.Balance then
            printfn "Niewystarczające środki na koncie. Aktualne saldo: %A" this.Balance
        else
            this.Balance <- this.Balance - amount
            printfn "Wypłacono %A. Aktualne saldo: %A" amount this.Balance


type Bank() =
    let accounts = new System.Collections.Generic.Dictionary<string, BankAccount>()

    member this.CreateAccount(accountNumber: string, initialBalance: decimal) =
        if accounts.ContainsKey(accountNumber) then
            printfn "Konto %s już istnieje" accountNumber
        else
            let account = new BankAccount(accountNumber, initialBalance)
            accounts.Add(accountNumber, account)
            printfn "Konto %s zostało utworzone. Saldo: %A" accountNumber initialBalance

    member this.GetAccount(accountNumber: string) =
        if accounts.ContainsKey(accountNumber) then
            Some(accounts.[accountNumber])
        else
            printfn "Konto %s nie istnieje" accountNumber
            None

    member this.UpdateAccount(accountNumber: string, newBalance: decimal) =
        match this.GetAccount(accountNumber) with
        | None -> ()
        | Some(account) ->
            account.Balance <- newBalance
            printfn "Saldo konta %s zostało zaktualizowane. Nowe saldo: %A" accountNumber newBalance

    member this.DeleteAccount(accountNumber: string) =
        if accounts.Remove(accountNumber) then
            printfn "Konto %s zostało usunięte." accountNumber
        else
            printfn "Konto %s nie istnieje." accountNumber
            

[<EntryPoint>]
let main argv =
    let bank = Bank()
    bank.CreateAccount("123", 1000.0m)
    bank.CreateAccount("654", 500.0m)

    bank.GetAccount("123") 
    |> Option.iter (fun account ->
        account.Deposit(200.0m)
        account.Withdraw(150.0m))

    bank.GetAccount("654")
    |> Option.iter (fun account ->
        account.Deposit(50.0m)
        account.Withdraw(1000.0m))

    bank.UpdateAccount("123", 2000.0m)
    bank.DeleteAccount("654")
    bank.GetAccount("654") |> ignore

    0