using ZXing;
using ZXing.Common;
using ZXing.SkiaSharp;
using SkiaSharp;
using MyApp1.Services.Interfaces;

namespace MyApp1.Services
{
    public class BarcodeService : IBarcodeService
    {
        public byte[] GenerateBarcode(string codice)
        {
            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.CODE_128,

                Options =
                {
                    Width = 400,
                    Height = 120,
                    Margin = 10
                }
            };

            using var bitmap = writer.Write(codice);

            using var image = SKImage.FromBitmap(bitmap);

            using var data = image.Encode(SKEncodedImageFormat.Png, 100);

            return data.ToArray();
        }
    }
}
