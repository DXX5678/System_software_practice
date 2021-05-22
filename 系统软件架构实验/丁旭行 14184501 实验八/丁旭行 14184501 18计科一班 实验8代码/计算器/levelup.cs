using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

using System.Windows.Forms;

namespace 计算器
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void bu_clear_Click(object sender, EventArgs e)
        {
            tb_exp.Text = "";
            tb_result.Text = "";
        }

        private void bu_equ_Click(object sender, EventArgs e)
        {
            tb_exp.Text += "\n";
            System.IO.StreamWriter sw = new System.IO.StreamWriter("in.txt");
            sw.Write(tb_exp.Text);
            sw.Close();
            Process pro = new Process();
            pro.StartInfo.FileName = "fb3-3.tab.exe";
            pro.StartInfo.CreateNoWindow = true;
            pro.Start();
            pro.WaitForExit();
            System.IO.StreamReader sr = new System.IO.StreamReader("out.txt");
            tb_result.Text = sr.ReadToEnd();
            sr.Close();
        }
    }
}
