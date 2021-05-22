;* 计算器实验 *;

data segment
T DW 1000 DUP(0)
H DW 1000 DUP(0)
data ends

stacks segment stack
db 1000 dup (128)
stacks ends
code segment
assume cs:code,ds:data,ss:stacks,es:data

start:
MOV AX,CODE
MOV DS,AX
MOV DX,00H

MOV BX,1
MOV T[BX],2

MOV BX,3
MOV T[BX],2

MOV BX,5
MOV T[BX],1

MOV BX,3
MOV AX,T[BX]
MOV BX,5
MOV DX,T[BX]
MOV BX,DX
ADD AX,BX
MOV BX,7
MOV T[BX],AX

MOV BX,1
MOV AX,T[BX]
MOV BX,7
MOV DX,T[BX]
MOV BX,DX
MUL BX
MOV BX,9
MOV T[BX],AX

MOV BX,9
MOV AX,T[BX]
MOV BX,1
MOV H[BX],AX

MOV BX,1
MOV T[BX],2

MOV BX,1
MOV AX,H[BX]
MOV DX,0
MOV BX,1
MOV CX,T[BX]
MOV BX,CX
DIV BX
MOV BX,3
MOV T[BX],AX

MOV BX,3
MOV AX,T[BX]
MOV BX,3
MOV H[BX],AX

MOV BX,1
MOV AX,H[BX]
call print

MOV BX,3
MOV AX,H[BX]
call print

MOV AH,4CH
INT 21H

;example for display register content
print	proc
push	ax
push dx
push cx
mov dx,-1
push dx
mov cx, 10
l_div10:
xor dx,dx
div    cx
push dx
test ax,ax
jne l_div10
mov cx,-1
mov ah,2
l_disp:
pop dx
cmp dx,cx
je l_ret
add dl,'0'
int 21h
jmp l_disp
l_ret:
pop cx
pop dx
pop ax
ret
print	endp

code ends
end start