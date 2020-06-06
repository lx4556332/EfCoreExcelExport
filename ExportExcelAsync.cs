using EfCoreExcelExport.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EfCoreExcelExport
{
    class ExportExcelAsync
    {
       public int q { get; set; }
        
       public List<TempExport> lists { get; set; }

        public void RunInvoke()
        {
            method(q, lists);
        }
        private void method(int q, List<TempExport> lists)
        {
            byte[] fileContents;
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add($".Net Core 导出");

                worksheet.Cells[1, 1].Value = "序号";
                worksheet.Cells[1, 2].Value = "Id";
                worksheet.Cells[1, 3].Value = "名称";
                worksheet.Cells[1, 4].Value = "年龄";

                int i = 2;
                foreach (var item in lists)
                {
                    worksheet.Cells["A" + i].Value = i - 1;
                    worksheet.Cells["B" + i].Value = item.Id;
                    worksheet.Cells["C" + i].Value = item.Name;
                    worksheet.Cells["D" + i].Value = item.Sex;
                    i = i + 1;
                }
                fileContents = package.GetAsByteArray();
            }

            var m_filePath = $"{Guid.NewGuid().ToString()}.xlsx";

            using (FileStream fsWrite = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "/ExportExcel/" + m_filePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                fsWrite.Write(fileContents, 0, fileContents.Length);
            }
            Console.WriteLine($"{q}写入完成...");

        }
    }
}
