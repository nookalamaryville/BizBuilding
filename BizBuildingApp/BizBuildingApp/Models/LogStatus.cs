using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BizBuildingApp.Models
{
    public class LogStatus
    {
        public int LogId { get; set; }
        public string Status { get; set; }
        public int? AssignedTo { get; set; }
    }
}