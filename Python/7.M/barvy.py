import tkinter
from tkinter import ttk
from tkinter import filedialog
from PIL import Image, ImageTk

def rgb_to_hsv(red,green,blue):
    red = red / 255
    green = green / 255
    blue = blue / 255
    C_max = max(red, green, blue)
    C_min = min(red, green, blue)

    delta = C_max - C_min

    if delta == 0:
        hue = 0
    elif C_max == red:
        hue = (60 * ((green - blue) / delta) + 360) % 360
    elif C_max == green:
        hue = (60 * ((blue - red) / delta) + 120) % 360
    else: 
        hue = (60 * ((red - green) / delta) + 240) % 360

    if C_max == 0:
        saturation = 0
    else:
        saturation =  delta / C_max

    valu = C_max

    return hue, saturation*100, valu*100


def hsv_to_rgb(hue, saturation, valu):
    saturation = saturation / 100
    valu = valu / 100
    c = valu * saturation
    x = c * (1 - abs((hue / 60) % 2 - 1))
    m = valu - c

    if 0 <= hue < 60:
        red, green, blue = c, x, 0
    elif 60 <= hue < 120:
        red, green, blue = x, c, 0
    elif 120 <= hue < 180:
        red, green, blue = 0, c, x
    elif 180 <= hue < 240:
        red, green, blue = 0, x, c
    elif 240 <= hue < 300:
        red, green, blue = x, 0, c
    else:
        red, green, blue = c, 0, x

    red = (red + m) * 255
    green = (green + m) * 255
    blue = (blue + m) * 255
    return round(red), round(green), round(blue)


def rgb_to_cmyk(red, green, blue):
    red = red / 255
    green = green / 255
    blue = blue / 255
    key = 1 - max(red, green, blue)
    if key == 1:
        return 0, 0, 0, 1
    cyan = (1 - red - key) / (1 - key)
    magenta = (1 - green - key) / (1 - key)
    yellow = (1 - blue - key) / (1 - key)
    return cyan*100, magenta*100, yellow*100, key*100


def cmyk_to_rgb(cyan, magenta, yellow, key):
    cyan = cyan / 100
    magenta = magenta / 100
    yellow = yellow / 100
    key = key / 100
    red = 255 * (1 - cyan) * (1 - key)
    green = 255 * (1 - magenta) * (1 - key)
    blue = 255 * (1 - yellow) * (1 - key)
    return round(red), round(green), round(blue)

root = tkinter.Tk()
root.title("Barvičky")

notebook = ttk.Notebook(root)
notebook.pack(fill="both", expand=True)

tab1 = ttk.Frame(notebook)
notebook.add(tab1, text="Barevná konverze")

color_display = tkinter.Label(tab1, text="Ukázka", width=20, height=5)
color_display.grid(row=0, column=0, columnspan=12, pady=10)

sliders = {}


def make_slider(name, min_v, max_v, row, col):
    label = tkinter.Label(tab1, text=name)
    label.grid(row=row, column=col, padx=5)
    slider = tkinter.Scale(tab1, from_=min_v, to=max_v, orient="horizontal", length=200)
    slider.grid(row=row, column=col+1, pady=10)
    sliders[name] = slider
    return slider

def update_from_rgb(val=None):
    r, g, b = sliders["R"].get(), sliders["G"].get(), sliders["B"].get()

    h, s, v = rgb_to_hsv(r, g, b)
    sliders["H"].set(int(h))
    sliders["S"].set(int(s))
    sliders["V"].set(int(v))
    c, m, y, k = rgb_to_cmyk(r, g, b)
    sliders["C"].set(int(c))
    sliders["M"].set(int(m))
    sliders["Y"].set(int(y))
    sliders["K"].set(int(k))

    color_display.config(bg=f"#{r:02x}{g:02x}{b:02x}")

