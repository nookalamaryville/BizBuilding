using BizBuildingApp.Helpers;
using BizBuildingApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BizBuildingApp.MyAccount
{
    public partial class SaveStaff : System.Web.UI.Page
    {
        public int staffId = 0;
        private int propertyId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["StaffId"] != null)
            {
                staffId = Convert.ToInt32(Request.QueryString["StaffId"]);
            }
            if (!IsPostBack)
            {
                if (staffId > 0)
                    BindData();
            }
        }
        private void BindData()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Configs.Global.BaseURL);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(Configs.Global.GetStaffById + "/" + staffId).Result;
            if (response.IsSuccessStatusCode)
            {
                PropertyUser objUser = JsonConvert.DeserializeObject<PropertyUser>(response.Content.ReadAsStringAsync().Result);
                if (!string.IsNullOrEmpty(objUser.EmailAddress))
                {
                    txtFirstName.Text = objUser.FirstName;
                    txtLastName.Text = objUser.LastName;
                    txtEmailAddress.Text = objUser.EmailAddress;
                    txtPhoneNumber.Text = objUser.PhoneNumber;
                    txtPassword.Attributes["value"] = EncryptDecrypt.DESDecrypt(objUser.Password);
                    if(objUser.UserType == "Landlord")
                    {
                        ddlUserType.Items.FindByValue("Landlord").Enabled = true;
                        ddlUserType.Enabled = false;
                    }
                    ddlUserType.SelectedValue = objUser.UserType;
                }
                else
                    Response.Redirect("Staffs.aspx");
            }
        }
        protected void lnkSubmit_Click(object sender, EventArgs e)
        {
            UserInformation objUserInfo = (UserInformation)Session["UserInfo"];
            propertyId = objUserInfo.PropertyId;
            PropertyUser objUser = new PropertyUser();
            objUser.UserId = staffId;
            objUser.FirstName = txtFirstName.Text;
            objUser.LastName = txtLastName.Text;
            objUser.EmailAddress = txtEmailAddress.Text;
            objUser.PhoneNumber = txtPhoneNumber.Text;
            objUser.Password = EncryptDecrypt.DESEncrypt(txtPassword.Text);
            objUser.UserType = ddlUserType.SelectedValue;
            objUser.PropertyId = propertyId;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Configs.Global.BaseURL);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var json = JsonConvert.SerializeObject(objUser);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(Configs.Global.SaveStaff, data).Result;
            if (response.IsSuccessStatusCode)
            {
                Session["SaveSuccess"] = "1";
                Response.Redirect("Staffs.aspx");
            }
            else
            {
                StatusInfo objStatus = JsonConvert.DeserializeObject<StatusInfo>(response.Content.ReadAsStringAsync().Result);
                lblError.Text = objStatus.Message;
                lblError.CssClass = "label-error";
            }
        }
    }
}