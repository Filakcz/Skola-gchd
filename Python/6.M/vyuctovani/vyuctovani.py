def valid_input(otazka):
    while True:
        odpoved = input(otazka)
        if "|" in odpoved:
            print("Nepoužívej znak |")
        else:
            return odpoved

jmeno_souboru = "vyuctovani.txt"
platby = {}

try:
    with open(jmeno_souboru, "r", encoding="utf-8") as file:
        for radek in file:
            jmeno, castka = radek.split("|")
            if jmeno in platby:
                platby[jmeno] += int(castka)
            else:
                platby.update({jmeno:int(castka)})

except FileNotFoundError:
    platby = {}

while True:
    akce = input("Připsat (+), vymazat vše (-) nebo konečný výpis (=): ")
    if akce == "+":
        jmeno = valid_input("Jméno: ")
        castka = valid_input("Částka: ")
        if jmeno in platby:
            platby[jmeno] += castka
        else:
            platby.update({jmeno:castka})

        with open(jmeno_souboru, "a", encoding="utf-8") as file:
            file.write(jmeno + "|" + castka + "\n")

    elif akce == "=":

        prumer = (sum(platby.values())) / len(platby)

        dluznici = {}
        veritele = {}

        for jmeno, castka in platby.items():
            rozdil = castka - prumer
            if rozdil < 0:
                dluznici[jmeno] = abs(rozdil)
            elif rozdil > 0:
                veritele[jmeno] = rozdil

        print("\n"+ "Každý by měl v průměru zaplatit:", round(prumer, 2), "Kč", "\n")
        print("Dostanou:")
        for jmeno, castka in veritele.items():
            print(f"{jmeno}: {round(castka, 2)} Kč")
        print("\n"+ "Zaplatí:")
        for jmeno, castka in dluznici.items():
            print(f"{jmeno}: {round(castka, 2)} Kč")
        print()

    elif akce == "-":
        print("Vymazáno!")
        platby = {}
        with open(jmeno_souboru, "w", encoding="utf-8") as file:
            file.write("")
            
    else:
        print("Neplatná akce.")