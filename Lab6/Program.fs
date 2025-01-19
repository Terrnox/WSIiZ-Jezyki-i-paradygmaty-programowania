open System
open System.Collections.Generic
//Zadanie 1. Liczba słów i znaków 
//Napisz program, który pobiera tekst od użytkownika, a następnie oblicza i wyświetla: 
//• Liczbę słów w podanym tekście. 
//• Liczbę znaków (bez spacji). 
let calculateWordsAndChars (text: string) =
    let wordNumber = text.Split(" ").Length
    let charNumber = text.Replace(" ","").Length

    printfn "Liczba słów: %i\nLiczba znaków: %i" wordNumber charNumber
//Zadanie 2. Sprawdzenie palindromu 
//Stwórz funkcję, która sprawdza, czy podany ciąg znaków jest palindromem (czytany od przodu i od tyłu 
//jest taki sam). Program powinien pobierać tekst od użytkownika i wyświetlać odpowiedni komunikat. 
let isPalindrome (text: string) =
    let charNumber = text.Length
    let mutable left = 0
    let mutable right = charNumber - 1
    let mutable break = false
    while left <= right && break = false do
        if text[left] <> text[right] then
            break <- true

        left <- left + 1
        right <- right - 1

    if break = false then
        printfn "Podany ciąg znaków jest palindromem"
    else
        printfn "Podany ciąg znaków nie jest palindromem"
    
//Zadanie 3: Usuwanie duplikatów 
//Napisz funkcję, która przyjmuje listę ciągów (np. słów) i zwraca nową listę, w której usunięte są 
//duplikaty. Użytkownik powinien mieć możliwość wprowadzenia słów oddzielonych spacjami, a program 
//powinien wyświetlić listę unikalnych słów. 
let removeDuplicates (text: string) = 
    let mutable uniqueList = []
    let words = text.Split(" ")
    let wordCounts = Dictionary<string, int>()
    words |> Array.iter (fun word ->
        let lowerWord = word.ToLower()
        if wordCounts.ContainsKey(lowerWord) then
            wordCounts.[lowerWord] <- wordCounts.[lowerWord] + 1
        else
            wordCounts.[lowerWord] <- 1
    )

    wordCounts |> Seq.iter (fun kvp ->
        if kvp.Value = 1 then
            uniqueList <- uniqueList @ [kvp.Key]
    )

    printfn "%A" uniqueList

//Zadanie 4: Zmiana formatu tekstu 
//Stwórz program, który przyjmuje tekst w formacie "imię; nazwisko; wiek" i przekształca go na format 
//"Nazwisko, Imię (wiek lat)". Użytkownik powinien móc wprowadzić dowolną liczbę takich wpisów, a 
//program powinien je przetworzyć i wyświetlić w nowym formacie. 
open System.Text.RegularExpressions

let changeTextFormat (input: bool) = 
    let regex = @"^\w+;\s*\w+;\s*\d+$"
    let mutable isTrue = true 
    while isTrue do
        printfn "Wprowadź ciąg znaków:"
        let text = Console.ReadLine()
        let isTrueFormat = Regex.IsMatch(text, regex)
        if isTrueFormat then
            let words = text.Split("; ")
            let changedText = words.[1] + ", " + words.[0] + " (" + words.[2] + " lat" + ")."
            printfn "%s" changedText
        else
            printfn "Niewłaściwy format tekstu"
            isTrue <- false
//Zadanie 5: Znajdowanie najdłuższego słowa 
//Stwórz funkcję, która przyjmuje tekst od użytkownika i zwraca najdłuższe słowo. Program powinien 
//także wyświetlać długość najdłuższego słowa.
let findLongestWord (text: string) =
    let words = text.Split([| ' '; '\n'; '\t'; ';'; ','; '.'; '!'; '?' |], StringSplitOptions.RemoveEmptyEntries)
    let wordLengthCounts = Dictionary<string, int>()
    words |> Array.iter (fun word ->
       wordLengthCounts.[word] <- word.Length
    )

    let longestWord = wordLengthCounts |> Seq.maxBy (fun kvp -> kvp.Value) |> fun kvp -> kvp.Key
    let lengthOfLongestWord = longestWord.Length
    printfn "%s %i" longestWord lengthOfLongestWord
//Zadanie 6. Wyszukiwanie i zamiana 
//Stwórz program, który umożliwia użytkownikowi wyszukiwanie określonego słowa w tekście i zamianę 
//go na inne. Program powinien wyświetlić zmodyfikowany tekst.
let findAndChange (text: string) (wordToChange: string) (changedWord: string) = 
    let allWords = text.Split(" ")
    let updatedWords = 
        allWords
        |> Array.map (fun word -> 
            let firstLetter = word.[0]
            if firstLetter >= 'a' && firstLetter <= 'z' then
                if word.ToLower() = wordToChange.ToLower() then changedWord.ToLower() else word.ToLower()
            elif firstLetter >= 'A' && firstLetter <= 'Z' then
                if word.ToLower() = wordToChange.ToLower() then 
                    let newWord = changedWord.ToLower()
                    System.Char.ToUpper(newWord.[0]).ToString() + newWord.Substring(1)
                else word
            else word
        )

    let updatedText = String.Join(" ", updatedWords)
    printfn "%s" updatedText

//Main
[<EntryPoint>]
    let main argv =
        printfn "Zadanie 1: Liczba słów i znaków"
        let text1 = Console.ReadLine()
        calculateWordsAndChars text1
        printfn "Zadanie 2: Palindrom"
        printfn "Wprowadź ciąg znaków:"
        let text2 = Console.ReadLine()
        isPalindrome text2
        printfn "Zadanie 3: Usuwanie duplikatów"
        printfn "Wprowadź słowa oddzielone spacjami:"
        let text3 = Console.ReadLine()
        removeDuplicates text3
        printfn "Zadanie 4: Zmiana formatu tekstu"
        changeTextFormat true
        printfn "Zadanie 5: Znajdowanie najdłuższego słowa"
        let text5 = Console.ReadLine()
        findLongestWord text5
        printfn "Zadanie 6: Wyszukiwanie i zamiana"
        printfn "Wprowadź tekst:"
        let text6 = Console.ReadLine()
        printfn "Wyszukaj słowo:"
        let wordToChange = Console.ReadLine()
        printfn "Zamień na słowo:"
        let changedWord = Console.ReadLine()
        findAndChange text6 wordToChange changedWord
        0
