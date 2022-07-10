num = int(input("Digite a Senha: "))
d1 = (num//1%10)*2
d2 = (num//10%10)*3
d3 = (num//100%10)*4
d4 = (num//1000%10)*5

resultado = (d1+d2+d3+d4)%11

print("Digito Verificador:", resultado)