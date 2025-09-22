import turtle
from colorsys import hsv_to_rgb
turtle.Screen().colormode(255)
pen = turtle.Turtle()
pen.penup()
pen.pensize(3)
turtle.tracer(False)
turtle.Screen().bgcolor("black")

#data = [10, 20, 30, 27, 15, 1, 5] # hodnoty na ose y
#data = [367, 454, 87, 316, 122, 322, 460, 289, 430, 234, 370, 136, 439, 9, 482]
data = [399, 392, 22, 416, 128, 315, 38, 245, 411, 228, 137, 461, 256, 353, 28, 68, 187, 213, 94, 363, 301, 256, 42, 302, 166, 313, 490, 67, 389, 406, 140, 331, 235, 159, 451, 18, 206, 313, 232, 429]

def KresliOsu(delka, uhel, jmeno):
    pen.pendown()
    pen.color("white")
    pen.left(uhel)
    pen.forward(delka)
    for i in [150,60]:
        pen.right(i)
        pen.forward(10)
        pen.backward(10)
    pen.right(150)
    pen.penup()
    pen.forward(5)
    pen.write(jmeno)
    pen.setheading(0)
    

def KresliObdelnik(vyska, sirka, barva, hodnota):
    pen.pendown()
    pen.color(barva)
    pen.begin_fill()
    for i in range(2):
        pen.forward(sirka)
        pen.left(90)
        pen.forward(vyska)
        # vykreslit nahore velikost hodnoty
        if i == 0:
            pen.penup()
            pen.forward(5)
            pen.left(90)
            pen.forward(sirka/2)
            pen.color("white")
            pen.write(hodnota, align="center")
            pen.backward(sirka/2)
            pen.right(90)
            pen.backward(5)
            pen.pendown()
            pen.color(barva)
        pen.left(90)
    pen.end_fill()
    pen.forward(sirka)
    pen.penup()
    
delka_osy_x = 980
start_x = -500
start_y = -250
mezera = 18

pen.goto(start_x - 4, start_y)
KresliOsu(delka_osy_x, 0,"x")
pen.goto(start_x, start_y - 4)
KresliOsu(delka_osy_x//2, 90, "y")
pen.goto(start_x, start_y+(delka_osy_x*0.53))
pen.write(f"data = {data}")

pen.goto(start_x, start_y+4)
sirka = (delka_osy_x-(mezera*(len(data)+2)))/(len(data))
for i in range(len(data)):
    pen.forward(mezera)
    r, g, b = (hsv_to_rgb(i/len(data), 1, 1))
    barva = (round(r*255), round(g*255), round(b*255))
    delka = (delka_osy_x//(2*(max(data)/data[i])))-4
    KresliObdelnik(delka, sirka, barva, data[i])

turtle.done()
