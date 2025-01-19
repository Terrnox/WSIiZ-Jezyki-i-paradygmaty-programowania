//• Klasa User: Reprezentuje użytkownika biblioteki, który może wypożyczać i zwracać książki. 
//Posiada metody do wypożyczania (BorrowBook) oraz zwracania (ReturnBook) książek. 
module User

open System
open System.Collections.Generic
open Book
open Library

type User(name: string) =
    let mutable borrowBooks : List<Book> = new List<Book>()
    member this.Name = name

    member this.BorrowBook(book: Book) =
        borrowBooks.Add(book)
        printfn "%s wypożyczył \"%s\"" this.Name book.Title

    member this.ReturnBook(book: Book) =
        if borrowBooks.Contains(book) then
            borrowBooks.Remove(book)
            printfn "%s zwrócił \"%s\"" this.Name book.Title
        else
            printfn "%s nie ma ksiązki \"%s\" do zwrócenia" this.Name book.Title

    member this.ListBorrowBooks() =
        if borrowBooks.Count > 0 then
            borrowBooks
            |> Seq.map(fun book -> book.GetInfo())
            |> String.concat "\n"
            |> fun booksInfo -> printfn "Książki wypożyczone przez %s:\n%s" this.Name booksInfo
        else
            printfn "%s nie ma ksiąźek do zwrócenia" this.Name
