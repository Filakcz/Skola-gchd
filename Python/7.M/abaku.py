powers = [2,3]

def SumDigits(n):
    result = 0
    while n:
        result += n % 10
        n = n // 10
    return result

while True:
    digits = input("Vstup: ").strip()
    score = 0
    n = len(digits)
    
    for i in range(n):
        for j in range(i+1,n):
            sub = digits[i:j+1]
            found = False
            for k in range(1, len(sub)):
                a = sub[:k]
                b = sub[k:]
                 
                if a[0] != "0" and b[0] != "0":
                    a = int(a)
                    b = int(b)
                    for p in powers:
                        if a**p == b:
                            print(f"{a}^{p}={b}")
                            score += (SumDigits(a)+SumDigits(b))
                            found = True
                if found:
                    break

            if not found:
                for k in range(1, len(sub) - 1):
                    a = sub[:k]
                    if a[0] != "0":
                        a = int(a)
                        rest = sub[k:]

                        for l in range(1, len(rest)):
                            b = rest[:l]
                            c = rest[l:]
                            if b[0] != "0" and c[0] != "0":
                                b = int(b)
                                c = int(c)
                                if a + b == c:
                                    print(f"{a} + {b} = {c}")
                                    score += (SumDigits(a)+SumDigits(b)+SumDigits(c))
                                    found = True
                                    break
                                elif a - b == c:
                                    print(f"{a} - {b} = {c}")
                                    score += (SumDigits(a)+SumDigits(b)+SumDigits(c))
                                    found = True
                                    break
                                elif a * b == c:
                                    print(f"{a} * {b} = {c}")
                                    score += (SumDigits(a)+SumDigits(b)+SumDigits(c))
                                    found = True
                                    break
                                elif a % b == 0 and a / b == c:
                                    print(f"{a} / {b} = {c}")
                                    score += (SumDigits(a)+SumDigits(b)+SumDigits(c))
                                    found = True
                                    break

                        if found:
                            break
    print(f"Score: {score}")
