# Zadanie 3 Optymalizacja Rozmieszczenia Zadań (Proceduralne i Funkcyjne)
# Masz N zadań do wykonania, każde zadanie ma przypisany czas wykonania oraz nagrodę za jego
# ukończenie. Twoim celem jest zaplanowanie kolejności wykonywania zadań, aby zminimalizować
# całkowity czas oczekiwania na ich wykonanie i zmaksymalizować zysk. Zaimplementuj rozwiązanie przy
# użyciu programowania proceduralnego oraz funkcyjnego.
# Wymagania:
# • Proceduralnie: Stwórz listę zadań i użyj pętli do sortowania i optymalizacji ich kolejności, aby
# zminimalizować całkowity czas oczekiwania.
# • Funkcyjnie: Użyj funkcji wyższego rzędu (sorted, map, reduce) do manipulacji listą zadań, aby
# osiągnąć optymalne rozwiązanie.
# • Program powinien zwrócić optymalną kolejność zadań oraz całkowity czas oczekiwania.
from functools import reduce

def plan_tasks_functional(tasks):
    sorted_tasks = sorted(tasks.items(), key=lambda item: item[1][0])

    planned_tasks = list(map(lambda item: item[0], sorted_tasks))
    wait_time = reduce(lambda total, item: total + item[1][0], sorted_tasks, 0)

    return planned_tasks, wait_time


def plan_tasks_procedural(tasks):
    task_list = [(name, time, reward) for name, (time, reward) in tasks.items()]

    task_list.sort(key=lambda x: x[1])

    planned_tasks = []
    total_wait_time = 0

    for task in task_list:
        planned_tasks.append(task[0])
        total_wait_time += task[1]

    return planned_tasks, total_wait_time


tasks = {"Zadanie 1":[10,10],
         "Zadanie 2":[5,7],
         "Zadanie 3":[7,15],
         "Zadanie 4":[25,8],
         "Zadanie 5":[100,50],
         "Zadanie 6":[30,20],}

planned_tasks_functional, wait_time_functional = plan_tasks_functional(tasks)
print("Optymalna kolejność zadań:", planned_tasks_functional)
print("Całkowity czas oczekiwania:", wait_time_functional)

planned_tasks_procedural, wait_time_procedural = plan_tasks_procedural(tasks)
print("Optymalna kolejność zadań:", planned_tasks_procedural)
print("Całkowity czas oczekiwania:", wait_time_procedural)