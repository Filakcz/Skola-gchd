def NactiBludiste():
    bludiste = []
    for i in range(1,velikost+1):
        if i < 10:
            radek = input(f"Řádek 0{i}: ").split()
        else:
            radek = input(f"Řádek {i}: ").split()

        if len(radek) != velikost:
            print("Neplatná velikost!")
            return NactiBludiste()

        bludiste.append(radek)

    return bludiste

def NajdiStart():
    for i in range(len(bludiste)):
        for j in range(len(bludiste[i])):
            if bludiste[i][j] == "S":
                return [i, j]
    # i je y osa (jaky radek)
    # j je x osa (jaky sloupec)

def VolnaPolickaOkolo(pole):
    moznosti = []
    for i in range(3):
        for j in range(3):
            if (i == 1 and not j == 1) or (not i == 1 and j == 1):
                # XOR
                akt_pole = [pole[0]-1+i, pole[1]-1+j]
                #print(akt_pole)

                if (0 <= akt_pole[0] < velikost) and (0 <= akt_pole[1] < velikost) and akt_pole not in navstivene:
                    # aby jsme se nekoukali mimo tabulku a neni v navstivenych
                    if bludiste[akt_pole[0]][akt_pole[1]] == ".":
                        moznosti.append(akt_pole)
                    if bludiste[akt_pole[0]][akt_pole[1]] == "C":
                        return [True, akt_pole]
                
    return moznosti

def BarevnyVytiskBludiste(cesta):
    GREEN = '\033[42m'
    RESET = '\033[0m'

    for i in range(velikost):
        radek = ""
        for j in range(velikost):
            if [i, j] in cesta:
                if [i,j+1] in cesta: # aby mezera mezi dvemi spravnymi v radku byla taky zelena
                    radek += f"{GREEN}{bludiste[i][j]} {RESET}"
                else:    
                    radek += f"{GREEN}{bludiste[i][j]}{RESET} "
            else:
                radek += f"{bludiste[i][j]} "
        print(radek)

while True:
    velikost = int(input("Velikost bludiště: "))
    bludiste = NactiBludiste()
    start = NajdiStart()
    fronta = [[start, [start]]]
    navstivene = []

    while True:
        if len(fronta) == 0:
            print("Nelze!")
            break
        moznosti = VolnaPolickaOkolo(fronta[0][0])

        navstivene.append(fronta[0][0])

        if len(moznosti) != 0:
            if moznosti[0] is True:
                fronta[0][1].append(moznosti[1])
                print("Počet kroků je", len(fronta[0][1])-1)

                for i in range(len(fronta[0][1])):
                    if i == 0:
                        print("Start -", fronta[0][1][0])
                    else:
                        print(f"{i}. krok -", fronta[0][1][i])

                BarevnyVytiskBludiste(fronta[0][1])
                break

            for i in range(len(moznosti)):
                fronta.append([moznosti[i], fronta[0][1]+[moznosti[i]]])

        fronta.pop(0)