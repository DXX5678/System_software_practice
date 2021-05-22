%{
int yylex();
int yyerror(char*);
#include <stdio.h>
#include <string.h>
#define YYSTYPE char*
%}
%token NAME EQ AGE
%%
file: record | record file
		;
record: NAME EQ AGE {printf("%s is %s years old!!!\n",$1,$3);}
		;
%%
int main()
{
	yyparse();
	return 0;
}
int yyerror(char* msg)
{
	printf("Error encountered: %s\n",msg);
	return 0;
}