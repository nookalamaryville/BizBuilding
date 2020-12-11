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
    public partial class TenantLogForm : System.Web.UI.Page
    {
        private int propertyId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["PropId"] != null)
            {
                propertyId = Convert.ToInt32(Request.QueryString["PropId"]);
            }
            else
                Response.Redirect("index.html");
            if (!IsPostBack)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Configs.Global.BaseURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(Configs.Global.CategoriesList + "/" + propertyId).Result;
                if (response.IsSuccessStatusCode)
                {
                    List<Category> objCategories = JsonConvert.DeserializeObject<List<Category>>(response.Content.ReadAsStringAsync().Result);
                    ddlCategories.DataSource = objCategories;
                    ddlCategories.DataBind();                    
                }
                else
                {
                    StatusInfo objStatus = JsonConvert.DeserializeObject<StatusInfo>(response.Content.ReadAsStringAsync().Result);
                }
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            TenantComplaint objTenantComplaint = new TenantComplaint();
            objTenantComplaint.PropertyId = propertyId;
            objTenantComplaint.CategoryId = Convert.ToInt32(ddlCategories.SelectedValue);
            objTenantComplaint.Location = txtLocation.Text;
            objTenantComplaint.Description = txtDescription.Text;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Configs.Global.BaseURL);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var json = JsonConvert.SerializeObject(objTenantComplaint);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(Configs.Global.SaveTeantComplaint, data).Result;
            if (response.IsSuccessStatusCode)
            {
                Response.Redirect("TenantLogSuccess.html");
            }
            else
            {
                StatusInfo objStatus = JsonConvert.DeserializeObject<StatusInfo>(response.Content.ReadAsStringAsync().Result);
                lblMessage.Text = objStatus.Message;
                lblMessage.CssClass = "label-error";
            }
        }
    }
}