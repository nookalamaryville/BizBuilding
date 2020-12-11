using BizBuildingApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BizBuildingApp.MyAccount
{
    public partial class Default : System.Web.UI.Page
    {
        private int propertyId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Session["SaveSuccess"] as string))
                {
                    lblMessage.Text = Convert.ToString(Session["SaveSuccess"]);
                    Session.Remove("SaveSuccess");
                }
                BindData();
            }
        }
        private void BindData()
        {
            UserInformation objUserInfo = (UserInformation)Session["UserInfo"];
            propertyId = objUserInfo.PropertyId;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Configs.Global.BaseURL);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(Configs.Global.TenantLogsList + "/" + propertyId).Result;
            if (response.IsSuccessStatusCode)
            {
                List<TenantLog> objLogs = JsonConvert.DeserializeObject<List<TenantLog>>(response.Content.ReadAsStringAsync().Result);
                gvLogs.DataSource = objLogs;
                gvLogs.DataBind();
                if (gvLogs.Rows.Count > 0)
                {
                    //Adds THEAD and TBODY Section.
                    gvLogs.HeaderRow.TableSection = TableRowSection.TableHeader;

                    //Adds TH element in Header Row.  
                    gvLogs.UseAccessibleHeader = true;
                }
            }
            else
            {
                lblMessage.Text = "No Complaints available.";
                lblMessage.CssClass = "label-error";
                gvLogs.DataSource = null;
                gvLogs.DataBind();
            }
        }
        protected void lnkStatus_Click(object sender, EventArgs e)
        {
            LinkButton lnkStatus = (LinkButton)sender;
            int logId = Convert.ToInt32(lnkStatus.CommandArgument);
            Response.Redirect("LogDetails.aspx?LogId=" + logId);
        }
        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            int logId = Convert.ToInt32(lnk.CommandArgument);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Configs.Global.BaseURL);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.DeleteAsync(Configs.Global.DeleteLog + "/" + logId).Result;
            if (response.IsSuccessStatusCode)
            {
                lblMessage.Text = "Selected complaint has been deleted successfully.";
            }
            BindData();
        }
    }
}