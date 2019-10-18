using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvvmLight.ViewModel
{
   public class Window1ViewModel : ViewModelBase
    {
        public Window1ViewModel()
        {
            Messenger.Default.Register<string>(this, MessageToken.SendMessageToken, (msg) =>
            {
                Msg = msg;
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
    }
}
