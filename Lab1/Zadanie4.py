# Zadanie 4: Problem Optymalizacji Zasobów – Algorytm Plecakowy (Proceduralne i Funkcyjne)
# Masz ograniczoną pojemność plecaka oraz listę przedmiotów, z których każdy ma określoną wagę i
# wartość. Celem jest wybranie przedmiotów tak, aby zmaksymalizować łączną wartość w plecaku, nie
# przekraczając jego pojemności. Problem ten wymaga implementacji algorytmu plecakowego (knapsack
# problem) przy użyciu zarówno podejścia proceduralnego, jak i funkcyjnego.
# Wymagania:
# • Proceduralnie: Użyj podejścia dynamicznego (programowanie dynamiczne) do rozwiązania
# problemu.
# • Funkcyjnie: Zaimplementuj algorytm w stylu funkcyjnym z naciskiem na funkcje rekurencyjne
# oraz mapowanie.
# • Program powinien zwracać maksymalną wartość oraz listę przedmiotów, które powinny zostać
# wybrane do plecaka.

from functools import lru_cache

def knapsack_packer_procedural(items, capacity):
    multiplier = 10  # Wartość, która konwertuje 0.5, 0.4 itp. na wartości całkowite
    capacity = int(capacity * multiplier)
    items_list = [(name, (int(weight * multiplier), value)) for name, (weight, value) in items.items()]

    n = len(items_list)
    dp = [[0] * (capacity + 1) for _ in range(n + 1)]

    for i in range(1, n + 1):
        item_name, (weight, value) = items_list[i - 1]
        for w in range(capacity + 1):
            if weight <= w:
                dp[i][w] = max(dp[i - 1][w], dp[i - 1][w - weight] + value)
            else:
                dp[i][w] = dp[i - 1][w]

    # Odczyt maksymalnej wartości i wybranych przedmiotów
    max_value = dp[n][capacity]
    selected_items = []
    w = capacity

    for i in range(n, 0, -1):
        item_name, (weight, value) = items_list[i - 1]
        if dp[i][w] != dp[i - 1][w]:
            selected_items.append(item_name)
            w -= weight

    selected_items.reverse()
    return max_value, selected_items

def knapsack_packer_functional(items, capacity):
    multiplier = 10  # Dla zaokrąglenia wag na wartości całkowite
    capacity = int(capacity * multiplier)

    items_list = [(name, int(weight * multiplier), value) for name, (weight, value) in items.items()]

    @lru_cache(None)
    def knapsack(capacity, index):
        # Warunek końcowy rekurencji
        if capacity <= 0 or index >= len(items_list):
            return 0, []

        name, weight, value = items_list[index]

        if weight > capacity:
            return knapsack(capacity, index + 1)

        value_with, items_with = knapsack(capacity - weight, index + 1)
        value_with += value
        items_with = [name] + items_with

        value_without, items_without = knapsack(capacity, index + 1)

        if value_with > value_without:
            return value_with, items_with
        else:
            return value_without, items_without

    max_value, selected_items = knapsack(capacity, 0)
    return max_value, selected_items

items_to_pack = {
    "Zbroja płytowa": [10, 100],
    "Miecz": [5, 75],
    "Książka": [0.5, 60],
    "Pochodnia": [0.4, 1],
    "Monety": [10, 110],
    "Obraz": [3, 10]
}

capacity = 7.5
max_value, selected_items = knapsack_packer_procedural(items_to_pack, capacity)
print(f'Maksymalna wartość: {max_value}, Wybrane przedmioty: {selected_items}')

capacity = 7.5
max_value, selected_items = knapsack_packer_functional(items_to_pack, capacity)
print(f'Maksymalna wartość: {max_value}, Wybrane przedmioty: {selected_items}')

