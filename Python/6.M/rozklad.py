cislo = int(input("Zadejte číslo: "))

stack = [[cislo, []]]
vysledky = []

while stack:
    zbytek, cesta = stack.pop()
    
    if zbytek == 0:
        vysledky.append(cesta)
        continue
    
    if not cesta:
        start = 1
    else:
        start = cesta[-1]
    
    for i in range(start, zbytek + 1):
        stack.append([zbytek - i, cesta + [i]])

vysledky.reverse()

for i in range(len(vysledky)):
    vysledek = ""

    for j in range(len(vysledky[i])):
        if j > 0:  
            vysledek += " + "
        vysledek += str(vysledky[i][j]) 

    print(vysledek)

