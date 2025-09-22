import pygame
import random

pygame.init()

sirka, vyska = 1920, 1080

zem_y = vyska - 480
t_start_x = sirka - 220
t_start_y = zem_y
ct_start_x = 0
ct_start_y = vyska - 470

t_rychlost = 1200
gravitace = 4000
vyskok = -2200
max_ct = 1900
ct_pricitani = 100
ct_start_rychlost = 100

screen = pygame.display.set_mode((sirka, vyska))
clock = pygame.time.Clock()

font = pygame.font.Font(None, 200)

pozadi_img = pygame.image.load("mapa.png").convert()
terorista_img = pygame.image.load("t.png").convert_alpha()
terorista_sirka = terorista_img.get_rect().width // 3.5
terorista_vyska = terorista_img.get_rect().height // 3.5
terorista_img = pygame.transform.scale(terorista_img, (terorista_sirka, terorista_vyska))
ct_img = pygame.image.load("ct.png").convert_alpha()
ct_sirka = ct_img.get_rect().width // 1.5
ct_vyska = ct_img.get_rect().height // 1.5
ct_img = pygame.transform.scale(ct_img, (ct_sirka, ct_vyska))
bomba_img = pygame.image.load("bomba.png").convert_alpha()
bomba_sirka = bomba_img.get_rect().width // 2
bomba_vyska = bomba_img.get_rect().height // 2
bomba_img = pygame.transform.scale(bomba_img, (bomba_sirka, bomba_vyska))


class Terorista(pygame.sprite.Sprite):
    def __init__(self, start_x, start_y):
        super().__init__()
        self.image = terorista_img
        self.rect = self.image.get_rect(topleft=(start_x, start_y))
        self.rychlost = t_rychlost
        self.delta_y = 0
        self.na_zemi = True
    def player_input(self):
        keys = pygame.key.get_pressed()
        self.pohyb_x = 0
        if keys[pygame.K_a]:
            self.pohyb_x = -1
        if keys[pygame.K_d]:
            self.pohyb_x = 1
        if keys[pygame.K_SPACE] and self.na_zemi:
            self.delta_y = vyskok
            self.na_zemi = False 
    
    def apply_gravity(self, dt):
        self.delta_y += gravitace * dt
        self.rect.y += self.delta_y * dt

        if self.rect.bottom >= zem_y + terorista_vyska:
            self.rect.bottom = zem_y + terorista_vyska
            self.delta_y = 0
            self.na_zemi = True

    def update(self, dt):
        self.player_input()

        self.rect.x += self.pohyb_x * self.rychlost * dt

        if self.rect.left < 0:
            self.rect.left = 0
        if self.rect.right > sirka:
            self.rect.right = sirka

        self.apply_gravity(dt)

    def reset(self):
        self.rect.topleft = (t_start_x, t_start_y)
        self.delta_y = 0
        self.na_zemi = True

class Counterterrorista(pygame.sprite.Sprite):
    def __init__(self, start_x, start_y):
        super().__init__()
        self.image = ct_img
        self.rect = self.image.get_rect(topleft=(start_x, start_y))
        self.rychlost = ct_start_rychlost

    def update(self, dt):
        self.rect.x += self.rychlost * dt
        if self.rect.left > sirka:
            self.rect.right = 0	
            if self.rychlost < max_ct:
                self.rychlost += ct_pricitani

    def reset(self):
        self.rect.topleft = (ct_start_x, ct_start_y)
        self.rychlost = ct_start_rychlost

class Bomba(pygame.sprite.Sprite):
    def __init__(self):
        super().__init__()
        self.image = bomba_img
        self.rect = self.image.get_rect()

    def reset(self):
        self.rect.x = random.randint(25, sirka - self.rect.width - 25)
        self.rect.y = random.randint(25, vyska - 250 - self.rect.height - 25)

    def update(self):
        pass

terorista = pygame.sprite.GroupSingle()
terorista.add(Terorista(t_start_x, t_start_y))

ct = pygame.sprite.GroupSingle()
ct.add(Counterterrorista(ct_start_x, ct_start_y))

bomba = pygame.sprite.Group()
bomba.add(Bomba())

skore = 0
hra_bezi = True

while True:
    dt = clock.tick(60) / 1000
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            pygame.quit()
            quit()
        if not hra_bezi:
            if event.type == pygame.KEYDOWN:
                if event.key == pygame.K_TAB:
                    hra_bezi = True
                    skore = 0
                    terorista.sprite.reset()
                    ct.sprite.reset()
                    bomba.empty()
                    nova_bomba = Bomba()
                    nova_bomba.reset()
                    bomba.add(nova_bomba)
                if event.key == pygame.K_ESCAPE:
                    pygame.quit()
                    quit()
    if hra_bezi:

        terorista.update(dt)
        ct.update(dt)
        bomba.update()

        if pygame.sprite.spritecollide(terorista.sprite, bomba, True):
            skore += 1
            nova_bomba = Bomba()
            nova_bomba.reset()
            bomba.add(nova_bomba)

        if pygame.sprite.spritecollide(terorista.sprite, ct, False):
            hra_bezi = False

        screen.blit(pozadi_img, (0, 0))

        terorista.draw(screen)
        ct.draw(screen)
        bomba.draw(screen)

        skore_text = font.render(f"Skóre: {skore}", True, (255, 255, 255))
        screen.blit(skore_text, (100, 100))
    else:
        screen.fill((0, 0, 0))
        text = font.render("Game Over!", True, (255, 255, 255))
        screen.blit(text, (550,-300+vyska//2))

        text = font.render(f"Skóre: {skore}", True, (255, 255, 255))
        screen.blit(text, (650,-100+vyska//2))

        text = font.render("TAB pro restart", True, (255, 255, 255))
        screen.blit(text, (400,100+vyska//2))

        text = font.render("ESC pro vypnutí", True, (255, 255, 255))
        screen.blit(text, (400,300+vyska//2))

    pygame.display.update()