//Klasa Bank: Zarządza kontami bankowymi. Posiada metody do: 
//• Tworzenia kont (CreateAccount). 
//• Odczytu kont (GetAccounts). 
//• Aktualizacji salda konta (UpdateAccount). 
//• Usuwania kont (DeleteAccount). 
module Bank

open System.Collections.Generic
open BankAccount

type Bank(bankName: string) =
    let _bankName = bankName
    let mutable accounts : List<BankAccount> = new List<BankAccount>()

    member this.BankName
        with get() = _bankName

    member this.CreateAccount(account: BankAccount) =
        if accounts.Contains(account) then
            printfn "Konto o id %s już istnieje" account.AccountNumber
        else
            accounts.Add(account)
            printfn "Utworzono konto o numerze %s" account.AccountNumber

    member this.GetAccount() =
        printfn "Konta w banku %s:" _bankName
        for account in accounts do
            printfn "Konto: %s ma saldo: %f" account.AccountNumber account.Balance

    member this.UpdateAccount(account: BankAccount, money: float) =
        if accounts.Contains(account) then
            let index = accounts.IndexOf(account)
            accounts[index].Balance <- accounts[index].Balance + money
        
    member this.DeleteAccount(account: BankAccount) =
        if accounts.Contains(account) then
            accounts.Remove(account)
            printfn "Usunięto konto o id %s" account.AccountNumber
        else
            printfn "Nie ma takiego konta"



