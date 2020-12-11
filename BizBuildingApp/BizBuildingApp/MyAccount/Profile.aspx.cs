using BizBuildingApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BizBuildingApp.MyAccount
{
    public partial class Profile : System.Web.UI.Page
    {
        private int propertyId;
        protected string propertyQRCode = "https://" + ConfigurationManager.AppSettings["QRCodeBucket"] + ".s3.amazonaws.com";
        protected void Page_Load(object sender, EventArgs e)
        {
            UserInformation objUserInfo = (UserInformation)Session["UserInfo"];
            propertyId = objUserInfo.PropertyId;
            propertyQRCode = propertyQRCode + "/" + Convert.ToString(propertyId) + ".png";
            if (!IsPostBack)
            {                
                BindData();
            }
        }
        private void BindData()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Configs.Global.BaseURL);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(Configs.Global.GetProfile + "/" + propertyId).Result;
            if (response.IsSuccessStatusCode)
            {
                Property objProperty = JsonConvert.DeserializeObject<Property>(response.Content.ReadAsStringAsync().Result);
                txtPropertyName.Text = objProperty.Name;
                txtAddress.Text = objProperty.Address;
                txtCity.Text = objProperty.City;
                txtState.Text = objProperty.State;
                txtZipcode.Text = objProperty.Zipcode;
            }
            else
            {
                StatusInfo objStatus = JsonConvert.DeserializeObject<StatusInfo>(response.Content.ReadAsStringAsync().Result);
            }
        }
        protected void lnkSave_Click(object sender, EventArgs e)
        {
            Property property = new Property();
            property.PropertyId = propertyId;
            property.Name = txtPropertyName.Text;
            property.Address = txtAddress.Text;
            property.City = txtCity.Text;
            property.State = txtState.Text;
            property.Zipcode = txtZipcode.Text;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Configs.Global.BaseURL);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var json = JsonConvert.SerializeObject(property);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(Configs.Global.SaveProfile, data).Result;
            if (response.IsSuccessStatusCode)
            {
                lblMessage.Text = "You information has been saved successfully.";
            }
            else
            {
                StatusInfo objStatus = JsonConvert.DeserializeObject<StatusInfo>(response.Content.ReadAsStringAsync().Result);
                lblMessage.Text = "You information has been saved successfully.";
                lblMessage.CssClass = "label-error";
                BindData();
            }
        }
    }
}