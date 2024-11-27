class Zadanie:
    def __init__(self, id, czas_wykonania, nagroda):
        self.id = id
        self.czas_wykonania = czas_wykonania
        self.nagroda = nagroda

zadania = [
    Zadanie(1, 3, 100),
    Zadanie(2, 1, 200),
    Zadanie(3, 2, 150),
]

# proceduralnie
def optymalizacja_proceduralna(zadania):
    zadania.sort(key=lambda x: x.czas_wykonania)

    czas_calk = 0
    czas_obecny = 0
    for zadanie in zadania:
        czas_calk += czas_obecny
        czas_obecny += zadanie.czas_wykonania

    print("Optymalizacja proceduralnie:")
    for zadanie in zadania:
        print(f"Zadanie {zadanie.id} (czas: {zadanie.czas_wykonania}, nagroda: {zadanie.nagroda})")
    print("Całkowity czas oczekiwania:", czas_calk)


# funkcyjnie
from functools import reduce

def optymalizacja_funkcyjna(zadania):
    posortowane = sorted(zadania, key=lambda x: x.czas_wykonania)

    def czas_lacznie(akumulacja, zadanie):
        akumulacja['czas_oczekiwania'] += akumulacja['czas_w_trakcie']
        akumulacja['czas_w_trakcie'] += zadanie.czas_wykonania
        return akumulacja
    
    wynik = reduce(czas_lacznie, posortowane, {'czas_oczekiwania': 0, 'czas_w_trakcie': 0})

    print("Optymalizacja funkcyjnie:")
    for zadanie in posortowane:
        print(f"Zadanie {zadanie.id} (czas: {zadanie.czas_wykonania}, nagroda: {zadanie.nagroda})")
    print("Całkowity czas oczekiwania:", wynik['czas_oczekiwania'])


#optymalizacja_proceduralna(zadania)
optymalizacja_funkcyjna(zadania)
