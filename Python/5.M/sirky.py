import random
sirky = [random.randrange(1,6), random.randrange(1,6), random.randrange(1,6)]

akt_hrac = 2
print("Odebírejte sirky. Minimální počet je 1 a maximalní celá hromádka.")
print("Vyhrává kdo odebral poslední sirku/y")

while True:
    print()
    print("Hromádky jsou: ", end="")
    for j in range(3):
        print(sirky[j], "", end="")
    print()
    vyhra = 0

    if akt_hrac == 1:
        akt_hrac = 2
    else:
        akt_hrac = 1
    print("Na řadě je hráč", akt_hrac)

    pozice = int(input("Z jaké hromádky chceš odebrat: "))
  
    while pozice > 3 or pozice < 1:
        print("Vybral si neplatnou hromádku.")
        pozice = int(input("Z jaké hromádky chceš odebrat: "))

    pocet = int(input("Kolik sirek odebrat: "))

    while pocet < 1 or sirky[pozice-1] < pocet:
        print("Musíš odebrat alespoň jednu sirku nebo byl odebrán moc velký počet")
        pocet = int(input("Kolik sirek odebrat: "))

    sirky[pozice-1] = sirky[pozice-1] - pocet
    for i in range(3):
        if sirky[i] == 0:
            vyhra += 1 

    if vyhra == 3:
        print()
        print("Hráč", akt_hrac, "vyhrál!")
        break
