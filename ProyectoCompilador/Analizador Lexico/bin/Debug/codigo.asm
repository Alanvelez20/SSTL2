.model small
.stack 100h

.data
    a dw 0
    b dw 0
    c dw 0

.code
main proc
    mov ax, @data
    mov ds, ax
    mov a, 12
    mov b, 8                 
    mov ax, a
    add ax, b
    mov c, ax
    
    mov ax, 4C00h
    int 21h
main endp

end main