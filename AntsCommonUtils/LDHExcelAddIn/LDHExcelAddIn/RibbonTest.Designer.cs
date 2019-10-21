namespace LDHExcelAddIn
{
    partial class RibbonTest : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public RibbonTest()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.DealTable = this.Factory.CreateRibbonTab();
            this.GroupTable = this.Factory.CreateRibbonGroup();
            this.TestBtn = this.Factory.CreateRibbonButton();
            this.separator1 = this.Factory.CreateRibbonSeparator();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.DealColor = this.Factory.CreateRibbonTab();
            this.groupColor = this.Factory.CreateRibbonGroup();
            this.SpanTableBtn = this.Factory.CreateRibbonButton();
            this.mergeColor = this.Factory.CreateRibbonButton();
            this.colorSpanDialog = new System.Windows.Forms.ColorDialog();
            this.checkBoxColor = this.Factory.CreateRibbonCheckBox();
            this.separator2 = this.Factory.CreateRibbonSeparator();
            this.DealTable.SuspendLayout();
            this.GroupTable.SuspendLayout();
            this.DealColor.SuspendLayout();
            this.groupColor.SuspendLayout();
            this.SuspendLayout();
            // 
            // DealTable
            // 
            this.DealTable.Groups.Add(this.GroupTable);
            this.DealTable.Groups.Add(this.group1);
            this.DealTable.Label = "测试功能";
            this.DealTable.Name = "DealTable";
            // 
            // GroupTable
            // 
            this.GroupTable.Items.Add(this.TestBtn);
            this.GroupTable.Items.Add(this.separator1);
            this.GroupTable.Label = "表格";
            this.GroupTable.Name = "GroupTable";
            // 
            // TestBtn
            // 
            this.TestBtn.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.TestBtn.Image = global::LDHExcelAddIn.Properties.Resources.test;
            this.TestBtn.Label = "测试\n功能";
            this.TestBtn.Name = "TestBtn";
            this.TestBtn.ShowImage = true;
            this.TestBtn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click);
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
            // 
            // group1
            // 
            this.group1.Label = "group1";
            this.group1.Name = "group1";
            // 
            // DealColor
            // 
            this.DealColor.Groups.Add(this.groupColor);
            this.DealColor.Label = "我党定制";
            this.DealColor.Name = "DealColor";
            // 
            // groupColor
            // 
            this.groupColor.Items.Add(this.SpanTableBtn);
            this.groupColor.Items.Add(this.separator2);
            this.groupColor.Items.Add(this.checkBoxColor);
            this.groupColor.Items.Add(this.mergeColor);
            this.groupColor.Label = "颜色处理";
            this.groupColor.Name = "groupColor";
            // 
            // SpanTableBtn
            // 
            this.SpanTableBtn.Label = "合并单元格";
            this.SpanTableBtn.Name = "SpanTableBtn";
            this.SpanTableBtn.ScreenTip = "从上向下合并";
            this.SpanTableBtn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.SpanTableBtn_Click);
            // 
            // mergeColor
            // 
            this.mergeColor.Label = "填充颜色";
            this.mergeColor.Name = "mergeColor";
            this.mergeColor.ScreenTip = "以第一列为主随机填充颜色，可以多次点击";
            this.mergeColor.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.mergeColor_Click);
            // 
            // checkBoxColor
            // 
            this.checkBoxColor.Label = "原生单元格";
            this.checkBoxColor.Name = "checkBoxColor";
            // 
            // separator2
            // 
            this.separator2.Name = "separator2";
            // 
            // RibbonTest
            // 
            this.Name = "RibbonTest";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.DealTable);
            this.Tabs.Add(this.DealColor);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.RibbonTest_Load);
            this.DealTable.ResumeLayout(false);
            this.DealTable.PerformLayout();
            this.GroupTable.ResumeLayout(false);
            this.GroupTable.PerformLayout();
            this.DealColor.ResumeLayout(false);
            this.DealColor.PerformLayout();
            this.groupColor.ResumeLayout(false);
            this.groupColor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab DealTable;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup GroupTable;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton TestBtn;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator1;
        internal Microsoft.Office.Tools.Ribbon.RibbonTab DealColor;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupColor;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton SpanTableBtn;
        private System.Windows.Forms.ColorDialog colorSpanDialog;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton mergeColor;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator2;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox checkBoxColor;
    }

    partial class ThisRibbonCollection
    {
        internal RibbonTest RibbonTest
        {
            get { return this.GetRibbon<RibbonTest>(); }
        }
    }
}
