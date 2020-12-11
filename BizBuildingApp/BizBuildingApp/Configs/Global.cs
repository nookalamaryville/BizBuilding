using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BizBuildingApp.Configs
{
    public static class Global
    {
#if DEBUG
        public const string BaseURL = "http://localhost:51061/api/BizBuilding/";
#else
        public const string BaseURL = "http://ec2-3-15-22-20.us-east-2.compute.amazonaws.com/api/BizBuilding/";
#endif
        public const string SignUpURL = "Signup";
        public const string SignInURL = "GetSignInInformation";
        public const string SaveTeantComplaint = "SaveCompliant";
        public const string TenantLogsList = "GetLogs";
        public const string GetLogInformation = "GetLogInformation";
        public const string UpdateLogStatus = "UpdateLogStatus";
        public const string DeleteLog = "DeleteLog";
        public const string StaffList = "GetStaffList";
        public const string SaveStaff = "SaveStaff";
        public const string GetStaffById = "GetUserInformation";
        public const string DeleteStaff = "DeleteStaff";
        public const string CategoriesList = "GetCategoriesList";
        public const string SaveCategory = "SaveCategory";
        public const string GetCategoryById = "GetCategoryInformation";
        public const string DeleteCategory = "DeleteCategory";
        public const string GetProfile = "GetPropertyInformation";
        public const string SaveProfile = "SavePropertyInformation";
    }
}