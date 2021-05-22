using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Text.RegularExpressions;


namespace 计算器
{
    public partial class Form_Main : Form
    {
        Boolean flag = true;
        object a = null;
        String str1 = "";
        String ans = "";
        Stack st1 = new Stack();
        Stack st2 = new Stack();
        public Boolean Priority(String ch1,String ch2)
        {
            int code1=0, code2=0;
            switch(ch1)
            {
                case "(":
                    code1 = 1;
                    break;
                case "+":
                case "-":
                    code1 = 2;
                    break;
                case "×":
                case "÷":
                case "%":
                    code1 = 3;
                    break;
                case "√":
                case "/":
                case "sin":
                case "cos":
                case "tan":
                case "ln":
                    code1 = 4;
                    break;
            }
            switch (ch2)
            {
                case "(":
                    code2 = 1;
                    break;
                case "+":
                case "-":
                    code2 = 2;
                    break;
                case "×":
                case "÷":
                case "%":
                    code2 = 3;
                    break;
                case "√":
                case "/":
                case "sin":
                case "cos":
                case "tan":
                case "ln":
                    code2 = 4;
                    break;
            }
            if (code1 > code2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string splitFunc(string tmp)  
        {
            string sRet = tmp;
            sRet = sRet.Replace("=", "\n=\n");
            sRet = sRet.Replace("+", "\n+\n");
            sRet = sRet.Replace("-", "\n-\n");
            sRet = sRet.Replace("×", "\n×\n");
            sRet = sRet.Replace("÷", "\n÷\n");
            sRet = sRet.Replace("(", "\n(\n");
            sRet = sRet.Replace(")", "\n)\n");
            sRet = sRet.Replace("%", "\n%\n");
            sRet = sRet.Replace("√", "\n√\n");
            sRet = sRet.Replace("/", "\n/\n");
            sRet = sRet.Replace("sin", "\nsin\n");
            sRet = sRet.Replace("cos", "\ncos\n");
            sRet = sRet.Replace("tan", "\ntan\n");
            sRet = sRet.Replace("ln", "\nln\n");
            return sRet;
        }
        public bool isNumber(string tmp)
        {
            return Regex.IsMatch(tmp, @"[0-9]+[.]{0,1}[0-9]*"); 
        }
        public void Change()
        {
            st1.Push(a);
            String str = txtDisplay.Text;
            string[] sz = splitFunc(str).Split('\n');


            for (int i = 0; i <= sz.Length - 1; ++i)
            {
                if (string.IsNullOrEmpty(sz[i]))                        
                    continue;
                else if (isNumber(sz[i]))                     
                    str1 += sz[i] + ',';
                else
                {
                    switch (sz[i])
                    {
                        case "/":
                            if (st1.Count == 0)
                            {
                                st1.Push(sz[i]);
                            }
                            else
                            {
                                String ch = (String)st1.Peek();
                                if (ch != "(")
                                {
                                    if (Priority(sz[i], ch))
                                    {
                                        st1.Push(sz[i]);
                                    }
                                    else
                                    {
                                        while (!Priority(sz[i], ch))
                                        {
                                            str1 += st1.Pop();
                                            str1 += ',';
                                            ch = (String)st1.Peek();
                                            if (ch == "(" || ch == null)
                                                break;
                                        }
                                        st1.Push(sz[i]);
                                    }
                                }
                                else
                                {
                                    st1.Push(sz[i]);
                                }
                            }
                            break;
                        case "√":
                            if (st1.Count == 0)
                            {
                                st1.Push(sz[i]);
                            }
                            else
                            {
                                String ch = (String)st1.Peek();
                                if (ch != "(")
                                {
                                    if (Priority(sz[i], ch))
                                    {
                                        st1.Push(sz[i]);
                                    }
                                    else
                                    {
                                        while (!Priority(sz[i], ch))
                                        {
                                            str1 += st1.Pop();
                                            str1 += ',';
                                            ch = (String)st1.Peek();
                                            if (ch == "(" || ch == null)
                                                break;
                                        }
                                        st1.Push(sz[i]);
                                    }
                                }
                                else
                                {
                                    st1.Push(sz[i]);
                                }
                            }
                            break;
                        case "sin":
                            if (st1.Count == 0)
                            {
                                st1.Push(sz[i]);
                            }
                            else
                            {
                                String ch = (String)st1.Peek();
                                if (ch != "(")
                                {
                                    if (Priority(sz[i], ch))
                                    {
                                        st1.Push(sz[i]);
                                    }
                                    else
                                    {
                                        while (!Priority(sz[i], ch))
                                        {
                                            str1 += st1.Pop();
                                            str1 += ',';
                                            ch = (String)st1.Peek();
                                            if (ch == "(" || ch == null)
                                                break;
                                        }
                                        st1.Push(sz[i]);
                                    }
                                }
                                else
                                {
                                    st1.Push(sz[i]);
                                }
                            }
                            break;
                        case "cos":
                            if (st1.Count == 0)
                            {
                                st1.Push(sz[i]);
                            }
                            else
                            {
                                String ch = (String)st1.Peek();
                                if (ch != "(")
                                {
                                    if (Priority(sz[i], ch))
                                    {
                                        st1.Push(sz[i]);
                                    }
                                    else
                                    {
                                        while (!Priority(sz[i], ch))
                                        {
                                            str1 += st1.Pop();
                                            str1 += ',';
                                            ch = (String)st1.Peek();
                                            if (ch == "(" || ch == null)
                                                break;
                                        }
                                        st1.Push(sz[i]);
                                    }
                                }
                                else
                                {
                                    st1.Push(sz[i]);
                                }
                            }
                            break;
                        case "tan":
                            if (st1.Count == 0)
                            {
                                st1.Push(sz[i]);
                            }
                            else
                            {
                                String ch = (String)st1.Peek();
                                if (ch != "(")
                                {
                                    if (Priority(sz[i], ch))
                                    {
                                        st1.Push(sz[i]);
                                    }
                                    else
                                    {
                                        while (!Priority(sz[i], ch))
                                        {
                                            str1 += st1.Pop();
                                            str1 += ',';
                                            ch = (String)st1.Peek();
                                            if (ch == "(" || ch == null)
                                                break;
                                        }
                                        st1.Push(sz[i]);
                                    }
                                }
                                else
                                {
                                    st1.Push(sz[i]);
                                }
                            }
                            break;
                        case "ln":
                            if (st1.Count == 0)
                            {
                                st1.Push(sz[i]);
                            }
                            else
                            {
                                String ch = (String)st1.Peek();
                                if (ch != "(")
                                {
                                    if (Priority(sz[i], ch))
                                    {
                                        st1.Push(sz[i]);
                                    }
                                    else
                                    {
                                        while (!Priority(sz[i], ch))
                                        {
                                            str1 += st1.Pop();
                                            str1 += ',';
                                            ch = (String)st1.Peek();
                                            if (ch == "(" || ch == null)
                                                break;
                                        }
                                        st1.Push(sz[i]);
                                    }
                                }
                                else
                                {
                                    st1.Push(sz[i]);
                                }
                            }
                            break;
                        case "+":     
                            if (st1.Count==0)
                            {
                                st1.Push(sz[i]);
                            }
                            else
                            {
                                String ch = (String)st1.Peek();
                                if (ch != "(")
                                {
                                    if (Priority(sz[i], ch))
                                    {
                                        st1.Push(sz[i]);
                                    }
                                    else
                                    {
                                        while (!Priority(sz[i], ch))
                                        {
                                            str1 += st1.Pop();
                                            str1 += ',';
                                            ch = (String)st1.Peek();
                                            if (ch == "(" || ch == null)
                                                break;
                                        }
                                        st1.Push(sz[i]);
                                    }
                                }
                                else
                                {
                                    st1.Push(sz[i]);
                                }
                            }
                            break;
                        case "-":
                            if (st1.Count==0)
                            {
                                st1.Push(sz[i]);
                            }
                            else
                            {
                                String ch = (String)st1.Peek();
                                if (ch != "(")
                                {
                                    if (Priority(sz[i], ch))
                                    {
                                        st1.Push(sz[i]);
                                    }
                                    else
                                    {
                                        while (!Priority(sz[i], ch))
                                        {
                                            str1 += st1.Pop(); 
                                            str1 += ',';
                                            ch = (String)st1.Peek();
                                            if (ch == "(" || ch == null)
                                                break;
                                        }
                                        st1.Push(sz[i]);
                                    }
                                }
                                else
                                {
                                    st1.Push(sz[i]);
                                }
                            }
                            break;
                        case "×":
                            if (st1.Count==0)
                            {
                                st1.Push(sz[i]);
                            }
                            else
                            {
                                String ch = (String)st1.Peek();
                                if (ch != "(")
                                {
                                    if (Priority(sz[i], ch))
                                    {
                                        st1.Push(sz[i]);
                                    }
                                    else
                                    {
                                        while (!Priority(sz[i], ch))
                                        {
                                            str1 += st1.Pop(); 
                                            str1 += ',';
                                            ch = (String)st1.Peek();
                                            if (ch == "(" || ch == null)
                                                break;
                                        }
                                        st1.Push(sz[i]);
                                    }
                                }
                                else
                                {
                                    st1.Push(sz[i]);
                                }
                            }
                            break;
                        case "÷":
                            if (st1.Count==0)
                            {
                                st1.Push(sz[i]);
                            }
                            else
                            {
                                String ch = (String)st1.Peek();
                                if (ch != "(")
                                {
                                    if (Priority(sz[i], ch))
                                    {
                                        st1.Push(sz[i]);
                                    }
                                    else
                                    {
                                        while (!Priority(sz[i], ch))
                                        {
                                            str1 += st1.Pop();
                                            str1 += ',';
                                            ch = (String)st1.Peek();
                                            if (ch == "(" || ch == null)
                                                break;
                                        }
                                        st1.Push(sz[i]);
                                    }
                                }
                                else
                                {
                                    st1.Push(sz[i]);
                                }
                            }
                            break;
                        case "%":
                            if (st1.Count == 0)
                            {
                                st1.Push(sz[i]);
                            }
                            else
                            {
                                String ch = (String)st1.Peek();
                                if (ch != "(")
                                {
                                    if (Priority(sz[i], ch))
                                    {
                                        st1.Push(sz[i]);
                                    }
                                    else
                                    {
                                        while (!Priority(sz[i], ch))
                                        {
                                            str1 += st1.Pop();
                                            str1 += ',';
                                            ch = (String)st1.Peek();
                                            if (ch == "(" || ch == null)
                                                break;
                                        }
                                        st1.Push(sz[i]);
                                    }
                                }
                                else
                                {
                                    st1.Push(sz[i]);
                                }
                            }
                            break;
                        case "(":              
                            st1.Push(sz[i]);
                            break;
                        case ")":             
                            if (!(st1.Count==0))
                            {
                                String ch = (String)st1.Peek();
                                while (ch != "(")
                                {
                                    str1 += st1.Pop(); 
                                    str1 += ',';
                                    ch = (String)st1.Peek();
                                }
                                st1.Pop();
                            }
                            break;
                    }
                }

            }
            while (!(st1.Count==0))    
            {
                str1 += st1.Pop(); 
                str1 += ',';
            }
            //txtDisplay.Text = str1;
        }
        public void Compute()
        {
            string[] sz = str1.Split(',');
            for(int i=0;i<=sz.Length-2;i++)
            {
                if (isNumber(sz[i]))
                {
                    st2.Push(sz[i]);
                }
                else
                {
                    double num1 = 0;
                    double num2 = 0;
                    switch (sz[i])
                    {
                        case "/":
                            num1 = Convert.ToDouble(st2.Pop());
                            st2.Push(1 / num1);
                            break;
                        case "√":
                            num1 = Convert.ToDouble(st2.Pop());
                            st2.Push(Math.Sqrt(num1));
                            break;
                        case "sin":
                            num1 = Convert.ToDouble(st2.Pop());
                            st2.Push(Math.Sin(num1));
                            break;
                        case "cos":
                            num1 = Convert.ToDouble(st2.Pop());
                            st2.Push(Math.Cos(num1));
                            break;
                        case "tan":
                            num1 = Convert.ToDouble(st2.Pop());
                            st2.Push(Math.Tan(num1));
                            break;
                        case "ln":
                            num1 = Convert.ToDouble(st2.Pop());
                            if (num1 == 0)
                                throw new Exception();
                            st2.Push(Math.Log(num1));
                            break;
                        case "+":
                            num1 = Convert.ToDouble(st2.Pop());
                            num2 = Convert.ToDouble(st2.Pop());
                            st2.Push(num2 + num1);
                            break;
                        case "-":
                            num1 = Convert.ToDouble(st2.Pop());
                            num2 = Convert.ToDouble(st2.Pop());
                            st2.Push(num2 - num1);
                            break;
                        case "×":
                            num1 = Convert.ToDouble(st2.Pop());
                            num2 = Convert.ToDouble(st2.Pop());
                            st2.Push(num2 * num1);
                            break;
                        case "÷":
                            num1 = Convert.ToDouble(st2.Pop());
                            num2 = Convert.ToDouble(st2.Pop());
                            if (num1 == 0)
                                throw new Exception();
                            st2.Push(num2 / num1);
                            break;
                        case "%":
                            num1 = Convert.ToDouble(st2.Pop());
                            num2 = Convert.ToDouble(st2.Pop());
                            st2.Push(num2 % num1);
                            break;
                    }
                }
            }
            ans = Convert.ToString(st2.Peek());
            txtDisplay.Text =Convert.ToString(st2.Pop());
        }
        public Form_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!flag)
            {
                txtDisplay.Text = "";
                flag = true;
            }
            txtDisplay.Text += "8";
        }

