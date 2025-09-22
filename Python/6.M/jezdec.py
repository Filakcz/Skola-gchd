import time
def GeneracePole(delka, vyska):
    pole = []
    for i in range(vyska):
        radek = ["."] * delka
        pole.append(radek)
    return pole

def GeneraceKombinaci(pozice):
    posuny = [[2, 1], [2, -1], [-2, 1], [-2, -1], [1, 2], [1, -2], [-1, 2], [-1, -2]]
    kombinace = []
    for posun in posuny:
        radek = pozice[0] + posun[0]
        sloupec = pozice[1] + posun[1]
        if 0 <= radek < len(pole) and 0 <= sloupec < len(pole[0]):
            kombinace.append([radek, sloupec])
    return kombinace

def NajdiReseni(pozice, krok):
    if krok == (len(pole) * len(pole[0])):
        return True

    kombinace = GeneraceKombinaci(pozice)

    # wansdorfovo pravidlo
    # serazeni kombinaci dle poctu tahu z ty kombinaci
    # na 6x6 dobehne bez serazeni za 2,93 sekundy
    # s wansdorfovym pravidlem za 0,009 sekundy
    kombinace.sort(key=lambda i:len(GeneraceKombinaci(i)))

    for i in kombinace:
        if pole[i[0]][i[1]] == ".":
            pole[i[0]][i[1]] = krok
            if NajdiReseni(i, krok+1):
                return True
            pole[i[0]][i[1]] = "."

    return False

def Vytisk():
    max_delka = len(str((delka*vyska)-1))
    for i in range(vyska):
        radek = ""
        for j in range(delka):
            akt_delka = len(str(pole[i][j]))
            if akt_delka < max_delka:
                pole[i][j] = (max_delka - akt_delka)*"0"+str(pole[i][j])
            radek += f"{pole[i][j]} "
        print(radek)

while True:
    delka = int(input("Délka pole: "))
    vyska = int(input("Výška pole: "))
    start_x = int(input("Start osa x: "))
    start_y = int(input("Start osa y: "))

    pole = GeneracePole(delka,vyska)
    start = [start_y,start_x]

    pole[start[0]][start[1]] = 0

    start_cas = time.time()

    if NajdiReseni(start, 1):
        print(round(time.time() - start_cas, 5), "sekund")
        Vytisk()
    else:
        print(round(time.time() - start_cas, 5), "sekund")
        print("Nejde!")
