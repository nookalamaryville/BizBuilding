using BizBuildingApp.Models;
using Newtonsoft.Json;
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
    public partial class Staffs : System.Web.UI.Page
    {
        private int propertyId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Session["SaveSuccess"] as string))
                {
                    lblMessage.Text = "Your have been submitted the staff information sucessfully.";
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
            HttpResponseMessage response = client.GetAsync(Configs.Global.StaffList + "/" + propertyId).Result;
            if (response.IsSuccessStatusCode)
            {
                List<PropertyUser> objLogs = JsonConvert.DeserializeObject<List<PropertyUser>>(response.Content.ReadAsStringAsync().Result);
                gvStaffs.DataSource = objLogs;
                gvStaffs.DataBind();
                if (gvStaffs.Rows.Count > 0)
                {
                    //Adds THEAD and TBODY Section.
                    gvStaffs.HeaderRow.TableSection = TableRowSection.TableHeader;

                    //Adds TH element in Header Row.  
                    gvStaffs.UseAccessibleHeader = true;
                }
            }
            else
            {
                gvStaffs.DataSource = null;
                gvStaffs.DataBind();
            }
        }
        protected void lnkAddStaff_Click(object sender, EventArgs e)
        {
            Response.Redirect("SaveStaff.aspx");
        }
        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            LinkButton linkEdit = (LinkButton)sender;
            Response.Redirect("SaveStaff.aspx?StaffId=" + linkEdit.CommandArgument);
        }
        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            int staffId = Convert.ToInt32(lnk.CommandArgument);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Configs.Global.BaseURL);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.DeleteAsync(Configs.Global.DeleteStaff + "/" + staffId).Result;
            if (response.IsSuccessStatusCode)
            {
                lblMessage.Text = "Your category has been deleted successfully.";
            }
            BindData();
        }
    }
}