#!/usr/bin/python3
# -*- coding: utf-8 -*-
# 工程:pymat/frac v2.7 alpha

from math import *

def iF(x):
	'''
	分离整数和小数部分
	'''
	if int(x)==x:
		return x,0
	elif x<0:
		zs=int(x)-1
		x=x-zs
		return zs,x
	else:
		zs=int(x)
		x=x-zs
		return zs,x


def frac(y):		
	'''
	将循环小数变成分数,输入小数,返回分子和分母
	'''
	zs,x=iF(y)
	if (x<0.000000001):
		return zs,1		#整数情况

	i=0
	j=0
	ans=0
	while i<=2048:		#大分数拟合意义不大,而且时间过长,忽略
		i=i+1
		j=1
		while j<i:
			ans=j/i
			if ((ans-x<0.000000001) and (x-ans<0.000000001)):
				return (j+zs*i),i	#分子,分母
			j=j+1
	return None,None	#拟合不了,放弃

def ln(x):
	'''
	重新转化ln函数的样子,符合我国的习惯
	'''
	return log(x)


def Factorial(x):
    '''
    阶乘计算
    '''
    i=1
    s=1
    while (i<=x):
        s=s*i
        i=i+1
    return s

'''
def Deg(r):
   return pi*r/180

'''

def Р(n,r):	#注意!这个不是英文字母p,这是俄语字母!
	'''
	排列数
	'''
	pass

def с(n,r):	#注意!这个不是英文字母c,这是俄语字母!
	'''
	组合数
	'''
	pass









