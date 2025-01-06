//Zadanie 1. Rekurencyjne generowanie ciągu Fibonacciego 
//Napisz funkcję rekurencyjną, która oblicza n-ty wyraz ciągu Fibonacciego. Następnie zoptymalizuj ją, 
//stosując funkcję z ogonową rekurencją. 

let rec fibonacci n =
    if n = 0 then
        0
    elif n = 1 then
        1
    else
        fibonacci (n-1) + fibonacci (n-2)


let rec fibonnacciTail n acc1 acc2 = 
    if n = 0 then
        acc1
    elif n = 1 then 
        acc2
    else
        fibonnacciTail (n - 1) acc2 (acc1 + acc2)


//Zadanie 2. Wyszukiwanie elementu w drzewie binarnym 
//Zaimplementuj funkcję rekurencyjną do wyszukiwania elementu w drzewie binarnym. Napisz też 
//iteracyjną wersję tej funkcji z użyciem stosu symulowanego za pomocą listy.
let rec binaryTreeSearchTail tree searchedValue =
    let firstKeyValue = tree |> Map.toSeq |> Seq.head |> fst
    let mutable flag = 0
    if tree[firstKeyValue] = searchedValue then
        flag <- 1
        if flag = 1 then
            printfn "Znaleziono"
    else 
        let updatedTree = Map.remove firstKeyValue tree
        binaryTreeSearchTail updatedTree searchedValue

let binaryTreeSearch tree searchedValue =
    let mutable flag = 0
    for KeyValue(k, v) in tree do
        if searchedValue = v then
            flag <- 1

    if flag = 0 then
        printfn "Nieznaleziono"
    else
        printfn "Znaleziono"

//Zadanie 3. Generowanie permutacji listy: 
//Utwórz funkcję rekurencyjną generującą wszystkie możliwe permutacje listy liczb całkowitych. 
let rec permutations list =
    match list with
    | [] -> [[]]
    | _ ->
        list
        |> List.collect (fun x ->
            let remaining = List.filter ((<>) x) list
            let subPermutations = permutations remaining
            subPermutations |> List.map (fun perm -> x :: perm))
    
//Zadanie 4. Rekurencyjne rozwiązywanie problemu wież Hanoi 
//Zaimplementuj funkcję rekurencyjną do rozwiązania problemu wież Hanoi i napisz funkcję iteracyjną, 
//która symuluje ten proces bez użycia stosu. 
let rec hanoi n fromRod toRod auxRod =
    match n with
    | 1 -> printfn "Przenieś dysk 1 z %s na %s" fromRod toRod
    | _ ->
        hanoi (n - 1) fromRod auxRod toRod
        printfn "Przenieś dysk %d z %s na %s" n fromRod toRod
        hanoi (n - 1) auxRod toRod fromRod

let hanoiIter n fromRod toRod auxRod = 
    let (rod1, rod2, rod3) =
        if n % 2 = 0 then (fromRod, auxRod, toRod)
        else (fromRod, toRod, auxRod)

    let totalMoves = (1 <<< n) - 1

    let targetRod move =
        match move % 3 with
        | 1 -> rod1, rod2
        | 2 -> rod1, rod3
        | 0 -> rod2, rod3
        | _ -> failwith "Nieprawidłowy ruch"

    for move in 1..totalMoves do
        let fromRod, toRod = targetRod move
        printfn "Przenieś dysk z %s do %s" fromRod toRod
//Zadanie 5. Implementacja algorytmu QuickSort 
//Napisz funkcję rekurencyjną realizującą algorytm QuickSort i porównaj ją z iteracyjną wersją, w której 
//stos jest symulowany ręcznie.
open System.Collections.Generic

let swap (arr: int[]) (i: int) (j: int) =
        let temp = arr.[i]
        arr.[i] <- arr.[j]
        arr.[j] <- temp

let partition (arr: int[]) (low: int) (high: int) =
        let pivot = arr.[high]
        let mutable i = low - 1
        for j = low to high - 1 do
            if arr.[j] <= pivot then
                i <- i + 1
                let temp = arr.[i]
                arr.[i] <- arr.[j]
                arr.[j] <- temp
        let temp = arr.[i + 1]
        arr.[i + 1] <- arr.[high]
        arr.[high] <- temp
        i + 1

let rec sort (arr: int[]) (low: int) (high: int) =
        if low < high then
            let p = partition arr low high
            sort arr low (p - 1)
            sort arr (p + 1) high

let rec quickSort (arr: int[]) =
    let rec sort (low: int) (high: int) =
        if low < high then
            let p = partition arr low high
            sort low (p - 1)
            sort (p + 1) high

    sort 0 (arr.Length - 1)
    arr


let quickSortIter (arr: int[]) =
    let stack = Stack<(int * int)>()
    stack.Push(0, arr.Length - 1)

    while stack.Count > 0 do
        let low, high = stack.Pop()
        if low < high then
            let p = partition arr low high
            stack.Push(low, p - 1)
            stack.Push(p + 1, high)

    arr
//Main
[<EntryPoint>]
let main argv =
    printfn "Zadanie 1"
    printfn $"{fibonacci 7}"
    printfn $"{fibonnacciTail 7 0 1}"
    printfn "Zadanie 2"
    let tree = Map.ofList [(1,2);(1,3);(2,4);(2,5);(4,6);(4,7);(5,8)]
    binaryTreeSearchTail tree 3
    binaryTreeSearch tree 8
    printfn "Zadanie 3"
    let inputList = [1; 2; 3]
    let result = permutations inputList
    printfn "%A" result
    printfn "Zadanie 4"
    hanoi 3 "A" "C" "B"
    hanoiIter 3 "A" "C" "B"
    printfn "Zadanie 5"
    let unsortedArray1 = [| 4; 2; 7; 1; 9; 3 |]
    let unsortedArray2 = unsortedArray1
    printfn "Nieposortowana tablica"
    printfn "%A" unsortedArray1
    printfn "Quicksort rekurencyjnie"
    quickSort unsortedArray1
    printfn "%A" unsortedArray1
    printfn "Quicksort iteracyjnie"
    quickSortIter unsortedArray2
    printfn "%A" unsortedArray2
    0