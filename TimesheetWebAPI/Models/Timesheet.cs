using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimesheetWebAPI.Models
{
    public class Timesheet
    {
        public int TitleId { get; set; }
        public string TitleName { get; set; }
        public string Hours { get; set; }
        public DateTime? Date { get; set; }

    }
}