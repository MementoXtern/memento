using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.Architecture
{
    public class PageBase : Page
    {
        #region Private Members

        private List<Exception> mErrors;
        private List<string> mWarnings;

        #endregion

        #region Controls

        protected Literal litError;
        protected Literal litMessage;
        protected Literal litWarning;

        #endregion

        #region Properties

        public int? AccountTypeId
        {
            get
            {
                return Session["AccountTypeId"] == null ? 0 : (int?)Session["AccountTypeId"];
            }
        }

        public int? AccountId
        {
            get
            {
                return Session["AccountId"] == null ? null : (int?)Session["AccountId"];
            }
        }

        public int? PageId { get; set; }


        public bool IsDebug
        {
            get { return true; }
        }

        public bool ProcessPage
        {
            get
            {
                return ValidateSession() && ValidatePageRequirements();
            }
        }

        #endregion

        #region Page Events

        public PageBase()
        {
            this.PreRender += PageBase_PreRender;
            this.PreInit += PageBase_PreInit;

            mErrors = new List<Exception>();
            mWarnings = new List<string>();
        }

        protected void PageBase_PreInit(object sender, EventArgs e)
        {
            litError = (Literal)Master.FindControl("litError");
            litMessage = (Literal)Master.FindControl("litMessage");
            litWarning = (Literal)Master.FindControl("litWarning");
        }

        protected void PageBase_PreRender(object sender, EventArgs e)
        {
            try
            {
                if (mErrors.Count > 0)
                {
                    StringBuilder errorHtml = new StringBuilder();
                    errorHtml.Append("<ul class=\"error\">");

                    foreach (Exception exception in mErrors)
                    {
                        errorHtml.Append(CreateErrorNode(exception));
                    }

                    errorHtml.Append("</ul>");

                    litError.Text = errorHtml.ToString();
                }

                if (mWarnings.Count > 0)
                {
                    StringBuilder warningHtml = new StringBuilder();
                    warningHtml.Append("<ul class=\"warning\">");

                    foreach (string warning in mWarnings)
                    {
                        warningHtml.Append(CreateWarningNode(warning));
                    }

                    warningHtml.Append("</ul>");

                    litWarning.Text = warningHtml.ToString();
                }
            }
            catch (Exception ex)
            {
                litError.Text = "<ul class=\"error\">" + CreateErrorNode(ex) + "</ul>";
            }
        }

        #endregion

        #region Public/Protected Methods

        public void AddError(Exception ex)
        {
            mErrors.Add(ex);
        }

        public void AddErrors(ICollection<Exception> errors)
        {
            mErrors.AddRange(errors);
        }

        public void AddWarning(string warning)
        {
            mWarnings.Add(warning);
        }

        protected virtual bool ValidatePageRequirements()
        {
            return true;
        }

        #endregion

        #region Private Methods

        private string CreateErrorNode(Exception ex)
        {
            if (IsDebug)
            {
                return "<li>" + ex.Message + "</li>";
            }
            else
            {
                return "<li>An unexpected error has occurred.  Please contact *********** to report this error.</li>";
            }
        }

        private string CreateWarningNode(string warning)
        {
            return "<li>" + warning + "</li>";
        }

        private bool ValidateSession()
        {
            bool valid = true;

            if ((!AccountTypeId.HasValue || !AccountId.HasValue) && PageId.HasValue)
            {
                valid = false;
            }

            return valid;
        }
        #endregion
    }
}