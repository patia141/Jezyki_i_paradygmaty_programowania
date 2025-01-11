#Funkcyjne
#Napisz funkcję rekurencyjną, która oblicza n-ty wyraz ciągu Fibonacciego.

def Fibonacci(n):
    if n >= 0:
        if n == 0: return 0
        elif n == 1 or n == 2: return 1
        else: return Fibonacci(n-1) + Fibonacci(n-2)
    else:
        print("Podaj liczbę >= 0")
        return None

a = 8
print(f'Fibonacci({a}): {Fibonacci(a)}')