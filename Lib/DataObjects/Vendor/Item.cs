using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lib.Utilities.DataAccess;
using Lib.Utilities;

namespace Lib.DataObjects.Vendor
{
    public class Item
    {
        /// <summary>
        /// Creates an item for the vendor
        /// </summary>
        /// <param name="vendorId"></param>
        /// <param name="itemName"></param>
        /// <param name="itemDesc"></param>
        /// <param name="itemPrice"></param>
        /// <param name="itemProcessingTime"></param>
        public static void Create(int vendorId, string itemName, string itemDesc, decimal itemPrice, int itemProcessingTime)
        {
            Query query = new Query(SqlQueryType.SqlStoredProc, "ItemSave");
            query.AddParameter("@VendorId", vendorId);
            query.AddParameter("@ItemName", itemName);
            query.AddParameter("@ItemDesc", itemDesc);
            query.AddParameter("@ItemPrice", itemPrice);
            query.AddParameter("@ItemProcessingTime", itemProcessingTime);

            DBManager.Execute(query);
        }
    }
}
