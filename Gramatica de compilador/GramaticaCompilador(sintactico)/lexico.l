%{
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "sintactico.tab.h"

int num_lines = 1;
%}

/*Seccion de opciones*/
%option noyywrap
/* Nombre de salida del archivo */
%option outfile = "scanner.c"


/* SECCION DE TOKENS */

/*TOKENS BASICOS*/
DIGITO            [0-9]
LETRA             [a-zA-ZñÑ]
GUIONBAJO         [_]
COMA              ","
PUNTO             "."
COMENTARIO        "//"
PUNTOYCOMA        ";"
ESPACIOS          [" "\n\t]         
CADENA            \"[^\n"]*\"
CARACTER          \"[^\n"]\"
ENTERO            (-?[1-9][0-9]{0,4})|0
REAL              {DIGITO}{0,8}"."{DIGITO}{1,8}
ID                {LETRA}({LETRA}|{DIGITO}|{GUIONBAJO})*

/*PALABRAS RESERVADAS*/
IF                "si"
ELSE              "sino"
WHILE             "mientras"
FOR               "para"
INT               "entero"
FLOAT             "flotante"
STRING            "cadena"
CHAR              "caracter"
PRINT             "imprimir"
INPUT             "input"
AND               "&&"
OR                "||"
BOOL              "boleano"
TRUE              "verdadero"
FALSE             "falso"
LIST              "lista"
INSERT            "insertar"
POP               "pop"

/*DELIMITADORES*/
LLAVE_A           "{"
LLAVE_C           "}"
PARENTESIS_A      "("
PARENTESIS_C      ")"
CORCHETE_A        "["
CORCHETE_C        "]" 

/*OPERADORES*/
OP_SUMA           "+"
OP_RESTA          "-"
OP_MULT           "*"
OP_DIV            "/"
OP_IGUAL          "="
OP_MENOR          "<"
OP_MENORIGUAL     "<="
OP_MAYOR          ">"
OP_MAYORIGUAL     ">="
OP_COMP_IGUAL     "=="
OP_NEGACION       "!"
OP_DISTINTO       "!="

/*Seccion de reglas, es importante el orden debido a que se buscara el patron y se ejecutara el patron en orden secuencial*/
%%

{COMA}            {return COMA;}
{PUNTOYCOMA}      {return PUNTOYCOMA;}
{ENTERO}          {return ENTERO;}
{REAL}            {return REAL;}
{CARACTER}        {return CARACTER;}
{CADENA}          {return CADENA;}
{GUIONBAJO}       {return GUIONBAJO;}
{PUNTO}           {return PUNTO;}
{COMENTARIO}      {return COMENTARIO;}

 
{OP_SUMA}         {return OP_SUMA;}
{OP_RESTA}        {return OP_RESTA;}
{OP_MULT}         {return OP_MULT;}
{OP_DIV}          {return OP_DIV;}
{OP_IGUAL}        {return OP_IGUAL;}
{OP_MENOR}        {return OP_MENOR;}
{OP_MENORIGUAL}   {return OP_MENORIGUAL;}
{OP_MAYOR}        {return OP_MAYOR;}
{OP_MAYORIGUAL}   {return OP_MAYORIGUAL;}
{OP_COMP_IGUAL}   {return OP_COMP_IGUAL;}
{OP_NEGACION}     {return OP_NEGACION;}
{OP_DISTINTO}     {return OP_DISTINTO;}

{LLAVE_A}         {return LLAVE_A;}
{LLAVE_C}         {return LLAVE_C;}
{PARENTESIS_A}    {return PARENTESIS_A;}
{PARENTESIS_C}    {return PARENTESIS_C;}
{CORCHETE_A}      {return CORCHETE_A;}
{CORCHETE_C}      {return CORCHETE_C;}

{IF}              {return IF;}
{ELSE}            {return ELSE;}
{WHILE}           {return WHILE;}
{FOR}             {return FOR;}
{INT}             {return INT;}
{FLOAT}           {return FLOAT;}
{STRING}          {return STRING;}
{CHAR}            {return CHAR;}
{PRINT}           {return PRINT;}
{INPUT}           {return INPUT;}
{AND}             {return AND;}
{OR}              {return OR;}
{TRUE}            {return TRUE;}
{FALSE}           {return FALSE;}
{BOOL}            {return BOOL;}
{LIST}            {return LIST;}
{INSERT}          {return INSERT;}
{POP}             {return POP;}

{ID}              {return ID;}

{ESPACIOS}

.               {printf("Error, caracter invalido: %s\n", yytext);}

%%

/*int main(){
    
    char linea[255];
    FILE *archivo = fopen("codigo.txt","r");
    FILE *aux = fopen("tem.txt", "w");
    while(fgets(linea, sizeof(linea), archivo)){
        aux = freopen("tem.txt", "w", aux);
        
        if(linea[strlen(linea)-1] == '\n')
            linea[strlen(linea)-1] = ' ';
        
        printf("\n%s\n\n", linea);
        fprintf(aux, "%s", linea);
        aux = freopen("tem.txt", "r", aux);
        yyin = aux;
        yylex();  
    }
    
    fclose(archivo);
    fclose(aux);
    remove("tem.txt");
    return 0;
}*/