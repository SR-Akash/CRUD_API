using DinkToPdf;

namespace CRUD_API.Helper
{
    public class CssHelper
    {
        public MarginSettings MarginSettings { get; set; }
        public string DocumentTitle { get; set; }
        public string HtmlContent { get; set; }
        public string FontName { get; set; }
        // public string image { get; set; }
        public string css { get; set; }
        public int? FontSize { get; set; }
        public ColorMode? ColorMode { get; set; }
    }
}
