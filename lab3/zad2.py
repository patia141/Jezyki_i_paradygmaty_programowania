import json
from zad1 import Employee, EmployeesManager

class AdvancedEmployeesManager(EmployeesManager):
    def __init__(self, data_file="employees.json"):
        super().__init__()
        self.data_file = data_file
        self.load_data()

    def load_data(self):
        try:
            with open(self.data_file, "r") as file:
                data = json.load(file)
                for item in data:
                    self.employees.append(Employee(item["name"], item["age"], item["salary"]))
        except FileNotFoundError:
            print("Brak pliku danych. Tworzenie nowego pliku...")
            self.save_data()
        except json.JSONDecodeError:
            print("Błąd w formacie pliku, dane nie zostały wczytane")

    def save_data(self):
        with open(self.data_file, "w") as file:
            data = [
                {"name": emp.name, "age": emp.age, "salary": emp.salary}
                for emp in self.employees
            ]
            json.dump(data, file, indent=4)

    def add_employee(self, name, age, salary):
        try:
            age = int(age)
            salary = float(salary)
            if age <= 0 or salary <= 0:
                raise ValueError("Wiek i wynagrodzenie muszą być dodatnie")
            super().add_employee(Employee(name, age, salary))
            self.save_data()
        except ValueError as e:
            print(f"Błąd walidacji danych: {e}")

    def remove_employees_by_age(self, min_age, max_age):
        super().remove_employees_by_age(min_age, max_age)
        self.save_data()

    def update_salary(self, name, new_salary):
        try:
            new_salary = float(new_salary)
            if new_salary <= 0:
                raise ValueError("Wynagrodzenie musi być dodatnie")
            super().update_salary(name, new_salary)
            self.save_data()
        except ValueError as e:
            print(f"Błąd walidacji danych: {e}")


def login():
    print("=== Logowanie do systemu ===")
    username = input("Login: ")
    password = input("Hasło: ")
    if username == "admin" and password == "admin":
        print("Logowanie udane!\n")
        return True
    else:
        print("Nieprawidłowy login lub hasło\n")
        return False


if __name__ == "__main__":
    if login():
        manager = AdvancedEmployeesManager()
        while True:
            print("\n1. Dodaj pracownika")
            print("2. Wyświetl listę pracowników")
            print("3. Usuń pracowników w przedziale wiekowym")
            print("4. Zaktualizuj wynagrodzenie pracownika")
            print("5. Wyjdź")

            choice = input("Wybierz opcję: ")

            if choice == "1":
                name = input("Imię i nazwisko: ")
                age = input("Wiek: ")
                salary = input("Wynagrodzenie: ")
                manager.add_employee(name, age, salary)
            elif choice == "2":
                manager.list_employees()
            elif choice == "3":
                min_age = int(input("Minimalny wiek: "))
                max_age = int(input("Maksymalny wiek: "))
                manager.remove_employees_by_age(min_age, max_age)
            elif choice == "4":
                name = input("Imię i nazwisko pracownika: ")
                new_salary = input("Nowe wynagrodzenie: ")
                manager.update_salary(name, new_salary)
            elif choice == "5":
                print("Koniec programu")
                break
            else:
                print("Nieprawidłowa opcja, spróbuj ponownie")
