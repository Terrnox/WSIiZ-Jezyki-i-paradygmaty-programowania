//Klasa BankAccount: Reprezentuje konto bankowe. Posiada: 
//• Właściwość AccountNumber do przechowywania numeru konta. 
//• Właściwość Balance do odczytu aktualnego salda. 
//• Metody Deposit do wpłat i Withdraw do wypłat, z odpowiednimi sprawdzeniami. 
module BankAccount

type BankAccount(accountNumber: string, balance: float) =
    let _accountNumber = accountNumber
    let mutable _balance = balance

    member this.AccountNumber
        with get() = _accountNumber

    member this.Balance
        with get() = _balance
        and set(value) =
            if value >= 0.0 then
                _balance <- value
            else
                _balance <- 0.0

    member this.Deposit(money: float) =
        if money > 0.0 then
            _balance <- _balance + money
        else
            printfn "Podano nieprawidłową wartość wpłaty"

    member this.Withdraw(money: float) =
        if money > 0.0 && _balance >= money then
            _balance <- _balance - money
        elif _balance < money then
            printfn "Niewystarczająco środków na koncie"
        else
            printfn "Podano złą wartość wypłaty"