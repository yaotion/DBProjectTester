namespace DbUnitTest2000
{
    partial class FrmDbUnitTestMainUi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDbUnitTestMainUi));
            this.topmenu = new System.Windows.Forms.MenuStrip();
            this.menufile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuopen = new System.Windows.Forms.ToolStripMenuItem();
            this.数据管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.架构更新浏览ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuexit = new System.Windows.Forms.ToolStripMenuItem();
            this.statusbar = new System.Windows.Forms.StatusStrip();
            this.Statuslbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.dlltree = new System.Windows.Forms.TreeView();
            this.checkextend = new System.Windows.Forms.CheckBox();
            this.treecheck = new System.Windows.Forms.CheckBox();
            this.opendllFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.toolscomboxconfig = new System.Windows.Forms.ToolStripComboBox();
            this.toolsbtncreate = new System.Windows.Forms.ToolStripButton();
            this.TsBtnUpdate = new System.Windows.Forms.ToolStripButton();
            this.toolbarrun = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.progressBarResult = new System.Windows.Forms.ProgressBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lablpath = new System.Windows.Forms.Label();
            this.lablResult = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listBoxlog = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.topmenu.SuspendLayout();
            this.statusbar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolbar.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // topmenu
            // 
            this.topmenu.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.topmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menufile,
            this.数据管理ToolStripMenuItem,
            this.menuexit});
            this.topmenu.Location = new System.Drawing.Point(0, 0);
            this.topmenu.Name = "topmenu";
            this.topmenu.Size = new System.Drawing.Size(1028, 29);
            this.topmenu.TabIndex = 0;
            this.topmenu.Text = "menuStrip1";
            // 
            // menufile
            // 
            this.menufile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuopen});
            this.menufile.Name = "menufile";
            this.menufile.Size = new System.Drawing.Size(54, 25);
            this.menufile.Text = "文件";
            // 
            // menuopen
            // 
            this.menuopen.Name = "menuopen";
            this.menuopen.Size = new System.Drawing.Size(208, 26);
            this.menuopen.Text = "打开测试项目类库";
            this.menuopen.Click += new System.EventHandler(this.menuopen_Click);
            // 
            // 数据管理ToolStripMenuItem
            // 
            this.数据管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.架构更新浏览ToolStripMenuItem});
            this.数据管理ToolStripMenuItem.Name = "数据管理ToolStripMenuItem";
            this.数据管理ToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.数据管理ToolStripMenuItem.Text = "数据管理";
            // 
            // 架构更新浏览ToolStripMenuItem
            // 
            this.架构更新浏览ToolStripMenuItem.Name = "架构更新浏览ToolStripMenuItem";
            this.架构更新浏览ToolStripMenuItem.Size = new System.Drawing.Size(176, 26);
            this.架构更新浏览ToolStripMenuItem.Text = "架构更新浏览";
            this.架构更新浏览ToolStripMenuItem.Click += new System.EventHandler(this.架构更新浏览ToolStripMenuItem_Click);
            // 
            // menuexit
            // 
            this.menuexit.Name = "menuexit";
            this.menuexit.Size = new System.Drawing.Size(54, 25);
            this.menuexit.Text = "退出";
            this.menuexit.Click += new System.EventHandler(this.menuexit_Click);
            // 
            // statusbar
            // 
            this.statusbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Statuslbl});
            this.statusbar.Location = new System.Drawing.Point(0, 651);
            this.statusbar.Name = "statusbar";
            this.statusbar.Size = new System.Drawing.Size(1028, 22);
            this.statusbar.TabIndex = 1;
            // 
            // Statuslbl
            // 
            this.Statuslbl.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom;
            this.Statuslbl.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
            this.Statuslbl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Statuslbl.Name = "Statuslbl";
            this.Statuslbl.Size = new System.Drawing.Size(4, 17);
            // 
            // dlltree
            // 
            this.dlltree.Location = new System.Drawing.Point(12, 27);
            this.dlltree.Name = "dlltree";
            this.dlltree.Size = new System.Drawing.Size(491, 584);
            this.dlltree.TabIndex = 2;
            this.dlltree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.dlltree_AfterSelect);
            // 
            // checkextend
            // 
            this.checkextend.AutoSize = true;
            this.checkextend.Location = new System.Drawing.Point(149, 617);
            this.checkextend.Name = "checkextend";
            this.checkextend.Size = new System.Drawing.Size(107, 20);
            this.checkextend.TabIndex = 3;
            this.checkextend.Text = "展开/折叠 ";
            this.checkextend.UseVisualStyleBackColor = true;
            this.checkextend.CheckedChanged += new System.EventHandler(this.checkextend_CheckedChanged);
            // 
            // treecheck
            // 
            this.treecheck.AutoSize = true;
            this.treecheck.Location = new System.Drawing.Point(320, 617);
            this.treecheck.Name = "treecheck";
            this.treecheck.Size = new System.Drawing.Size(99, 20);
            this.treecheck.TabIndex = 3;
            this.treecheck.Text = "全选/反选";
            this.treecheck.UseVisualStyleBackColor = true;
            this.treecheck.CheckedChanged += new System.EventHandler(this.treecheck_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolbar);
            this.panel1.Location = new System.Drawing.Point(509, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(882, 35);
            this.panel1.TabIndex = 4;
            // 
            // toolbar
            // 
            this.toolbar.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolscomboxconfig,
            this.toolsbtncreate,
            this.TsBtnUpdate,
            this.toolbarrun});
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(882, 28);
            this.toolbar.TabIndex = 0;
            this.toolbar.Text = "toolStrip1";
            // 
            // toolscomboxconfig
            // 
            this.toolscomboxconfig.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolscomboxconfig.Name = "toolscomboxconfig";
            this.toolscomboxconfig.Size = new System.Drawing.Size(90, 28);
            // 
            // toolsbtncreate
            // 
            this.toolsbtncreate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolsbtncreate.Image = ((System.Drawing.Image)(resources.GetObject("toolsbtncreate.Image")));
            this.toolsbtncreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolsbtncreate.Name = "toolsbtncreate";
            this.toolsbtncreate.Size = new System.Drawing.Size(46, 25);
            this.toolsbtncreate.Text = "配置";
            this.toolsbtncreate.Click += new System.EventHandler(this.toolsbtncreate_Click);
            // 
            // TsBtnUpdate
            // 
            this.TsBtnUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TsBtnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("TsBtnUpdate.Image")));
            this.TsBtnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsBtnUpdate.Name = "TsBtnUpdate";
            this.TsBtnUpdate.Size = new System.Drawing.Size(46, 25);
            this.TsBtnUpdate.Text = "更新";
            this.TsBtnUpdate.Click += new System.EventHandler(this.TsBtnUpdate_Click);
            // 
            // toolbarrun
            // 
            this.toolbarrun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolbarrun.Image = ((System.Drawing.Image)(resources.GetObject("toolbarrun.Image")));
            this.toolbarrun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbarrun.Name = "toolbarrun";
            this.toolbarrun.Size = new System.Drawing.Size(46, 25);
            this.toolbarrun.Text = "运行";
            this.toolbarrun.Click += new System.EventHandler(this.toolbarrun_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.progressBarResult);
            this.groupBox1.Location = new System.Drawing.Point(511, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(881, 75);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "测试进度";
            // 
            // progressBarResult
            // 
            this.progressBarResult.Location = new System.Drawing.Point(6, 25);
            this.progressBarResult.Name = "progressBarResult";
            this.progressBarResult.Size = new System.Drawing.Size(869, 44);
            this.progressBarResult.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lablpath);
            this.groupBox2.Controls.Add(this.lablResult);
            this.groupBox2.Location = new System.Drawing.Point(512, 150);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(881, 58);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "测试结果";
            // 
            // lablpath
            // 
            this.lablpath.AutoSize = true;
            this.lablpath.Location = new System.Drawing.Point(9, 29);
            this.lablpath.Name = "lablpath";
            this.lablpath.Size = new System.Drawing.Size(0, 16);
            this.lablpath.TabIndex = 1;
            this.lablpath.Visible = false;
            // 
            // lablResult
            // 
            this.lablResult.AutoSize = true;
            this.lablResult.Location = new System.Drawing.Point(93, 26);
            this.lablResult.Name = "lablResult";
            this.lablResult.Size = new System.Drawing.Size(0, 16);
            this.lablResult.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(517, 214);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(881, 388);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listBoxlog);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(873, 358);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "执行日志";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listBoxlog
            // 
            this.listBoxlog.FormattingEnabled = true;
            this.listBoxlog.ItemHeight = 16;
            this.listBoxlog.Location = new System.Drawing.Point(18, 7);
            this.listBoxlog.Name = "listBoxlog";
            this.listBoxlog.Size = new System.Drawing.Size(856, 452);
            this.listBoxlog.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(873, 358);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "说明";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(6, 6);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(856, 466);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // FrmDbUnitTestMainUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 673);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.treecheck);
            this.Controls.Add(this.checkextend);
            this.Controls.Add(this.dlltree);
            this.Controls.Add(this.statusbar);
            this.Controls.Add(this.topmenu);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.topmenu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmDbUnitTestMainUi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据库单元测试V1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmDbUnitTestMainUi_Load);
            this.topmenu.ResumeLayout(false);
            this.topmenu.PerformLayout();
            this.statusbar.ResumeLayout(false);
            this.statusbar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip topmenu;
        private System.Windows.Forms.StatusStrip statusbar;
        private System.Windows.Forms.TreeView dlltree;
        private System.Windows.Forms.CheckBox checkextend;
        private System.Windows.Forms.CheckBox treecheck;
        private System.Windows.Forms.ToolStripStatusLabel Statuslbl;
        private System.Windows.Forms.ToolStripMenuItem menufile;
        private System.Windows.Forms.ToolStripMenuItem menuopen;
        private System.Windows.Forms.ToolStripMenuItem menuexit;
        private System.Windows.Forms.OpenFileDialog opendllFileDialog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolbar;
        private System.Windows.Forms.ToolStripComboBox toolscomboxconfig;
        private System.Windows.Forms.ToolStripButton toolsbtncreate;
        private System.Windows.Forms.ToolStripButton toolbarrun;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar progressBarResult;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lablResult;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox listBoxlog;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label lablpath;
        private System.Windows.Forms.ToolStripButton TsBtnUpdate;
        private System.Windows.Forms.ToolStripMenuItem 数据管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 架构更新浏览ToolStripMenuItem;
    }
}