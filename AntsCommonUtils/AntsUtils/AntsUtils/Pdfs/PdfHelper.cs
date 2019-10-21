using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AntsUtils.Pdfs
{
    public class PdfHelper
    {
        public static void PrintExcelToPDF(string _lstrInputFile, string _lstrOutFile)
        {
            try
            {


                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                Workbook wb = excel.Workbooks.Open(_lstrInputFile);



                //iterate through tabs
                foreach (Worksheet s in wb.Sheets)
                {
                    // Save into a PDF.
                    string filename = _lstrOutFile + "\\" + s.Name + ".pdf";
                    const int xlQualityStandard = 2;

                    s.ExportAsFixedFormat(
                    Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF,
                    filename, xlQualityStandard, true, false,
                    Type.Missing, Type.Missing, false, Type.Missing);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 转换excel 成PDF文档
        /// </summary>
        /// <param name="_lstrInputFile">原文件路径</param>
        /// <param name="_lstrOutFile">pdf文件输出路径</param>
        /// <returns>true 成功</returns>
        public static bool ExcelToPdf(string _lstrInputFile, string _lstrOutFile)
        {
            Microsoft.Office.Interop.Excel.Application lobjExcelApp = null;
            Microsoft.Office.Interop.Excel.Workbooks lobjExcelWorkBooks = null;
            Microsoft.Office.Interop.Excel.Workbook lobjExcelWorkBook = null;

            string lstrTemp = string.Empty;
            object lobjMissing = System.Reflection.Missing.Value;

            try
            {
                lobjExcelApp = new Microsoft.Office.Interop.Excel.Application();
                lobjExcelApp.Visible = true;
                lobjExcelWorkBooks = lobjExcelApp.Workbooks;
                lobjExcelWorkBook = lobjExcelWorkBooks.Open(_lstrInputFile, true, true, lobjMissing, lobjMissing, lobjMissing, true,
                    lobjMissing, lobjMissing, lobjMissing, lobjMissing, lobjMissing, false, lobjMissing, lobjMissing);

                //Microsoft.Office.Interop.Excel 12.0.0.0之后才有这函数            
                lstrTemp = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".xls" + (lobjExcelWorkBook.HasVBProject ? 'm' : 'x');
                //lstrTemp = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".xls";
                lobjExcelWorkBook.SaveAs(lstrTemp, Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel4Workbook, Type.Missing, Type.Missing, Type.Missing, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing,
                    false, Type.Missing, Type.Missing, Type.Missing);
                //输出为PDF 第一个选项指定转出为PDF,还可以指定为XPS格式
                lobjExcelWorkBook.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, _lstrOutFile, Microsoft.Office.Interop.Excel.XlFixedFormatQuality.xlQualityStandard, Type.Missing, false, Type.Missing, Type.Missing, false, Type.Missing);
                lobjExcelWorkBooks.Close();
                lobjExcelApp.Quit();
            }
            catch (Exception ex)
            {
                //其他日志操作；
                return false;
            }
            finally
            {
                if (lobjExcelWorkBook != null)
                {
                    lobjExcelWorkBook.Close(Type.Missing, Type.Missing, Type.Missing);
                    Marshal.ReleaseComObject(lobjExcelWorkBook);
                    lobjExcelWorkBook = null;

                }
                if (lobjExcelWorkBooks != null)
                {
                    lobjExcelWorkBooks.Close();
                    Marshal.ReleaseComObject(lobjExcelWorkBooks);
                    lobjExcelWorkBooks = null;
                }
                if (lobjExcelApp != null)
                {
                    lobjExcelApp.Quit();
                    Marshal.ReleaseComObject(lobjExcelApp);
                    lobjExcelApp = null;

                }
                //主动激活垃圾回收器，主要是避免超大批量转文档时，内存占用过多，而垃圾回收器并不是时刻都在运行！
                GC.Collect();
                GC.WaitForPendingFinalizers();



            }
            return true;
        }
        /// <summary>
        /// WordToPDF
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="targetPath"></param>
        /// <returns></returns>
        public static bool WordToPDF(string sourcePath, string targetPath)
        {
            bool result = false;
            Microsoft.Office.Interop.Word.Application application = new Microsoft.Office.Interop.Word.Application();
            Document document = null;
            try
            {
                application.Visible = false;
                document = application.Documents.Open(sourcePath);
                document.ExportAsFixedFormat(targetPath, WdExportFormat.wdExportFormatPDF);
                result = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                result = false;
            }
            finally
            {
                document.Close();
            }
            return result;
        }
        /// <summary>
        ///  powerpointToPdf
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="OutPath"></param>
        /// <returns></returns>
        public static bool PowerpointToPdf(string Path, string OutPath)
        {
            bool result;
            var targetType = Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsPDF;
            try
            {
                var application = new Microsoft.Office.Interop.PowerPoint.Application();
                var persentation = application.Presentations.Open(Path, MsoTriState.msoTrue, MsoTriState.msoFalse, MsoTriState.msoFalse);
                persentation.SaveAs(OutPath, targetType, Microsoft.Office.Core.MsoTriState.msoTrue);
                result = true;

            }
            catch
            {

                result = false;
            }

            return result;
        }
    }
}
