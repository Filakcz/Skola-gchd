def Reseni(krok, akt_vaha, akt_cena, vybrane):
    # binarni strom, vzdy vybere bud levou nebo pravou stranu dle vyhodnosti/nejde (rekurzivne volame az na na spodek stromu)
    # prava strana nic nepridame
    # leva strana pridame predmet daneho kroku
    if krok == len(vahy):
        if akt_vaha <= hmotnost:
            return [akt_vaha, akt_cena, vybrane]
        else:
            return None
    
    prava = Reseni(krok+1, akt_vaha, akt_cena, vybrane)
    
    leva = None
    if (akt_vaha + vahy[krok]) <= hmotnost:
        leva = Reseni(krok+1, akt_vaha+vahy[krok], akt_cena+ceny[krok], vybrane+[krok])
        
    # None = prevyseni povolene hmotnosti
    if leva is None:
        return prava
    # neni potreba naopak (if prava is none ...) pokud nemame zaporne hmotnosti
    if leva[1] > prava[1]:
        return leva
    else:
        return prava

while True:
    vahy = [int(i) for i in input("Váhy: ").split()]
    ceny = [int(i) for i in input("Ceny: ").split()]
    hmotnost = int(input("Maximální hmotnost: "))

    vysledky = Reseni(0, 0, 0, [])
    #print(vysledky)
    if not vysledky[2]:
        print("Nic se nevejde!")
    else:
        print("Vybrané:")
        for i in vysledky[2]:
            print(f" - Předmět {i+1}: váha {vahy[i]}, cena {ceny[i]}")
        print(f"Celková váha: {vysledky[0]}")
        print(f"Celková cena: {vysledky[1]}")