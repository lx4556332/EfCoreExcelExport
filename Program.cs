using EfCoreExcelExport.Models;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EfCoreExcelExport
{
    class Program
    {
        static void Main(string[] args)
        {
            var  lists=new List<TempExport>();
            using (var context = new CompleteExcelExportContext())
            {
                 lists = context.TempExport.ToList();
            }
  
            for (var q = 1; q < 4; q++)
            {
                var ll = lists.Where(t => t.Id == q).ToList();
                ExportExcelAsync c = new ExportExcelAsync();
                c.q = q;
                c.lists = ll;
                Thread t = new Thread(new ThreadStart(c.RunInvoke)); //多线程执行
                t.IsBackground = true;
                t.Start();
            }
            Console.ReadLine();
        }
    }
}
