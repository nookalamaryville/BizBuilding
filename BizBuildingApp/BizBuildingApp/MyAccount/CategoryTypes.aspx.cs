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
    public partial class CategoryTypes : System.Web.UI.Page
    {
        private int propertyId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Session["SaveSuccess"] as string))
                {
                    lblMessage.Text = "Your category have been saved successfully.";
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
            HttpResponseMessage response = client.GetAsync(Configs.Global.CategoriesList + "/" + propertyId).Result;
            if (response.IsSuccessStatusCode)
            {
                List<Category> objCategories = JsonConvert.DeserializeObject<List<Category>>(response.Content.ReadAsStringAsync().Result);
                gvCategories.DataSource = objCategories;
                gvCategories.DataBind();
                if (gvCategories.Rows.Count > 0)
                {
                    //Adds THEAD and TBODY Section.
                    gvCategories.HeaderRow.TableSection = TableRowSection.TableHeader;

                    //Adds TH element in Header Row.  
                    gvCategories.UseAccessibleHeader = true;
                }
            }
            else
            {
                gvCategories.DataSource = null;
                gvCategories.DataBind();
            }
        }
        protected void lnkAddCategory_Click(object sender, EventArgs e)
        {
            Response.Redirect("SaveCategory.aspx");
        }
        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            LinkButton linkEdit = (LinkButton)sender;
            Response.Redirect("SaveCategory.aspx?CatId=" + linkEdit.CommandArgument);
        }
        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            int categoryId = Convert.ToInt32(lnk.CommandArgument);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Configs.Global.BaseURL);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.DeleteAsync(Configs.Global.DeleteCategory + "/" + categoryId).Result;
            if (response.IsSuccessStatusCode)
            {
                lblMessage.Text = "Your category has been deleted successfully.";
            }
            BindData();
        }
    }
}