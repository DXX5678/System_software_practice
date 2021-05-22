
namespace 计算器
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bu_equ = new System.Windows.Forms.Button();
            this.bu_clear = new System.Windows.Forms.Button();
            this.tb_exp = new System.Windows.Forms.TextBox();
            this.tb_result = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bu_equ
            // 
            this.bu_equ.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bu_equ.Location = new System.Drawing.Point(12, 384);
            this.bu_equ.Name = "bu_equ";
            this.bu_equ.Size = new System.Drawing.Size(139, 53);
            this.bu_equ.TabIndex = 0;
            this.bu_equ.Text = "=";
            this.bu_equ.UseVisualStyleBackColor = true;
            this.bu_equ.Click += new System.EventHandler(this.bu_equ_Click);
            // 
            // bu_clear
            // 
            this.bu_clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bu_clear.Location = new System.Drawing.Point(157, 384);
            this.bu_clear.Name = "bu_clear";
            this.bu_clear.Size = new System.Drawing.Size(139, 53);
            this.bu_clear.TabIndex = 1;
            this.bu_clear.Text = "清空";
            this.bu_clear.UseVisualStyleBackColor = true;
            this.bu_clear.Click += new System.EventHandler(this.bu_clear_Click);
            // 
            // tb_exp
            // 
            this.tb_exp.Location = new System.Drawing.Point(12, 114);
            this.tb_exp.Multiline = true;
            this.tb_exp.Name = "tb_exp";
            this.tb_exp.Size = new System.Drawing.Size(284, 264);
            this.tb_exp.TabIndex = 3;
            // 
            // tb_result
            // 
            this.tb_result.BackColor = System.Drawing.SystemColors.Info;
            this.tb_result.Location = new System.Drawing.Point(12, 12);
            this.tb_result.Multiline = true;
            this.tb_result.Name = "tb_result";
            this.tb_result.ReadOnly = true;
            this.tb_result.Size = new System.Drawing.Size(284, 96);
            this.tb_result.TabIndex = 4;
            this.tb_result.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 445);
            this.Controls.Add(this.tb_result);
            this.Controls.Add(this.tb_exp);
            this.Controls.Add(this.bu_clear);
            this.Controls.Add(this.bu_equ);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "高级版计算器";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bu_equ;
        private System.Windows.Forms.Button bu_clear;
        private System.Windows.Forms.TextBox tb_exp;
        private System.Windows.Forms.TextBox tb_result;
    }
}