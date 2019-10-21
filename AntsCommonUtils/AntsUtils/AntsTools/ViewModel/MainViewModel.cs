using AntsTools.Models;
using AntsUtils.Strings;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows;
using System.Windows.Controls;

namespace AntsTools.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            //初始化对象
            FramePage = new FrameNavigation();
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            //初始化命令
            ShowQRCommand = new RelayCommand<string>(ShowQRPage);
            ShowCodeTransCommand = new RelayCommand<string>(ShowCodeTransPage);
            CheckedCommand = new RelayCommand(Checked);

            UnCheckedCommand = new RelayCommand(UnChecked);
            SendCommand = new RelayCommand(() =>
            {
                FramePage.Name = "pages/OfficePage.xaml";
               
                try
                {
                    string path = "AntsTools.Pages.OfficePage";
                    Type type = Type.GetType(path);
                    object obj = type.Assembly.CreateInstance(path);
                    //Type t = System.Reflection.Assembly.GetExecutingAssembly().GetType(path);
                    Page p = obj as Page;
                    Messenger.Default.Send<string>("HiddenLoading", MessageToken.SendMessageToken);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            });
        }
        private string _msg;


        public string Msg
        {
            get
            {
                return _msg;
            }
            set
            {
                _msg = value;
                RaisePropertyChanged(() => Msg);
            }
        }
        public RelayCommand SendCommand
        {
            get; set;
        }



        public RelayCommand CheckedCommand
        {
            get;
            set;
        }

        public RelayCommand UnCheckedCommand
        {
            get;
            set;
        }

        private void Checked()
        {
            MessageBox.Show("Checked");
        }

        private void UnChecked()
        {
            MessageBox.Show("Unchecked");
        }
        private string _txt;

        /// <summary>
        /// 绑定到界面的Txt
        /// </summary>
        public string Txt
        {
            get
            {
                return _txt;
            }
            set
            {
                _txt = value;
                RaisePropertyChanged(() => Txt);
            }
        }

        /// <summary>
        /// 显示二维码页面
        /// </summary>
        public RelayCommand<string> ShowQRCommand
        {
            get;
            set;
        }
        public RelayCommand<string> ShowCodeTransCommand
        {
            get;set;
        }
        /// <summary>
        /// 命令显示二维码页面
        /// </summary>
        private void ShowQRPage(string pagePath)
        {
            FramePage.Name = "pages/QRCode.xaml";
            ShowPathPage(pagePath);
        }

        private  void ShowPathPage(string pagePath)
        {
            try
            {
                Type type = Type.GetType(pagePath);
                object obj = type.Assembly.CreateInstance(pagePath);
                // Type t = System.Reflection.Assembly.GetExecutingAssembly().GetType(pagePath);
                Page p = obj as Page;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowCodeTransPage(string pagePath)
        {
            FramePage.Name = "pages/CodeTransform.xaml";
            ShowPathPage(pagePath);
        }
        /// <summary>
        /// 显示消息命令是否可以执行
        /// </summary>
        /// <returns></returns>
        private bool CanShowMsgExecute()
        {
            return !string.IsNullOrEmpty(Txt);
        }

        private FrameNavigation framePage;

        public FrameNavigation FramePage
        {
            get { return framePage; }
            set
            {
                framePage = value;
                RaisePropertyChanged(() => FramePage);
            }
        }

    }

}