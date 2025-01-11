#Obiektowe
#Zaimplementuj klasę Samochod, która dziedziczy po klasie Pojazd, i dodaj metodę jazda.

class Pojazd:
    def __init__(self, marka, rocznik):
        self.marka = marka
        self.rocznik = rocznik

class Samochod(Pojazd):
    def jazda(self):
        print(f"Jazda {self.marka}!")

mojeAutko = Samochod("CITROEN", 2015)
mojeAutko.jazda()