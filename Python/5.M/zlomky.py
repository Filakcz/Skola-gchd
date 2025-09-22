def nsd(x,y):
    if y == 0:
        return x
    return nsd(y, x % y)

def nsn(x, y):
    return ((x*y)/nsd(x,y))


# VLASTNÍ DATOVÉ TYPY
class Zlomek:
    def __init__(self, citatel, jmenovatel): # konstruktor
        self.citatel = citatel
        self.jmenovatel = jmenovatel
    def __str__(self): # převeď zlomek na text k výpisu
        return f"{self.citatel}/{self.jmenovatel}"
    
    def multiply(self, other):
        return Zlomek(self.citatel*other.citatel, self.jmenovatel * other.jmenovatel)
        
    def scitani(self, other):
        spolecny_jmenovatel = nsn(self.jmenovatel, other.jmenovatel)
        return Zlomek(round(self.citatel*(spolecny_jmenovatel / self.jmenovatel) + other.citatel*(spolecny_jmenovatel / other.jmenovatel)), round(spolecny_jmenovatel))
    
    def odcitani(self, other):
        spolecny_jmenovatel = nsn(self.jmenovatel, other.jmenovatel)
        return Zlomek(round(self.citatel*(spolecny_jmenovatel / self.jmenovatel) - other.citatel*(spolecny_jmenovatel / other.jmenovatel)), round(spolecny_jmenovatel))
    
    def kraceni(self):
        return Zlomek(self.citatel // nsd(self.jmenovatel, self.citatel), self.jmenovatel // nsd(self.jmenovatel, self.citatel))


g = Zlomek(int(input("Čitatel 1. zlomek: ")), int(input("Jmenovatel 1. zlomek: ")))
h = Zlomek(int(input("Čitatel 2. zlomek: ")), int(input("Jmenovatel 2. zlomek: ")))

while True:
    akce = input("Nový zlomky (nz), násobení (n), sčítání (s), odčítání (o), krácení (k): ")
    if akce == "nz":
        g = Zlomek(int(input("Čitatel 1. zlomek: ")), int(input("Jmenovatel 1. zlomek: ")))
        h = Zlomek(int(input("Čitatel 2. zlomek: ")), int(input("Jmenovatel 2. zlomek: ")))

    elif akce == "n":
        print(g.multiply(h))
    elif akce == "s":
        print(g.scitani(h))
    elif akce == "o":
        print(g.odcitani(h))
    elif akce == "k":
        jaky = input("Zlomek na zkrácení (1) nebo (2): ")
        if jaky == "1":
            print(g.kraceni())
        elif jaky == "2":
            print(h.kraceni())
        else:
            print("Neplatná akce!")
    else:
        print("Neplatná akce!")




