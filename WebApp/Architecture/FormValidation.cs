using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;

namespace WebApp.Architecture
{
    public class FormValidation
    {
        #region Variables

        // set up some private internal variables
        private ArrayList mFormValues = new ArrayList();
        private List<Exception> mExceptions = new List<Exception>();
        /// <summary>
        /// Enumeration defining all available validation types.
        /// </summary>
        public enum ValidationTypes
        {
            Integer,
            PositiveInteger,
            PositiveSmallInt,
            Existence,
            Date,
            LetterGrade,
            Phone,
            OfficePhone,
            URL,
            ComboBox,
            BuildingRoom,
            RegularExpression,
            ZipCode,
            Email,
            Decimal,
            Year,
            MultipleEmail,
            MultipleDate,
            SerialCheck,
            UniqueIdentifier,
            Text,
            Time,
            Boolean
        }

        public List<Exception> Errors
        {
            get { return mExceptions; }
        }

        #endregion

        /// <summary>
        /// Class constructor that loads the status reporter into an internal variable.
        /// </summary>
        /// <param name="oStatusReporter">Instance of the status reporting class. This object is automatically created on the master page.</param>
        public FormValidation()
        {
        }

        /// <summary>
        /// Adds a value to the form values collection so it will be validated
        /// </summary>
        /// <param name="formValue">Value entered in the html "name" attribute of the form element being validated.</param>
        /// <param name="dataType">Type of validation to be preformed on the form value. Value comes from the "ValidationTypes" enumeration.</param>
        /// <param name="valueName">Text name that will be outputted in any validation error that occurs.</param>
        /// <param name="required">Boolean value determining if this value is required. If the value is required it cannot be left blank. If it is not required an empty string can be entered.</param>
        public void AddValue(string formValue, ValidationTypes dataType, string valueName, bool required)
        {
            object[] newRequiredValue = new object[4];
            object[] newValue = new object[4];

            // if the field is required add a default existance check
            if (required && dataType != ValidationTypes.Existence)
            {
                newRequiredValue[0] = formValue;
                newRequiredValue[1] = ValidationTypes.Existence;
                newRequiredValue[2] = valueName;
                newRequiredValue[3] = required;
            }

            // create a static array and add it to the array list
            newValue[0] = formValue;
            newValue[1] = dataType;
            newValue[2] = valueName;
            newValue[3] = required;

            mFormValues.Add(newValue);
        }

