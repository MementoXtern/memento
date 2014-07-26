using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lib.BusinessObjects;
using MenuItem = Lib.DataObjects.MenuItem;
namespace WebApp
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        public List<MenuItemObject> _menuItems = new List<MenuItemObject>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["AccountId"] = 5;
            Session["AccountTypeId"] = 2;

            if (Session["AccountId"] != null && Session["AccountTypeId"] != null)
            {
                SetMenu();
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        private void SetMenu()
        {
            int accountId = (int)Session["AccountId"];
            int typeId = (int)Session["AccountTypeId"];

            _menuItems = MenuItem.GetMenuItems(typeId);
        }
    }
}
