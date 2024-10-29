# Zadanie 2. Wyznaczanie Najkrótszej Ścieżki (Programowanie Funkcyjne)
# Stwórz program obliczający najkrótszą ścieżkę w grafie nieważonym przy użyciu algorytmu BFS
# (Breadth-First Search). Implementacja powinna być zrealizowana przy użyciu programowania
# funkcyjnego z naciskiem na niemutowalne struktury danych, funkcje lambda, i mapowanie.
# Wymagania:
# • Napisz funkcję BFS przy użyciu funkcyjnego podejścia z rekurencją lub funkcjami wyższego
# rzędu.
# • Zaimplementuj graf jako słownik (dict), gdzie klucz to wierzchołek, a wartość to lista sąsiednich
# wierzchołków.
# • Funkcja powinna przyjmować graf oraz wierzchołek początkowy i końcowy, zwracając
# najkrótszą ścieżkę jako listę wierzchołków

def bfs(graph, start, end):
    def bfs_queue_visted_checker(queue, visited):
        if not queue:
            return None

        current_node, path = queue[0]

        if current_node == end:
            return path

        neighbors = graf.get(current_node, [])
        new_paths = [(n, path + [n]) for n in neighbors if n not in visited]

        return bfs_queue_visted_checker(queue[1:] + new_paths, visited | {current_node})

    initial_queue = [(start, [start])]
    visited_set = set()
    visited_set.add(start)

    return bfs_queue_visted_checker(initial_queue, visited_set)

graf = {
    '1': ['2', '3', '5'],
    '2': ['1', '4'],
    '3': ['1', '5', '6'],
    '4': ['2', '7'],
    '5': ['1', '3', '7'],
    '6': ['3', '8'],
    '7': ['4', '5', '8'],
    '8': ['6', '7']
}

print(bfs(graf, '1', '7'))