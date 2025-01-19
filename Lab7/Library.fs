//• Klasa Library: Reprezentuje bibliotekę, która zarządza kolekcją książek. Posiada metody do 
//dodawania (AddBook), usuwania (RemoveBook) oraz listowania (ListBooks) książek. 
module Library

open System.Collections.Generic
open Book

type Library(books: List<Book>) =
    member this.AddBook(book: Book) =
        books.Add(book)
        printfn "Książka %s została dodana" book.Title

    member this.RemoveBook(book: Book) =
        if books.Remove(book) then
            printfn "Książka %s została usunięta" book.Title
        else
            printfn "Książka %s nie istnieje w bibliotece" book.Title

    member this.ListBooks() =
        if books.Count > 0 then
            printfn "Książki w bibliotece:"
            books |> Seq.iter (fun book -> printfn "%s" book.Title)
        else
            printfn "Nie ma książek w bibliotece"

