namespace DbUnitTest2000
{
    partial class frmmsg
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
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.txtfile = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txbPwd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbUserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbDbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbServer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnclose = new System.Windows.Forms.Button();
            this.btntest = new System.Windows.Forms.Button();
            this.myopenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(397, 267);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "发布";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(233, 304);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "发布状态：待发布";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(538, 148);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(39, 23);
            this.button4.TabIndex = 13;
            this.button4.Text = "...";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtfile
            // 
            this.txtfile.Location = new System.Drawing.Point(361, 148);
            this.txtfile.Name = "txtfile";
            this.txtfile.Size = new System.Drawing.Size(180, 21);
            this.txtfile.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(276, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "数据库文件：";
            // 
            // txbPwd
            // 
            this.txbPwd.Location = new System.Drawing.Point(361, 105);
            this.txbPwd.MaxLength = 100;
            this.txbPwd.Name = "txbPwd";
            this.txbPwd.PasswordChar = '*';
            this.txbPwd.Size = new System.Drawing.Size(180, 21);
            this.txbPwd.TabIndex = 9;
            this.txbPwd.Text = "sa123456";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(312, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "密码：";
            // 
            // txbUserName
            // 
            this.txbUserName.Location = new System.Drawing.Point(361, 62);
            this.txbUserName.MaxLength = 100;
            this.txbUserName.Name = "txbUserName";
            this.txbUserName.Size = new System.Drawing.Size(180, 21);
            this.txbUserName.TabIndex = 10;
            this.txbUserName.Text = "sa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(300, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "用户名：";
            // 
            // txbDbName
            // 
            this.txbDbName.Location = new System.Drawing.Point(361, 188);
            this.txbDbName.MaxLength = 200;
            this.txbDbName.Name = "txbDbName";
            this.txbDbName.Size = new System.Drawing.Size(180, 21);
            this.txbDbName.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(278, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "生成数据库：";
            // 
            // txbServer
            // 
            this.txbServer.Location = new System.Drawing.Point(361, 25);
            this.txbServer.MaxLength = 30;
            this.txbServer.Name = "txbServer";
            this.txbServer.Size = new System.Drawing.Size(180, 21);
            this.txbServer.TabIndex = 12;
            this.txbServer.Text = "192.168.1.166";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(300, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "服务器：";
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(501, 267);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 23);
            this.btnclose.TabIndex = 14;
            this.btnclose.Text = "保存并退出";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btntest
            // 
            this.btntest.Location = new System.Drawing.Point(293, 267);
            this.btntest.Name = "btntest";
            this.btntest.Size = new System.Drawing.Size(75, 23);
            this.btntest.TabIndex = 15;
            this.btntest.Text = "测试";
            this.btntest.UseVisualStyleBackColor = true;
            this.btntest.Click += new System.EventHandler(this.btntest_Click);
            // 
            // frmmsg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 319);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btntest);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txtfile);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txbPwd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txbUserName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbDbName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbServer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmmsg";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "加载中。。。。。";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmmsg_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtfile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbPwd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbDbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Button btntest;
        private System.Windows.Forms.OpenFileDialog myopenFileDialog;
    }
}