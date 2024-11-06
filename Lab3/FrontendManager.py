# 3. FrontendManager - klasa zapewnia interfejs użytkownika do interakcji z EmployeesManager.
# Użytkownicy mogą wykonywać akcje takie jak:
# • Dodawanie nowych pracowników.
# • Wyświetlenie listy istniejących pracowników.
# • Usuwanie pracowników na podstawie przedziału wiekowego.
# • Aktualizacja wynagrodzeń pracowników według nazwiska.
from Lab3.EmployeesManager import EmployeesManager

class FrontendManager(EmployeesManager):
    def __init__(self, name, age, salary):
        super().__init__(name, age, salary)

    def add_employee(self, employees, employee):
        if isinstance(employee, EmployeesManager):
            employees.append(employee)

    def show_employees(self, employees):
        print("Lista managerów:")
        for employee in employees:
            if isinstance(employee, EmployeesManager):
                employee.show_info()

    def delete_employees(self, min_age, max_age, employees):
        indexes_employees_to_delete = []
        for emp in range(len(employees)):
            if employees[emp].age >= min_age and employees[emp].age <= max_age and isinstance(employees[emp], EmployeesManager):
                indexes_employees_to_delete.append(emp)

        indexes_employees_to_delete.sort(reverse=True)
        for ind in indexes_employees_to_delete:
            employees.pop(ind)

        return employees

    def find_employee(self, name, employees):
        indexes_searched_employees = []
        for i in range(len(employees)):
            if name == employees[i].name and isinstance(employees[i], EmployeesManager):
                indexes_searched_employees.append(i)

        return indexes_searched_employees

    def update_salary(self,name, employees, new_salary):
        indexes_searched_employees = self.find_employee(name, employees)
        if indexes_searched_employees != []:
            for i in range(len(indexes_searched_employees)):
                employees[indexes_searched_employees[i]].salary = new_salary