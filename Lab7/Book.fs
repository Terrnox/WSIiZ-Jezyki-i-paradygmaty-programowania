//• Klasa Book: Reprezentuje książkę z tytułem, autorem i liczbą stron. Posiada metodę GetInfo() 
//zwracającą informacje o książce. 
module Book

type Book (title: string, author: string, pages: int) =
    let mutable _title = title
    let mutable _author = author
    let mutable _pages = pages

    member this.Title
        with get() = _title
        and set(value) =
            if value = "" then
                _title <- value
            else
                failwith "Nie podano tytułu książki"

    member this.Author
        with get() = _author
        and set(value) =
            if value = "" then
                _author <- value
            else
                failwith "Nie podano autora książki"

    member this.Pages
        with get() = _pages
        and set(value) =
            if value <= 0 then
                _pages <- value
            else
                failwith "Podano złą ilość stron"

    member this.GetInfo() = 
        sprintf "%s %s %i" _title _author _pages