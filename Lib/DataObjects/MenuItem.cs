using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lib.BusinessObjects;
using Lib.Utilities;
using Lib.Utilities.DataAccess;

namespace Lib.DataObjects
{
    public class MenuItem
    {

        /// <summary>
        /// Returns the menu based on the account type
        /// </summary>
        /// <param name="accountTypeId"></param>
        /// <returns></returns>
        public static List<MenuItemObject> GetMenuItems(int accountTypeId)
        {
            List<MenuItemObject> menuItems = new List<MenuItemObject>();

            //Query query = new Query();
            //query.AddParameter("@AccountTypeId", testId);

           // DBManager.Execute(query, ref xml);
            menuItems.Add(new MenuItemObject { Url = "boobies.aspx", Name = "BOOBIES" });
            menuItems.Add(new MenuItemObject { Url = "titties.aspx", Name = "GIGANTIC TITS" });

            return menuItems;
        }
    }
}
