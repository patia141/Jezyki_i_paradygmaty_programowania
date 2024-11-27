from functools import reduce


class Zadanie:
    def __init__(self, c_rozpoczecia, c_zakonczenia, nagroda):
        self.c_rozpoczecia = c_rozpoczecia
        self.c_zakonczenia = c_zakonczenia
        self.nagroda = nagroda

    def __repr__(self):
        return f"Zadanie({self.c_rozpoczecia}, {self.c_zakonczenia}, {self.nagroda})"

class Harmonogram:
    def __init__(self, zadania):
        self.zadania = zadania

    def proceduralnie(self):
        zad_posortowane = sorted(self.zadania, key=lambda x: x.c_zakonczenia)
        optymalny_har = []
        ostatnie_zakonczone = 0
        maks_nagroda = 0

        for zadanie in zad_posortowane:
            if zadanie.c_rozpoczecia >= ostatnie_zakonczone:
                optymalny_har.append(zadanie)
                ostatnie_zakonczone = zadanie.c_zakonczenia
                maks_nagroda += zadanie.nagroda

        return maks_nagroda, optymalny_har


def funkcyjnie(zadania):
    zad_posortowane = sorted(zadania, key=lambda x: x.c_zakonczenia)

    def wybierz_zad(acc, zadanie):
        ostatnie_zad = acc[-1] if acc else None
        if not ostatnie_zad or zadanie.c_rozpoczecia >= ostatnie_zad.c_zakonczenia:
            return acc + [zadanie]
        return acc

    optymalny_har = reduce(wybierz_zad, zad_posortowane, [])
    maks_nagroda = sum(zadanie.nagroda for zadanie in optymalny_har)

    return maks_nagroda, optymalny_har

#testowanie
zadania = [
    Zadanie(1, 3, 50),
    Zadanie(3, 5, 20),
    Zadanie(0, 6, 100),
    Zadanie(5, 7, 30),
    Zadanie(5, 9, 60),
    Zadanie(7, 8, 25)
]

harmonogram = Harmonogram(zadania)
#maks_nagroda, optymalny_harmonogram = harmonogram.proceduralnie()
maks_nagroda, optymalny_harmonogram = funkcyjnie(zadania)
print(f"Maksymalna nagroda: {maks_nagroda}")
print(f"Wybrane zadania: {optymalny_harmonogram}")