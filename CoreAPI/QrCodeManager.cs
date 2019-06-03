using QRCoder;

namespace CoreAPI
{
    public class QrCodeManager : BaseManager
    {
        public string GenerateQRCode(string path)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(path, QRCodeGenerator.ECCLevel.Q);
            Base64QRCode qrCode = new Base64QRCode(qrCodeData);
            string qrCodeImageAsBase64 = qrCode.GetGraphic(20);

            return qrCodeImageAsBase64;
        }
    }
}
