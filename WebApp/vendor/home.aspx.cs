using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.Architecture;

namespace WebApp.vendor
{
    public partial class Home : Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            //PageId = 1;
            //litError.Text = "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (true)
                {
                    // Do Shit
                }
                else
                {
                    Response.Redirect("~/redirect.aspx");
                }
            }
            catch (Exception ex)
            {
                //AddError(ex);
            }
        }
    }
}