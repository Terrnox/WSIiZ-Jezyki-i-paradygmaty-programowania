# EmployeesManager – klasa która jest odpowiedzialna za zarządzanie listą pracowników. Posiada
# nastepujące funkcjonalności:
# • dodanie nowego pracownika do listy,
# • wyświetlenie listy wszystkich istniejących pracowników,
# • usunięcie pracowników w określonym przedziale wiekowym,
# • wyszukanie pracownika według jego imienia i nazwiska,
# • aktualizacja wynagrodzenia pracownika według jego imienia i nazwiska.
from Lab3.Employee import Employee

class EmployeesManager(Employee):
    def __init__(self, name, age, salary):
        super().__init__(name, age, salary)

    def add_employee(self, employees, employee):
        employees.append(employee)

    def show_employees(self, employees):
        print("Lista pracowników:")
        for employee in employees:
            employee.show_info()

    def delete_employees(self, min_age, max_age, employees):
        indexes_employees_to_delete = []
        for emp in range(len(employees)):
            if employees[emp].age >= min_age and employees[emp].age <= max_age:
                indexes_employees_to_delete.append(emp)

        indexes_employees_to_delete.sort(reverse=True)
        for ind in indexes_employees_to_delete:
            employees.pop(ind)

        return employees

    def find_employee(self, name, employees):
        indexes_searched_employees = []
        for i in range(len(employees)):
            if name == employees[i].name:
                indexes_searched_employees.append(i)

        return indexes_searched_employees

    def update_salary(self,name, employees, new_salary):
        indexes_searched_employees = self.find_employee(name, employees)
        if indexes_searched_employees != []:
            for i in range(len(indexes_searched_employees)):
                employees[indexes_searched_employees[i]].salary = new_salary

