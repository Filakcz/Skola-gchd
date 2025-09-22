while True:
    print("Napiš zvířata:")
    zvirata = input().split()

    a = input().split()
    prostor = [eval(i) for i in a]

    b = input().split()
    cena = [eval(i) for i in b]

    if len(zvirata) == len(prostor) == len(cena):
        break
    else:
        print("Špatně napsáno")

zoo = int(input())

vyhodny = []
c_zvirata = []
c_cena = 0

for i in range(len(zvirata)):
    vyhodny.append(cena[i]/prostor[i]) 
#print(vyhodny)

# Program má chybu!!!!!!

# Program by měl udělaný, aby vždy byla celá zoo zaplněna. Příklad:
# Pes kočka pták 
# 40 30 20
# 800 540 300
# 50
# Nejlepší možnost: kočka + pták = 840
# Poté by se ale mohlo stát, že pes by byl mnohem více výhodný, tak se nevyplatí zaplnit celou zoo. Nejlepší by tedy pravděpodobně bylo projít všechny možnosti.

while True: 
    #Aby se zoo zaplňovala pomocí nejvýhodnějších a když jsou stejné tak menší prostor
    zvirata.reverse()
    prostor.reverse()
    cena.reverse()
    vyhodny.reverse()

    pozice = vyhodny.index(max(vyhodny))
    zoo = zoo - prostor[pozice]
    if zoo >= 0 and len(vyhodny) > 0: 
        #print("Zvíře", zvirata[pozice], "s prostorem", prostor[pozice], "a cenou", cena[pozice], "bylo použito.")
        c_cena = c_cena + cena[pozice]
        c_zvirata.append(zvirata[pozice])
        vyhodny.pop(pozice)
        prostor.pop(pozice)
        zvirata.pop(pozice)
        cena.pop(pozice)
    else:
        print("Celková cena je", c_cena)
        print("Zvířata jsou", c_zvirata)
        break

