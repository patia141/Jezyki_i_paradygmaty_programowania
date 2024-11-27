class Plecak:
    def __init__(self, pojemnosc, przedmioty):
        self.pojemnosc = pojemnosc
        self.przedmioty = przedmioty

    def proceduralnie(self):
        n = len(self.przedmioty)
        mwart = [[0 for _ in range(self.pojemnosc + 1)] for _ in range(n + 1)]

        for i in range(1, n + 1):
            wartosc, waga = self.przedmioty[i-1]
            for j in range(self.pojemnosc + 1):
                if waga <= j:
                    mwart[i][j] = max(mwart[i-1][j], mwart[i-1][j-waga]+wartosc)
                else:
                    mwart[i][j] = mwart[i-1][j]

        maks_wartosc = mwart[n][self.pojemnosc]
        w = self.pojemnosc
        wybrane_przedmioty = []

        for i in range(n, 0, -1):
            if mwart[i][w] != mwart[i-1][w]:
                wybrane_przedmioty.append(self.przedmioty[i-1])
                w -= self.przedmioty[i-1][1]

        return maks_wartosc, wybrane_przedmioty


def funkcyjnie(przedmioty, pojemnosc):
    if not przedmioty or pojemnosc == 0:
        return 0, []

    wartosc, waga = przedmioty[0]
    reszta_przedmiotow = przedmioty[1:]

    if waga > pojemnosc:
        return funkcyjnie(reszta_przedmiotow, pojemnosc)
    else:
        bez_przedmiotu, lista_bez = funkcyjnie(reszta_przedmiotow, pojemnosc)
        z_przedmiotem, lista_z = funkcyjnie(reszta_przedmiotow, pojemnosc - waga)
        z_przedmiotem += wartosc

        if z_przedmiotem > bez_przedmiotu:
            return z_przedmiotem, [(wartosc, waga)] + lista_z
        else:
            return bez_przedmiotu, lista_bez

#testowanie
przedmioty = [(60,10), (100,20), (123,30)]
pojemnosc = 50

plecak = Plecak(pojemnosc, przedmioty)
#maks_wartosc, wybrane_przedmioty = plecak.proceduralnie()
maks_wartosc, wybrane_przedmioty = funkcyjnie(przedmioty, pojemnosc)
print(f"Maksymalna wartość: {maks_wartosc} \nWybrane przedmioty: {wybrane_przedmioty}")
