using CRUD_API.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_API.Helper
{
    public class HtmlTemplete
    {
        public static string BarCodeView(List<BarCodeDTO> image)
        {
            var sb = new StringBuilder();
            sb.Append($@"
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta http-equiv='X-UA-Compatible' content='IE=edge'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
  
    <title>Campaign {DateTime.Now.ToString("dd-MM-yyyy")}</title>
</head>
<body>
<div style=' width: 100%; margin: 100;'>
");
            foreach (var item in image)
            {
                sb.Append($@"
    <div style='display: inline-block;
                  width: 20%;
                  height: 100px;'>
     
        <div style='margin:10px;bottom-margin-10px'>
          <img src='{item.Image}' alt='image' />
           <p>{item.Desc}</p>
        </div>
      
    </div>
  ");
            }

            sb.Append($@"
  </div>
</body>
</html>
            ");

            return sb.ToString();
        }
    }
}
