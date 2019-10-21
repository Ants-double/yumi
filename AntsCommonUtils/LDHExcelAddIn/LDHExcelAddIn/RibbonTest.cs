using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Ribbon;
using Excel = Microsoft.Office.Interop.Excel;
namespace LDHExcelAddIn
{
    public partial class RibbonTest
    {
        private void RibbonTest_Load(object sender, RibbonUIEventArgs e)
        {
            MessageBox.Show("如果有问题及时告诉我尽量能复现。=^_^=");

        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            var app = Globals.ThisAddIn.Application;
            Excel.Workbook book = app.Workbooks[1];
            Excel.Worksheet sheet = book.Worksheets[1];

            MessageBox.Show(sheet.Name);

            MessageBox.Show("点我");
        }

        private void SpanTableBtn_Click(object sender, RibbonControlEventArgs e)
        {
            var app = Globals.ThisAddIn.Application;
            app.DisplayAlerts = false;
            Excel.Workbook book = app.ActiveWorkbook;
            Excel.Worksheet sheet = book.ActiveSheet;
            var rowCount = sheet.UsedRange.Rows.Count;
            var colCount = sheet.UsedRange.Columns.Count;

            // MessageBox.Show(string.Format("{0}{1}", rowCount, colCount));
            for (int i = 1; i <= colCount; i++)//列
            {
                List<int> mergeList = new List<int>();
                for (int j = 1; j <= rowCount; j++)//行
                {
                    Range tempRan = sheet.Cells[j, i];//行，列
                    int start = j;
                    int end = j;

                    if (tempRan.Value != "" && tempRan.Value != null)
                    {
                        mergeList.Add(j);
                        continue;
                    }
                }

                if (mergeList.Count >= 2)
                {
                    if (!mergeList.Contains(rowCount))
                    {
                        mergeList.Add(rowCount);
                    }
                    for (int index = 0; index < mergeList.Count - 1; index++)
                    {
                        try
                        {
                            if (mergeList[index + 1] <= rowCount)
                            {

                                Range mergeRan = sheet.Range[sheet.Cells[mergeList[index], i], sheet.Cells[mergeList[index + 1] - 1, i]];
                                mergeRan.Application.DisplayAlerts = false;
                                mergeRan.Merge(Missing.Value);
                                mergeRan.Borders.LineStyle = XlLineStyle.xlLineStyleNone;
                                // mergeRan.ColumnWidth = 15;
                                mergeRan.VerticalAlignment = XlVAlign.xlVAlignCenter;
                                mergeRan.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                // mergeRan.Cells.Interior.Color = System.Drawing.Color.FromArgb(255, 204, 153).ToArgb();
                                // mergeRan.Columns.AutoFit();
                                mergeRan.Application.DisplayAlerts = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }

                    }

                }
            }

            // var v = sheet.get_Range("A1", "A11");

        }

        private void mergeColor_Click(object sender, RibbonControlEventArgs e)
        {
            var app = Globals.ThisAddIn.Application;
            app.DisplayAlerts = false;
            Excel.Workbook book = app.ActiveWorkbook;
            Excel.Worksheet sheet = book.ActiveSheet;
            var rowCount = sheet.UsedRange.Rows.Count;
            var colCount = sheet.UsedRange.Columns.Count;

            //MessageBox.Show(string.Format("{0}{1}", rowCount, colCount));

            List<Range> rangeList = new List<Range>();
            for (int j = 1; j <= rowCount; j++)//行
            {
                Range tempRan = sheet.Cells[j, 1];//行，列

                if (this.checkBoxColor.Checked)
                {
                    if (tempRan.MergeArea.Cells.Rows.Count == 1)
                    {
                        rangeList.Add(tempRan);

                    }
                    else
                    {
                        MessageBox.Show("有合并的单元格请不要勾选原生单元格选项");
                        break;
                    }
                }
                else
                {
                    if (tempRan.Value != "" && tempRan.Value != null)//不考虑原生的单元空格
                    {
                        rangeList.Add(tempRan);
                        //continue;
                    }
                }
                
                
            }
            Random rd = new Random();
            List<int> listColor = new List<int>();
            for (int colorNum = 0; colorNum < rangeList.Count; colorNum++)
            {
                listColor.Add(System.Drawing.Color.FromArgb(rd.Next(0, 255), rd.Next(0, 158), rd.Next(120, 255)).ToArgb());
            }
            //for (int rowOne = 1; rowOne <= rangeList.Count; rowOne++)//第一列
            //{
            //    Range numRan = sheet.Cells[rowOne, 1];
            //    numRan.Cells.Interior.Color = listColor.ElementAt(rowOne-1);
            //}
            for (int i = 1; i <= colCount; i++)//列
            {
                int falgNumber = 1;
                for (int index = 0; index < rangeList.Count; index++)
                {
                    int merNumber = rangeList[index].MergeArea.Rows.Count;
                    for (int num = 0; num < merNumber; num++)
                    {
                        Range numRan = sheet.Cells[falgNumber, i];
                        numRan.Cells.Interior.Color = listColor.ElementAt(index);
                        falgNumber++;
                    }
                }
            }



        }
    }
}
