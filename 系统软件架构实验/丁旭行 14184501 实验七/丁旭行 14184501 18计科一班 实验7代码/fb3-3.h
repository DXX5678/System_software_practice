/* Companion source code for "flex & bison", published by O'Reilly
 * Media, ISBN 978-0-596-15597-1
 * Copyright (c) 2009, Taughannock Networks. All rights reserved.
 * See the README file for license conditions and contact info.
 * $Header: /home/johnl/flnb/code/RCS/fb3-2.h,v 2.1 2009/11/08 02:53:18 johnl Exp $
 */
/* fb3-3�߼���������������� */
/* ���ű� */
struct symbol {		
  char *name; /* ������ */
  double value;
  struct ast *func;	/* ������ */
  struct symlist *syms; /* ��ʽ�����б� */
};
/* �̶���С�ļ򵥵ķ��ű� */
#define NHASH 9997

/*���Ų�ѯ������ָ��*/
struct symbol *lookup(char*);
/* �����б���Ϊ�����б� */
struct symlist {
  struct symbol *sym;
  struct symlist *next;
};
/* ���������б� */
struct symlist *newsymlist(struct symbol *sym, struct symlist *next);
/* �ͷŲ����б� */
void symlistfree(struct symlist *sl);
/* �ڵ�����
 *  + - * / |
 *  0-7 �Ƚϲ�����, λ���룺04 ���ڣ�02 С��, 01 ����
 *  M ��Ŀ����
 *  L ���ʽ��������б�
 *  I IF ���
 *  W WHILE ���
 *  N ��������
 *  = ��ֵ
 *  S �����б�
 *  F ���ú�������
 *  C �û���������
 */ 
enum bifs {	  /* ���ú�����ʶ */
  B_sqrt = 1,
  B_exp,
  B_log,
  B_print,
  B_pow
};
/* �����﷨���ڵ� */
/* ���нڵ㶼�й����ĳ�ʼnodetype */
struct ast {
  int nodetype;
  struct ast *l;
  struct ast *r;
};
struct fncall {			/* ���ú��� */
  int nodetype;			/* ���� F */
  struct ast *l;
  enum bifs functype;
};
struct ufncall {		/* �û��Զ��庯�� */
  int nodetype;			/* ���� C */
  struct ast *l;		/* �����б� */
  struct symbol *s;
};
struct flow {           /*�������*/
  int nodetype;			/* ���� I ���� W */
  struct ast *cond;		/* ���� */
  struct ast *tl;		/* then ��֧���� do ����б� */
  struct ast *el;		/* ��ѡ else ��֧ */
};
struct numval {
  int nodetype;			/* ���� K */
  double number;
};
struct symref {
  int nodetype;			/* ���� N */
  struct symbol *s;
};
struct symasgn {
  int nodetype;			/* ���� = */
  struct symbol *s;
  struct ast *v;		/* ֵ */
};
/* ���������﷨�� */
struct ast *newast(int nodetype, struct ast *l, struct ast *r);
struct ast *newcmp(int cmptype, struct ast *l, struct ast *r);
struct ast *newfunc(int functype, struct ast *l);
struct ast *newcall(struct symbol *s, struct ast *l);
struct ast *newref(struct symbol *s);
struct ast *newasgn(struct symbol *s, struct ast *v);
struct ast *newnum(double d);
struct ast *newflow(int nodetype, struct ast *cond, struct ast *tl, struct ast *tr);
/* ���庯�� */
void dodef(struct symbol *name, struct symlist *syms, struct ast *stmts);
/* ��������﷨�� */
double eval(struct ast *);
/* ɾ�����ͷų����﷨�� */
void treefree(struct ast *);
/* ��ʷ��������Ľӿ� */
extern int yylineno; /* ���Դʷ������� */
void yyerror(char *s, ...);
extern int debug;
void dumpast(struct ast *a, int level);

