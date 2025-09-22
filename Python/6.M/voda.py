def PrelitiVody(do_lahev_max, od_lahev_akt, do_lahev_akt):
    # Prelivame z lahve 1 do lahve 2
    rozdil = do_lahev_max - do_lahev_akt # kolik litru dolit
    if od_lahev_akt >= rozdil: # lejeme dokud neni plna a pote odecteme z lahve 1
        do_lahev_akt = do_lahev_max 
        od_lahev_akt -= rozdil
    else: # prelejeme vse co jde a lahev 1 bude prazdna
        do_lahev_akt += od_lahev_akt
        od_lahev_akt = 0
    return [od_lahev_akt, do_lahev_akt]

def GeneraceKombinaci(lahev1_max, lahev2_max, lahev1_akt, lahev2_akt):

    kombinace = []
    
    # vylit lahvi
    if lahev1_akt != 0:
        kombinace.append([0,lahev2_akt])
    if lahev2_akt != 0:
        kombinace.append([lahev1_akt, 0])

    # naplneni lahvi
    if lahev1_akt != lahev1_max:
        kombinace.append([lahev1_max, lahev2_akt])
    if lahev2_akt != lahev2_max: 
        kombinace.append([lahev1_akt, lahev2_max])

    if lahev2_akt != lahev2_max and lahev1_akt !=0: # preliti z lahve 1 do lahve 2
        kombinace.append(PrelitiVody(lahev2_max, lahev1_akt, lahev2_akt)) 

    if lahev1_akt != lahev1_max and lahev2_akt !=0: # preliti z lahve 2 do lahve 1
        kombinace.append(PrelitiVody(lahev1_max, lahev2_akt, lahev1_akt)[::-1])

    return kombinace

def ReseniDFS(lahev1_akt, lahev2_akt, lahev1_cil, lahev2_cil, lahev1_max, lahev2_max, cesta, navstivene):
    # reseni pres dfs s rekurzi
    if lahev1_akt == lahev1_cil and lahev2_akt == lahev2_cil:
        return cesta
    
    # list s navstivenymi
    navstivene.append([lahev1_akt, lahev2_akt])
    
    # generace kombinaci
    moznosti = GeneraceKombinaci(lahev1_max, lahev2_max, lahev1_akt, lahev2_akt)

    for i in moznosti:
        # ulozeni cesty v rekurzi pokud nebyla jiz navstivena
        if [i[0], i[1]] not in navstivene:
            new_cesta = cesta + [[i[0], i[1]]]

            res = ReseniDFS(i[0], i[1], lahev1_cil, lahev2_cil, lahev1_max, lahev2_max, new_cesta, navstivene)
            if res: # pokud nalezeni res (reseni) => vracime
                return res
         
    return None # slepa ulicka :), vracime none

def ReseniBFS(lahev1_akt, lahev2_akt, lahev1_cil, lahev2_cil, lahev1_max, lahev2_max):
    # bfs - najde kratsi reseni nez dfs
    
    # prvni prvek v listu listu fronty je stav a druhy je cesta k nemu
    fronta = [[[lahev1_akt, lahev2_akt], [[lahev1_akt, lahev2_akt]]]]
    navstivene = [[lahev1_akt, lahev2_akt]]
    
    while len(fronta) > 0:
        # odebrani z fronty
        aktualni_stav, cesta = fronta.pop(0)

        if aktualni_stav[0] == lahev1_cil and aktualni_stav[1] == lahev2_cil:
            return cesta

        # generace kombinaci
        moznosti = GeneraceKombinaci(lahev1_max, lahev2_max, aktualni_stav[0], aktualni_stav[1])

        for i in moznosti:
            # pokud nebyl navstiven => do fronty (stav, cesta k nemu) + navstivenych
            if [i[0], i[1]] not in navstivene:
                navstivene.append([i[0], i[1]])
                fronta.append([[i[0], i[1]], cesta + [[i[0], i[1]]]])

    return None  


while True:
    lahev1_max = int(input("Láhev 1 max: "))
    lahev2_max = int(input("Láhev 2 max: "))

    lahev1_cil = int(input("Láhev 1 má být: "))
    lahev2_cil = int(input("Láhev 2 má být: "))

    akce = input("DFS (d) nebo BFS (b): ")

    if akce == "d":
        cesta = [[0,0]]
        navstivene = []
        res = ReseniDFS(0,0, lahev1_cil, lahev2_cil,lahev1_max, lahev2_max, cesta, navstivene)

        if res:
            print("Řešení existuje s", len(res)-1, "kroky.")
            for i in res:
                print(i, end='\n')
        else:
            print("Řešení neexistuje!")

    elif akce == "b":
        res = ReseniBFS(0,0, lahev1_cil, lahev2_cil,lahev1_max, lahev2_max)

        if res:
            print("Řešení existuje s", len(res)-1, "kroky.")
            for i in res:
                print(i, end='\n')
        else:
            print("Řešení neexistuje!")


    else:
        print("Neplatná akce!")

