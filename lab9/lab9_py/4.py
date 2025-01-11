#Proceduralne
#Napisz skrypt do analizy danych z pliku CSV, który oblicza średnią dla wybranej kolumny.
#PRZECINKI w pliku zamiast średników!!!
import csv

def oblicz_srednia(nazwa_pliku, nazwa_kolumny):
    with open(nazwa_pliku, 'r', encoding='utf-8') as plik:
        dane = csv.DictReader(plik)
        wartosci = [float(wiersz[nazwa_kolumny]) for wiersz in dane if wiersz[nazwa_kolumny]]
    return sum(wartosci) / len(wartosci) if wartosci else None


plik = "dane.csv"
kolumna = "punkty"
srednia = oblicz_srednia(plik, kolumna)
print(f"Średnia dla kolumny '{kolumna}' wynosi: {srednia:.2f}" if srednia else "Brak danych w kolumnie.")
#.2f - po przecinku tylko 2 cyfry sie pokazują
