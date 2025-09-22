def palindrom(text):
    if text == text[::-1]:
        return True
    else:
        return False

def del_mezery(text):
    text = text.strip()
    while text.count("  ") > 0:
        text = text.replace("  "," ")
    return text

def sifra(text):
    sifra = ""
    for i in range(len(text)):
        if ord(text[i]) > 96 and ord(text[i]) < 123:
            sifra += str((ord(text[i])-96))
            if i < len(text) - 1 and ord(text[i+1]) > 96 and ord(text[i+1]) < 123:
                sifra += "|"
        else:
            sifra += (text[i])
    return sifra

while True:
    akce = input("Ověření palindromu (p), odstranění přebytečných mezer (o), šifra (s): ")
    if akce == "p":
        if palindrom(input("Zadejte text na palindrom: ").replace(" ", "").lower()):
            print("Text je palindrom.")
        else:
            print("Text není palindrom.")

    elif akce == "o":
        print("Text bez přebytečných mezer je ", del_mezery(input("Text na odstranění přebytečných mezer: ")))

    elif akce == "s":
        print(sifra(input("Text na zašifrování: ").lower()))

    else:
        print("Neplatná akce!")

    print()