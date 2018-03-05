using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Data.Schema.UnitTesting;
using Microsoft.Data.Schema.UnitTesting.Conditions;

namespace TF.GoodManager.UnitTest
{
 
    [TestClass()]
    public class GoodManagerSqlUnitTest : DatabaseTestClass
    {

        public GoodManagerSqlUnitTest()
        {
            InitializeComponent();
        }

        [TestInitialize()]
        public void TestInitialize()
        {
            base.InitializeTest();
        }
        [TestCleanup()]
        public void TestCleanup()
        {
            base.CleanupTest();
        }

        [TestMethod()]
        public void DatabaseTestsql()
        {
 
            DatabaseTestActions testActions = this.DatabaseTestsqlData;
            // 执行预先测试脚本
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "正在执行预先测试脚本...");
            ExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            // 执行测试脚本
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "正在执行测试脚本...");
            ExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            // 执行后期测试脚本
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "正在执行后期测试脚本...");
            ExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
        }

        #region 设计器支持代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.Data.Schema.UnitTesting.DatabaseTestAction DatabaseTestsql_TestAction;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GoodManagerSqlUnitTest));
            Microsoft.Data.Schema.UnitTesting.Conditions.NotEmptyResultSetCondition notEmptyResultSetCondition1;
            Microsoft.Data.Schema.UnitTesting.Conditions.RowCountCondition rowCountCondition1;
            Microsoft.Data.Schema.UnitTesting.Conditions.ChecksumCondition checksumCondition1;
            Microsoft.Data.Schema.UnitTesting.Conditions.ExecutionTimeCondition executionTimeCondition1;
            Microsoft.Data.Schema.UnitTesting.DatabaseTestAction testInitializeAction;
            this.DatabaseTestsqlData = new Microsoft.Data.Schema.UnitTesting.DatabaseTestActions();
            DatabaseTestsql_TestAction = new Microsoft.Data.Schema.UnitTesting.DatabaseTestAction();
            notEmptyResultSetCondition1 = new Microsoft.Data.Schema.UnitTesting.Conditions.NotEmptyResultSetCondition();
            rowCountCondition1 = new Microsoft.Data.Schema.UnitTesting.Conditions.RowCountCondition();
            checksumCondition1 = new Microsoft.Data.Schema.UnitTesting.Conditions.ChecksumCondition();
            executionTimeCondition1 = new Microsoft.Data.Schema.UnitTesting.Conditions.ExecutionTimeCondition();
            testInitializeAction = new Microsoft.Data.Schema.UnitTesting.DatabaseTestAction();
            // 
            // DatabaseTestsql_TestAction
            // 
            DatabaseTestsql_TestAction.Conditions.Add(notEmptyResultSetCondition1);
            DatabaseTestsql_TestAction.Conditions.Add(rowCountCondition1);
            DatabaseTestsql_TestAction.Conditions.Add(checksumCondition1);
            DatabaseTestsql_TestAction.Conditions.Add(executionTimeCondition1);
            resources.ApplyResources(DatabaseTestsql_TestAction, "DatabaseTestsql_TestAction");
            // 
            // notEmptyResultSetCondition1
            // 
            notEmptyResultSetCondition1.Enabled = true;
            notEmptyResultSetCondition1.Name = "notEmptyResultSetCondition1";
            notEmptyResultSetCondition1.ResultSet = 1;
            // 
            // rowCountCondition1
            // 
            rowCountCondition1.Enabled = true;
            rowCountCondition1.Name = "rowCountCondition1";
            rowCountCondition1.ResultSet = 1;
            rowCountCondition1.RowCount = 4;
            // 
            // checksumCondition1
            // 
            checksumCondition1.Checksum = "1402852810";
            checksumCondition1.Enabled = true;
            checksumCondition1.Name = "checksumCondition1";
            // 
            // executionTimeCondition1
            // 
            executionTimeCondition1.Enabled = true;
            executionTimeCondition1.ExecutionTime = System.TimeSpan.Parse("00:00:30");
            executionTimeCondition1.Name = "executionTimeCondition1";
            // 
            // testInitializeAction
            // 
            resources.ApplyResources(testInitializeAction, "testInitializeAction");
            // 
            // DatabaseTestsqlData
            // 
            this.DatabaseTestsqlData.PosttestAction = null;
            this.DatabaseTestsqlData.PretestAction = null;
            this.DatabaseTestsqlData.TestAction = DatabaseTestsql_TestAction;
            // 
            // DatabaseUnitTest
            // 
            this.TestInitializeAction = testInitializeAction;
        }

        #endregion


        #region 附加测试特性
        //
        // 编写测试时，可以使用以下附加特性:
        //
        // 在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        #endregion

        private DatabaseTestActions DatabaseTestsqlData;
    }
}