        private void btn_sqrt_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                flag = true;
            }
            txtDisplay.Text += "√";
        }

        private void btn_point_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                txtDisplay.Text = "";
                flag = true;
            }
            if (string.IsNullOrEmpty(txtDisplay.Text))
            {
                txtDisplay.Text = "0.0";
            }
            else if(!txtDisplay.Text.Contains("."))
            {
                txtDisplay.Text += ".";
            }
        }

        private void btn_0_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                txtDisplay.Text = "";
                flag = true;
            }
            txtDisplay.Text += "0";
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                txtDisplay.Text = "";
                flag = true;
            }
            txtDisplay.Text += "1";
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                txtDisplay.Text = "";
                flag = true;
            }
            txtDisplay.Text += "2";
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                txtDisplay.Text = "";
                flag = true;
            }
            txtDisplay.Text += "3";
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                txtDisplay.Text = "";
                flag = true;
            }
            txtDisplay.Text += "4";
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                txtDisplay.Text = "";
                flag = true;
            }
            txtDisplay.Text += "5";
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                txtDisplay.Text = "";
                flag = true;
            }
            txtDisplay.Text += "6";
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                txtDisplay.Text = "";
                flag = true;
            }
            txtDisplay.Text += "7";
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                txtDisplay.Text = "";
                flag = true;
            }
            txtDisplay.Text += "9";
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            flag = true;
            txtDisplay.Text = "";
            st1.Clear();
            st2.Clear();
            str1 = "";
        }

        private void btn_backspace_Click(object sender, EventArgs e)
        {
            try
            {
                txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
            }
            catch(Exception)
            {
                MessageBox.Show("已经为空，无法再退格了！", "错误", MessageBoxButtons.OK);
            }
        }

        private void btn_zuo_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                flag = true;
            }
            txtDisplay.Text += "(";
        }

        private void btn_you_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                flag = true;
            }
            txtDisplay.Text += ")";
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                flag = true;
            }
            txtDisplay.Text += "+";
        }

        private void btn_sub_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                flag = true;
            }
            txtDisplay.Text += "-";
        }

        private void btn_multi_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                flag = true;
            }
            txtDisplay.Text += "×";
        }

        private void btn_div_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                flag = true;
            }
            txtDisplay.Text += "÷";
        }

        private void btn_left_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                flag = true;
            }
            txtDisplay.Text += "%";
        }

        private void btn_res_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                flag = true;
            }
            txtDisplay.Text += "/";
        }

        private void btn_equal_Click(object sender, EventArgs e)
        {
            try
            {
                flag = false;
                txtDisplay.Text += "=";
                Change();
                Compute();
            }
            catch (Exception)
            {
                flag = true;
                txtDisplay.Text = "";
                st1.Clear();
                st2.Clear();
                str1 = "";
                MessageBox.Show("算式输入不规范，请重新输入。", "错误", MessageBoxButtons.OK);
            }
        }

        private void btn_ans_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = ans;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                flag = true;
            }
            txtDisplay.Text += "cos";
        }

        private void btn_sin_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                flag = true;
            }
            txtDisplay.Text += "sin";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                flag = true;
            }
            txtDisplay.Text += "tan";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!flag)
            {
                flag = true;
            }
            txtDisplay.Text += "ln";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form=new Form2();
            form.ShowDialog();
        }
    }
}