def update_from_hsv(val=None):
    h, s, v = sliders["H"].get(), sliders["S"].get(), sliders["V"].get()

    r, g, b = hsv_to_rgb(h, s, v)
    sliders["R"].set(r)
    sliders["G"].set(g)
    sliders["B"].set(b)
    c, m, y, k = rgb_to_cmyk(r, g, b)
    sliders["C"].set(int(c))
    sliders["M"].set(int(m))
    sliders["Y"].set(int(y))
    sliders["K"].set(int(k))

    color_display.config(bg=f"#{r:02x}{g:02x}{b:02x}")


def update_from_cmyk(val=None):
    c, m, y, k = sliders["C"].get(), sliders["M"].get(), sliders["Y"].get(), sliders["K"].get()

    r, g, b = cmyk_to_rgb(c, m, y, k)
    sliders["R"].set(r)
    sliders["G"].set(g)
    sliders["B"].set(b)
    h, s, v = rgb_to_hsv(r, g, b)
    sliders["H"].set(int(h))
    sliders["S"].set(int(s))
    sliders["V"].set(int(v))

    color_display.config(bg=f"#{r:02x}{g:02x}{b:02x}")

make_slider("R",0,255,1,0)
make_slider("G",0,255,2,0)
make_slider("B",0,255,3,0)
for x in ("R","G","B"):
    sliders[x].bind("<B1-Motion>", update_from_rgb)
    sliders[x].bind("<ButtonRelease-1>", update_from_rgb)

make_slider("H",0,360,1,3)
make_slider("S",0,100,2,3)
make_slider("V",0,100,3,3)
for x in ("H","S","V"):
    sliders[x].bind("<B1-Motion>", update_from_hsv)
    sliders[x].bind("<ButtonRelease-1>", update_from_hsv)

make_slider("C",0,100,1,6)
make_slider("M",0,100,2,6)
make_slider("Y",0,100,3,6)
make_slider("K",0,100,4,6)
for x in ("C","M","Y","K"):
    sliders[x].bind("<B1-Motion>", update_from_cmyk)
    sliders[x].bind("<ButtonRelease-1>", update_from_cmyk)

tab1.grid_columnconfigure(2, minsize=40) 
tab1.grid_columnconfigure(5, minsize=40)

sliders["R"].set(128)
sliders["G"].set(64)
sliders["B"].set(200)
update_from_rgb()


tab2 = ttk.Frame(notebook)
notebook.add(tab2, text="Barevná paleta")

def load_image():
    filepath = filedialog.askopenfilename(
        filetypes=[("Obrázky", "*.jpg *.jpeg *.png")]
    )
    if not filepath:
        return
    
    img = Image.open(filepath)
    img.thumbnail((300, 300)) 
    tk_img = ImageTk.PhotoImage(img) # konvert na tk
    image_label.config(image=tk_img)
    image_label.image = tk_img

    palette_img = img.convert('P', palette=Image.ADAPTIVE, colors=5)
    palette = palette_img.getpalette()
    # [0,0,0,255,255,255 atd.] barvy bez oddeleni
    color_counts = sorted(
        palette_img.getcolors(), reverse=True
    )  

    for widget in palette_frame.winfo_children():
        widget.destroy()

    for i in range(min(5, len(color_counts))):
        _, color_index = color_counts[i]
        r, g, b = palette[color_index*3:color_index*3+3]
        hex_color = f"#{r:02x}{g:02x}{b:02x}"
        swatch = tkinter.Label(palette_frame, bg=hex_color, width=10, height=2)
        swatch.grid(row=0, column=i, padx=5, pady=5)
        color_label = tkinter.Label(palette_frame, text=hex_color, )
        color_label.grid(row=1, column=i)



upload_btn = tkinter.Button(tab2, text="Nahrát obrázek", command=load_image)
upload_btn.pack(pady=10)

image_label = tkinter.Label(tab2)
image_label.pack(pady=10)

palette_frame = tkinter.Frame(tab2)
palette_frame.pack(pady=10)


root.mainloop()