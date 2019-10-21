using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using OfficeToolCommons;
using OfficeToolCommons.Helpers;
using OfficeTools.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace OfficeTools.ViewModel
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
            //��ʼ������
            FramePage = new FrameNavigation();
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            //��ʼ������
            ShowTxtCommand = new RelayCommand(ShowMsg, CanShowMsgExecute);
            CheckedCommand = new RelayCommand(Checked);

            UnCheckedCommand = new RelayCommand(UnChecked);
            SendCommand = new RelayCommand(() =>   
            {
                FramePage.Name = "pages/QRCode.xaml";
                //Messenger.Default.Send<string>(Msg, MessageToken.SendMessageToken);
                string strcmd = "ping www.baidu.com";
                MessageBox.Show(strcmd.RunCmd().TrimString());               
                    try
                    {
                        string path = "OfficeTools.Pages.QRCode";
                        Type type = Type.GetType(path);
                        object obj = type.Assembly.CreateInstance(path);
                        //Type t = System.Reflection.Assembly.GetExecutingAssembly().GetType(path);
                        Page p = obj as Page;                       
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
        /// �󶨵������Txt
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
        /// ��ʾ��Ϣ����
        /// </summary>
        public RelayCommand ShowTxtCommand
        {
            get;
            set;
        }
        /// <summary>
        /// �������ʵ��
        /// </summary>
        private void ShowMsg()
        {
            MessageBox.Show(Txt);
        }

        /// <summary>
        /// ��ʾ��Ϣ�����Ƿ����ִ��
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
            set {
                framePage = value;
                RaisePropertyChanged(() => FramePage);
            }
        }

    }


}