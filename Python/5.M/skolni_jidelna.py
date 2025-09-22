import random

class Lunch:
    def __init__(self, datum, moznost1, moznost2, moznost3, cena):
        self.datum = datum
        self.cena = cena
        self.Options = [moznost1, moznost2, moznost3]
    def __str__(self):
        return f"Oběd {self.datum} ({self.cena},-): \n a) {self.Options[0]} \n b) {self.Options[1]} \n c) {self.Options[2]}"
class Student:
    def __init__(self, name, lastname):
        self.Name = name
        self.Lastname = lastname
        self.AccountBalance = 0

        self.Lunches = dict() 
            # dictionary (slovník) - podobný jako seznam, ale uchovává dvojice hodnot: KLÍČ a HODNOTA
            # v našem případě jsou klíčem objekty typu Lunch a hodnotou zvolená možnost (integer) -> viz funkce orderLunch

    def __str__(self):
        return f"{self.Name} {self.Lastname}: {self.AccountBalance},-"
    
    def orderLunch(self, lunch: Lunch, option: int):
        if self.AccountBalance < lunch.cena:
            return f"Bohužel si tento oběd nemůžeš dovolit."
        else:
            self.Lunches.update({lunch : option}) # do slovníku přidáme oběd a zvolenou možnost
            self.AccountBalance -= lunch.cena
            return f"Objednán oběd {lunch.Options[option-1]}" # vytiskne zvolneou možnost oběda
        

    def uploadMoney(self, amount):
        self.AccountBalance += amount
        return f"Na účet studenta {self.Name} {self.Lastname} nahráno {amount},-"

    def printAllLunchesWithTotalPrice(self):
        print(self)
        print(25*"-")
        totalPrice = 0
        for lunch in self.Lunches: # prochází položky ve slovníku obědů
            option = self.Lunches[lunch] # získá ze slovníku uloženou možnost oběda
            print(lunch.datum, lunch.Options[option-1]) # vytiskne datum a název objednané možnosti oběda
            totalPrice += lunch.cena
        print(25*"-")
        print("TOTAL PRICE:", totalPrice)

obedy = [
        # datum, 1. možnost, 2. možnost, 3. možnost, cena
    Lunch("14. 5.", "svíčková", "řízek", "špagety", 85),
    Lunch("15. 5.", "pštrosí vejce", "kuře podivné chuti", "koprovka", 90),
    Lunch("16. 5.", "žemlovka", "rajská", "guláš", 70),
    Lunch("17. 5.", "rizoto", "bulgur", "čočka", 50),
    Lunch("18. 5.", "mahi-mahi", "zapečené těstoviny", "poridge", 80),
    Lunch("19. 5.", "kuřecí stehno", "kuřecí prso", "kuřecí játra", 75)
]
for obed in obedy: print(obed)
print()

s1 = Student("Misa", "Mazna")
s2 = Student("Jan", "Novak")

print(s1.orderLunch(obedy[0],1))
print()

print(s1.uploadMoney(1000))
print()

for obed in obedy:
    option = random.randint(1,3)
    print(s1.orderLunch(obed, option))
print()

s1.printAllLunchesWithTotalPrice()