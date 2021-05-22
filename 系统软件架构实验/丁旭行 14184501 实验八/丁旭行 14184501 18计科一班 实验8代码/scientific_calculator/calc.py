#!/usr/bin/python3
# -*- coding: utf-8 -*-
#nwu/sist developed
#ngc1300@stumail.nwu.edu.cn
#PS >  pyinstaller -w -F calc.py -i D:\程序源代码\Qt\calculator\nano_icon_pack_6~1.ico

#import threading
import ctypes
from ctypes import *
from calcGui import Ui_MainWindow
from PyQt5.QtCore import *
from PyQt5.QtGui import *
from PyQt5.QtWidgets import *
import sys
from frac import *
import aboutGUI
import helpGUI
from Gcalc import Ui_CForm


global Ans,N2Dresult
Ans=0
N2Dresult = ""

class gjjsq(QWidget,Ui_CForm):

    def llink(self):
        self.cle.clicked.connect(lambda:self.clearq())
        self.equ.clicked.connect(lambda:self.dengyu())

    def clearq(self):
        self.exp.setText("")
        self.result.setText("")

    def dengyu(self):
        text=self.exp.toPlainText()
        text+="\n"
        fp=open("./in.txt",mode='w')
        fp.write(text)
        fp.close()
        cur = cdll.LoadLibrary("./calc.dll")
        cur.calc()
        fp2=open("./out.txt",'r')
        number=fp2.readline()
        self.result.setText(number)
        fp2.close()



    def __init__(self,parent=None):
        super(gjjsq,self).__init__(parent)
        self.setupUi(self)
        self.llink()




class calc(QMainWindow,Ui_MainWindow):

    def link(self):
        self.pb1.clicked.connect(lambda:self.be("1"))
        self.pb2.clicked.connect(lambda:self.be("2"))
        self.pb3.clicked.connect(lambda:self.be("3"))
        self.pb4.clicked.connect(lambda:self.be("4"))
        self.pb5.clicked.connect(lambda:self.be("5"))
        self.pb6.clicked.connect(lambda:self.be("6"))
        self.pb7.clicked.connect(lambda:self.be("7"))
        self.pb8.clicked.connect(lambda:self.be("8"))
        self.pb9.clicked.connect(lambda:self.be("9"))
        self.pb0.clicked.connect(lambda:self.be("0"))
        self.pbDot.clicked.connect(lambda:self.be("."))
        self.pbMul.clicked.connect(lambda:self.be("×"))
        self.pbDvd.clicked.connect(lambda:self.be("/"))
        self.pbAdd.clicked.connect(lambda:self.be("+"))
        self.pbMin.clicked.connect(lambda:self.be("-"))
        self.pbPwr.clicked.connect(lambda:self.be("^"))
        self.pbMod.clicked.connect(lambda:self.be("%"))
        self.pbSqrt.clicked.connect(lambda:self.be("√("))
        self.pbLkh.clicked.connect(lambda:self.be("("))
        self.pbRkh.clicked.connect(lambda:self.be(")"))
        self.pbClear.clicked.connect(lambda:self.clear())
        self.pbDel.clicked.connect(lambda:self.delete())
        self.pbEnter.clicked.connect(lambda:self.Enter())
        self.pbAns.clicked.connect(lambda:self.putAns())
        self.pbClearHistory.clicked.connect(lambda:self.clearHistory())
        self.pbSqr.clicked.connect(lambda:self.be("^2"))
        self.pb1Dx.clicked.connect(lambda:self.be("1/"))
        self.pbAbs.clicked.connect(lambda:self.be("abs("))
        self.pbLn.clicked.connect(lambda:self.be("ln("))
        self.pbE.clicked.connect(lambda:self.be("е"))
        self.pbPi.clicked.connect(lambda:self.be("π"))
        self.pbSin.clicked.connect(lambda:self.be("sin("))
        self.pbCos.clicked.connect(lambda:self.be("cos("))
        self.pbTan.clicked.connect(lambda:self.be("tan("))
        self.pbJC.clicked.connect(lambda:self.be("Factorial("))
        self.pbDegree.clicked.connect(lambda:self.be("°"))
        self.pbI.clicked.connect(lambda:self.be("j"))
        self.Qgj.triggered.connect(lambda:self.gj())
        self.Qhelp.triggered.connect(lambda:self.help())
        self.Qabout.triggered.connect(lambda:self.about())

    def __init__(self, parent=None):
        super(calc,self).__init__(parent)
        self.setupUi(self)
        self.link()
        self.history.setText("----历史区----")
        self.zck=gjjsq()

    def gj(self):
        self.zck.show()

    def be(self,x):
        txt=self.inputBox.toPlainText()
        txt=txt+x
        self.inputBox.setText(str(txt))

    def clear(self):
        self.inputBox.setText("")
        self.NDbox.setText(" ")

    def delete(self):
        t=self.inputBox.toPlainText()
        t=t[:len(t)-1]
        self.inputBox.setText(t)

    def putAns(self):
        txt=self.inputBox.toPlainText()
        txt=txt+"Ans"
        self.inputBox.setText(str(txt))

    def clearHistory(self):
        self.history.setText("----历史区----")
        

    def help(self):
        #self.hlp=helpGUI.Ui_Dialog()
        self.hlp=QDialog()
        h=helpGUI.Ui_Dialog()
        h.setupUi(self.hlp)
        self.hlp.show()

    def about(self):
        self.abt=QDialog()
        a=aboutGUI.Ui_Dialog()
        a.setupUi(self.abt)
        self.abt.show()


    def Enter(self):
        global Ans
        text=self.inputBox.toPlainText()
        text=text.replace("×","*")
        text=text.replace("^","**")
        text=text.replace("√(","sqrt(")
        text=text.replace("π","3.141592653589793")
        text=text.replace("°","*pi/180")
        text=text.replace("е","2.718281828459045")
            #注意!这个е是俄文字母,不是英语!为了在替换时不会换掉其他的地方.造成麻烦.
        try:
            global Ans
            temp=eval(text)
            Ans=temp
            temp=str(temp)
        except BaseException:
            temp='oops!出错了.....'
        
        temp=temp.replace("j","i")
        t=self.inputBox.toPlainText()+'\n =  '+temp
        self.inputBox.setText(t)
        ngc=self.history.toPlainText()
        ngc=ngc+'\n'+t
        self.history.setText(ngc)

        self.NDbox.setText("计算中...")

        if Ans.imag==0:
            a,b=frac(Ans)
            if b==1:
                fract="Ans →\n {}".format(a)
            elif a!=None:
                fract="Ans →\n {} / {}".format(a,b)
            else:
                fract="Ans →\n {:.7f}".format(Ans)
            self.NDbox.setText(fract)
        else:
            a,b=frac(Ans.real)
            c,d=frac(Ans.imag)
            if b==1:
                text1=str(a)
            elif a!=None:
                text1=str(a)+'/'+str(b)
            else:
                text1="{:.4f}".format(Ans.real)

            if d==1:
                text2=str(c)
            elif c!=None:
                text2=str(c)+'/'+str(d)
            else:
                text2="{:.4f}".format(Ans.imag)

            if (Ans.imag<(-0.000001)):
                text0="Ans →\n"+text1+text2+' i'
            else:
                text0="Ans →\n"+text1+"+"+text2+' i'

            self.NDbox.setText(text0)
            


if __name__ == "__main__":
    app = QApplication([])
    window = calc()
    window.show()
    sys.exit(app.exec_())

