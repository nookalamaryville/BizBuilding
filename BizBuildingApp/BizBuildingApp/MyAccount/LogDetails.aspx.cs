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
    public partial class LogDetails : System.Web.UI.Page
    {
        private int logId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["LogId"] != null)
            {
                logId = Convert.ToInt32(Request.QueryString["LogId"]);
            }
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
            HttpResponseMessage response = client.GetAsync(Configs.Global.GetLogInformation + "/" + logId).Result;
            if (response.IsSuccessStatusCode)
            {
                LogInformation objProperty = JsonConvert.DeserializeObject<LogInformation>(response.Content.ReadAsStringAsync().Result);
                lblCategory.Text = objProperty.TenantComplaint.CategoryName;
                lblLocation.Text = objProperty.TenantComplaint.Location;
                lblDescription.Text = objProperty.TenantComplaint.Description;
                lblRequestedDate.Text = objProperty.TenantComplaint.RequestedDate.ToString();
                lblCompletedDate.Text = objProperty.TenantComplaint.ResolveDate.ToString();
                ddlStatus.SelectedValue = objProperty.TenantComplaint.Status;
                ddlUsers.DataSource = objProperty.Users;
                ddlUsers.DataBind();
                if (objProperty.TenantComplaint.AssignedTo != null)
                    ddlUsers.SelectedValue = Convert.ToString(objProperty.TenantComplaint.AssignedTo);
            }
            else
            {
                StatusInfo objStatus = JsonConvert.DeserializeObject<StatusInfo>(response.Content.ReadAsStringAsync().Result);
            }
        }
        protected void lnkSave_Click(object sender, EventArgs e)
        {
            LogStatus objLogStatus = new LogStatus();
            objLogStatus.LogId = logId;
            objLogStatus.Status = ddlStatus.SelectedValue;
            objLogStatus.AssignedTo = ddlUsers.SelectedValue != "" ? Convert.ToInt32(ddlUsers.SelectedValue) : (int?)null;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Configs.Global.BaseURL);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var json = JsonConvert.SerializeObject(objLogStatus);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(Configs.Global.UpdateLogStatus, data).Result;
            if (response.IsSuccessStatusCode)
            {
                Session["SaveSuccess"] = "Log Status has been updated sucessfully.";
                Response.Redirect("Default.aspx");
            }
            else
            {
                StatusInfo objStatus = JsonConvert.DeserializeObject<StatusInfo>(response.Content.ReadAsStringAsync().Result);
                lblMessage.Text = objStatus.Message;
            }
        }
    }
}