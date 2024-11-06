# Zadanie 1. Z wykorzystaniem OOP zaproponuj implementację Employees System Project.
# Employees System Project ma być prostym projektem oparty na języku Python, który prezentuje
# wykorzystanie zasad programowania obiektowego (OOP). Obejmować ma trzy główne klasy: Employee,
# EmployeesManager i FrontendManager. System ma za zadanie zarządzać danymi i interakcją
# pracowników przy użyciu koncepcji OOP. Employees System Project powinien objemować trzy
# podstawowe klasy, z których każda służy odrębnemu celowi: Employee, EmployeesManager, FrontendManager
# Zadanie 2. W oparciu o system z zadania 1 zmodyfikuj/rozszerz go o poniższe funkcjonalności:
# • logowanie do systemu – poprzez konto admin, hasło admin,
# • dane o pracownikach mają być przechowywane w plikach, format pliku dowolny txt, json,
# zewnętrzna baza,
# • dane maja być zapisywane do pliku,
# • wyświetlane dane mają być odczytywane z pliku,
# • każde zmiany/modyfikacje mają być aktualizowane w plikach
# • walidację danych.
from Lab3.Employee import Employee
from Lab3.EmployeesManager import EmployeesManager
from Lab3.FrontendManager import FrontendManager

if __name__ == '__main__':
    employees = []
    emp1 = Employee("Wiktor Nowak",21, 2000)
    emp2 = Employee("Jan Kowalski", 23, 2500)
    emp_man1 = EmployeesManager("Tomasz Jop", 35, 5000)
    employees.append(emp1)
    employees.append(emp2)
    employees.append(emp_man1)
    emp_man1.find_employee("Wiktor Nowak", employees)
    # emp_man1.delete_employees(20,24, employees)
    emp_man1.update_salary("Jan Kowalski", employees, 3000)
    emp_front1 = FrontendManager("Tomasz Nowak", 50, 10000)
    for emp in employees:
        emp.show_info()

    emp_front1.show_employees(employees)
