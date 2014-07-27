using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.Architecture;
using Lib.DataObjects.Vendor;

namespace WebApp
{
    public partial class Manage_Inventory : PageBase
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            PageId = null;
            litError.Text = "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (ProcessPage)
                {
                    // Do Shit
                }
                else
                {
                    throw new AccessViolationException("The page did not process correctly.");
                }
            }
            catch (Exception ex)
            {
                AddError(ex);
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void newItemPrice_TextChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void addItemBtn_Click(object sender, EventArgs e)
        {
            string itemName = newItemNameText.Text;
            decimal itemPrice = decimal.Parse(newItemPriceText.Text);

            Item.Create(AccountId.Value, itemName, null, itemPrice, 0);
            lbInventory.Items.Add(itemName);
            //Response.Redirect("/manage_inventory.aspx");
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Console.WriteLine("Delete clicked");
        }

        protected void btnRemoveItem_Click(object sender, EventArgs e)
        {
            Item.Delete(AccountId.Value, lbInventory.SelectedItem.ToString());
            lbInventory.Items.Remove(lbInventory.SelectedItem);
        }
    }
}