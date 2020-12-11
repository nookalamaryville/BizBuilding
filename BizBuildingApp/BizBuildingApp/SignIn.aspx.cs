using BizBuildingApp.Helpers;
using BizBuildingApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BizBuildingApp
{
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            UserLogin objLogin = new UserLogin();
            objLogin.EmailAddress = txtEmailAddress.Text;
            objLogin.Password = EncryptDecrypt.DESEncrypt(txtPassword.Text);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Configs.Global.BaseURL);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var json = JsonConvert.SerializeObject(objLogin);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(Configs.Global.SignInURL, data).Result;
            if (response.IsSuccessStatusCode)
            {                
                UserInformation objUserInfo = JsonConvert.DeserializeObject<UserInformation>(response.Content.ReadAsStringAsync().Result);               
                Session["UserInfo"] = objUserInfo;
                Response.Redirect("MyAccount/Default.aspx");
            }
            else
            {
                StatusInfo objStatus = JsonConvert.DeserializeObject<StatusInfo>(response.Content.ReadAsStringAsync().Result);
                lblError.Text = objStatus.Message;
            }
        }
    }
}