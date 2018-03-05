namespace DbUnitTest2000
{
    partial class DbSet
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtserver = new System.Windows.Forms.TextBox();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.btntest = new System.Windows.Forms.Button();
            this.btnrefresh = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comdb = new System.Windows.Forms.ComboBox();
            this.btnsel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据库地址（服务名 ）：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(127, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "用户名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(151, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "密码:";
            // 
            // txtserver
            // 
            this.txtserver.Location = new System.Drawing.Point(205, 30);
            this.txtserver.Name = "txtserver";
            this.txtserver.Size = new System.Drawing.Size(296, 26);
            this.txtserver.TabIndex = 0;
            this.txtserver.Text = "192.168.1.166";
            // 
            // txtuser
            // 
            this.txtuser.Location = new System.Drawing.Point(205, 87);
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(296, 26);
            this.txtuser.TabIndex = 1;
            this.txtuser.Text = "sa";
            // 
            // txtpass
            // 
            this.txtpass.Location = new System.Drawing.Point(205, 146);
            this.txtpass.Name = "txtpass";
            this.txtpass.PasswordChar = '*';
            this.txtpass.Size = new System.Drawing.Size(296, 26);
            this.txtpass.TabIndex = 2;
            this.txtpass.Text = "Think123";
            // 
            // btntest
            // 
            this.btntest.Location = new System.Drawing.Point(551, 51);
            this.btntest.Name = "btntest";
            this.btntest.Size = new System.Drawing.Size(75, 23);
            this.btntest.TabIndex = 4;
            this.btntest.Text = "测试";
            this.btntest.UseVisualStyleBackColor = true;
            this.btntest.Click += new System.EventHandler(this.btntest_Click);
            // 
            // btnrefresh
            // 
            this.btnrefresh.Location = new System.Drawing.Point(551, 130);
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.Size = new System.Drawing.Size(75, 23);
            this.btnrefresh.TabIndex = 5;
            this.btnrefresh.Text = "刷新";
            this.btnrefresh.UseVisualStyleBackColor = true;
            this.btnrefresh.Click += new System.EventHandler(this.btnrefresh_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(119, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "数据库名:";
            // 
            // comdb
            // 
            this.comdb.FormattingEnabled = true;
            this.comdb.Location = new System.Drawing.Point(205, 204);
            this.comdb.Name = "comdb";
            this.comdb.Size = new System.Drawing.Size(296, 24);
            this.comdb.TabIndex = 3;
            // 
            // btnsel
            // 
            this.btnsel.Location = new System.Drawing.Point(551, 209);
            this.btnsel.Name = "btnsel";
            this.btnsel.Size = new System.Drawing.Size(75, 23);
            this.btnsel.TabIndex = 6;
            this.btnsel.Text = "确认";
            this.btnsel.UseVisualStyleBackColor = true;
            this.btnsel.Click += new System.EventHandler(this.btnsel_Click);
            // 
            // DbSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 272);
            this.Controls.Add(this.comdb);
            this.Controls.Add(this.btnsel);
            this.Controls.Add(this.btnrefresh);
            this.Controls.Add(this.btntest);
            this.Controls.Add(this.txtpass);
            this.Controls.Add(this.txtuser);
            this.Controls.Add(this.txtserver);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DbSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据库设置 ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DbSet_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DbSet_FormClosed);
            this.Load += new System.EventHandler(this.DbSet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtserver;
        private System.Windows.Forms.TextBox txtuser;
        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.Button btntest;
        private System.Windows.Forms.Button btnrefresh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comdb;
        private System.Windows.Forms.Button btnsel;
    }
}