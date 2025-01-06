open System
open System.Collections.Generic

type Status =
    | Dostepna
    | Wypozyczona

type Book(title: string, author: string, pages: int) =
    let mutable status = "dostępna"
    member this.Title = title
    member this.Author = author
    member this.Pages = pages
    member this.Status
        with get() = status
        and set(value) = status <- value

    member this.GetInfo() =
        sprintf "Tytuł: %s \tAutor: %s \tLiczba stron: %d \tStatus: %s" this.Title this.Author this.Pages this.Status


type User(name: string) =
    member this.Name = name
    member this.BorrowedBooks = new List<Book>()

    member this.BorrowBook(book: Book) =
        if book.Status = "dostępna" then
            this.BorrowedBooks.Add(book)
            book.Status <- "wypożyczona"
            printfn "%s wypożyczył/a książkę %s" this.Name book.Title
        else
            printfn "Książka %s jest już wypożyczona i niedostępna" book.Title

    member this.ReturnBook(book: Book) =
        book.Status <- "dostępna"
        this.BorrowedBooks.Remove(book) |> ignore
        printfn "%s zwrócił/a książkę %s" this.Name book.Title


type Library() = 
    let books = new List<Book>()

    member this.AddBook(book: Book) =
        books.Add(book)
        printfn "Dodano książkę %s" book.Title

    member this.RemoveBook(book: Book) =
        if books.Remove(book) then
            printfn "Usunięto książkę %s" book.Title
        else
            printfn "Nie znaleziono książki %s" book.Title

    member this.ListBooks() =
        printfn "\nKsiążki w bibliotece:"
        for book in books do
            printfn "- %s" (book.GetInfo())
        printfn "--------------------------------------------------------------------------------------"


[<EntryPoint>]
let main argv =
    let library = Library()

    let book1 = Book("Książka 1", "Autor 1", 123)
    let book2 = Book("Książka 2", "Autor 2", 321)
    let book3 = Book("Książka 3", "Autor 3", 420)

    library.AddBook(book1)
    library.AddBook(book2)
    library.AddBook(book3)
    library.ListBooks()

    let user = User("Jan Kowalski")

    user.BorrowBook(book1)
    user.BorrowBook(book2)
    user.BorrowBook(book3)
    library.ListBooks()

    user.ReturnBook(book1)
    user.ReturnBook(book3)
    user.BorrowBook(book2)
    library.ListBooks()

    0