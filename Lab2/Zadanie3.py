# Zadanie 3. Dynamiczne Wyznaczanie Ekstremów w Niejednorodnych Danych
# Napisz funkcję, która przyjmuje listę niejednorodnych danych (np. liczby, napisy, krotki, listy, słowniki) i
# wykonuje dynamiczną analizę danych, aby:
# • Zwrócić największą liczbę (lub wartość numeryczną) w danych.
# • Zwrócić najdłuższy napis.
# • Zwrócić krotkę o największej liczbie elementów.
# Wskazówka: Użyj filter() do selekcji odpowiednich typów danych oraz map() do przekształceń na
# elementach.
def filter_extreme_data(data):
    numbers = list(filter(lambda x: isinstance(x, (int, float)), data))
    highest_number = [x for x in numbers if x == max(numbers)] if numbers else []

    strings = list(filter(lambda x: isinstance(x, str), data))
    max_length = max(map(len, strings), default=0)  # Największa długość napisu
    longest_strings = [x for x in strings if len(x) == max_length] if strings else []

    # Filtracja danych: krotki
    tuples = list(filter(lambda x: isinstance(x, tuple), data))
    max_length_tuple = max(map(len, tuples), default=0)
    biggest_tuples = [x for x in tuples if len(x) == max_length_tuple] if tuples else []

    return highest_number, longest_strings, biggest_tuples


# Przykładowe dane i wywołanie funkcji
data = [23, "apple", (1, 2, 3), 12, "banana", (4, 5, 6, 7), "kiwi", 42.5, (1, 2), 0 , "Panama"]

highest_number, longest_string, biggest_tuple = filter_extreme_data(data)
print(f"Najwyższa liczba: {highest_number}\nNajdłuższy napis: {longest_string}\nNajwiększa krotka: {biggest_tuple}")