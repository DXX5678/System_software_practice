/* Companion source code for "flex & bison", published by O'Reilly
 * Media, ISBN 978-0-596-15597-1
 * Copyright (c) 2009, Taughannock Networks. All rights reserved.
 * See the README file for license conditions and contact info.
 * $Header: /home/johnl/flnb/code/RCS/fb3-2.y,v 2.1 2009/11/08 02:53:18 johnl Exp $
 */
/* ���ڳ����﷨���ļ����� */
%{
#  include <stdio.h>
#  include <stdlib.h>
#  include "fb3-3.h"
%}
%union {
  struct ast *a;
  double d;
  struct symbol *s;		/* ָ������ */
  struct symlist *sl;
  int fn;			/* ָ������ */
}
/* �����ս�� */
%token <d> NUMBER
%token <s> NAME
%token <fn> FUNC
%token EOL
%token IF THEN WHILE DO LET
%token ELSE
%nonassoc <fn> CMP
/* �������ս�� */
%type <a> exp stmt list explist
%type <sl> symlist
/* �涨���ȼ��ͽ���� */
%right '='
%left '+' '-'
%left '*' '/'
%right '{'
%left '}' 
%nonassoc '|' ';' UMINUS
/*��ʼ����*/
%start calclist
%%
stmt: IF exp THEN list                       { $$ = newflow('I', $2, $4, NULL); }
   | IF exp THEN '{' list '}'                { $$ = newflow('I', $2, $5, NULL); }
   | IF exp THEN list ELSE list  %prec UMINUS            { $$ = newflow('I', $2, $4, $6); }
   | IF exp THEN '{' list '}' ELSE list  %prec UMINUS    { $$ = newflow('I', $2, $5, $8); }
   | IF exp THEN list ELSE '{' list '}'      { $$ = newflow('I', $2, $4, $7); }
   | IF exp THEN '{' list '}' ELSE '{' list '}' %prec UMINUS { $$ = newflow('I', $2, $5, $9); }
   | WHILE exp DO list           { $$ = newflow('W', $2, $4, NULL); }
   | WHILE exp DO '{' list '}'   { $$ = newflow('W', $2, $5, NULL); }
   | exp
   ;
list: /* �� */ { $$ = NULL; }
   | stmt ';' list %prec UMINUS { if ($3 == NULL)
	                    $$ = $1;
                     else
			            $$ = newast('L', $1, $3);
                   }
   | stmt { $$ = $1; }
   ;
exp: exp CMP exp          { $$ = newcmp($2, $1, $3); }
   | exp '+' exp          { $$ = newast('+', $1,$3); }
   | exp '-' exp          { $$ = newast('-', $1,$3);}
   | exp '*' exp          { $$ = newast('*', $1,$3); }
   | exp '/' exp          { $$ = newast('/', $1,$3); }
   | '|' exp              { $$ = newast('|', $2, NULL); }
   | '(' exp ')'          { $$ = $2; }
   | '-' exp %prec UMINUS { $$ = newast('M', $2, NULL); }
   | NUMBER               { $$ = newnum($1); }
   | FUNC '(' explist ')' ';' %prec UMINUS { $$ = newfunc($1, $3); }
   | FUNC '(' explist ')' { $$ = newfunc($1, $3); }
   | NAME                 { $$ = newref($1); }
   | NAME '=' exp         { $$ = newasgn($1, $3); }
   | NAME '(' explist ')' ';' %prec UMINUS { $$ = newcall($1, $3); }
   | NAME '(' explist ')' { $$ = newcall($1, $3); }
   ;
explist: exp
 | exp ',' explist  { $$ = newast('L', $1, $3); }
 ;
symlist: NAME       { $$ = newsymlist($1, NULL); }
 | NAME ',' symlist { $$ = newsymlist($1, $3); }
 ;
calclist: /* �� */
  | calclist stmt EOL {
    if(debug) dumpast($2, 0);
     printf("= %4.4g\n> ", eval($2));
     treefree($2);
    }
  | calclist LET NAME '(' symlist ')' '{' list '}' EOL {
                       dodef($3, $5, $8);
                       printf("Defined %s\n> ", $3->name); }
  | calclist error EOL { yyerrok; printf("> "); }
  ;
%%
