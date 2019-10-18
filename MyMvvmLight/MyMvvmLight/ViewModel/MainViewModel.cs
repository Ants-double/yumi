using GalaSoft.MvvmLight;
//using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.CommandWpf;

using GalaSoft.MvvmLight.Messaging;
using System.Windows;

namespace MyMvvmLight.ViewModel
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
                Messenger.Default.Send<string>(Msg, MessageToken.SendMessageToken);
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
    }
}