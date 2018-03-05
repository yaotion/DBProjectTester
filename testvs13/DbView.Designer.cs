namespace DbUnitTest2000
{
    partial class DbView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.remotxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnremot = new System.Windows.Forms.Button();
            this.btnlocal = new System.Windows.Forms.Button();
            this.dbtxtlocal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.localtree = new System.Windows.Forms.TreeView();
            this.localtxtsql = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.remotree = new System.Windows.Forms.TreeView();
            this.remotxtsql = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnbj = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnbj);
            this.panel1.Controls.Add(this.remotxt);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnremot);
            this.panel1.Controls.Add(this.btnlocal);
            this.panel1.Controls.Add(this.dbtxtlocal);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1111, 124);
            this.panel1.TabIndex = 0;
            // 
            // remotxt
            // 
            this.remotxt.Location = new System.Drawing.Point(585, 45);
            this.remotxt.Name = "remotxt";
            this.remotxt.Size = new System.Drawing.Size(394, 26);
            this.remotxt.TabIndex = 4;
            this.remotxt.TextChanged += new System.EventHandler(this.remotxt_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(451, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "远程数据库地址:";
            // 
            // btnremot
            // 
            this.btnremot.Location = new System.Drawing.Point(985, 42);
            this.btnremot.Name = "btnremot";
            this.btnremot.Size = new System.Drawing.Size(65, 23);
            this.btnremot.TabIndex = 2;
            this.btnremot.Text = "...";
            this.btnremot.UseVisualStyleBackColor = true;
            this.btnremot.Click += new System.EventHandler(this.btnremot_Click);
            // 
            // btnlocal
            // 
            this.btnlocal.Location = new System.Drawing.Point(368, 45);
            this.btnlocal.Name = "btnlocal";
            this.btnlocal.Size = new System.Drawing.Size(65, 23);
            this.btnlocal.TabIndex = 2;
            this.btnlocal.Text = "...";
            this.btnlocal.UseVisualStyleBackColor = true;
            this.btnlocal.Click += new System.EventHandler(this.btnlocal_Click);
            // 
            // dbtxtlocal
            // 
            this.dbtxtlocal.Location = new System.Drawing.Point(139, 45);
            this.dbtxtlocal.Name = "dbtxtlocal";
            this.dbtxtlocal.Size = new System.Drawing.Size(223, 26);
            this.dbtxtlocal.TabIndex = 1;
            this.dbtxtlocal.TextChanged += new System.EventHandler(this.dbtxtlocal_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "本地数据库文件:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.localtree);
            this.groupBox1.Controls.Add(this.localtxtsql);
            this.groupBox1.Location = new System.Drawing.Point(1, 131);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(551, 423);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "本地数据结构";
            // 
            // localtree
            // 
            this.localtree.Location = new System.Drawing.Point(14, 26);
            this.localtree.Name = "localtree";
            this.localtree.Size = new System.Drawing.Size(531, 254);
            this.localtree.TabIndex = 1;
            this.localtree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.localtree_AfterSelect);
            // 
            // localtxtsql
            // 
            this.localtxtsql.Location = new System.Drawing.Point(11, 286);
            this.localtxtsql.Name = "localtxtsql";
            this.localtxtsql.Size = new System.Drawing.Size(534, 131);
            this.localtxtsql.TabIndex = 0;
            this.localtxtsql.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.remotree);
            this.groupBox2.Controls.Add(this.remotxtsql);
            this.groupBox2.Location = new System.Drawing.Point(558, 131);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(551, 423);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "远程数据结构";
            // 
            // remotree
            // 
            this.remotree.Location = new System.Drawing.Point(6, 25);
            this.remotree.Name = "remotree";
            this.remotree.Size = new System.Drawing.Size(531, 254);
            this.remotree.TabIndex = 1;
            this.remotree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.remotree_AfterSelect);
            // 
            // remotxtsql
            // 
            this.remotxtsql.Location = new System.Drawing.Point(6, 286);
            this.remotxtsql.Name = "remotxtsql";
            this.remotxtsql.Size = new System.Drawing.Size(545, 126);
            this.remotxtsql.TabIndex = 0;
            this.remotxtsql.Text = "";
            // 
            // btnbj
            // 
            this.btnbj.Location = new System.Drawing.Point(985, 83);
            this.btnbj.Name = "btnbj";
            this.btnbj.Size = new System.Drawing.Size(83, 34);
            this.btnbj.TabIndex = 5;
            this.btnbj.Text = "比较";
            this.btnbj.UseVisualStyleBackColor = true;
            this.btnbj.Click += new System.EventHandler(this.btnbj_Click);
            // 
            // DbView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 566);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "DbView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据架构更新浏览";
            this.Load += new System.EventHandler(this.DbView_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox remotxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnremot;
        private System.Windows.Forms.Button btnlocal;
        private System.Windows.Forms.TextBox dbtxtlocal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView localtree;
        private System.Windows.Forms.RichTextBox localtxtsql;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TreeView remotree;
        private System.Windows.Forms.RichTextBox remotxtsql;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnbj;

    }
}