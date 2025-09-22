import pygame
import random

def vykresli_pole(text, barvicka):
    screen.fill(cerna)
    for i in range(velikosty):
        for j in range(velikostx):
            # pygame.draw.rect(screen, barva ve tvaru (255,255,255), (x,y, delka, vyska))
            # pygame.draw.circle(screen, barva ve tvaru (255,255,255), (x,y), polomer)
            barva = bez_zetonu
            if pole[i][j] == "1":
                barva = barva_hrac1
            elif pole[i][j] == "2":
                barva = barva_hrac2
            pygame.draw.circle(screen, barva, (j*velikost + velikost//2 + posun_x, i*velikost + velikost//2 + 200), polomer)
    vykresli_text(text, 400, 120, barvicka)
    vykresli_text("ESC = vrácení do hlavního menu (neuloží hru)", 120, 50, bez_zetonu)
    pygame.display.update()

def hod(sloupec, hrac):
    #while True:
        #sloupec = int(input("kam: "))-1
    if sloupec < 0 or sloupec >= len(pole[0]):
        print("Neplatný sloupec!")
        return False
    for i in range(1, len(pole)+1):
        if pole[-i][sloupec] == ".":
            pole[-i][sloupec] = hrac
            return True
    return False
        #print("Zaplněný sloupec!")

def vyhra(board):
    for radek in board:
        for i in range(len(radek) - (na_kolik - 1)):
            if radek[i] != ".":
                vyhra = True
                for j in range(1, na_kolik):
                    if radek[i] != radek[i+j]:
                        vyhra = False
                        break
                if vyhra:
                    return radek[i]
    for sloupec in range(len(board[0])):
        for radek in range(len(board) - (na_kolik-1)):
            if board[radek][sloupec] != ".":
                vyhra = True
                for j in range(1, na_kolik):
                    if board[radek][sloupec] != board[radek+j][sloupec]:
                        vyhra = False
                        break
                if vyhra:
                    return board[radek][sloupec]

    for radek in range(len(board) - (na_kolik-1)):
        for sloupec in range(len(board[0]) - (na_kolik-1)):
            if board[radek][sloupec] != ".":
                vyhra = True
                for j in range(1, na_kolik):
                    if board[radek][sloupec] != board[radek+j][sloupec+j]:
                        vyhra = False
                        break
                if vyhra:
                    return board[radek][sloupec]

    for radek in range(len(board) - (na_kolik-1)):
        for sloupec in range(na_kolik-1, len(board[0])):  
            if board[radek][sloupec] != ".":
                vyhra = True
                for j in range(1, na_kolik):
                    if board[radek][sloupec] != board[radek+j][sloupec-j]:
                        vyhra = False
                        break
                if vyhra:
                    return board[radek][sloupec]
    return None

def plny_pole(board):
    for i in range(velikostx):
        if board[0][i] == ".":
            return False
    return True

def setup_hry():
    pole = []
    for i in range(velikosty):
        pole.append(["."]*velikostx)
    return pole

def konec_hry():
    if hrac == "nikdo":
        vykresli_pole("Remíza :(", zelena)
    elif hrac == "1":
        vykresli_pole(f"Vyhrál {hrac2_nick}!", cervena)
    elif hrac == "2":
        vykresli_pole(f"Vyhrál {hrac1_nick}!", modra)
    elif hrac == "pocitac":
        vykresli_pole("Vyhrál počítač!", cervena)
    else:
        vykresli_pole("Neco se pos**lo", cervena)
    pygame.time.delay(200)
    while True:
        for event in pygame.event.get():
            if event.type == pygame.QUIT:
                    pygame.quit()
                    exit()
            if event.type == pygame.MOUSEBUTTONDOWN:
                return

def vykresli_text(text, x,y, barva):
    text_povrch = font.render(text, True, barva)
    screen.blit(text_povrch, (x,y))

def hlavni_menu():
    selectly_item = 0
    input_buttony = [pygame.Rect(400, 200, 200, 60), pygame.Rect(400, 300, 200, 60), pygame.Rect(400, 400, 200, 60)]
    popisky_buttony = ["Hrát", "Nastavení", "Vypnout :("]

    while True:
        screen.fill(cerna)
        vykresli_text("Hlavní menu", 400, 100, bez_zetonu)
        for i in range(3):
                if i == selectly_item:
                    pygame.draw.rect(screen, modra, input_buttony[i])
                else:
                    pygame.draw.rect(screen, fialova, input_buttony[i])
                vykresli_text(popisky_buttony[i], input_buttony[i].x + 10, input_buttony[i].y + 10, bez_zetonu)

        vykresli_text("ENTER = enter, Šipky = posun výběru", 200, 500, bez_zetonu)
        vykresli_text("Hod žetonu ve hře kliknutím levého tlačítka na sloupec", 50, 600, bez_zetonu)
        pygame.display.update()
        
        for event in pygame.event.get():
            if event.type == pygame.QUIT:
                pygame.quit()
                exit()
            if event.type == pygame.KEYDOWN:
                if event.key == pygame.K_RETURN:  
                    if selectly_item == 0:
                        return vyber_modu()
                    if selectly_item == 1:
                        nastaveni_menu()
                    else:
                        pygame.quit()
                        exit()

                elif event.key == pygame.K_DOWN:  
                    if  (selectly_item + 1) > 2:
                        selectly_item = 0
                    else:
                        selectly_item += 1

                elif event.key == pygame.K_UP: 
                    if  (selectly_item - 1) < 0:
                        selectly_item = 2
                    else:
                        selectly_item -= 1

def nastaveni_menu():
    global velikostx, velikosty, hrac1_nick, hrac2_nick, na_kolik

    bezi_nastaveni = True
    text_input = [str(velikostx), str(velikosty), str(na_kolik), str(hrac1_nick), str(hrac2_nick)]
    selectly_item = 0

    input_tlacitka = [pygame.Rect(500, 200, 200, 50), pygame.Rect(500, 300, 200, 50), pygame.Rect(500, 400, 200, 50), pygame.Rect(500, 500, 200, 50), pygame.Rect(500, 600, 200, 50)]
    popisky = ["Šířka:", "Výška:", "Na kolik:","Jméno hráče 1:", "Jméno hráče 2:"]

    while bezi_nastaveni:
        screen.fill(cerna)
        vykresli_text("Nastavení hry", 400, 100, bez_zetonu)
        
        for i in range(5):
            if i == selectly_item:
                pygame.draw.rect(screen, modra, input_tlacitka[i])
            else:
                pygame.draw.rect(screen, fialova, input_tlacitka[i])
            vykresli_text(popisky[i], 150, input_tlacitka[i].y + 10, bez_zetonu)
            vykresli_text(text_input[i], input_tlacitka[i].x + 10, input_tlacitka[i].y + 10, bez_zetonu)

        vykresli_text("Kdo začíná se volí náhodně", 300, 700, bez_zetonu)
        vykresli_text("Šipky = posun výběru, BACKSPACE = mazání", 100, 800, bez_zetonu)
        vykresli_text("ENTER = odejít a uložit, ESC = odejít bez uložení", 100, 900, bez_zetonu)

        pygame.display.update()

        for event in pygame.event.get():
            if event.type == pygame.QUIT:
                pygame.quit()
                exit()

            if event.type == pygame.KEYDOWN:
                if event.key == pygame.K_RETURN:  
                    velikostx = int(text_input[0])
                    velikosty = int(text_input[1])
                    na_kolik = int(text_input[2])
                    hrac1_nick = text_input[3]
                    hrac2_nick = text_input[4]
                    bezi_nastaveni = False  

                elif event.key == pygame.K_ESCAPE:  
                    bezi_nastaveni = False

                elif event.key == pygame.K_DOWN:  
                    if  (selectly_item + 1) > 4:
                        selectly_item = 0
                    else:
                        selectly_item += 1

                elif event.key == pygame.K_UP: 
                    if  (selectly_item - 1) < 0:
                        selectly_item = 4
                    else:
                        selectly_item -= 1
                elif event.key == pygame.K_BACKSPACE:  
                    text_input[selectly_item] = text_input[selectly_item][:-1]

                elif event.unicode.isprintable():
                    text_input[selectly_item] += event.unicode

def vyber_modu():
    selectly_item = 0
    input_buttony = [pygame.Rect(300, 250, 400, 60), pygame.Rect(300, 350, 400, 60), pygame.Rect(300, 450, 400, 60)]
    popisky_buttony = ["1v1 samostatně", "Lehký - proti počítači", "Těžký - proti počítači"]

    while True:
        screen.fill(cerna)
        vykresli_text("Výběr herního režimu", 320, 150, bez_zetonu)

        for i in range(3):
            if i == selectly_item:
                pygame.draw.rect(screen, modra, input_buttony[i])
            else:
                pygame.draw.rect(screen, fialova, input_buttony[i])
            vykresli_text(popisky_buttony[i], input_buttony[i].x + 10, input_buttony[i].y + 10, bez_zetonu)
        vykresli_text("ENTER = enter, Šipky = posun výběru", 200, 600, bez_zetonu)
        vykresli_text("ESC = vrátit se do hlavního menu", 250, 700, bez_zetonu)
        pygame.display.update()

        for event in pygame.event.get():
            if event.type == pygame.QUIT:
                pygame.quit()
                exit()
            if event.type == pygame.KEYDOWN:
                if event.key == pygame.K_RETURN:  
                    return selectly_item  
                    # 0 = 1v1
                    # 1 = pc ez
                    # 2 = pc hard
                elif event.key == pygame.K_ESCAPE:
                    return "zpet"
                elif event.key == pygame.K_DOWN:  
                    if  (selectly_item + 1) > 2:
                        selectly_item = 0
                    else:
                        selectly_item += 1

                elif event.key == pygame.K_UP: 
                    if  (selectly_item - 1) < 0:
                        selectly_item = 2
                    else:
                        selectly_item -= 1

def pc_tah0():
    hod(random.choice(volne_sloupce(pole)), "2")

# https://www.youtube.com/watch?v=l-hh51ncgDI
# https://connect4.gamesolver.org/
def minimax(board, depth, alpha, beta, maximizingplayer):
    vyherce = vyhra(board)
    if vyherce:
        if vyherce == "2":
            return 100000, -1
        else:
            return -100000, -1
    elif plny_pole(board):
        return 0, -1
    elif depth == 0:
        return ohodnoceni_pozice(board), -1

    
    if maximizingplayer:
        max_eval = float("-inf")
        for i in range(velikostx):
            if board[0][i] == ".":
                radek = volny_radek(board, i)
                board[radek][i] = "2"
                eval, _ = minimax(board, depth-1, alpha, beta, False)
                board[radek][i] = "."
                if eval > max_eval:
                    max_eval = eval
                    tah = i
                alpha = max(alpha, eval)
                if beta <= alpha:
                    break
        return max_eval, tah
    else:
        min_eval = float("inf")
        for i in range(velikostx):
            if board[0][i] == ".":
                radek = volny_radek(board, i)
                board[radek][i] = "1"
                eval, _ = minimax(board, depth-1, alpha, beta, True)
                board[radek][i] = "."
                if eval < min_eval:
                    min_eval = eval
                    tah = i
                beta = min(beta, eval)
                if beta <= alpha:
                    break
        return min_eval, tah

def volny_radek(board, sloupec):
    for i in range(1, len(board)+1):
        if board[-i][sloupec] == ".":
            return len(board) - i
    return -1

def volne_sloupce(board):
    nezaplneny_sloupce = []
    for i in range(velikostx):
        if board[0][i] == ".":
            nezaplneny_sloupce.append(i)
    return nezaplneny_sloupce

def ohodnoceni_pozice(board):
    skore = 0
    smery = [(1, 0), (0, 1), (1, 1), (-1, 1)]

    for y in range(velikosty):
        for x in range(velikostx):
            if board[y][x] != ".":
                akt_hrac = board[y][x]
                for posun_x, posun_y in smery:
                    pocet = 0
                    for i in range(na_kolik):
                        x2 = x + i * posun_x
                        y2 = y + i * posun_y
                        if 0 <= x2 < velikostx and 0 <= y2 < velikosty:
                            if board[y2][x2] == akt_hrac:
                                pocet += 1
                            else:
                                break
                    
                    if akt_hrac == "2":
                        skore += pocet
                    else:
                        skore -= pocet

    return skore


def pc_tah1():
    a, tah = minimax(pole, hloubka, float("-inf"), float("inf"), True)
    #+hodnoty = ai vede, -hodnoty ty vedes
    print(a, tah)
    hod(tah, "2")

sirka, vyska = 1000, 1000
pygame.init()

screen = pygame.display.set_mode((sirka, vyska))
pygame.display.set_caption("Connet 4")

bez_zetonu = (255, 255, 200) 
cerna = (0, 0, 0)    
barva_hrac1 = (0, 0, 255) 
barva_hrac2 = (255, 0, 0)
modra = (0,0,255)
font = pygame.font.Font(None, 50)
fialova = (128, 0, 128)
hloubka = 7
cervena = (255,0,0)
zelena = (0,255,0)

velikostx, velikosty = 7, 6
hrac1_nick, hrac2_nick = "Hráč 1", "Hráč 2"
na_kolik = 4

while True:
    rezim_hry = hlavni_menu()

    if rezim_hry != "zpet":  
        break

if rezim_hry != 0:  
    hrac2_nick = "Počítač"

while True:
    velikost = min(sirka // velikostx, (vyska-200) // velikosty)
    polomer = velikost // 2 - 5
    pole = setup_hry()
    hrac = str(random.randint(1,2))
    posun_x = (sirka - (velikostx * velikost)) // 2

    run = True
    if hrac == "1":
        vykresli_pole(f"Tah má {hrac1_nick}", bez_zetonu)
    else:
        vykresli_pole(f"Tah má {hrac2_nick}", bez_zetonu)

    while run:
        for event in pygame.event.get():
            if event.type == pygame.QUIT:
                run = False
                pygame.quit()
                exit()
            if event.type == pygame.MOUSEBUTTONDOWN and (rezim_hry == 0 or hrac == "1"):
                if pygame.mouse.get_pressed()[0]:
                    x, y = event.pos
                    sloupec = (x - posun_x) // velikost
                    if hod(sloupec, hrac): 
                        if hrac == "1":
                            hrac = "2"
                            vykresli_pole(f"Tah má {hrac2_nick}", bez_zetonu)   
                        else:
                            hrac = "1"
                            vykresli_pole(f"Tah má {hrac1_nick}", bez_zetonu)
                    if vyhra(pole):
                        konec_hry()
                        run = False
                        break
                    if plny_pole(pole):
                        hrac = "nikdo"
                        konec_hry()
                        run = False
                        break
            if event.type == pygame.KEYDOWN:
                if event.key == pygame.K_ESCAPE:  
                    rezim_hry = hlavni_menu()
                    run = False
                    if rezim_hry != 0:  
                        hrac2_nick = "Počítač"
                    break

        if rezim_hry != 0 and hrac == "2" and run:
            if rezim_hry == 1:
                pygame.time.delay(300)
                pc_tah0()
            else:
                pc_tah1()

            if vyhra(pole):
                hrac = "pocitac"
                konec_hry()
                run = False
                break
            if plny_pole(pole):
                hrac = "nikdo"
                konec_hry()
                run = False
                break

            hrac = "1"
            vykresli_pole(f"Tah má {hrac1_nick}", bez_zetonu)
