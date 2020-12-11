using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BizBuildingApp.Models
{
    public class PropertyUser
    {
        public int UserId { get; set; }
        public int PropertyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string UserType { get; set; }
        public string FullName { get; set; }
    }
    public class UserLogin
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}