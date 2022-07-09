using System;

namespace EZDMS.App.Core
{
    /// <summary>
    /// The data model for the sales deal to recall
    /// </summary>
    public class SalesDealsItemDataModel
    {

        /// <summary>
        /// The deal number for the sales record
        /// </summary>
        public int DealNumber { get; set; }

        /// <summary>
        /// The Status of the sales record
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// The full name of the buyer for the sales record
        /// </summary>
        public string BuyerName { get; set; }

        /// <summary>
        /// The type of sales record
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The vehicle information for the sales record
        /// </summary>
        public string VehicleInfo { get; set; }

        /// <summary>
        /// The deal date for the sales record
        /// </summary>
        public DateTime DealDate { get; set; }

        /// <summary>
        /// The last activity date of the sales record
        /// </summary>
        public DateTime LastActivityDate { get; set; }

        /// <summary>
        /// The sales person for the sales record
        /// </summary>
        public string SalesPerson { get; set; }

        /// <summary>
        /// The full name of the cobuyer for the sales record
        /// </summary>
        public string CoBuyerName { get; set; }

        /// <summary>
        /// The trade 1 vehicle information
        /// </summary>
        public string Trade1Info { get; set; }

        /// <summary>
        /// The trade 2 vehicle information
        /// </summary>
        public string Trade2Info { get; set; }

        /// <summary>
        /// The trade 3 vehicle information
        /// </summary>
        public string Trade3Info { get; set; }

        /// <summary>
        /// The 2nd sales person for the sales record
        /// </summary>
        public string SalesPerson2 { get; set; }

        /// <summary>
        /// The created date for the sales record
        /// </summary>
        public DateTime CreatedDate { get; set; }
                
        /// <summary>
        /// The boolean for active status of the deal
        /// </summary>
        public bool? IsActive { get; set; }

        /// <summary>
        /// The boolean for the finalized status of the deal
        /// </summary>
        public bool? IsFinalized { get; set; }

        /// <summary>
        /// The sales manager for the deal
        /// </summary>
        public string SalesManager { get; set; }

        /// <summary>
        /// The finance manager for the deal
        /// </summary>
        public string FinanceManager {get; set;}

        /// <summary>
        /// The buyer number for the deal
        /// </summary>
        public string BuyerNumber { get; set; }

        /// <summary>
        /// The cobuyer number for the deal
        /// </summary>
        public string CoBuyerNumber { get; set; }

        /// <summary>
        /// The stock number for the deal
        /// </summary>
        public string StockNumber { get; set; }

    }
}
