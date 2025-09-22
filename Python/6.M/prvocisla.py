def GenPrimes(max):
    primes = []
    for i in range(2,max):
        is_prime = True
        for prime in primes:
            if i % prime == 0:
                is_prime = False
                break
        if is_prime:
            primes.append(i)
    return primes
        
def IsPrime(cislo):
    if cislo == 1:
        return True
    primes = GenPrimes(int(cislo**0.5)+1)

    for i in range(len(primes)):
        if cislo % primes[i] == 0:
            return False
    return True    

def NextPrime(cislo):
    primes = []
    if cislo < 1:
        return 1
    i = 1
    while True:
        i += 1
        is_prime = True
        for prime in primes:
            if i % prime == 0:
                is_prime = False
                break
        if is_prime:
            primes.append(i)
        if primes[-1] > cislo:
            return primes[-1]

while True:
    akce = input("Vyber akci: Je to prvočíslo? (p), generace prvočísel menží než horní mez (g), nejbližší prvočíslo vyšší než zadané (n): ")
    if akce == "p":
        print(IsPrime(int(input("Jaké číslo chceš zkontrolovat jestli je prvočíslo? "))))
    elif akce == "g":
        print(GenPrimes(int(input("Všechna prvočísla menší než horní mez: "))))
    elif akce == "n":
        print(NextPrime(int(input("Nejbližší prvočíslo vyšší než zadané číslo: "))))
    else:
        print("Neplatná akce!")
        
    