using BizBuildingApp.Helpers;
using BizBuildingApp.Models;
using BizBuildingApp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;

namespace BizBuildingApp
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
        }
        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            PropertySignUp propertySignUp = new PropertySignUp();
            Property property = new Property();
            PropertyUser propertyUser = new PropertyUser();
            property.Name = txtPropertyName.Text;
            propertyUser.EmailAddress = txtEmailAddress.Text;
            propertyUser.Password = EncryptDecrypt.DESEncrypt(txtPassword.Text);
            propertyUser.UserType = "Landlord";
            propertySignUp.property = property;
            propertySignUp.propertyUser = propertyUser;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Configs.Global.BaseURL);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var json = JsonConvert.SerializeObject(propertySignUp);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(Configs.Global.SignUpURL, data).Result;
            if (response.IsSuccessStatusCode)
            {
                Response.Redirect("SignUpSucess.html");
            }
            else
            {
                StatusInfo objStatus = JsonConvert.DeserializeObject<StatusInfo>(response.Content.ReadAsStringAsync().Result);
                lblMessage.Text = objStatus.Message;
                lblMessage.CssClass = "label-error";
                txtEmailAddress.Text = "";
            }
        }
    }
}