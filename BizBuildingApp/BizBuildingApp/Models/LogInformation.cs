using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BizBuildingApp.Models
{
    public class LogInformation
    {
        public List<PropertyUser> Users { get; set; }
        public TenantLog TenantComplaint { get; set; }
    }
}