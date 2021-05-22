 /*定义段作全局声明，定义词法分析所要求的变量*/
%{
#include <stdio.h>
int nchar; /*定义整型变量nchar为字符数*/
int nword; /*定义整型变量nword为单词数*/
int nline; /*定义整型变量nline为行数*/
int line=1; /*定义整型变量line为当前行数，初始化其值为1*/
void commend(void); /*关于注释函数的预先声明*/
%}
 /*用正则表达式完成模式宏定义*/
 /*定义字母letter*/
letter [A-Za-z\_]
 /*定义数字digit*/
digit [0-9] 
 /*定义ID由一个或多个letter组成*/
ID {letter}({letter})* 
 /*定义NUM由一个或多个digit组成*/
NUM {digit}({digit})* 
 /*定义B由至少一个letter后接零个或多个digit或letter组成*/
B {letter}({digit}|{letter})* 
 /*规则段说明模式匹配的规则以及相应的动作，段与段之间用%%隔开*/
%%
"else"|"if"|"switch"|"for"|"int"|"float"|"return"|"void"|"while"|"else if"|"include"|"iostream"|"using"|"namespace"|"std"|"main"|"cout"|"endl" {nword++;nchar+=yyleng;printf("第%d行：\t",line);printf("关键字：%s\n",yytext);fprintf(yyout,"第%d行：\t",line);fprintf(yyout,"关键字：%s\n",yytext);} /*处理关键字并显示*/
{B} {nword++;nchar+=yyleng;printf("第%d行：\t",line);printf("标识符：%s\n",yytext);fprintf(yyout,"第%d行：\t",line);fprintf(yyout,"标识符：%s\n",yytext);} /*处理标识符并显示*/
{NUM} {nword++;nchar+=yyleng;printf("第%d行：\t",line);printf("数字：%s\n",yytext);fprintf(yyout,"第%d行：\t",line);fprintf(yyout,"数字：%s\n",yytext);} /*处理数字并显示*/
\/\* {nchar+=yyleng;printf("第%d行：\t",line);printf("专用符号：%s\n",yytext);fprintf(yyout,"第%d行：\t",line);fprintf(yyout,"专用符号：%s\n",yytext);commend();} /*处理/*符号并显示，调用commend()函数*/
\+|\-|\*|\/|\<|\>|\=|\;|\,|\(|\)|\[|\]|\{|\}|\<\=|\>\=|\<\=|\>\=|\=\=|\!\= {nchar+=yyleng;printf("第%d行：\t",line);printf("专用符号：%s\n",yytext);fprintf(yyout,"第%d行：\t",line);fprintf(yyout,"专用符号：%s\n",yytext);} /*处理专用符号并显示*/
\!|\"|\#|\. {nchar+=yyleng;printf("第%d行：\t",line);printf("其他符号：%s\n",yytext);fprintf(yyout,"第%d行：\t",line);fprintf(yyout,"其他符号：%s\n",yytext);} /*处理其他符号并显示*/
[" "\t]+ {nchar++;} /*处理空格*/
\n {nline++;line++;nchar++;} /*处理换行符*/
%%
 /*用户代码段，定义在规则段中使用的辅助函数以及主程序入口*/
void main() /*主程序入口*/
{
	yyout=fopen("result.txt","w");
	yylex(); /*调用yylex()函数进行词法分析，它由Lex自动生成*/
	printf("字符数：%d\t 单词数：%d\t 行数：%d\n",nchar,nword,nline); /*打印字符数、单词数、行数*/
	fprintf(yyout,"字符数：%d\t 单词数：%d\t 行数：%d\n",nchar,nword,nline);
	fclose(yyout);
}
int yywrap() /*这一函数在输入(或文件)的末尾处调用，如果返回值为1，就停止解析*/
{
	return 1;
}
void commend(void) /*用于注释处理的用户自定义函数*/
{
	printf("注释：");
	fprintf(yyout,"注释：");
	char c=input();
	char prev=c;
	while((c=input())!=0)
	{
		if(c=='/'&&prev=='*')
			{
				printf("\n");
				fprintf(yyout,"\n");
				printf("第%d行：\t",line);
				fprintf(yyout,"第%d行：\t",line);
				printf("专用符号：%s\n","*/");
				fprintf(yyout,"专用符号：%s\n","*/");
				return;
			}
		if(prev=='\n')
			{
				nchar++;
				line++;
				nline++;
			}
		else
			{
				printf("%c",prev);
				fprintf(yyout,"%c",prev);			
			}
		prev=c;
	}
	printf("unterminated comment");
}
