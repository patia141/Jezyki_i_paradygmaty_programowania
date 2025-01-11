#Funkcyjne
#Używając funkcji wbudowanych (np. map, filter, reduce), znajdź wszystkie liczby parzyste w liście liczb
#oraz ich sumę.

def czyParzyste(liczby):
    parzyste = list(filter(lambda x: x % 2 == 0, liczby))
    suma = sum(parzyste)
    return parzyste, suma

Liczby = [0,1,7,4,3,2,11,6,12]
Parzyste, Suma = czyParzyste(Liczby)
print(f'Liczby parzyste: {Parzyste}\nSuma: {Suma}')