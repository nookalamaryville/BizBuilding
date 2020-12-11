using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BizBuildingApp
{
    public partial class Dashboard : System.Web.UI.MasterPage
    {
        protected override void OnInit(EventArgs e)
        {
            try
            {
                base.OnInit(e);
                if (!string.IsNullOrEmpty(Session["UserInfo"] as string))
                {
                    Response.Redirect(Page.ResolveClientUrl("~/index.html"));
                }
            }
            catch (Exception ex)
            {
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}