def sifra(text, posun):
    stext = ""
    while posun > 26:
        posun -= 26
    while posun < 0:
        posun += 26

    for i in range(len(text)):
        if text[i].islower():
            if (ord(text[i]) + posun) > 122:
                stext += str(chr(ord(text[i]) + posun - 26))
            else:
                stext += str(chr(ord(text[i]) + posun))

        elif text[i].isupper():
            if (ord(text[i]) + posun) > 90:
                stext += str(chr(ord(text[i]) + posun - 26))
            else:
                stext += str(chr(ord(text[i]) + posun))

        else:
            stext += str(text[i])
    return stext


def desifra(text):
    for i in range(26):
        dtext = ""
        for j in range(len(text)):
            if text[j].islower():
                if (ord(text[j]) - i) < 97:
                    dtext += str(chr(ord(text[j]) - i + 26))
                else:
                    dtext += str(chr(ord(text[j]) - i))

            elif text[j].isupper():
                if (ord(text[j]) - i) < 65:
                    dtext += str(chr(ord(text[j]) - i + 26))
                else:
                    dtext += str(chr(ord(text[j]) - i))

            else:
                dtext += str(text[j])

        print("Použití klíče " + str(i) + ": " + dtext)


while True:
    akce = input("Zašifrování (z) a dešifrování (d): ")
    if akce == "z":
        print(sifra(input("Text na zašifrování: "), int(input("Posun: "))))
    elif akce == "d":
        desifra(input("Text na dešifrování: "))
    else:
        print("Neplatná akce!")
        
    print()