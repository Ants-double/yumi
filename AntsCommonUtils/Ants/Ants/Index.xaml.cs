using Ants.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Ants
{
    /// <summary>
    /// Index.xaml 的交互逻辑
    /// </summary>
    public partial class Index : Window
    {
        string SourcePath;
        string TargetPath;

        public Index()
        {
            InitializeComponent();
            btnOpenOriginalFolder.Click += BtnOpenOriginalFolder_Click;
            btnOpenDealFolder.Click += BtnOpenDealFolder_Click;
            StartDeal.Click += StartDeal_Click;
            CloseWord.Click += CloseWord_Click;
            CloseExcel.Click += CloseExcel_Click;
            ClosePpt.Click += ClosePpt_Click;
            this.Loaded += Index_Loaded;
            // ShowLoading("aaaa");
        }

        private void ClosePpt_Click(object sender, RoutedEventArgs e)
        {
            //杀死打开的word进程
            Process myProcess = new Process();
            Process[] wordProcess = Process.GetProcessesByName("POWERPNT");
            foreach (var pro in wordProcess)
            {
                //IntPtr ip = pro.MainWindowHandle;
                pro.Kill();
            }
        }

        private void CloseExcel_Click(object sender, RoutedEventArgs e)
        {
            //杀死打开的word进程
            Process myProcess = new Process();
            Process[] wordProcess = Process.GetProcessesByName("excel");
            foreach (var pro in wordProcess)
            {
                //IntPtr ip = pro.MainWindowHandle;
                pro.Kill();
            }
        }

        private void CloseWord_Click(object sender, RoutedEventArgs e)
        {
            //杀死打开的word进程
            Process myProcess = new Process();
            Process[] wordProcess = Process.GetProcessesByName("winword");
            foreach (var pro in wordProcess)
            {
                //IntPtr ip = pro.MainWindowHandle;
                pro.Kill();
            }
        }

        private void Index_Loaded(object sender, RoutedEventArgs e)
        {
            ReadMeMessage.Text = FileHelper.Read(AppDomain.CurrentDomain.BaseDirectory + "readme.txt", Encoding.Default);
            // ReadMeMessage.TextWrapping = TextWrapping.Wrap;
        }

        private void StartDeal_Click(object sender, RoutedEventArgs e)
        {
            DealFloderFile();
        }

        private void BtnOpenDealFolder_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            if (dialog.ShowDialog(this).GetValueOrDefault())
            {
                TargetPath = dialog.SelectedPath;
                ChangeLoadingContent(string.Format("当前选中：{0}", TargetPath));
                if (SourcePath == TargetPath)
                {
                    MessageBox.Show("两个目录相同将自动保存在同级目录并追加Temp以区别,否则请重新选择");
                    TargetPath += "Temp";
                }
            }
        }

        private void DealFloderFile()
        {
            ShowLoading("开始处理文档");
            var TaskDeal = Task.Factory.StartNew(() =>
            {
                List<FileInfo> listRes = FileHelper.GetAllFileName(SourcePath);
                ChangeLoadingContent(string.Format("一共有{0}文件处理", listRes.Count));
                try
                {
                    //获取所有的目录结构并创建
                    FileHelper.CopyDirNotCopyFile(SourcePath, TargetPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                ReadMeMessage.Dispatcher.Invoke(() =>
                {
                    ReadMeMessage.Text = string.Format("一共有{0}文件处理,文件数据多将启用并发转换，需要一定的资源，电脑可能有所卡顿", listRes.Count);
                });

                foreach (FileInfo item in listRes)
                {
                    switch (item.Extension)
                    {
                        case ".doc":
                        case ".docx":
                            var docTask = Task.Factory.StartNew(() =>
                            {
                                ChangeLoadingContent(string.Format("正在处理：{0}...", item.FullName));
                                PdfHelper.WordToPDF(item.FullName, TargetPath + item.FullName.Substring(item.FullName.IndexOf("\\")) + ".pdf");
                            }, TaskCreationOptions.AttachedToParent);
                            break;
                        case ".xls":
                        case ".xlsx":
                            var xlsTask = Task.Factory.StartNew(() =>
                            {
                                ChangeLoadingContent(string.Format("正在处理{0}...", item.FullName));
                                IMSConvert app = new MSExcel(item.FullName, TargetPath + item.FullName.Substring(item.FullName.IndexOf("\\")) + ".pdf", true);
                                //PdfHelper.ExcelToPdf(file.FullName, System.IO.Path.Combine(TargetPath, file.Name+".pdf" ));
                                app.Convert();
                                app.Close();
                                GC.Collect();
                            }, TaskCreationOptions.AttachedToParent);
                            break;
                        case ".ppt":
                        case ".pptx":
                            var pptTask = Task.Factory.StartNew(() =>
                            {
                                ChangeLoadingContent(string.Format("正在处理{0}...", item.FullName));
                                PdfHelper.PowerpointToPdf(item.FullName, TargetPath + item.FullName.Substring(item.FullName.IndexOf("\\")) + ".pdf");
                            }, TaskCreationOptions.AttachedToParent);
                            break;
                        case ".pdf":
                            var pdfTask = Task.Factory.StartNew(() =>
                            {
                                ChangeLoadingContent(string.Format("正在处理{0}...", item.FullName));
                                IMSConvert appWord = new MSWord(item.FullName, TargetPath + item.FullName.Substring(item.FullName.IndexOf("\\")) + ".docx", true);
                                //PdfHelper.ExcelToPdf(file.FullName, System.IO.Path.Combine(TargetPath, file.Name+".pdf" ));
                                appWord.Convert();
                                appWord.Close();
                            }, TaskCreationOptions.AttachedToParent);
                            break;
                        default:
                            break;
                    }
                }

            });
            TaskDeal.ContinueWith((t) =>
            {
                ChangeLoadingContent(string.Format("处理完成,正在回收内存"));
                GC.Collect();
                GC.WaitForPendingFinalizers();
                ChangeLoadingContent(string.Format("处理完成"));
                HiddenLoading();
            });
        }

        private void BtnOpenOriginalFolder_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            if (dialog.ShowDialog(this).GetValueOrDefault())
            {
                SourcePath = dialog.SelectedPath;
                ChangeLoadingContent(string.Format("当前选中：{0}", SourcePath));
                if (SourcePath.Length < 4)
                {
                    MessageBox.Show("不支持根目录，请移动文件夹后再重新选择");
                }
            }
        }


        private void ChangeLoadingContent(string strContent)
        {

            TipMessage.Dispatcher.Invoke(() =>
                {
                    TipMessage.Text = strContent;
                });
            //MainLoading.Dispatcher.Invoke(() =>
            //{
            //    MainLoading.TipContentLoading.Text = strContent;
            //});
        }

        private void ShowLoading(string strContent = "处理中...")
        {
            MainLoading.Dispatcher.Invoke(() =>
            {
                // MainLoading.TipContentLoading.Text = strContent;
                MainLoading.Visibility = Visibility.Visible;
            });
        }

        private void HiddenLoading()
        {
            MainLoading.Dispatcher.Invoke(() =>
            {
                MainLoading.Visibility = Visibility.Hidden;
            });
        }
    }
}
