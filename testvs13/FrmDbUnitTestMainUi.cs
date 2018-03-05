using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

using System.Text.RegularExpressions;
using System.Xml.Serialization;
namespace DbUnitTest2000
{
    public partial class FrmDbUnitTestMainUi : Form
    {
         AppDomain currentDomain = AppDomain.CurrentDomain;

        public static string pubfolder = "";
     public   static Assembly MyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            string strFielName = args.Name.Split(',')[0];
            //MessageBox.Show(args.Name);
            return Assembly.LoadFrom(string.Format(pubfolder+"{0}.dll", strFielName));
        }
        
        public FrmDbUnitTestMainUi()
        {
            InitializeComponent();
             currentDomain.AssemblyResolve += new ResolveEventHandler(MyResolveEventHandler);
        }

        private void checkextend_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkextend.Checked)
            {
                this.dlltree.ExpandAll();
            }
            if (this.checkextend.Checked == false)
            {
                this.dlltree.CollapseAll();
            }
        }

        private void treecheck_CheckedChanged(object sender, EventArgs e)
        {
            TreeNode tn = null;//tn里面有名称、索引等属性自己去出来
            TreeNodeCollection tnc = this.dlltree.Nodes;//获取treeview的子节点的集合
            for (int i = 0; i < tnc.Count; i++)//两级的循环只能找出两级中所有被选中节点
            {
                //tn = tnc[i];
                if (this.treecheck.Checked)
                {
                    tnc[i].Checked = true;

                    if (tnc[i].GetNodeCount(true) > 1)//下面还有子节点
                    {


                        for (int j = 0; j < tnc[i].GetNodeCount(true); j++)
                        {

                            if (this.treecheck.Checked)
                                tnc[i].Nodes[j].Checked = true;
                            else
                                tnc[i].Nodes[j].Checked = false;


                        }
                    }
                }
                else
                {
                    tnc[i].Checked = false;
                    if (tnc[i].GetNodeCount(true) > 1)//下面还有子节点
                    {


                        for (int j = 0; j < tnc[i].GetNodeCount(true); j++)
                        {

                            if (this.treecheck.Checked)
                                tnc[i].Nodes[j].Checked = true;
                            else
                                tnc[i].Nodes[j].Checked = false;


                        }
                    }

                }


            }
        }

        private void menuopen_Click(object sender, EventArgs e)
        {
            opendllFileDialog.Filter = "测试类库dll文件(*.DLL)|*.dll";
            this.opendllFileDialog.ShowDialog();
            string path = this.opendllFileDialog.FileName;
            this.dlltree.CheckBoxes = true;
            AssemblyHandler ah = new AssemblyHandler();
            if (!String.IsNullOrEmpty(path))
            {
                Assembly assembly = Assembly.LoadFile(path);
                pubfolder = Path.GetDirectoryName(path) + "\\";
                //MessageBox.Show(pubfolder);
                this.Statuslbl.Text = "类库位置 ：" + path;
                try
                {
                    AssemblyResult ar = ah.GetClassName(path);
                    this.lablpath.Text = path;
                    this.dlltree.Nodes.Clear();

                    //  thand();
                    for (int i = 0; i < ar.ClassName.Count; i++)
                    {
                        try
                        {
                            string strcls = ar.ClassName[i];
                            AssemblyResult clsinfo = ah.GetClassInfo(path, strcls);
                            // 
                            List<TreeNode> lst = new List<TreeNode>();

                            if (clsinfo.Methods.Count > 0)
                            {
                                for (int ii = 0; ii < clsinfo.Methods.Count; ii++)
                                {
                                    Application.DoEvents();
                                    object obj = assembly.CreateInstance(strcls); // 创建类的实例 
                                    Type t = obj.GetType();
                                    try
                                    {
                                        MethodInfo minfo = t.GetMethod(clsinfo.Methods[ii]);                              
                                        IList<System.Reflection.CustomAttributeData> lstsx = minfo.GetCustomAttributesData();

                                        if (lstsx != null && lstsx.Count > 0)
                                        {
                                            for (int k = 0; k < lstsx.Count; k++)
                                            {
                                                object O = (object)lstsx[k];
                                                string OX = O.ToString();
                                                // (lstsx)).Items[0].AttributeType	{Name = "TestAttribute" FullName = "NUnit.Framework.TestAttribute"}	System.Type {System.RuntimeType}
                                                if (OX.Equals("[NUnit.Framework.TestAttribute()]"))
                                                {
                                                    TreeNode subtree = new TreeNode();

                                                    subtree.Text = clsinfo.Methods[ii];
                                                    subtree.Tag = ii.ToString();
                                                    if (!String.IsNullOrEmpty(clsinfo.Methods[ii]))
                                                        lst.Add(subtree);
                                                }
                                            }
                                        }
                                        //}
                                    }
                                    catch (Exception error)
                                    {
                                        //  MessageBox.Show(error.Message);
                                        continue;
                                    }
                                    // trlst[ii].Checked = true;
                                }



                                TreeNode[] treearray = new TreeNode[lst.Count];
                                for (int jj = 0; jj < lst.Count; jj++)
                                {
                                    Application.DoEvents();
                                    treearray[jj] = new TreeNode();
                                    treearray[jj].Text = lst[jj].Text;
                                    treearray[jj].Tag = lst[jj].Tag;

                                }


                                if (treearray.Length > 0)
                                {
                                    TreeNode tn = new TreeNode(strcls, treearray);
                                    this.dlltree.Nodes.Add(tn);
                                }
                            }

                        }
                        catch
                        {
                            continue;
                        }

                    }
                    //this.dlltree.ExpandAll();
                    // threads.Abort();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //  MessageBox.Show(error.Message);
                }


            }
        }

        private void menuexit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要退出？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Dispose();
        }
        private void Query_OnShowString(string ip)
        {

            this.toolscomboxconfig.Text = ip;
        }
        private void toolsbtncreate_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process p = System.Diagnostics.Process.Start("Db2000.exe");
            //p.WaitForExit();
            frmmsg fm = new frmmsg();
            fm.OnShowString += new EventOnShowStringHandler(Query_OnShowString);
            fm.ShowDialog();
          //  FrmDbDeploy.pubstr = this.toolscomboxconfig.Text;
          //  FrmDbDeploy dbgui = new FrmDbDeploy();

          ////  dbgui.OnShowString += new EventOnShowStringHandler(Query_OnShowString);

          //  dbgui.ShowDialog();
          //  this.toolscomboxconfig.Text = FrmDbDeploy.pubstr;
        }

        private void toolbarrun_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.lablpath.Text))
            {
                Assembly assembly = Assembly.LoadFrom(this.lablpath.Text);

                List<int> pross = new List<int>();
                this.listBoxlog.Items.Clear();
                int prs = 0;

                int intcussint = 0; ;
                int failcnt = 0;
                for (int m = 0; m < this.dlltree.Nodes.Count; m++)
                {
                    if (this.dlltree.Nodes[m].Checked || this.dlltree.Nodes[m].GetNodeCount(true) > 1)
                    {
                        for (int n = 0; n < this.dlltree.Nodes[m].GetNodeCount(true); n++)
                        {
                            Application.DoEvents();
                            if (this.dlltree.Nodes[m].Nodes[n].Checked)
                            {
                                prs++;
                                pross.Add(prs);
                                object obj = assembly.CreateInstance(this.dlltree.Nodes[m].Text); // 创建类的实例 
                                Type t = obj.GetType();
                                PropertyInfo[] propertyinfo = t.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                                //首先传给他，然后判断连接成功否，否则调用设置窗口，是则继续执行
                                foreach (PropertyInfo propInfo in propertyinfo)
                                {
                                    if (propInfo.Name == "Bolconn")
                                    {
                                        object po = propInfo.GetValue(obj, null);
                                        bool bpo = (bool)po;
                                        if (bpo == false)
                                        {
                                         
                                            MessageBox.Show("请先配置数据库连接，并发布数据库。", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            return;
                               
                                        }
                                        if (bpo == true)
                                            break;

                                    }

                                }


                                MethodInfo minfo = t.GetMethod(this.dlltree.Nodes[m].Nodes[n].Text);

                                try
                                {
                                    NUnit.Framework.Api.NUnitTestAssemblyRunner a;
                                    a.Run();
                                    object value = minfo.Invoke(obj, null);
                                    intcussint++;
                                    this.listBoxlog.Items.Add("时间:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "  第" + prs.ToString() + "个方法:" + this.dlltree.Nodes[m].Nodes[n].Text + "测试通过");
                                }
                                catch (Exception error)
                                {
                                    failcnt++;
                                    this.listBoxlog.Items.Add("时间:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "  第" + prs.ToString() + "个方法:" + this.dlltree.Nodes[m].Nodes[n].Text + "测试不通过");
                                    // this.listBoxlog.Items.Add("原因:" + error.Message);
                                }
                            }
                        }
                    }
                }
                this.progressBarResult.Maximum = prs;
                for (int m = 0; m <= prs; m++)
                {
                    this.progressBarResult.Value = m;
                }
                int allint = intcussint + failcnt;
                this.lablResult.Text = "成功:" + intcussint.ToString() + "个" + "   失败:" + failcnt.ToString() + "个" + " 总计:" + allint.ToString() + "个";

            }
            else
            {
                MessageBox.Show("请先选择运行类库。", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //MessageBox.Show("选择运行类库为空了。");
            }
        }

        private void FrmDbUnitTestMainUi_Load(object sender, EventArgs e)
        {
            string newconfig = AppConfig.GetConnectionStringsConfig("MyCon");
            string[] str = newconfig.Split(';');
            if (str.Length > 0)
            {
                toolscomboxconfig.ComboBox.Items.Add(str[0].Replace("Data Source=", ""));
                toolscomboxconfig.ComboBox.SelectedIndex = 0;
            }
        }

        private void dlltree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                //  AssemblyHandler ah = new AssemblyHandler();
                if (this.dlltree.SelectedNode.Parent != null)
                {
                    //string ret = ah.GetMethodInfo(this.lablpath.Text, this.dlltree.SelectedNode.Parent.Text, this.dlltree.SelectedNode.Text);
                    this.richTextBox1.Clear();
                    this.richTextBox1.AppendText("类:" + this.dlltree.SelectedNode.Parent.Text + Environment.NewLine + "方法" + this.dlltree.SelectedNode.Text);
                }
                else
                {
                    this.richTextBox1.AppendText("类:" + this.dlltree.SelectedNode.Text);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

       
          
        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
             System.Diagnostics.Process p =  System.Diagnostics.Process.Start("Db2000.exe");
            p.WaitForExit();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void TsBtnUpdate_Click(object sender, EventArgs e)
        {
            FrmDbDeploy dbset = new FrmDbDeploy();
            dbset.ShowDialog();
        }

        private void 架构更新浏览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DbView dv = new DbView();
            dv.ShowDialog();
        }
    }
}
