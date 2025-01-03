class Employee:
    def __init__(self, name, age, salary):
        self.name = name
        self.age = age
        self.salary = salary

    def employee_info(self):
        print(f'Imię i nazwisko: {self.name}\nWiek: {self.age}\nWynagrodzenie: {self.salary}')


class EmployeesManager:
    def __init__(self):
        self.employees = []

    def add_employee(self, employee):
        self.employees.append(employee)
        print(f"Pracownik {employee.name} został dodany do listy.")

    def list_employees(self):
        if not self.employees:
            print("Brak pracowników")
        else:
            print("Lista pracowników:")
            for employee in self.employees:
                print(employee.name)

    def remove_employees_by_age(self, min_age, max_age):
        self.employees = [
            employee for employee in self.employees
            if not (min_age <= employee.age <= max_age)
        ]

    def find_employee_by_name(self, name):
        for employee in self.employees:
            if employee.name == name:
                return employee
            else:
                print(f"Nie znaleziono pracownika {name}")
                return None

    def update_salary(self, name, new_salary):
        updated = False
        for employee in self.employees:
            if employee.name == name:
                employee.salary = new_salary
                updated = True
        if updated:
            print(f"Wynagrodzenie pracownika {name} zostało zaktualizowane na {new_salary}")
        else:
            print(f"Nie znaleziono pracownika {name}")


class FrontendManager:
    def __init__(self):
        self.manager = EmployeesManager()

    def display_menu(self):
        while True:
            print("\nMenu")
            print("1. Dodaj pracownika")
            print("2. Wyświetl listę pracowników")
            print("3. Usuń pracownika na podstawie przedziału wiekowego")
            print("4. Zaktualizuj wynagrodzenie pracownika")
            print("5. Wyjdź")
            choice = input("Wybierz opcję: ")

            if choice == "1":
                self.add_employee_interface()
            elif choice == "2":
                self.manager.list_employees()
            elif choice == "3":
                self.remove_employee_interface()
            elif choice == "4":
                self.update_salaey_interface()
            elif choice == "5":
                print("Koniec programu")
                break
            else:
                print("Nieprawidłowa opcja, spróbuj ponownie")

    def add_employee_interface(self):
        name = input("Podaj imię i nazwisko: ")
        age = int(input("Podaj wiek: "))
        salary = float(input("Podaj wynagrodzenie: "))
        employee = Employee(name, age, salary)
        self.manager.add_employee(employee)

    def remove_employees_interface(self):
        min_age = int(input("Podaj minimalny wiek: "))
        max_age = int(input("Podaj maksymalny wiek: "))
        self.manager.remove_employee_by_age(min_age, max_age)

    def update_salaey_interface(self):
        employee = input("Podaj pracownika: ")
        new_salary = float(input("Podaj nowe wynagrodzenie: "))
        self.manager.update_salary(employee, new_salary)


# Uruchomienie systemu
if __name__ == "__main__":
    frontend = FrontendManager()
    frontend.display_menu()
