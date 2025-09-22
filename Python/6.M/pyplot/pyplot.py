from matplotlib import pyplot as plt
import pandas as pd

df = pd.read_csv("klasifikacni_tabulka.csv") # df - data frame

prezdivky = df["Prezdivka"]
body = df["Celkem"]
znamky = df["Znamka"].value_counts().sort_index()
jmena_uloh = df.columns[7:20]
nejvyssi_skore = df.iloc[:, 7:20].max() 

def spojnicovy_bodovy():
    plt.clf()
    plt.xticks(rotation=90)  
    plt.subplots_adjust(bottom=0.44, left=0.055, right=0.986, top=0.916)
    prumer = body.mean()
    plt.axhline(y=prumer, color="orange", linestyle="--", linewidth=2, label=f"Průměr {round(prumer,2)}")
    plt.plot(prezdivky, body, color="blue")
    plt.scatter(prezdivky, body, color="green", label="Individuální skóre", s=body/2, edgecolors="black", zorder=2)
    plt.title("Přehled výkonů studentů", pad=20, weight="bold", fontsize=25)
    plt.xlabel("Přezdívka", fontsize=15)
    plt.ylabel("Celkové body", fontsize=15)
    plt.grid(True, linestyle="--", alpha=0.7)
    plt.legend()
    plt.draw()

def kolacovy():
    plt.clf()
    plt.subplots_adjust(bottom=0.137, top=0.867)
    barvy = ["#64C2A6", "#AADEA7", "#E6F69D", "#FEAE65", "#F66D44"]
    plt.pie(znamky.values, labels=znamky.index, autopct="%.1f%%", textprops={"fontsize":20}, colors=barvy[:len(znamky)], explode=(0.1, 0.1, 0.1, 0.1,0.1), shadow=True)  
    plt.title("Rozdělení známek ve třídě", pad=20, weight="bold", fontsize=25)
    plt.draw()

def sloupcovy():
    plt.clf()
    plt.subplots_adjust(bottom=0.474, top=0.914)
    plt.bar(jmena_uloh, nejvyssi_skore, color="blue", alpha=0.5, edgecolor="black")
    plt.xticks(rotation=90)
    plt.title("Nejvyšší dosažené skóre k jednotlivým úlohám", pad=20, weight="bold", fontsize=25)
    plt.xlabel("Úlohy", fontsize=15, labelpad=20)
    plt.ylabel("Body", fontsize=15)
    plt.draw()

grafy = [spojnicovy_bodovy, kolacovy, sloupcovy]
akt_graf = 0

def zmacknuti_tlacitka(event):
    global akt_graf
    if event.key == "right":
        akt_graf = (akt_graf + 1) % len(grafy) % len(grafy)
    elif event.key == "left":
        akt_graf = (akt_graf - 1) % len(grafy) % len(grafy)
    grafy[akt_graf]()


plt.figure().canvas.mpl_connect("key_press_event", zmacknuti_tlacitka)

grafy[akt_graf]()

plt.show()
