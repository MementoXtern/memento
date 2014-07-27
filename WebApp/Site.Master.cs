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
            SetMenu();
        }

        private void SetMenu()
        {
            int typeId = Session["AccountTypeId"] != null ? (int)Session["AccountTypeId"] : 0;

            _menuItems = MenuItem.GetMenuItems(typeId);
        }
    }
}
