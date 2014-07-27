using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.Architecture;
using Lib.DataObjects;
using Lib.BusinessObjects;

namespace WebApp
{
    public partial class Login : PageBase
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string userName = txtUsername.Text;
            string password = txtPassword.Text;

            LoginObject loginObject = Account.CheckLogin(userName, password);

            if (loginObject != null)
            {
                Session["AccountId"] = loginObject.AccountId;
                Session["AccountTypeId"] = loginObject.AccountTypeId;

                Response.Redirect(loginObject.LandingUrl);
            }
            else
            {
                litLoginError.Text = "Incorrect username / password combination";
            }
        }
    }
}