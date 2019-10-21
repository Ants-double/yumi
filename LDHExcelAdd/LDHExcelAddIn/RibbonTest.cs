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
            // MessageBox.Show("如果有问题及时告诉我尽量能复现。=^_^=");

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
            try
            {
                var app = Globals.ThisAddIn.Application;
                if (app.DisplayAlerts==true)
                {
                    app.DisplayAlerts = false;
                }
                Excel.Workbook book = app.ActiveWorkbook;
                Excel.Worksheet sheet = book.ActiveSheet;
                var rowCount = sheet.UsedRange.Rows.Count;
                var colCount = sheet.UsedRange.Columns.Count;

                // MessageBox.Show(string.Format("{0}{1}", rowCount, colCount));
                for (int i = sheet.UsedRange.Column; i < sheet.UsedRange.Column + colCount; i++)//列
                {
                    List<int> mergeList = new List<int>();
                    for (int j = sheet.UsedRange.Row; j < sheet.UsedRange.Row + rowCount; j++)//行
                    {
                        Range tempRan = sheet.Cells[j, i];//行，列
                        int start = j;
                        int end = j;
                        if (tempRan.Value != null)
                        {
                            if (tempRan.Value.GetType().Name == "Double" || tempRan.Value.GetType().Name == "String")
                            {
                                if (string.Format("{0}",tempRan.Value) != "")
                                {
                                    mergeList.Add(j);
                                    // continue;
                                }
                            }
                            else
                            {
                                mergeList.Add(j);
                            }
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

                            if (mergeList[index + 1] <= rowCount)
                            {

                                Range mergeRan = sheet.Range[sheet.Cells[mergeList[index], i], sheet.Cells[mergeList[index + 1] - 1, i]];
                                if (mergeList[index] == rowCount)
                                {
                                    mergeRan = sheet.Range[sheet.Cells[mergeList[index], i], sheet.Cells[mergeList[index + 1], i]];
                                }
                                //if (mergeRan.Application.DisplayAlerts==true)
                                //{
                                //    mergeRan.Application.DisplayAlerts = false;

                                //}
                                mergeRan.Merge(Missing.Value);
                                mergeRan.Borders.LineStyle = XlLineStyle.xlLineStyleNone;
                                // mergeRan.ColumnWidth = 15;
                                mergeRan.VerticalAlignment = XlVAlign.xlVAlignCenter;
                                mergeRan.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                // mergeRan.Cells.Interior.Color = System.Drawing.Color.FromArgb(255, 204, 153).ToArgb();
                                // mergeRan.Columns.AutoFit();
                               // mergeRan.Application.DisplayAlerts = true;
                            }


                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
            for (int j = sheet.UsedRange.Row; j < sheet.UsedRange.Row + rowCount; j++)//行
            {
                Range tempRan = sheet.Cells[j, sheet.UsedRange.Column];//行，列

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
                    // if (string.Format(tempRan.Value) != "" && tempRan.Value != null)//不考虑原生的单元空格
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
            for (int i = sheet.UsedRange.Column; i < sheet.UsedRange.Column + colCount; i++)//列
            {
                int falgNumber = sheet.UsedRange.Row;
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



        private void Sheet_SelectionChange(Range Target)
        {
            var colCount = Target.Columns.Count;
            var rowCount = Target.Rows.Count;
            decimal sum = 0;
            for (int i = Target.Column; i < Target.Column + colCount; i++)//列
            {

                for (int j = Target.Row; j < Target.Row + rowCount; j++)//行
                {
                    Range tempRan = SheetWork.Cells[j, i];//行，列

                    if (tempRan.Value != null)
                    {
                        if (tempRan.Value.GetType().Name == "Double" || tempRan.Value.GetType().Name == "String")
                        {

                            decimal value = 0;
                            if (decimal.TryParse(string.Format("{0}", tempRan.Value), out value))
                            {
                                sum += value;
                            }
                            else
                            {
                                MessageBox.Show(string.Format("第{0}行{1}列不是有效的数字", j, i));
                            }
                        }
                        else
                        {
                            MessageBox.Show(string.Format("第{0}行{1}列不是有效的数字", j, i));
                        }

                    }

                }
            }
            MessageBox.Show(string.Format("有效数字之和是{0}", sum));
        }

        private void AddSum_Click(object sender, RibbonControlEventArgs e)
        {
            var app = Globals.ThisAddIn.Application;
            app.DisplayAlerts = false;
            Excel.Workbook book = app.ActiveWorkbook;
            Excel.Worksheet sheet = book.ActiveSheet;
            var rowCount = sheet.UsedRange.Rows.Count;
            var colCount = sheet.UsedRange.Columns.Count;
            decimal sum = 0;
            if (colCount < 2)
            {
                MessageBox.Show("只有一列序号不进行求和");
                return;
            }
            for (int i = sheet.UsedRange.Column > 2 ? sheet.UsedRange.Column : 1; i <= (sheet.UsedRange.Column > 2 ? sheet.UsedRange.Column : 1) + colCount; i++)//列
            {

                for (int j = sheet.UsedRange.Row; j <= sheet.UsedRange.Row + rowCount; j++)//行
                {
                    Range tempRan = sheet.Cells[j, i];//行，列

                    if (tempRan.Value != null)
                    {
                        if (tempRan.Value.GetType().Name == "Double" || tempRan.Value.GetType().Name == "String")
                        {

                            decimal value = 0;
                            if (decimal.TryParse(string.Format("{0}", tempRan.Value), out value))
                            {
                                sum += value;
                            }
                            else
                            {
                                MessageBox.Show(string.Format("第{0}行{1}列不是有效的数字", j, i));
                            }
                        }
                        else
                        {
                            MessageBox.Show(string.Format("第{0}行{1}列不是有效的数字", j, i));
                        }

                    }

                }
            }
            MessageBox.Show(string.Format("有效数字之和是{0}", sum));
        }
        Excel.Worksheet SheetWork = null;
        private void SelectSum_Click(object sender, RibbonControlEventArgs e)
        {



        }

        private void SelectAir_Click(object sender, RibbonControlEventArgs e)
        {
            var app = Globals.ThisAddIn.Application;
            app.DisplayAlerts = false;
            Excel.Workbook book = app.ActiveWorkbook;
            Excel.Worksheet sheet = book.ActiveSheet;
            SheetWork = sheet;
            if (this.SelectAir.Checked)
            {
                SheetWork.SelectionChange += Sheet_SelectionChange;
            }
            else
            {
                SheetWork.SelectionChange -= Sheet_SelectionChange;
            }

        }

        private void Button1_Click_1(object sender, RibbonControlEventArgs e)
        {

        }
    }
}
