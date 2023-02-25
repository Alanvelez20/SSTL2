
/* A Bison parser, made by GNU Bison 2.4.1.  */

/* Skeleton interface for Bison's Yacc-like parsers in C
   
      Copyright (C) 1984, 1989, 1990, 2000, 2001, 2002, 2003, 2004, 2005, 2006
   Free Software Foundation, Inc.
   
   This program is free software: you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation, either version 3 of the License, or
   (at your option) any later version.
   
   This program is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU General Public License for more details.
   
   You should have received a copy of the GNU General Public License
   along with this program.  If not, see <http://www.gnu.org/licenses/>.  */

/* As a special exception, you may create a larger work that contains
   part or all of the Bison parser skeleton and distribute that work
   under terms of your choice, so long as that work isn't itself a
   parser generator using the skeleton or a modified version thereof
   as a parser skeleton.  Alternatively, if you modify or redistribute
   the parser skeleton itself, you may (at your option) remove this
   special exception, which will cause the skeleton and the resulting
   Bison output files to be licensed under the GNU General Public
   License without this special exception.
   
   This special exception was added by the Free Software Foundation in
   version 2.2 of Bison.  */


/* Tokens.  */
#ifndef YYTOKENTYPE
# define YYTOKENTYPE
   /* Put the tokens into the symbol table, so that GDB and other debuggers
      know about them.  */
   enum yytokentype {
     ENTERO = 258,
     REAL = 259,
     LLAVE_A = 260,
     LLAVE_C = 261,
     PARENTESIS_A = 262,
     PARENTESIS_C = 263,
     CORCHETE_A = 264,
     CORCHETE_C = 265,
     IF = 266,
     ELSE = 267,
     WHILE = 268,
     FOR = 269,
     INT = 270,
     FLOAT = 271,
     STRING = 272,
     CHAR = 273,
     PRINT = 274,
     INPUT = 275,
     AND = 276,
     OR = 277,
     ID = 278,
     TRUE = 279,
     FALSE = 280,
     BOOL = 281,
     LIST = 282,
     INSERT = 283,
     POP = 284,
     OP_SUMA = 285,
     OP_RESTA = 286,
     OP_MULT = 287,
     OP_DIV = 288,
     OP_MENOR = 289,
     OP_MENORIGUAL = 290,
     OP_MAYOR = 291,
     OP_MAYORIGUAL = 292,
     OP_COMP_IGUAL = 293,
     OP_IGUAL = 294,
     OP_NEGACION = 295,
     OP_DISTINTO = 296,
     COMA = 297,
     PUNTOYCOMA = 298,
     CADENA = 299,
     CARACTER = 300,
     GUIONBAJO = 301,
     PUNTO = 302,
     COMENTARIO = 303
   };
#endif



#if ! defined YYSTYPE && ! defined YYSTYPE_IS_DECLARED
typedef int YYSTYPE;
# define YYSTYPE_IS_TRIVIAL 1
# define yystype YYSTYPE /* obsolescent; will be withdrawn */
# define YYSTYPE_IS_DECLARED 1
#endif

extern YYSTYPE yylval;


