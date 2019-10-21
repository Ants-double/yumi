using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using System.Windows.Forms;

namespace LDHExcelAddIn
{
    public partial class ThisAddIn
    {
       
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            //Excel.Workbook book = this.Application.Workbooks[1];
            //Excel.Worksheet sheet = book.Worksheets[1];

            //MessageBox.Show(sheet.Name);
        }


        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
           // MessageBox.Show("end");
        }

        #region VSTO 生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
