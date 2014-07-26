﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.Architecture;
using Lib.DataObjects;

namespace WebApp
{
    public partial class _Default : PageBase
    {
        private FormValidation mValidator = new FormValidation();

        protected void Page_PreInit(object sender, EventArgs e)
        {
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

        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("RequestKey.aspx"); 
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx"); 
        }
    }
}
