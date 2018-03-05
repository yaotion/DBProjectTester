namespace DbUnitTest2000
{
    partial class FrmDbDeploy
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.btnfb = new System.Windows.Forms.Button();
            this.btntest = new System.Windows.Forms.Button();
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.myopenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.btnclose);
            this.groupBox1.Controls.Add(this.btnfb);
            this.groupBox1.Controls.Add(this.btntest);
            this.groupBox1.Controls.Add(this.txtfile);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txbPwd);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txbUserName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txbDbName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txbServer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(251, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 314);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(214, 236);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "浏览 ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(273, 146);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(39, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = "...";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(214, 284);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 23);
            this.btnclose.TabIndex = 2;
            this.btnclose.Text = "退出";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnfb
            // 
            this.btnfb.Location = new System.Drawing.Point(108, 284);
            this.btnfb.Name = "btnfb";
            this.btnfb.Size = new System.Drawing.Size(75, 23);
            this.btnfb.TabIndex = 2;
            this.btnfb.Text = "更新";
            this.btnfb.UseVisualStyleBackColor = true;
            this.btnfb.Click += new System.EventHandler(this.btnfb_Click);
            // 
            // btntest
            // 
            this.btntest.Location = new System.Drawing.Point(108, 236);
            this.btntest.Name = "btntest";
            this.btntest.Size = new System.Drawing.Size(75, 23);
            this.btntest.TabIndex = 2;
            this.btntest.Text = "测试";
            this.btntest.UseVisualStyleBackColor = true;
            this.btntest.Click += new System.EventHandler(this.btntest_Click);
            // 
            // txtfile
            // 
            this.txtfile.Location = new System.Drawing.Point(96, 146);
            this.txtfile.Name = "txtfile";
            this.txtfile.Size = new System.Drawing.Size(180, 21);
            this.txtfile.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "数据库文件：";
            // 
            // txbPwd
            // 
            this.txbPwd.Location = new System.Drawing.Point(96, 103);
            this.txbPwd.MaxLength = 100;
            this.txbPwd.Name = "txbPwd";
            this.txbPwd.PasswordChar = '*';
            this.txbPwd.Size = new System.Drawing.Size(180, 21);
            this.txbPwd.TabIndex = 1;
            this.txbPwd.Text = "sa123456";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "密码：";
            // 
            // txbUserName
            // 
            this.txbUserName.Location = new System.Drawing.Point(96, 60);
            this.txbUserName.MaxLength = 100;
            this.txbUserName.Name = "txbUserName";
            this.txbUserName.Size = new System.Drawing.Size(180, 21);
            this.txbUserName.TabIndex = 1;
            this.txbUserName.Text = "sa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "用户名：";
            // 
            // txbDbName
            // 
            this.txbDbName.Location = new System.Drawing.Point(96, 186);
            this.txbDbName.MaxLength = 200;
            this.txbDbName.Name = "txbDbName";
            this.txbDbName.ReadOnly = true;
            this.txbDbName.Size = new System.Drawing.Size(180, 21);
            this.txbDbName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "生成数据库：";
            // 
            // txbServer
            // 
            this.txbServer.Location = new System.Drawing.Point(96, 21);
            this.txbServer.MaxLength = 30;
            this.txbServer.Name = "txbServer";
            this.txbServer.Size = new System.Drawing.Size(180, 21);
            this.txbServer.TabIndex = 1;
            this.txbServer.Text = "192.168.1.166";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器：";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 24);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(233, 304);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "更新状态：待更新";
            // 
            // FrmDbDeploy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 333);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmDbDeploy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据库设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDbDeploy_FormClosing);
            this.Load += new System.EventHandler(this.FrmDbDeploy_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Button btnfb;
        private System.Windows.Forms.Button btntest;
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
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.OpenFileDialog myopenFileDialog;
        private System.Windows.Forms.Button button1;

    }
}