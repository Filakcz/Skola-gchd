import sys
import pygame

rozmer = 900
pozadi = (255, 255, 255)
barva = (0, 0, 0)
hloubka = 5

pygame.init()
screen = pygame.display.set_mode((rozmer, rozmer))


def vykres(x, y, velikost, hloubka):
    if hloubka == 0:
        pygame.draw.rect(screen, barva, (x, y, velikost, velikost))
    else:
        while velikost % 3 != 0:
            velikost = velikost + 1
        nova = velikost / 3
        for i in range(3):
            for j in range(3):
                if i != 1 or j != 1:
                    vykres((i * nova) + x, (j * nova) + y, nova, hloubka - 1)



bezi = True
while bezi:
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            bezi = False
    
    screen.fill(pozadi)
    vykres(0, 0, rozmer, hloubka)
    pygame.display.flip()

pygame.quit()
sys.exit()