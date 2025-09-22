def nacti():
    matice = []
    for i in range(velikost):
        radek = input().split()
        if len(radek) != velikost:
            print("Chybně napsaný počet prvků. Napište znovu.")
            return nacti() 
        matice.append([int(a) for a in radek])
    return matice 

def secti():
    for x in range(len(matice1)):  
        for y in range(len(matice1[0])):
            vysledek[x][y] = matice1[x][y] + matice2[x][y]

def odecti():
    for x in range(len(matice1)):  
        for y in range(len(matice1[0])):
            vysledek[x][y] = matice1[x][y] - matice2[x][y]

def vypis():
    for z in vysledek:
        print(z)

matice1 = []
matice2 = []
vysledek = []

while True:
    velikost = int(input("Zadej velikost matic:"))
    while velikost < 1:
        print("Napiš celé číslo >= 1")
        velikost = int(input("Zadej velikost matic:"))
    
    print("Piš matici 1 po řádkách:")
    matice1 = nacti()

    print("Piš matici 2 po řádkách:")
    matice2 = nacti()

    for i in range(velikost):
        radek = []
        for j in range(velikost):
            radek.append(0)
        vysledek.append(radek)

    operace = input("Chceš sečíst nebo odečíst? (napiš + pro sečtení a - pro odečtení): ")
    if operace == "+":
        secti()
    elif operace == "-":
        odecti()
    else:
        print("Neznámá operace")

    vypis()

