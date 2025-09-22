def QuickSelect(list, k):
    if len(list) == 1:
        return list[0]
    nizky = []
    vysoky = []
    pivoti = []
    pivot = ZvoleniPivota(list)
    for i in range(len(list)):
        if list[i] < pivot:
            nizky.append(list[i])
        if list[i] > pivot:
            vysoky.append(list[i])
        if list[i] == pivot:
            pivoti.append(list[i])
    if k < len(nizky):
        return QuickSelect(nizky, k)
    elif k < (len(nizky)+len(pivoti)):
        return pivoti[0]
    else:
        return QuickSelect(vysoky, k - len(nizky) - len(pivoti))

def ZvoleniPivota(list):
    prvni = list[0]
    mid = list[len(list)//2]
    posledni = list[-1]
    if (prvni <= mid <= posledni) or (posledni <= mid <= prvni):
        return mid
    elif (mid <= prvni <= posledni) or (posledni <= prvni <= mid):
        return prvni
    else:
        return posledni

while True:
    vstup_list = [int(x) for x in input("List: ").split()]
    k = int(input("Kolikátý prvek (indexuje se od 1): ")) -1
    print(QuickSelect(vstup_list, k))
