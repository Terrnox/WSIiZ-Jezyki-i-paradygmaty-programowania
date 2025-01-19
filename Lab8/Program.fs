//1. Napisz funkcję, która tworzy listę łączoną na podstawie zwykłej listy (List<'T>).
type LinkedList<'T> = 
    | Empty
    | Node of 'T * LinkedList<'T>

let rec linkList (list1: 'T list) : LinkedList<'T> =
    match list1 with
    | [] -> Empty
    | head :: tail -> Node(head, linkList tail)

//2. Napisz funkcję, która sumuje elementy listy zawierającej liczby całkowite.
let sumIntElements (list: obj List) =
    let mutable sum = 0
    list |> List.iter (fun elem ->
        match elem with
        | :? int as i -> sum <- sum + i
        | _ -> ()
    )
    sum
//3. Napisz funkcję, która znajduje maksymalny i minimalny element w liście liczbowej.
let findMinAndMaxInList (list: float List) =
    let mutable max = list[0]
    let mutable min = list[0]
    list |> List.iter (fun elem ->
        match elem with
        | _ when elem > max -> (max <- elem)
        | _ when elem < min -> (min <- elem)
        | _ -> ()
    )
    (max, min)
//4. Napisz funkcję, która odwraca kolejność elementów listy.
let rec reverseList (list: obj List) acc =
    match list with
    | [] -> acc
    | head :: tail -> reverseList tail (head :: acc)
//5. Napisz funkcję, która sprawdza, czy dany element znajduje się w liście.
let rec searchForElement searchValue list = 
    list |> List.iter (fun elem ->
        match elem with
        | _ when elem = searchValue -> printfn "Znaleziono"
        | _ -> ()
    )
//6. Napisz funkcję, która określi indeks podanego elementu, jeżeli element nie znajduje się na liście
//zwróć odpowiednią wartość (można wykorzystać unie z dyskryminatorem).
let rec searchForElementAndReturnIndex searchValue list = 
    let mutable index = 0
    list |> List.iter (fun elem ->
        match elem with
        | _ when elem = searchValue -> printfn "Znaleziono po indeksem %i" index
        | _ -> ()
        index <- index + 1
    )
//7. Napisz funkcję, która zlicza, ile razy dany element występuje w liście.
let rec searchForElementAndCountAppearances searchValue list = 
    let mutable numberOfAppearances = 0
    list |> List.iter (fun elem ->
        match elem with
        | _ when elem = searchValue -> numberOfAppearances <- numberOfAppearances + 1
        | _ -> ()
    )
    numberOfAppearances
//8. Napisz funkcję, która łączy dwie listy łączone w jedną.
let mergeList list1 list2 =
    let list = list1 @ list2
    list
//9. Napisz funkcję, która będzie przyjmowała dwie listy liczb całkowitych i zwracała listę wartości
//logicznych, gdzie true określa, że liczba na pierwszej liście była większa, a false, że wartość na
//drugiej liście byłą większa. Jeżeli jednia lista jest dłużna od drugiej zwróć wyjątek informujący o tym
//fakcie.
let compareValuesInList (list1: int List) (list2: int List) =
    let lengthOfList1 = list1.Length
    let lengthOfList2 = list2.Length
    
    if lengthOfList1 <> lengthOfList2 then
        raise (System.Exception("Różna długość list"))
    else
        List.map2 (fun elem1 elem2 -> 
            if elem1 > elem2 then
                true
            else
                false) list1 list2
//10. Napisz funkcję, która zwraca listę zawierającą tylko elementy spełniające określony warunek.
let filterList condition list =
    List.filter condition list
//11. Napisz funkcję, która usuwa duplikaty z listy.
let removeDuplicates list =
    List.distinct list
//12. Napisz funkcję, która dzieli listę na dwie części: jedną z elementami spełniającymi warunek, a drugą
//z pozostałymi elementami.
let partictionListByCondition condition list =
    List.partition condition list

// Zadanie 1
printfn "Zadanie 1"
let list1 = [1;2]
let combined = linkList list1
printfn "Lista 1: %A" list1
printfn "Lista łączona: %A" combined

// Zadanie 2
printfn "Zadanie 2"
let list3 = [box 0.5; box 1; box 6; box 0.7; box 3]
let sum = sumIntElements list3
printfn "Lista: %A" list3
printfn "Zsumowana wartość elementów listy: %i" sum

// Zadanie 3
printfn "Zadanie 3"
let list4 = [0.3;0.5;-0.7;1;0.9;-15;10]
let max, min = findMinAndMaxInList list4
printfn "Lista: %A" list4
printfn "Max: %f\nMin: %f" max min

// Zadanie 4
printfn "Zadanie 4"
let list5 = [box "Żaba";box "Lis";box "1";box 2;box 3; box 0.7]
let reversedList = reverseList list5 []
printfn "Lista przed odwróceniem: %A" list5
printfn "Odwrócona lista: %A" reversedList

// Zadanie 5
printfn "Zadanie 5"
let list6 = [1;2;3;4;5;1;3;10;7;8]
let element = 3
printfn "Lista: %A" list6
printfn "Szukany element: %i" element
searchForElement element list6

// Zadanie 6
printfn "Zadanie 6"
let list7 = [1;2;3;4;5;1;3;10;7;8]
let elementValue = 2
printfn "Lista: %A" list7
printfn "Szukany element: %i" elementValue
searchForElementAndReturnIndex elementValue list7

// Zadanie 7
printfn "Zadanie 7"
let list8 = [1;2;3;4;6;1;3;10;7;12]
let value = 1
let numberOfAppearances = searchForElementAndCountAppearances value list8
printfn "Lista: %A" list8
printfn "Szukana wartość: %i" value
printfn "Ilość wystąpień: %i" numberOfAppearances

// Zadanie 8
printfn "Zadanie 8"
let list9 = [1;2]
let list10 = [3;4]
let mergedList = mergeList list9 list10
printfn "Lista 1: %A" list9
printfn "Lista 2: %A" list10
printfn "Złączona lista: %A" mergedList

// Zadanie 9
printfn "Zadanie 9"
let list11 = [1;2;10;11;5]
let list12 = [0;3;4;12;5]
let comparedList = compareValuesInList list11 list12
printfn "Pierwsza lista: %A" list11
printfn "Druga lista: %A" list12
printfn "Lista porównania: %A" comparedList

// Zadanie 10
printfn "Zadanie 10"
let list13 = [8;10;5;1;2;-11]
let condition = (fun x -> x > 5)
let filteredList = filterList condition list13
printfn "Nieprzefiltrowana lista: %A" list13
printfn "Przefiltrowana lista: %A" filteredList

// Zadanie 11
printfn "Zadanie 11"
let list14 = [2;2;1;3;3;3;1;8;9]
let listWithoutDuplicates = removeDuplicates list14
printfn "Lista z duplikatami: %A" list14
printfn "Lista bez duplikatów: %A" listWithoutDuplicates

// Zadanie 12
printfn "Zadanie 11"
let list15 = [2;2;1;3;3;3;1;8;9]
let partOneList, partTwoList = partictionListByCondition condition list15
printfn "Pierwotna lista: %A" list15
printfn "Pierwsza lista: %A\nDruga lista: %A" partOneList partTwoList



