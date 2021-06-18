using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Magicodes.ExporterAndImporter.Core;
using Magicodes.ExporterAndImporter.Excel;

namespace ExcelExportDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string format=args[0];
            string img=format.ToLower() == "png" ? "https://gitee.com/magicodes/Magicodes.IE/raw/master/docs/Magicodes.IE.png" : "https://gitee.com/magicodes/Magicodes.IE/raw/master/res/wechat.jpg";
            IExporter exporter = new ExcelExporter();

            var data = new List<ExportTestDataWithPicture>
            {
                new ExportTestDataWithPicture
                {
                    Img =img
                }
            };

            var filePath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "test.xlsx");
            var result = exporter.Export("test.xlsx", data).Result;
            Console.WriteLine("导出成功！");
        }
    }

    [ExcelExporter(Name = "测试")]
    public class ExportTestDataWithPicture
    {
        [ExportImageField(Width = 50, Height = 120, Alt = "404")]
        [ExporterHeader(DisplayName = "图", IsAutoFit = false)]
        public string Img { get; set; }
    }
}
