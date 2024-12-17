// Zadanie 1. Stwórz aplikację konsolową, która oblicza wskaźnik masy ciała (BMI) użytkownika na
// podstawie wprowadzonych przez niego wagi (kg) i wzrostu (cm). Program powinien komunikować się z
// użytkownikiem, odczytywać dane wejściowe, przeliczać BMI i wyświetlać wynik wraz z kategorią BMI.
// Wymagane funkcje:
// • Komunikacja z użytkownikiem: Odczyt danych za pomocą Console.ReadLine() i wyświetlanie
// wyników za pomocą printfn.
// • Przekształcanie typów: Konwersja danych wejściowych z string na float.
// • Instrukcje warunkowe: Określenie kategorii BMI na podstawie wartości obliczonej.
// • Niezmienne struktury danych: Możesz użyć rekordów do przechowywania danych użytkownika.
open System
open System.Collections.Generic

let BMI height weight = 
    let floatHeight : float = float height / 100.0
    let floatWeight : float = float weight
    let bmi = floatWeight / (floatHeight**2)
    match bmi with
        | bmi when bmi < 18.5 ->  printfn $"Wartość BMI: {bmi} - Niedowaga"
        | bmi when bmi >= 18.5 && bmi < 24.99 -> printfn $"Wartość BMI: {bmi} - Wartość prawidłowa"
        | bmi when bmi >= 25 && bmi < 29.99 -> printfn $"Wartość BMI: {bmi} - Nadwaga"
        | bmi when bmi >= 30 && bmi < 34.99 -> printfn $"Wartość BMI: {bmi} - Otyłość I stopnia"
        | bmi when bmi >= 35 && bmi < 40 -> printfn $"Wartość BMI: {bmi} - Otyłość II stopnia"
        | _ -> printfn $"Wartość BMI: {bmi} - Otyłość III stopnia"

//Zadanie 2. Napisz program, który pozwala użytkownikowi na konwersję kwoty z jednej waluty na inną.
//Program powinien pobierać od użytkownika:
//• Kwotę do przeliczenia.
//• Walutę źródłową (np. USD, EUR, GBP).
//• Walutę docelową.
//Następnie program powinien obliczyć i wyświetlić przeliczoną kwotę na podstawie zdefiniowanych
//kursów wymiany.
//Wymagane funkcje:
//• Instrukcje let: Przechowywanie kursów wymiany jako stałe.
//• Instrukcje warunkowe: Obsługa różnych kombinacji walut.
//• Operatory arytmetyczne: Obliczanie przeliczonej kwoty.
//• Niezmienne struktury danych: Użycie mapy (Map) do przechowywania kursów wymiany.

let currencyCalculator amount sourceCurrency targetCurrency =
    let exchangeRates = 
        Map.ofList [
            ("PLN", "USD"), 0.25; ("PLN", "GBP"), 0.19; ("PLN", "EUR"), 0.23; ("PLN", "CHF"), 0.22;
            ("USD", "PLN"), 4.05; ("USD", "GBP"), 0.78; ("USD", "EUR"), 0.95; ("USD", "CHF"), 0.88;
            ("GBP", "PLN"), 5.18; ("GBP", "USD"), 1.27; ("GBP", "EUR"), 1.21; ("GBP", "CHF"), 1.13;
            ("EUR", "PLN"), 4.26; ("EUR", "USD"), 1.05; ("EUR", "GBP"), 0.82; ("EUR", "CHF"), 0.93;
            ("CHF", "PLN"), 4.59; ("CHF", "USD"), 1.13; ("CHF", "GBP"), 0.89; ("CHF", "EUR"), 1.08;
            ("PLN", "PLN"), 1.0; ("USD", "USD"), 1.0; ("GBP", "GBP"), 1.0; ("EUR", "EUR"), 1.0; ("CHF", "CHF"), 1.0;
        ]

    let floatAmount = float amount
    match exchangeRates.TryFind (sourceCurrency, targetCurrency) with
    | Some rate -> floatAmount * rate
    | None -> 
        failwithf "Nieobsługiwany kurs wymiany: %s na %s" sourceCurrency targetCurrency

         
