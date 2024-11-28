def analiza_niejednorodnych_danych(dane):
    #liczby
    liczby = list(filter(lambda x: isinstance(x, (int, float)), dane))
    max_liczba = max(liczby) if liczby else None

    napisy = list(filter(lambda x: isinstance(x, str), dane))
    max_napisy = max(napisy, key=len) if napisy else None

    krotki = list(filter(lambda x: isinstance(x, tuple), dane))
    max_krotka = max(krotki, key=len) if krotki else None

    return max_liczba, max_napisy, max_krotka


#testowanie
dane = [42, "kotek", (1,2,3), {"aa": "bb"}, 5.55, "kawa", (9,0), [7,21]]
Mliczba, Mnapis, Mkrotka = analiza_niejednorodnych_danych(dane)
print(f"Największa liczba: {Mliczba}")
print(f"Najdłuższy napis: {Mnapis}")
print(f"Najdłuższa krotka: {Mkrotka}")