        /// <summary>
        /// Loops through the form values collection and validates each post variable.
        /// </summary>
        /// <returns>
        /// Returns true if all values are correct.
        /// Returns false if one or more values are not correct.
        /// </returns>
        public bool ValidateValues()
        {
            HttpContext httpContext;
            HttpRequest httpRequest;

            // get the current http context
            httpContext = HttpContext.Current;

            // load the current request object
            httpRequest = httpContext.Request;

            // loop through each of the form values entered into the collection
            for (int i = 0; i <= mFormValues.Count - 1; i++)
            {
                // load the static array from the array list
                object[] valueArray = (object[])mFormValues[i];
                string value = (string)valueArray[0];
                ValidationTypes valueDataType = (ValidationTypes)valueArray[1];
                string valueName = (string)valueArray[2];
                bool required = (bool)valueArray[3];

                // check to make sure that value is even in the post variables
                if (httpRequest.Form.GetValues(value) != null)
                {
                    // loop through that variable name in case multiple inputs were created with the same name
                    for (int ii = 0; ii <= httpRequest.Form.GetValues(value).Length - 1; ii++)
                    {
                        // the the current form value being validated and trim all of the
                        // space characters from the beginning and end of the value
                        string currentValue = httpRequest.Form.GetValues(value)[ii].ToString().Trim();

                        // if the value is required then always run the validation check
                        // if the value is not required only run the validation check if it is not an empty string
                        if (required == true && (currentValue.Length == 0 || currentValue == "<br />"))
                        {
                            mExceptions.Add(new Exception(valueName + " has been left blank."));
                        }
                        else if (required == true || httpRequest.Form.GetValues(value)[ii].ToString().Length != 0)
                        {
                            switch (valueDataType)
                            {
                                // check integers
                                case ValidationTypes.Integer:
                                    if (!ValidateInteger(currentValue))
                                    {
                                       mExceptions.Add(new Exception(valueName + " is not a valid whole number."));
                                    }
                                    break;
                                // check for positive integers
                                case ValidationTypes.PositiveInteger:
                                    if (!ValidatePositiveInteger(currentValue))
                                    {
                                       mExceptions.Add(new Exception(valueName + " is not a valid number that is > 0."));
                                    }
                                    break;
                                // check for positive integers
                                case ValidationTypes.PositiveSmallInt:
                                    if (!ValidatePositiveSmallInteger(currentValue))
                                    {
                                       mExceptions.Add(new Exception(valueName + " is not a valid number that is > 0 and < 32767."));
                                    }
                                    break;
                                // check to see if they entered a value
                                case ValidationTypes.Existence:
                                    if (!ValidateExistence(currentValue))
                                    {
                                       mExceptions.Add(new Exception(valueName + " has been left blank."));
                                    }
                                    break;
                                // check for a valid date
                                case ValidationTypes.Date:
                                    // see if the value is valid
                                    if (!ValidateDate(currentValue))
                                    {
                                        // it isn't so show a warning
                                       mExceptions.Add(new Exception(valueName + " is not a valid date."));
                                    }
                                    break;
                                // check for a valid letter grade
                                case ValidationTypes.LetterGrade:
                                    if (!ValidateLetterGrade(currentValue.Trim()))
                                    {
                                       mExceptions.Add(new Exception(valueName + " is not in a valid letter grade format."));
                                    }
                                    break;
                                // check for a valid phone number
                                case ValidationTypes.Phone:
                                    if (!ValidatePhone(currentValue))
                                    {
                                       mExceptions.Add(new Exception("The value entered for the " + valueName + " text box is not a valid phone number."));
                                    }
                                    break;
                                // check for a valid office phone number
                                case ValidationTypes.OfficePhone:
                                    if (!ValidateOfficePhone(currentValue))
                                    {
                                       mExceptions.Add(new Exception("The value entered for the " + valueName + " text box is not a valid office phone number. Please use xxxxx."));
                                    }
                                    break;
                                // check for a valid url prefix
                                case ValidationTypes.URL:
                                    if (!ValidateUrl(currentValue))
                                    {
                                       mExceptions.Add(new Exception(valueName + " is not a valid url."));
                                    }
                                    break;
                                // check that the first option of combo box was not selected
                                case ValidationTypes.ComboBox:
                                    if (!ValidateComboBox(currentValue))
                                    {
                                       mExceptions.Add(new Exception(valueName + " must have an option selected."));
                                    }

                                    break;
                                // validate based on regular expression
                                case ValidationTypes.RegularExpression:
                                    if (!ValidateExpression((string)valueArray[4], currentValue))
                                    {
                                       mExceptions.Add(new Exception((string)valueArray[5]));
                                    }
                                    break;
                                // Zip Code
                                case ValidationTypes.ZipCode:
                                    // Does no validation currently
                                    break;
                                // Email
                                case ValidationTypes.Email:
                                    if (!ValidateEmail(currentValue))
                                    {
                                       mExceptions.Add(new Exception("The " + valueName + " value entered is not in a valid format."));
                                    }
                                    break;
                                case ValidationTypes.Decimal:
                                    if (!ValidateDecimal(currentValue))
                                    {
                                       mExceptions.Add(new Exception("The " + valueName + " value entered is not in a valid format."));
                                    }
                                    break;
                                case ValidationTypes.Year:
                                    if (!ValidateYear(currentValue))
                                    {
                                       mExceptions.Add(new Exception("The " + valueName + " value entered is not in a valid format."));
                                    }
                                    break;
                                case ValidationTypes.MultipleEmail:
                                    string[] emails = null;

                                    // split the e-mails
                                    if (currentValue.IndexOf(",") > -1)
                                    {
                                        emails = currentValue.Split(',');
                                    }
                                    else
                                    {
                                        emails = currentValue.Split(';');
                                    }

                                    // loop through the split e-mails
                                    for (int j = 0; j < emails.Length; j++)
                                    {
                                        if (!ValidateEmail(emails[j].Trim()))
                                        {
                                            // report the warning
                                           mExceptions.Add(new Exception("The " + valueName + " value entered is not in a valid format."));
                                            // mark this whole thing as invalid
                                            // stop looping
                                            break;
                                        }
                                    }
                                    break;
                                case ValidationTypes.MultipleDate:
                                    // split the dates
                                    string[] dates = currentValue.Split(';');

                                    // loop through all of the dates
                                    for (int j = 0; j < dates.Length; j++)
                                    {
                                        // validate each one
                                        if (!ValidateDate(dates[j]))
                                        {
                                            // show a warning
                                           mExceptions.Add(new Exception(valueName + " is not a valid date time group."));
                                            // mark the thing as invalid
                                            break;
                                        }
                                    }
                                    break;
                                case ValidationTypes.UniqueIdentifier:
                                    if (!ValidateUniqueIdentifier(currentValue))
                                    {
                                       mExceptions.Add(new Exception("The " + valueName + " value entered is not a valid unique identifier."));
                                    }
                                    break;
                                case ValidationTypes.Text:
                                    if (!ValidateText(currentValue))
                                    {
                                       mExceptions.Add(new Exception("The " + valueName + " value entered contains invalid character(s)."));
                                    }
                                    break;
                                case ValidationTypes.Time:
                                    Regex regEx = new Regex("^(1[012]|0?[1-9]):([0-5][0-9])$");

                                    if (!regEx.Match(currentValue).Success)
                                    {
                                       mExceptions.Add(new Exception(valueName + " is not a valid time."));
                                    }
                                    break;
                                case ValidationTypes.Boolean:

                                    break;
                                default:
                                   mExceptions.Add(new Exception(valueName + " is not a recognized data type."));
                                    break;
                            }
                        }
                    }
                }
            }

            // return the boolean value determinging if all the values were valid or not
            return mExceptions.Count == 0;
        }

