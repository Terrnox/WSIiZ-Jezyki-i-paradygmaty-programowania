# Problem Podziału Paczek (Prograowanie Proceduralne)
# Mamy listę paczek o różnych wagach oraz maksymalną wagę, jaką może unieść kurier w jednym kursie.
# Twoim zadaniem jest podzielić paczki na jak najmniejszą liczbę kursów, aby każda waga nie przekraczała
# maksymalnej dozwolonej wagi. Program powinien korzystać z algorytmu zachłannego do optymalizacji
# podziału paczek.
# Wymagania:
# • Napisz funkcję, która przyjmuje listę wag paczek i maksymalną wagę.
# • Użyj pętli for i instrukcji warunkowych if, else do iteracyjnego podziału paczek.
# • Program powinien zwracać minimalną liczbę kursów oraz listę paczek w każdym kursie.

def podzielPaczki(wagi, max_waga):
    for waga in wagi:
        if waga > max_waga:
            raise ValueError(f"Paczka o wadze {waga} przekracza dozwolną wagę kursu {max_waga} kg")

    wagi_sorted = sorted(wagi, reverse=True)

    kursy = []

    for waga in wagi_sorted:
        dodano = False
        for kurs in kursy:
            if sum(kurs) + waga <= max_waga:
                kurs.append(waga)
                dodano = True
                break
        if not dodano:
            kursy.append([waga])

    return len(kursy), kursy

max_waga = 25

lista_paczek = [20, 5, 8, 15, 10, 10, 7]

liczba_kursow, kursy = podzielPaczki(lista_paczek, max_waga)

for i, kurs in enumerate(kursy, 1):
    print(f"Kurs {i}: {kurs} \t suma wagi: {sum(kurs)} kg")