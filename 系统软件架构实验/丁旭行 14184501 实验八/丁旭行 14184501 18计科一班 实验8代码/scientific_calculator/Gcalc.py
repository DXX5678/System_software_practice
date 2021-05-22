# -*- coding: utf-8 -*-

# Form implementation generated from reading ui file 'Gcalc.ui'
#
# Created by: PyQt5 UI code generator 5.9.2
#
# WARNING! All changes made in this file will be lost!

from PyQt5 import QtCore, QtGui, QtWidgets

class Ui_CForm(object):

    def setupUi(self, CForm):
        CForm.setObjectName("CForm")
        CForm.resize(419, 461)
        self.result = QtWidgets.QTextBrowser(CForm)
        self.result.setGeometry(QtCore.QRect(10, 150, 400, 221))
        font = QtGui.QFont()
        font.setPointSize(13)
        self.result.setFont(font)
        self.result.setObjectName("result")
        self.result.setStyleSheet("background:lightblue")
        self.exp = QtWidgets.QTextEdit(CForm)
        self.exp.setGeometry(QtCore.QRect(10, 10, 400, 131))
        font = QtGui.QFont()
        font.setPointSize(13)
        self.exp.setFont(font)
        self.exp.setObjectName("exp")
        self.exp.setStyleSheet("background:lightgray")
        self.equ = QtWidgets.QPushButton(CForm)
        self.equ.setGeometry(QtCore.QRect(20, 390, 171, 61))
        font = QtGui.QFont()
        font.setPointSize(15)
        self.equ.setFont(font)
        self.equ.setObjectName("equ")
        self.cle = QtWidgets.QPushButton(CForm)
        self.cle.setGeometry(QtCore.QRect(230, 390, 171, 61))
        font = QtGui.QFont()
        font.setPointSize(15)
        self.cle.setFont(font)
        self.cle.setObjectName("cle")

        self.retranslateUi(CForm)
        QtCore.QMetaObject.connectSlotsByName(CForm)

    def retranslateUi(self, CForm):
        _translate = QtCore.QCoreApplication.translate
        CForm.setWindowTitle(_translate("CForm", "高级计算器"))
        self.equ.setText(_translate("CForm", "="))
        self.cle.setText(_translate("CForm", "清空"))

