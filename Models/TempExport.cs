using System;
using System.Collections.Generic;

namespace EfCoreExcelExport.Models
{
    public partial class TempExport
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public int? Sex { get; set; }
        public int? National { get; set; }
    }
}
