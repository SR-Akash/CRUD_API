using DinkToPdf;
using System.IO;

namespace CRUD_API.Helper
{
    public static class PdfGenerator
    {
        public static HtmlToPdfDocument Generate(CssHelper? element)
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = element.ColorMode ?? ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = element?.MarginSettings ?? default,
                DocumentTitle = element?.DocumentTitle ?? default,
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = element?.HtmlContent,
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), element?.css) },
                HeaderSettings = { FontName = element?.FontName, FontSize = element?.FontSize }, //, Right = "Page [page] of [toPage]"
                FooterSettings = { FontName = element?.FontName, FontSize = element?.FontSize, },
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            return pdf;
        }
    }
}
