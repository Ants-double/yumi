using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeTools.Models
{
   public class FrameNavigation : ObservableObject
    {
        private string _name= "pages/WelcomePage.xaml";
        /// <summary>
        /// 页面名子
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                RaisePropertyChanged(() => Name);
            }
        }
    }
}
