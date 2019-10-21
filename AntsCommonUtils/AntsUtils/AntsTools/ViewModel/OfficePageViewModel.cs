
using AntsUtils.Pdfs;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AntsTools.ViewModel
{
    public class OfficePageViewModel : ViewModelBase
    {
        public OfficePageViewModel()
        {
            OpenOriginFloader = new RelayCommand(SelectOriginPath);
            OpenResFloader = new RelayCommand(SelectResPath);
            Messenger.Default.Register<string>(this, MessageToken.SendMessageToken, (msg) =>
            {
                switch (msg)
                {
                    case "ShowLoading":
                        Visiable = Visibility.Visible;
                        break;
                    case "HiddenLoading":
                        Visiable = Visibility.Collapsed;
                        break;
                    default:
                        break;
                }
            });
        }

       

        /// <summary>
        /// 打开源文件夹
        /// </summary>
        public RelayCommand OpenOriginFloader { get; set; }
        /// <summary>
        /// 打开目标文件夹
        /// </summary>
        public RelayCommand OpenResFloader { get; set; }

        private Visibility _visiable=Visibility.Collapsed;
        /// <summary>
        /// 进度条
        /// </summary>
        public Visibility Visiable
        {
            get { return _visiable; }
            set
            {
                _visiable = value;
                RaisePropertyChanged(() => Visiable);
            }
        }
        private string statusContext="状态:";
        /// <summary>
        /// 
        /// </summary>
        public string StatusContext
        {
            get { return statusContext; }
            set {
                statusContext = value;
                RaisePropertyChanged(() => StatusContext);
            }
        }
        string SourcePath;
        string TargetPath;
        private void SelectOriginPath()
        {
            var dialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                SourcePath = dialog.SelectedPath;
                statusContext=string.Format("当前选中：{0}", SourcePath);
                // MessageBox.Show(dialog.SelectedPath);
            }

        }
        private void SelectResPath()
        {
            var dialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                TargetPath = dialog.SelectedPath;
                ChangeStatus(string.Format("当前选中：{0}", TargetPath));
                ChangeStatus("开始处理文档");
                Visiable = Visibility.Visible;
                var TaskDeal = Task.Factory.StartNew(() =>
                {
                    DirectoryInfo folder = new DirectoryInfo(SourcePath);
                    foreach (FileInfo file in folder.GetFiles("*.doc"))
                    {
                        // MessageBox.Show(file.FullName);
                        ChangeStatus(string.Format("正在处理：{0}...", file.Name));
                        PdfHelper.WordToPDF(file.FullName, System.IO.Path.Combine(TargetPath, file.Name + ".pdf"));
                    }
                    foreach (FileInfo file in folder.GetFiles("*.xls"))
                    {
                        // MessageBox.Show(file.FullName);
                        ChangeStatus(string.Format("正在处理{0}...", file.Name));
                        IMSConvert app = new MSExcel(file.FullName, System.IO.Path.Combine(TargetPath, file.Name + ".pdf"), true);
                        //PdfHelper.ExcelToPdf(file.FullName, System.IO.Path.Combine(TargetPath, file.Name+".pdf" ));
                        app.Convert();
                        app.Close();
                    }
                    GC.Collect();
                    foreach (FileInfo file in folder.GetFiles("*.ppt"))
                    {
                        // MessageBox.Show(file.FullName);
                        ChangeStatus(string.Format("正在处理{0}...", file.Name));
                        PdfHelper.PowerpointToPdf(file.FullName, System.IO.Path.Combine(TargetPath, file.Name + ".pdf"));
                    }
                });
                TaskDeal.ContinueWith((t) =>
                {
                    ChangeStatus(string.Format("处理完成"));
                    Visiable = Visibility.Collapsed;
                });
                //MessageBox.Show(dialog.SelectedPath);
            }
        }

      
        private void ChangeStatus(string strStatus)
        {
            DispatcherHelper.CheckBeginInvokeOnUI(() =>
            {
                StatusContext = strStatus;
            });

        }
       
    }


}


