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
        static async Task Main(string[] args)
        {
            IExporter exporter = new ExcelExporter();
            var data = new List<ExportTestDataWithPicture>();
            data.Add(new ExportTestDataWithPicture
            {
                Img = "http://image-demo.oss-cn-hangzhou.aliyuncs.com/example.jpg"
            });

            var filePath = Path.Combine(AppContext.BaseDirectory, "test.xlsx");
            var result = await exporter.Export(filePath, data);
            Console.WriteLine(result.FileName);
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
