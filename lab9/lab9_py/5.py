#Obiektowe
#Stwórz klasę Prostokat z polami długość i szerokość. Dodaj metody do obliczania pola i obwodu.

class Prostokat:
    def __init__(self, dlugosc, szerokosc):
        self.dlugosc = dlugosc
        self.szerokosc = szerokosc

    def obliczPole(self):
        if self.dlugosc > 0 and self.szerokosc > 0:
            return self.dlugosc * self.szerokosc
        else:
            print("To nie jest prostokąt")
            return 0

    def obliczObwod(self):
        if self.dlugosc > 0 and self.szerokosc > 0:
            return 2 * (self.dlugosc + self.szerokosc)
        else:
            print("To nie jest prostokąt")
            return 0

mojProstokat = Prostokat(0,5)
pole = mojProstokat.obliczPole()
obwod = mojProstokat.obliczObwod()
print("Pole: ", pole)
print("Obwod: ", obwod)