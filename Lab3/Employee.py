# 1. Employee - reprezentuje indywidualnego pracownika z następującymi atrybutami:
# • name: Imię i nazwisko pracownika.
# • age: Wiek pracownika.
# • salary: Wynagrodzenie pracownika.
# Klasa ma udostępniać metody pozwalające na reprezentację informacji o pracownikach, które zostały
# wprowadzone jako dane wejściowe.

class Employee:
    def __init__(self, name, age, salary):
        self.name = name
        self.age = age
        self.salary = salary

    def show_info(self):
        print(f"Imię i nazwisko: {self.name}\tWiek: {self.age}\tWynagrodzenie: {self.salary}")