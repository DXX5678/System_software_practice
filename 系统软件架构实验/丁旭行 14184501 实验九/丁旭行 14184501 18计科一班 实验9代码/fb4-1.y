
/* Companion source code for "flex & bison", published by O'Reilly
 * Media, ISBN 978-0-596-15597-1
 * Copyright (c) 2009, Taughannock Networks. All rights reserved.
 * See the README file for license conditions and contact info.
 * $Header: /home/johnl/flnb/code/RCS/fb3-2.y,v 2.1 2009/11/08 02:53:18 johnl Exp $
 */
/* calculator with AST */

%{
#  include <stdio.h>
#  include <stdlib.h>
#  include "fb4-1.h"
extern int yylex();
extern int yyparse();
extern FILE *yyout;
%}

%union {
  struct ast *a;
  double d;
  struct symbol *s;		/* which symbol */
  int fn;			/* which function */
}

/* declare tokens */
%token <d> NUMBER
%token <s> NAME
%token <fn> FUNC
%token INTT 
%token MAIN



%right '='
%left '+' '-'
%left '*' '/'
%nonassoc '|' UMINUS

%nonassoc lower_then_fenhao
%nonassoc ';'

%type <a> exp stmt list explist

%start calclist

%%
stmt: /* nothing */ { $$ = NULL; }
   |  list '}' { $$ = $1; }
   ;

list: /* nothing */ { $$ = NULL; }
   |  exp ';' list    { if ($3 == NULL)
	                $$ = $1;
                      else
			$$ = newast('L', $1, $3);
                    }

   ;


exp: exp '+' exp          { $$ = newast('+', $1,$3); }
   | exp '-' exp          { $$ = newast('-', $1,$3);}
   | exp '*' exp          { $$ = newast('*', $1,$3); }
   | exp '/' exp          { $$ = newast('/', $1,$3); }
   | '|' exp              { $$ = newast('|', $2, NULL); }
   | '(' exp ')'          { $$ = $2; }
   | '-' exp %prec UMINUS { $$ = newast('M', $2, NULL); }
   | NUMBER               { $$ = newnum($1); }
   | FUNC '(' explist ')' { $$ = newfunc($1, $3); }
   | NAME                 { $$ = newref($1); }
   | NAME '=' exp         { $$ = newasgn($1, $3); }
;

explist: exp
 | exp ',' explist  { $$ = newast('L', $1, $3); }
;

calclist: /* nothing */{}
  | calclist INTT MAIN '(' ')' '{' stmt  {
      initt();
      if(debug) dumpast($7, 0);
      else {
         eval($7);
         treefree($7);
         FILE *fwritez = fopen("temp.txt","a+");
         fprintf(fwritez, "\n");
         fclose(fwritez);
      }
   }
  | calclist error { yyerrok; fprintf(yyout," "); }
 ;
%%
