def dodaj_macierze(A, B):
    if len(A) != len(B) or len(A[0]) != len(B[0]):
        raise ValueError("Macierze muszą mieć takie same wymiary!")
    return [[A[i][j] + B[i][j] for j in range(len(A[0]))] for i in range(len(A))]


def mnoz_macierze(A, B):
    if len(A[0]) != len(B):
        raise ValueError("Liczba kolumn pierwszej macierzy musi równać się liczbie wierszy drugiej macierzy!")
    return [[sum(A[i][k] * B[k][j] for k in range(len(B))) for j in range(len(B[0]))] for i in range(len(A))]


def transponuj_macierz(A):
    return [[A[j][i] for j in range(len(A))] for i in range(len(A[0]))]


def waliduj_i_wykonaj(operacja, zmienne):
    try:
        wynik = eval(operacja, {"__builtins__": None}, {**globals(), **zmienne})
        return wynik
    except Exception as e:
        raise ValueError(f"Nieprawidłowa operacja: {e}")


#testowanie
A = [[1, 2], [3, 4]]
B = [[5, 6], [7, 8]]
C = [[1, 2, 3], [4, 5, 6]]

zmienne = {
    "A": A,
    "B": B,
    "C": C,
    "dodaj": dodaj_macierze,
    "mnoz": mnoz_macierze,
    "transponuj": transponuj_macierz
}

while True:
    print("\nDostępne operacje:")
    print("1. Dodawanie: np. dodaj(A, B)")
    print("2. Mnożenie: np. mnoz(A, C)")
    print("3. Transpozycja: np. transponuj(A)")
    print("Wpisz 'exit', aby zakończyć.")

    operacja = input("\nWprowadź operację na macierzach: ")
    if operacja.lower() == "exit":
        break

    try:
        wynik = waliduj_i_wykonaj(operacja, zmienne)
        print("Wynik operacji:")
        for wiersz in wynik:
            print(wiersz)
    except ValueError as e:
        print(e)
