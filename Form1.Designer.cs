﻿namespace My.RabbitMQ
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.tbSend = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tbReceive = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.uniConnection1 = new Devart.Data.Universal.UniConnection();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.oracleConnection1 = new Devart.Data.Oracle.OracleConnection();
            this.sqlConnection1 = new Devart.Data.SqlServer.SqlConnection();
            ((System.ComponentModel.ISupportInitialize)(this.uniConnection1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(76, 92);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // tbSend
            // 
            this.tbSend.Location = new System.Drawing.Point(76, 156);
            this.tbSend.Multiline = true;
            this.tbSend.Name = "tbSend";
            this.tbSend.Size = new System.Drawing.Size(229, 75);
            this.tbSend.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(496, 83);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "receive";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // tbReceive
            // 
            this.tbReceive.Location = new System.Drawing.Point(496, 156);
            this.tbReceive.Multiline = true;
            this.tbReceive.Name = "tbReceive";
            this.tbReceive.Size = new System.Drawing.Size(263, 86);
            this.tbReceive.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(185, 92);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(634, 82);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // uniConnection1
            // 
            this.uniConnection1.ConnectionString = "provider=Oracle;User Id=smart;Password=smart;Server=121.40.101.29;Direct=True;Por" +
    "t=1521;Sid=orcl;";
            this.uniConnection1.Name = "uniConnection1";
            this.uniConnection1.Owner = this;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(76, 370);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 6;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(212, 370);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 7;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(433, 369);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 8;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.Button7_Click);
            // 
            // oracleConnection1
            // 
            this.oracleConnection1.ConnectionString = "User Id=smart;Password=smart;Server=121.40.101.29;Direct=True;Sid=orcl;";
            this.oracleConnection1.Name = "oracleConnection1";
            this.oracleConnection1.Owner = this;
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = "Data Source=121.40.101.29;Initial Catalog=scm_main;Integrated Security=False;Pass" +
    "word=sa123;Persist Security Info=True;User ID=sa;Application Name=\"dotConnect fo" +
    "r SQL Server\";";
            this.sqlConnection1.Name = "sqlConnection1";
            this.sqlConnection1.Owner = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 541);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.tbReceive);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tbSend);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.uniConnection1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbSend;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbReceive;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private Devart.Data.Universal.UniConnection uniConnection1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private Devart.Data.Oracle.OracleConnection oracleConnection1;
        private Devart.Data.SqlServer.SqlConnection sqlConnection1;
    }
}

