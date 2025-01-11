#Proceduralne
#Napisz program, który oblicza sumę cyfr liczby podanej przez użytkownika.
def obliczSume (liczba):
    suma = 0
    for x in liczba:
        suma += int(x)
    return suma


a = "12345"
print(f"Wynik: {obliczSume(a)}")