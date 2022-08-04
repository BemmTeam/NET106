using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM.SHARE.Helper
{
    public class QRcodeHelper
    {
        public string GenerateQrCodeString(string text) // http:host//product/{productId}
        {
            string data = "";
            if (!string.IsNullOrEmpty(text))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
                    QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrcode = new(qRCodeData);
                    using (Bitmap bitmap = qrcode.GetGraphic(20))
                    {
                        bitmap.Save(ms, ImageFormat.Png);
                        
                        data = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                    }
                }
            }

            return data;
        }
    }
}
