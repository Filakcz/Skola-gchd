while True:
    rle = input("RLE compression: ")
    end_str = ""
    act_char = ""
    a = 0

    for i in range(len(rle)):
        if rle[i] == act_char:
            a += 1
        else:
            if a > 0:
                end_str += f"{a}{rle[i-1]}" 
            act_char = rle[i]
            a = 1

        if i == (len(rle)-1):
            end_str += f"{a}{rle[i]}" 
    print(end_str)
