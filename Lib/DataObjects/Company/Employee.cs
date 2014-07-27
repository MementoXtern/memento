using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lib.Utilities.DataAccess;
using Lib.Utilities;

namespace Lib.DataObjects.Company
{
    public class Employee
    {
        /// <summary>
        /// Create an employee 
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="fName"></param>
        /// <param name="lName"></param>
        /// <param name="DOB"></param>
        /// <param name="StartDate"></param>
        /// <param name="shipAddress"></param>
        /// <param name="shipCity"></param>
        /// <param name="shipState"></param>
        /// <param name="shipZip"></param>
        /// <returns></returns>
        public static int Create(int companyId, string fName, string lName, DateTime DOB, DateTime StartDate, string shipAddress, string shipCity, string shipState, string shipZip)
        {
            int? newCompanyId = null;

            Query query = new Query(SqlQueryType.SqlStoredProc, "EmployeeSave");
            query.AddParameter("@CompanyId", companyId);
            query.AddParameter("@EmployeeFName", fName);
            query.AddParameter("@EmployeeLName", lName);
            query.AddParameter("@EmployeeDOB", DOB.Date);
            query.AddParameter("@EmployeeStartDate", StartDate.Date);
            query.AddParameter("@EmployeeShipAddress", shipAddress);
            query.AddParameter("@EmployeeShipCity", shipCity);
            query.AddParameter("@EmployeeShipState", shipState);
            query.AddParameter("@EmployeeShipZip", shipZip);

            DBManager.ExecuteScalar(query, ref newCompanyId);

            return newCompanyId.Value;
        }
    }
}
