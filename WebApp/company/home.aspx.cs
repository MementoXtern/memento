﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.Architecture;

namespace WebApp.company
{
    public partial class home : PageBase
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            PageId = 2;
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
                    Response.Redirect("~/redirect.aspx");
                }
            }
            catch (Exception ex)
            {
                AddError(ex);
            }
        }
    }
}