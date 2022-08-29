using CRUD_API.DTO;
using CRUD_API.Helper;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;


namespace CRUD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarCodeController : ControllerBase
    {

        private readonly IConverter _converter;
        public BarCodeController(IConverter converter)
        {
            _converter = converter;
        }
        [HttpGet]
        [Route("GetBarcode")]
        public async Task<IActionResult> GetBarcode()
        {
            var img = BarCodeGenerate.Generate("26-000001", 290, 120);

            Image imgg = img;
            var data = ConvertImageToByte(imgg);
            return File(data, "image/png");
            // return Ok(img);
            // System.IO.File.ReadAllBytesAsync(img);
            // return File(img, "image/png");
            //return img;
        }
        private byte[] ConvertImageToByte(Image img)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                img.Save(memoryStream, ImageFormat.Png);
                return memoryStream.ToArray();
            }
        }

        [HttpGet]
        [Route("GetBarCodeInPDF")]
        public async Task<IActionResult> GetBarCodeInPDF()
        {

            var barcodeList = new List<BarCodeDTO>();
            for (var i = 1; i < 10; i++)
            {
                var all = new BarCodeDTO
                {
                    Image = BarCodeGenerate.GenerateBase64("BarCode" + i, BarcodeLib.TYPE.CODE128, 200, 40),
                    Desc = "BarCode -" + i
                };
                //var barcode = BarCodeGenerate.GenerateBase64("Akash-" + i, BarcodeLib.TYPE.CODE128, 200, 40);
                barcodeList.Add(all);
            }


            var content = new CssHelper
            {
                DocumentTitle = $"BarCode {DateTime.Now.ToString("dd-MM-yyyy hh:mm tt")}",
                FontName = "Roboto",
                FontSize = 12,
                MarginSettings = new MarginSettings { Top = 0, Bottom = 0, Left = 0, Right = 0 },
                ColorMode = DinkToPdf.ColorMode.Grayscale,
                HtmlContent = HtmlTemplete.BarCodeView(barcodeList),
                css = ""
            };

            var dataa = PdfGenerator.Generate(content);

            var file = _converter.Convert(dataa);


            return File(file, "application/pdf");


        }
    }
}
