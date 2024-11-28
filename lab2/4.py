from functools import reduce
import numpy as np


def laczenie_macierzy(macierze, operacja):
    if isinstance(operacja, str):
        operacja_funkcja = eval(f"lambda x, y: {operacja}")
    elif callable(operacja):
        operacja_funkcja = operacja
    else:
        raise ValueError("Operacja musi być stringiem lub funkcją.")

    wynik = reduce(operacja_funkcja, macierze)
    return wynik


#testowanie
macierze = [
    np.array([[1, 2], [3, 4]]),
    np.array([[5, 6], [7, 8]]),
    np.array([[9, 10], [11, 12]])
]

operacja_sumowania = "x + y"
wynik_sumowania = laczenie_macierzy(macierze, operacja_sumowania)
print("Wynik sumowania macierzy:\n", wynik_sumowania)

operacja_mnozenia = "np.dot(x, y)"
wynik_mnozenia = laczenie_macierzy(macierze, operacja_mnozenia)
print("Wynik mnożenia macierzy:\n", wynik_mnozenia)

#niestandardowa operacja użytkownika
def operacja_max(x, y):
    return np.maximum(x, y)

wynik_max = laczenie_macierzy(macierze, operacja_max)
print("Wynik niestandardowej operacji (maksimum):\n", wynik_max)
