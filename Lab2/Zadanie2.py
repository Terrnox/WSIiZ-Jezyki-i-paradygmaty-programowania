# Zadanie 2: Walidacja i Przekształcenia Operacji na Macierzach
# Stwórz system, który przyjmuje operacje na macierzach jako stringi i wykonuje je dynamicznie,
# zapewniając jednocześnie walidację poprawności operacji:
# • Operacje mogą obejmować dodawanie, mnożenie i transponowanie macierzy.
# • System powinien sprawdzać poprawność operacji (zgodność wymiarów) i zwracać wynik w
# postaci macierzy.
# • Wykorzystaj eval() i exec() do wykonywania operacji na macierzach, a także funkcje
# walidacyjne, które sprawdzają poprawność przed wykonaniem.
# Wskazówka: Zaimplementuj walidację operacji i użyj funkcji funkcyjnych do przekształceń i obliczeń na
# macierzach.
import numpy as np

def matrix_operations(matrix_A, matrix_B, operation):
    if operation == '+':
        if matrix_A.shape == matrix_B.shape:
            matrix_after = eval("matrix_A + matrix_B")
            return matrix_after
        else:
            raise ValueError("Rozmiary macierzy A i B muszą być takie same do dodawania.")
    elif operation == '-':
        if matrix_A.shape == matrix_B.shape:
            return eval("matrix_A - matrix_B")
        else:
            raise ValueError("Rozmiary macierzy A i B muszą być takie same do odejmowania.")
    elif operation == '*':
        if matrix_A.shape[1] == matrix_B.shape[0]:
            return eval("matrix_A @ matrix_B")
        else:
            raise ValueError("Liczba kolumn w macierzy A musi być równa liczbie wierszy w macierzy B do mnożenia.")
    elif operation == 'T':
        return eval("matrix_A.T")
    else:
        raise ValueError("Nieznana operacja. Dostępne operacje to: '+', '-', '*', 'T'.")


print("Podaj rozmiary macierzy A:")
rowA = int(input("Podaj liczbę wierszy pierwszej macierzy:"))
columnA = int(input("Podaj liczbę kolumn pierwszej macierzy:"))
A = np.empty((rowA, columnA))
for row in range(rowA):
    for column in range(columnA):
        A[row][column] = float(input(f"Wypełnij komórkę wiersz:{row+1} kolumna:{column+1}\n"))
print("Podaj operację na macierzach (Dostępne operacje to: '+', '-', '*', 'T'.)")
operation = input("Podaj liczbę operację macierzy:")
if operation == 'T':
    print(f"Macierz przed transformacją:\n{A}")
    try:
        print("Wynik transpozycji:\n", matrix_operations(A, None, operation))
    except ValueError as e:
        print(e)
else:
    print("Podaj rozmiary macierzy B:")
    rowB = int(input("Podaj liczbę wierszy drugiej macierzy:"))
    columnB = int(input("Podaj liczbę kolumn drugiej macierzy:"))
    B = np.empty((rowB, columnB))
    for row in range(rowB):
        for column in range(columnB):
            B[row][column] = float(input(f"Wypełnij komórkę wiersz:{row+1} kolumna:{column+1}\n"))

    print(f"Macierze przed transformacją:\n{A}\n{B}")
    try:
        print(f"Wynik działania {operation}:\n", matrix_operations(A, B, operation))
    except ValueError as e:
        print(e)
