using BarcodeLib;
using System;
using System.Drawing;

namespace CRUD_API.Helper
{
    public static class BarCodeGenerate
    {
        public static Image Generate(string text, int? width, int? height)
        {
            var b = new Barcode();
            var img = b.Encode(BarcodeLib.TYPE.CODE128, text, Color.Black, Color.White, width ?? 290, height ?? 120);
            return img;
        }

        public static string GenerateBase64(string text, TYPE type, int? width, int? height)
        {
            var b = new Barcode();
            var img = b.Encode(BarcodeLib.TYPE.CODE128, text, Color.Black, Color.White, width ?? 290, height ?? 120);

            var image = (byte[])new ImageConverter().ConvertTo(img, typeof(byte[]));
            string base64String = Convert.ToBase64String(image);
            string result = "data:image/png;base64," + Convert.ToBase64String(image);
            return result;
        }

        //public static string GenerateBase64(string text, TYPE type, int? width, int? height)
        //{
        //    var b = new Barcode();
        //    var img = b.Encode(BarcodeLib.TYPE.CODE128, text, Color.Black, Color.White, width ?? 290, height ?? 120);
        //    var ms = new MemoryStream();
        //    {

        //        img.Save(ms, System.Drawing.Imaging.ImageFormat.Png); ;
        //    }
        //    // var image = (byte[])new System.Drawing.ImageConverter()//ImageConverter().ConvertTo(img, typeof(byte[]));
        //    string base64String = Convert.ToBase64String(ms.ToArray());
        //    string result = "data:image/png;base64," + base64String;
        //    return result;
        //}
    }
}
