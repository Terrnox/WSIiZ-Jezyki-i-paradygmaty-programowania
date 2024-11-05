# Zadanie 4 Implementacja Złożonej Funkcji Matrycowej z Użyciem reduce()
# Napisz program, który przyjmuje listę macierzy i łączy je w jedną za pomocą operacji zdefiniowanej
# przez użytkownika (np. suma macierzy, iloczyn), korzystając z reduce(). Program powinien:
# • Dynamicznie wywoływać różne operacje (np. sumowanie, mnożenie) na macierzach.
# • Umożliwiać definiowanie niestandardowych operacji przez użytkownika.
# Wskazówka: Wykorzystaj reduce() do łączenia macierzy oraz eval() do dynamicznej definicji operacji.
import numpy as np
from functools import reduce


def calculate_matrixes(list_of_matrix, list_of_operations):
    return reduce(lambda A, i: apply_operation(A, list_of_matrix[i + 1], list_of_operations[i]),range(len(list_of_operations)), list_of_matrix[0])

def apply_operation(A, B, operation):
    if operation == '+':
        if A.shape == B.shape:
            return eval("A + B")
        else:
            raise ValueError("Rozmiary macierzy muszą być takie same do dodawania.")
    elif operation == '-':
        if A.shape == B.shape:
            return eval("A - B")
        else:
            raise ValueError("Rozmiary macierzy muszą być takie same do odejmowania.")
    elif operation == '*':
        if A.shape[1] == B.shape[0]:
            return eval("A @ B")  # Używamy operatora @ do mnożenia macierzy
        else:
            raise ValueError("Liczba kolumn w macierzy A musi być równa liczbie wierszy w macierzy B, aby wykonać mnożenie.")
    else:
        raise ValueError("Nieznana operacja. Dostępne operacje to: '+', '-', '*'")

def matrix_size_entry(m):
    flag_row = False
    flag_column = False
    while (flag_row == False or flag_column == False):
        if flag_row == False:
            row_number = int(input(f"Podaj liczbę wierszy {m+1}. macierzy:"))
            if row_number > 0:
                flag_row = True
        if flag_column == False:
            column_number = int(input(f"Podaj liczbę kolumn {m+1}. macierzy:"))
            if column_number > 0:
                flag_column = True

    return row_number, column_number

def fill_matrix(row_number, column_number):
    matrix = np.empty((row_number, column_number))
    print(f"Wypełnij zawartość macierzy o rozmiarze {row_number}x{column_number}")
    for row in range(row_number):
        for column in range(column_number):
            matrix[row][column] = float(input(f"Wypełnij komórkę wiersz:{row + 1} kolumna:{column + 1}\n"))

    return matrix

def enter_matrix_count():
    flag_matrix_count = False
    while flag_matrix_count == False:
        matrix_count = int(input("Podaj liczbę macierzy:\n"))
        if matrix_count > 1:
            flag_matrix_count = True

    return matrix_count

list_of_matrix = []
list_of_operations = []
matrix_count = enter_matrix_count()
operation_count = matrix_count - 1

for m in range(matrix_count):
    row, column = matrix_size_entry(m)
    print(f"Podaj rozmiary macierzy {m+1}:")
    matrix = fill_matrix(row, column)
    if m == operation_count:
        list_of_matrix.append(matrix)
    else:
        list_of_matrix.append(matrix)
        print("Podaj operację na macierzach (Dostępne operacje to: '+', '-', '*')")
        operation = input("Operacja:\n")
        list_of_operations.append(operation)

print(calculate_matrixes(list_of_matrix,list_of_operations))