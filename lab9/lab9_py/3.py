#Proceduralne
#Utwórz program do rozwiązania równania kwadratowego przy pomocy formuły kwadratowej.
def rozwiazRownanie (a,b,c):
    if a != 0 and b != 0 and c != 0:
        delta = b**2 - 4*a*c

        if delta > 0:
            x1 = (-b + delta**(1/2))/(2*a)
            x2 = (-b - delta**(1/2))/(2*a)
            return x1,x2
        elif delta == 0:
            x0 = -b/(2*a)
            return x0
        else:
            return "Delta mniejsza od 0 - brak rozwiązań"
    else:
        print("Podane równanie nie jest równaniem kwadratowym")
        return 0

wynik = rozwiazRownanie(1,-2,3)
print(wynik)