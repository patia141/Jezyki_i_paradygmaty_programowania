#Funkcyjne
#Zaimplementuj funkcję, która sprawdza, czy podana lista liczb jest palindromem, używając jedynie
#funkcji wbudowanych.

def czyPalindrom(liczby):
    return liczby == liczby[::-1]

lista1 = [1,2,3,2,1]
lista2 = [1,2,3,4,5]
print(f'Lista {lista1} - jest palindromem? {czyPalindrom(lista1)}')
print(f'Lista {lista2} - jest palindromem? {czyPalindrom(lista2)}')