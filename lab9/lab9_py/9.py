#Funkcyjne
#Napisz program obliczający permutacje listy liczb za pomocą funkcji rekurencyjnej.

def permuteacje(lista):
    if len(lista) == 0: return [[]]

    wynik = [[]]
    for i in range(len(lista)):
        element = lista[i]
        pozostale = lista[:i] + lista[i+1:]
        for p in permuteacje(pozostale):
            wynik.append([element] + p)
    return wynik

liczby = [1,2,3]
print(f'Permutacje liczb: {permuteacje(liczby)}')