//Zadanie 3. Stwórz program, który analizuje wprowadzony przez użytkownika tekst. Program powinien: 
//• Liczyć liczbę słów. 
//• Liczyć liczbę znaków (bez spacji). 
//• Znajdować najczęściej występujące słowo. 
//Wymagane funkcje: 
//• Nadawanie wartości: Przechowywanie danych tekstowych. 
//• Łańcuchy znaków: Operacje na stringach, takie jak dzielenie na słowa. 
//• Instrukcje warunkowe: Obsługa różnych scenariuszy analizy. 
//• Niezmienne struktury danych: Użycie list i map do przechowywania i analizowania słów.

let analyseText (text: string) =
    let words = text.Split([|' '; '\t'; '\n'; '\r'|], StringSplitOptions.RemoveEmptyEntries)
    let wordCount = words.Length
    let charCount = text.Replace(" ", "").Length

    let wordCounts = Dictionary<string, int>()
    words |> Array.iter (fun word ->
        let lowerWord = word.ToLower()
        if wordCounts.ContainsKey(lowerWord) then
            wordCounts.[lowerWord] <- wordCounts.[lowerWord] + 1
        else
            wordCounts.[lowerWord] <- 1
    )

    let mostFreqWord = 
        wordCounts
        |> Seq.maxBy (fun kvp -> kvp.Value)
        |> fun kvp -> kvp.Key
    
    (wordCount, charCount, mostFreqWord)

//Zadanie 4. Stwórz aplikację, która symuluje podstawowe operacje bankowe. Użytkownik powinien móc: 
//• Tworzyć nowe konto. 
//• Depozytować środki na konto. 
//• Wypłacać środki z konta. 
//• Wyświetlać saldo konta. 
//Wymagane funkcje: 
//• Niezmienne struktury danych: Użycie mapy (Map) do przechowywania kont z unikalnymi identyfikatorami. 
//• Rekordy: Definiowanie struktury konta z numerem konta i saldem. 
//• Instrukcje warunkowe i operatorów: Obsługa różnych akcji i walidacja operacji (np. brak środków). 
//• Komunikacja z użytkownikiem: Interakcja poprzez menu tekstowe.

type Account = {
    Id: int
    mutable Balance: decimal
}

let accounts = System.Collections.Generic.Dictionary<int, Account>()

let createAccount id initialDeposit =
    if accounts.ContainsKey(id) then
        printfn "Konto ID %d już istnieje." id
    else
        let newAccount = { Id = id; Balance = initialDeposit }
        accounts.Add(id, newAccount)
        printfn "Utworzono noweg konto ID %d z kwotą %.2f" id initialDeposit

let deposit id amount =
    match accounts.TryGetValue(id) with
    | true, account ->
        account.Balance <- account.Balance + amount
        printfn "Zdeponowano %.2f na konto %d. Nowe saldo: %.2f" amount id account.Balance
    | false, _ ->
        printfn "Nie znaleziono konta ID %d" id

let withdraw id amount =
    match accounts.TryGetValue(id) with
    | true, account when account.Balance >= amount ->
        account.Balance <- account.Balance - amount
        printfn "Wyciągnięto %.2f z konta %d. Nowe saldo: %.2f" amount id account.Balance
    | true, _ ->
        printfn "Za mało pieniędzy na koncie %d." id
    | false, _ ->
        printfn "Nie znaleziono konta ID %d" id

let checkBalance id =
    match accounts.TryGetValue(id) with
    | true, account ->
        printfn "Saldo konta %d wynosi %.2f" id account.Balance
    | false, _ ->
        printfn "Nie znaleziono konta ID %d" id

