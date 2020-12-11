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
    public partial class SaveCategory : System.Web.UI.Page
    {
        public int catId = 0;
        private int propertyId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["CatId"] != null)
            {
                catId = Convert.ToInt32(Request.QueryString["CatId"]);
            }
            if (!IsPostBack)
            {
                if (catId > 0)
                    BindData();
            }
        }
        private void BindData()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Configs.Global.BaseURL);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(Configs.Global.GetCategoryById + "/" + catId).Result;
            if (response.IsSuccessStatusCode)
            {
                Category objCategory = JsonConvert.DeserializeObject<Category>(response.Content.ReadAsStringAsync().Result);
                txtName.Text = objCategory.Name;
                txtDescription.Text = objCategory.Description;
            }
        }
        protected void lnkSubmit_Click(object sender, EventArgs e)
        {
            UserInformation objUserInfo = (UserInformation)Session["UserInfo"];
            propertyId = objUserInfo.PropertyId;
            Category objCategory = new Category();
            objCategory.PropertyId = propertyId;
            objCategory.Name = txtName.Text;
            objCategory.Description = txtDescription.Text;
            objCategory.CategoryId = catId;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Configs.Global.BaseURL);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var json = JsonConvert.SerializeObject(objCategory);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(Configs.Global.SaveCategory, data).Result;
            if (response.IsSuccessStatusCode)
            {
                Session["SaveSuccess"] = "1";
                Response.Redirect("CategoryTypes.aspx");
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