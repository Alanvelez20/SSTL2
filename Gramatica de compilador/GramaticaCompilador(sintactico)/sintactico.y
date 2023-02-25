%{
#include <stdio.h>
#include <stdlib.h>

extern int yylex();
extern int yyparse();
extern FILE* yyin;
void yyerror(const char* s);

%}

%token ENTERO
%token REAL

//Delimitadores
%token LLAVE_A LLAVE_C PARENTESIS_A PARENTESIS_C
%token CORCHETE_A CORCHETE_C

//Palabras reservadas
%token IF ELSE WHILE FOR INT FLOAT STRING CHAR PRINT
%token INPUT AND OR ID TRUE FALSE BOOL LIST INSERT POP

//Operadores aritmeticos
%token OP_SUMA OP_RESTA OP_MULT OP_DIV

//Operadores logicos
%token OP_MENOR OP_MENORIGUAL OP_MAYOR OP_MAYORIGUAL 
%token OP_COMP_IGUAL OP_IGUAL OP_NEGACION OP_DISTINTO

//Otros tokens
%token COMA PUNTOYCOMA CADENA CARACTER GUIONBAJO PUNTO COMENTARIO

//Precedencia de operadores 

%left AND OR
%left OP_MENOR OP_MENORIGUAL OP_MAYOR OP_MAYORIGUAL OP_DISTINTO OP_COMP_IGUAL
%left OP_NEGACION

%left OP_SUMA OP_RESTA
%left OP_MULT OP_DIV
 

%start codigo

%%

codigo: 
        | '\n'
        | codigo linea
        | linea
;

linea:    PRINT PARENTESIS_A cadena_io PARENTESIS_C PUNTOYCOMA
        | ID OP_IGUAL INPUT PARENTESIS_A cadena_io PARENTESIS_C PUNTOYCOMA
        | INT ID OP_IGUAL exp_ari PUNTOYCOMA
        | FLOAT ID OP_IGUAL exp_ari_f PUNTOYCOMA
        | STRING ID OP_IGUAL CADENA PUNTOYCOMA
        | CHAR ID OP_IGUAL CARACTER PUNTOYCOMA
        | BOOL ID OP_IGUAL TRUE PUNTOYCOMA
        | BOOL ID OP_IGUAL FALSE PUNTOYCOMA
        | LIST ID OP_IGUAL CORCHETE_A elementos CORCHETE_C PUNTOYCOMA
        | ID PUNTO INSERT CORCHETE_A indice CORCHETE_C OP_IGUAL valor PUNTOYCOMA
        | ID PUNTO POP CORCHETE_A indice CORCHETE_C PUNTOYCOMA
        | IF PARENTESIS_A exp_bool PARENTESIS_C LLAVE_A codigo LLAVE_C 
        | WHILE PARENTESIS_A exp_bool PARENTESIS_C LLAVE_A codigo LLAVE_C 
        | op_inc_dec PUNTOYCOMA
        | FOR PARENTESIS_A ID OP_IGUAL exp_ari PUNTOYCOMA exp_bool PUNTOYCOMA op_inc_dec PARENTESIS_C LLAVE_A codigo LLAVE_C 
;

op_inc_dec:   ID OP_SUMA OP_SUMA
            | ID OP_RESTA OP_RESTA
;

elementos:            
         | ENTERO
         | REAL
         | CADENA
         | elementos COMA elementos
;

indice:   ENTERO
        | ID
;

valor:    ENTERO
        | REAL
        | CADENA
;

cadena_io:  CADENA
          | ID
          | ID CORCHETE_A indice CORCHETE_C
          | cadena_io COMA cadena_io
;

exp_ari:  ENTERO                               //{ $$ = $1; }
        | ID CORCHETE_A indice CORCHETE_C
        | exp_ari OP_SUMA exp_ari              //{ $$ = $1 + $3; }
        | exp_ari OP_RESTA exp_ari             //{ $$ = $1 - $3; }
        | exp_ari OP_MULT exp_ari              //{ $$ = $1 * $3; }
        | exp_ari OP_DIV exp_ari               //{ $$ = $1 / $3; }
        | PARENTESIS_A exp_ari PARENTESIS_C    //{ $$ = $2; }
;

exp_ari_f: REAL
        | ID CORCHETE_A indice CORCHETE_C
        | exp_ari_f OP_SUMA exp_ari_f	         //{ $$ = $1 + $3; }
    	  | exp_ari_f OP_RESTA exp_ari_f	       //{ $$ = $1 - $3; }
    	  | exp_ari_f OP_MULT exp_ari_f          //{ $$ = $1 * $3; }
    	  | exp_ari_f OP_DIV exp_ari_f	         //{ $$ = $1 / $3; }
    	  | PARENTESIS_A exp_ari_f PARENTESIS_C  //{ $$ = $2; }
    	  | exp_ari OP_SUMA exp_ari_f	 	         //{ $ = $1 + $3; }
    	  | exp_ari OP_RESTA exp_ari_f	 	       //{ $$ = $1 - $3; }
    	  | exp_ari OP_MULT exp_ari_f 	         //{ $$ = $1 * $3; }
    	  | exp_ari OP_DIV exp_ari_f	           //{ $$ = $1 / $3; }
    	  | exp_ari_f OP_SUMA exp_ari	 	         //{ $$ = $1 + $3; }
    	  | exp_ari_f OP_RESTA exp_ari	 	       //{ $$ = $1 - $3; }
    	  | exp_ari_f OP_MULT exp_ari 	         // $$ = $1 * $3; }
    	  | exp_ari_f OP_DIV exp_ari	           //{ $$ = $1 / $3; }
;

exp_bool:   exp_ari
          | exp_ari_f
          | ID
          | CARACTER
          | CADENA
          | OP_NEGACION exp_bool
          | exp_bool OP_MAYOR exp_bool
          | exp_bool OP_MAYORIGUAL exp_bool
          | exp_bool OP_MENOR exp_bool
          | exp_bool OP_MENORIGUAL exp_bool
          | exp_bool OP_COMP_IGUAL exp_bool
          | exp_bool OP_DISTINTO exp_bool
          | exp_bool AND exp_bool
          | exp_bool OR exp_bool
          | PARENTESIS_A exp_bool PARENTESIS_C
;

%%

int main(){
    yyin = fopen("codigo.txt", "r");
    if(yyparse() == 0)
    {
        printf("Sintaxis correcta!\n");
    }
    else
    {
        printf("Sintaxis incorrecta\n");
    }
    system("pause");
    return 0;
}

void yyerror(const char* s) {
    //printf("Parse error: %s\n", s);

}