let rec showMenu () =
    printfn "Witaj w banku. Wybierz jedną z poniższych opcji:"
    printfn "1. Utwórz nowe konto"
    printfn "2. Wpłać pieniądze na konto"
    printfn "3. Wypłać pieniądze z konta"
    printfn "4. Sprawdź saldo konta"
    printfn "5. Wyjście"
    let option = Console.ReadLine()
    Console.Clear()
    match option with
    | "1" ->
        printf "Wprowadź ID konta: "
        let id = int (Console.ReadLine())
        printf "Wprowadź kwotę nowoutworzonego konta "
        let initialDeposit = decimal (Console.ReadLine())
        createAccount id initialDeposit
        showMenu()
    | "2" ->
        printf "Wprowadź ID konta: "
        let id = int (Console.ReadLine())
        printf "Wprowadź kwotę: "
        let amount = decimal (Console.ReadLine())
        deposit id amount
        showMenu()
    | "3" ->
        printf "Wprowadź ID konta: "
        let id = int (Console.ReadLine())
        printf "Wprwowadź kwotę"
        let amount = decimal (Console.ReadLine())
        withdraw id amount
        showMenu()
    | "4" ->
        printf "Wprowadź ID konta: "
        let id = int (Console.ReadLine())
        checkBalance id
        showMenu()
    | "5" ->
        printfn "Dziękujemy za skorzystanie z usług naszego banku"
    | _ ->
        printfn "Nieobsługiwana opcja"
        showMenu()

//Zadanie 5. Zaprojektuj i zaimplementuj grę „Kółko i Krzyżyk” w konsoli, gdzie użytkownik gra przeciwko 
//komputerowi. Gra powinna: 
//• Wyświetlać planszę po każdej turze. 
//• Umożliwiać graczowi wybór pozycji na planszy. 
//• Komputer powinien wykonywać ruchy losowo lub według prostego algorytmu. 
//• Określać zwycięzcę lub remis. 
//Wymagane funkcje: 
//• Niezmienne struktury danych: Reprezentacja planszy jako list lub tablica. 
//• Instrukcje warunkowe i operatorów: Sprawdzanie stanu gry, wygrywających kombinacji. 
//• Operacje na łańcuchach znaków: Wyświetlanie planszy. 
//• Instrukcje let i rekursja: Zarządzanie turami gry. 

// Main
[<EntryPoint>]
let main argv =
    printfn "Lista wykonanych zadań:\n1.Kalkulator BMI\n2.Kalkulator walut\n3.Analiza tekstu\n4.Bank\n5.Kółko i krzyżyk"
    printfn "Podaj numer zadania:"
    let choice = Console.ReadLine()
    match choice with
    | "1" ->
        printfn "Zadanie 1"
        printfn "Podaj wzrost w centymentach:"
        let height = Console.ReadLine()
        printfn "Podaj wagę w kilogramach:"
        let weight = Console.ReadLine()
        let bmiValue = BMI height weight
        bmiValue
    | "2" ->
        printfn "Obsługiwane waluty to: PLN, USD, GBP, EUR, CHF"
        printf "Podaj kwotę do przeliczenia: "
        let amount = Console.ReadLine() |> float
        printf "Podaj walutę źródłową: "
        let sourceCurrency = Console.ReadLine()
        printf "Podaj walutę docelową: "
        let targetCurrency = Console.ReadLine()
        try
            let exchangedAmount = currencyCalculator amount sourceCurrency targetCurrency
            printfn "Kwota po przeliczeniu: %.2f %s" exchangedAmount targetCurrency
        with
        | ex -> printfn "Błąd: %s" ex.Message
    | "3" ->
        printfn "Zadanie 3"
        printfn "Podaj tekst do przeanalizowania:"
        let text = Console.ReadLine()
        let (wordCount, charCount, mostFreqWord) = analyseText text
        printfn $"Liczba słów - {wordCount}\nLiczba znaków - {charCount}\nNajczęstsze słowo - {mostFreqWord}"
    | "4" ->
        printfn "Zadanie 4"
        showMenu()
    | "5" ->
        printfn "Zadanie 5"
    | _ -> printfn "Podano zły numer zadania"
    0