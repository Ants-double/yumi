
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Window = System.Windows.Window;
using Spire.Xls;
using System.IO;
using System.Threading;
using System.Windows.Threading;

namespace MergeExcelTools
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        private string sourcePathStr = "E:/test";
        private string resultPathStr = "E:/result.xlsx";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void merge_Click(object sender, RoutedEventArgs e)
        {
            try
            {

           
            List<FileInfo> lists = getFile(sourcePathStr, ".xlsx");
            Workbook workbook = new Workbook();
            if (!File.Exists(resultPathStr))
            {
                MessageBox.Show("请选择结果文件");
            }
            workbook.LoadFromFile(resultPathStr);

            merge.IsEnabled = false;
            //加载Excel文件
            foreach (FileInfo item in lists)
            {
                Workbook workbookTemp = new Workbook();
                workbookTemp.LoadFromFile(item.FullName);
                foreach (Worksheet itemSheet in workbookTemp.Worksheets)
                {
                    Worksheet sheetTemp = workbook.Worksheets.AddCopy(itemSheet);
                    sheetTemp.Name = itemSheet.Name + DateTime.Now.ToLocalTime().ToString("mmssfff");
                    statusLabel.Dispatcher.Invoke(DispatcherPriority.Background, (Action)delegate ()
                    {
                        statusLabel.Content = "正在处理" + item.FullName + itemSheet.Name;
                    });
                   
                }
            }


            //保存文件
            workbook.SaveToFile(resultPathStr);

            Thread.Sleep(300);
            merge.Content = "操作完成";
            merge.IsEnabled = true;
            MessageBox.Show("操作完成");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void sourceBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog folder = new System.Windows.Forms.FolderBrowserDialog();


            if (folder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                sourcePathStr = folder.SelectedPath;//获取文件夹路径
                sourceText.Text = sourcePathStr;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();


            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)//注意，此处一定要手动引入System.Window.Forms空间，否则你如果使用默认的DialogResult会发现没有OK属性
            {

                resultPathStr = openFileDialog.FileName;
                resultText.Text = resultPathStr;
            }
        }

        public List<FileInfo> getFile(string path, string extName)
        {
            List<FileInfo> lst = new List<FileInfo>();

            try
            {
                string[] dir = Directory.GetDirectories(path); //文件夹列表
                DirectoryInfo fdir = new DirectoryInfo(path);
                FileInfo[] file = fdir.GetFiles();
                //FileInfo[] file = Directory.GetFiles(path); //文件列表
                if (file.Length != 0 || dir.Length != 0) //当前目录文件或文件夹不为空
                {
                    foreach (FileInfo f in file) //显示当前目录所有文件
                    {
                        if (extName.ToLower().IndexOf(f.Extension.ToLower()) >= 0)
                        {
                            lst.Add(f);
                        }
                    }
                    foreach (string d in dir)
                    {
                        getFile(d, extName);//递归
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {

                return lst;
            }
        }
    }
}
