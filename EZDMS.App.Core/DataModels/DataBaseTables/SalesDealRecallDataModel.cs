using System;

namespace EZDMS.App.Core
{
    /// <summary>
    /// The data model for the sales deal to recall
    /// </summary>
    public class SalesDealRecallDataModel
    {
        //public int DealNumber { get; set; }
        //public string Buyer_First_Name { get; set; }
        //public string Buyer_Last_Name { get; set; }
        //public string Stock_No { get; set; }
        //public int Sold_Year { get; set; }
        //public string Sold_Make { get; set; }
        //public string Sold_Vin { get; set; }
        //public int Buyer_No { get; set; }
        //public int CoBuyer_No { get; set; }
        //public bool Finalized_Yn { get; set; }
        //public DateTime Finalized_Date { get; set; }
        //public DateTime Entry_Date { get; set; }
        //public string Status { get; set; }
        //public string Sold_Model { get; set; }
        //public bool? ActiveYn { get; set; }



        /// <summary>
        /// The deal number for the sales record
        /// </summary>
        public int DealNumber { get; set; }

        /// <summary>
        /// The Status of the sales record
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// The type of sales record
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The full name of the buyer for the sales record
        /// </summary>
        public string BuyerFullName { get; set; }

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
    }
}
