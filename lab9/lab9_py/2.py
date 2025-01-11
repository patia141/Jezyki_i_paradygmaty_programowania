#Proceduralne
def kalkulator(a, b, operacja):
    if operacja == "+": return a + b
    elif operacja == "-": return a - b
    elif operacja == '*': return a * b
    elif operacja == '/':
        if b != 0: return a / b
        else:
            print("Nie dziel przez zero!")
            return 0
    else:
        print("Nieznana operacja")
        return 0

wynik = kalkulator(10, 0, '/')
print(f'Wynik: {wynik}')