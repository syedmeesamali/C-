using System;

namespace WorkDB
{
    class TaskLog
    {
        public DateTime Date { get; set; }
        public string ProjectName { get; set; }
        public string Place { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
    }
}
