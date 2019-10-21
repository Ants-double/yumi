using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;
using ZXing.QrCode.Internal;

namespace AntsTools.ViewModel
{
    public class QRCodeViewModel : ViewModelBase
    {

        public RelayCommand<string> CreateQR { get; set; }
        public RelayCommand<string> DistinguishQR { get; set; }
        public QRCodeViewModel()
        {
            CreateQR = new RelayCommand<string>(CreateQRFunction);
            DistinguishQR = new RelayCommand<string>(DistinguishQRFunction);

        }
        private void CreateQRFunction(string strContent)
        {
            string content = strContent;
            var byteMatrix = new MultiFormatWriter().encode(content, BarcodeFormat.QR_CODE, 200, 200);
           // Bitmap bitmap = toBitmap(byteMatrix);

        }
        private void DistinguishQRFunction(string strContent)
        {
            // create a barcode reader instance
            IBarcodeReader reader = new BarcodeReader();
            // load a bitmap
            var barcodeBitmap = (Bitmap)Image.FromFile("C:\\sample-barcode-image.png");
            // detect and decode the barcode inside the bitmap
            var result = reader.Decode(barcodeBitmap);
            // do something with the result
            if (result != null)
            {
                result.BarcodeFormat.ToString();
                strContent= result.Text;
            }
        }
    }
}
