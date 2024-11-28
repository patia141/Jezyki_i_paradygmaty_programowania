def generuj_i_wykonaj_kod(szablon, dane):
    try:
        kod = szablon.format(**dane)
        print("Generowany kod:\n", kod)

        skompilowany_kod = compile(kod, "<string>", "exec")

        lokalne = {}
        exec(skompilowany_kod, {}, lokalne)

        if "funkcja" in lokalne:
            wynik = lokalne["funkcja"](dane.get("argument", 0))
            return wynik
        else:
            return "Kod nie zawiera funkcji `funkcja`."
    except Exception as e:
        return f"Błąd w generowanym kodzie: {e}"


#przykładowy szablon kodu
szablon = """
def funkcja(x):
    return x + {wartosc}
"""

dane = {
    "wartosc": 10,
    "argument": 5
}

wynik = generuj_i_wykonaj_kod(szablon, dane)
print("Wynik wykonania funkcji:", wynik)
