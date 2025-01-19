// Zadanie 1. System do zarządzania biblioteką
//Zaproponuj system do zarządzania biblioteką, który będzie zwierał klasy do reprezentowania książek, 
//użytkowników biblioteki oraz samej biblioteki, z funkcjonalnością do dodawania i usuwania książek oraz 
//wypożyczania ich użytkownikom. Program powinien zawierać: Klasa Book, Klasa User, Klasa Library, 
//Program główny: Tworzy instancję biblioteki i użytkownika, dodaje książki do biblioteki, 
//wypożycza i zwraca książki przez użytkownika oraz wyświetla aktualny stan biblioteki.
// Zadanie 2. System BankAccount
// Zaproponuj system do zarządzania kontami bankowymi, który będzie implementował operacje CRUD. 
//W systemie należy zaimplementować: Klasa BankAccount, Klasa Bank
//Program główny: 
//Tworzy instancję banku i wykonuje operacje CRUD na kontach bankowych. 
//Demonstracja działań obejmuje tworzenie kont, wpłaty, wypłaty, aktualizację salda oraz usuwanie kont. 
open System.Collections.Generic
open Book
open Library
open User
open Bank
open BankAccount
// Main
[<EntryPoint>]
    let main argv =

        printfn "Biblioteka"
        let users = [ 
            User("Jan") 
            User("Anna") 
            User("Krzysztof") 
        ] 
        let book1 = Book("1984", "George Orwell", 100)
        let book2 = Book("Krzyżacy", "Henryk Sienkiewicz", 200)
        let book3 = Book("W pustyni i w puszczy", "Henryk Sienkiewicz", 150)

        let books = List<Book>()
        books.Add(book1)
        books.Add(book2)
        books.Add(book3)

        let library = Library(books)
        library.ListBooks()
        users[0].BorrowBook(book1)
        users[0].ListBorrowBooks()

        printfn "Bank"
        let bank = Bank("iBank")

        // Tworzymy konta bankowe
        let account1 = BankAccount("12345", 1000.0)
        let account2 = BankAccount("67890", 500.0)

        // Dodajemy konta do banku
        bank.CreateAccount(account1)
        bank.CreateAccount(account2)

        // Wyświetlamy konta w banku
        bank.GetAccount()

        // Wykonujemy wpłaty
        account1.Deposit(200.0)  // Konto 1 - wpłata 200
        account2.Deposit(150.0)  // Konto 2 - wpłata 150

        // Wyświetlamy konta po wpłatach
        printfn "\nPo wpłatach:"
        bank.GetAccount()

        // Wykonujemy wypłatę
        account1.Withdraw(500.0)  // Konto 1 - wypłata 500
        account2.Withdraw(100.0)  // Konto 2 - wypłata 100

        // Wyświetlamy konta po wypłatach
        printfn "\nPo wypłatach:"
        bank.GetAccount()

        // Aktualizujemy saldo konta
        bank.UpdateAccount(account1, 300.0)  // Konto 1 - dodanie 300 do salda

        // Wyświetlamy konta po aktualizacji
        printfn "\nPo aktualizacji salda:"
        bank.GetAccount()

        // Usuwamy konto
        bank.DeleteAccount(account2)  // Usunięcie konta 2

        // Wyświetlamy konta po usunięciu
        printfn "\nPo usunięciu konta 2:"
        bank.GetAccount()
        0