        #region Validation Methods

        public bool ValidateText(string value)
        {
            // return false if the value is null
            if (value == null) { return false; }

            // set up the expression
            string expression = @"^[^<>]+$";

            // return the answer to the validation
            return ValidateExpression(expression, value);
        }

        public bool ValidatePhone(string value)
        {
            // return false if the value is null
            if (value == null) { return false; }

            // set up the expression
            string expression = @"^([\(\)\-\s\.+\d]*)$";

            // return the answer to the validation
            return ValidateExpression(expression, value);
        }

        public bool ValidateOfficePhone(string value)
        {
            int phonenum;
            if (value.Length != 5 || !int.TryParse(value, out phonenum))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool ValidateDate(string value)
        {
            // return false if the value is null
            if (value == null) { return false; }

            // set up the expression
            string expression = "^([0]{0,1}[1-9]|1[012])[- /.]([0]{0,1}[1-9]|[12][0-9]|3[01])[- /.](19|20)\\d\\d$";

            // return the answer to the validation
            return ValidateExpression(expression, value);
        }

        public bool ValidateInteger(string value)
        {
            // return false if the value is null
            if (value == null) { return false; }

            string expression = "^[-]?[0-9]*$";
            int result;

            // make sure it is only digits
            if (ValidateExpression(expression, value))
            {
                // try to parse the int
                if (int.TryParse(value, out result))
                {
                    // it parsed return true
                    return true;
                }
                else
                {
                    // it didn't parse return false
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool ValidatePositiveInteger(string value)
        {
            // return false if the value is null
            if (value == null) { return false; }

            // see if it is at least an integer
            if (ValidateInteger(value))
            {
                // ssee if it is 0 or greater
                if (int.Parse(value) >= 0)
                {
                    // it is a valid positive integer
                    return true;
                }
                else
                {
                    // it is not greater than zero
                    return false;
                }
            }
            else
            {
                // it isn't a valid integer
                return false;
            }
        }

        public bool ValidatePositiveSmallInteger(string value)
        {
            // return false if the value is null
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            string expression = "^[0-9]*$";

            // see if it is at least an integer
            if (ValidateExpression(expression, value))
            {
                // ssee if it is 0 or greater
                if (int.Parse(value) >= 0 && int.Parse(value) <= 32767)
                {
                    // it is a valid positive small integer
                    return true;
                }
                else
                {
                    // it is not greater than zero and less than 32767
                    return false;
                }
            }
            else
            {
                // it isn't a valid integer
                return false;
            }
        }

        public bool ValidateExistence(string value)
        {
            // check to make sure it is not null and that it has a length
            if (!string.IsNullOrEmpty(value) && value.Trim() != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidateLetterGrade(string value)
        {
            // return false if the value is null
            if (value == null) { return false; }

            string expression = "(^(A|B|C|D|F|I|P|NP|NS|S|U|W|WF)$)|(^(A[+]|A-|B[+]|B-|C[+]|C-|D[+]|D-)$)";

            return ValidateExpression(expression, value);
        }

        public bool ValidateUrl(string value)
        {
            // return false if the value is null
            if (value == null) { return false; }

            string expression = "^(http://|https://|ftp://|ftps://)";
            return ValidateExpression(expression, value, RegexOptions.IgnoreCase);
        }

        public bool ValidateComboBox(string value)
        {
            // return false if the value is null
            if (value == null) { return false; }

            // just checks to see if it is "" or not
            return ValidateExistence(value);
        }

        public bool ValidateEmail(string value)
        {
            // return false if the value is null
            if (value == null) { return false; }

            string expression = "^[A-Za-z0-9._%-]+@[A-Za-z0-9.-]+\\.([A-Za-z]{2}|aero|biz|cat|com|coop|info|jobs|mobi|museum|name|net|org|pro|travel|gov|edu|mil|int)$";

            return ValidateExpression(expression, value, RegexOptions.IgnoreCase);
        }

        public bool ValidateYear(string value)
        {
            // return false if the value is null
            if (value == null) { return false; }

            string expression = "^[0-9]{4}$";

            return ValidateExpression(expression, value);
        }

        public bool ValidateDecimal(string value)
        {
            // return false if the value is null
            if (value == null) { return false; }

            string expression = "^[0-9]{0,16}[.]?[0-9]{1,2}$";

            return ValidateExpression(expression, value);
        }

        public bool ValidateUniqueIdentifier(string value)
        {
            // return false if the value is null
            if (value == null) { return false; }

            string expression = "^[0-9A-Fa-f]{8}-[0-9A-Fa-f]{4}-[0-9A-Fa-f]{4}-[0-9A-Fa-f]{4}-[0-9A-Fa-f]{12}$";

            return ValidateExpression(expression, value);
        }

        public bool ValidateTime(string value)
        {
            // return false if the value is null
            if (string.IsNullOrEmpty(value)) { return false; }

            string expression = "^(1[012]|[1-9]):([0-5]?[0-9])$";

            return ValidateExpression(expression, value);
        }

        public bool ValidateBoolean(string value)
        {
            // return false if the value is null
            if (string.IsNullOrEmpty(value)) { return false; }

            bool retVal;

            return bool.TryParse(value, out retVal);
        }
        #endregion

        #region Helper Methods

        public bool ValidateExpression(string expression, string value)
        {
            Regex validationExpression = new Regex(expression);
            Match expressionMatches = validationExpression.Match(value.Replace("\r", " ").Replace("\n", " "));

            if (expressionMatches.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidateExpression(string expression, string value, RegexOptions Option)
        {
            Match expressionMatches = Regex.Match(value, expression, Option);

            if (expressionMatches.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}