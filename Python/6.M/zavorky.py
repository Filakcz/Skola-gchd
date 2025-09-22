oteviraci_zavorky = ['{', '[','(']
zaviraci_zavorky = ['}', ']',')']

while True:
    text = input("input: ")
    stack = []
    spatny = False

    for znak in text:
        if znak in oteviraci_zavorky:
            stack.append(znak)
        elif znak in zaviraci_zavorky:
            if not stack:
                spatny = True
                break
            if zaviraci_zavorky.index(znak) == oteviraci_zavorky.index(stack[-1]):
                stack.pop()
            else:
                spatny = True
                break
        

    if not stack and not spatny:
        print("Závorkování je správně!")
    if spatny or stack:
        print("Závorkování je špatně!")