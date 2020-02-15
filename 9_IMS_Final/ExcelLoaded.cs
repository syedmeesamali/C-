using System;
using System.ComponentModel.DataAnnotations;

namespace IMS_Final
{
    class ExcelLoaded
    {
        [Key]
        public int ID { get; set; }
        public string LoadedFileExcel { get; set; }
    }
}
