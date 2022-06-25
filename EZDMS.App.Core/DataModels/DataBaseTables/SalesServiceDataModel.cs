using System;
using System.Collections.Generic;
using System.Text;

namespace EZDMS.App.Core
{
    public class SalesServiceDataModel
    {

        /// <summary>
        /// The deal number of this Sales  record
        /// <summary>
        public int DealNumber { get; set; }

        /// <summary>
        /// The provider number of this Sales Service record
        /// <summary>
        public string ProviderNumber { get; set; }

        /// <summary>
        /// The plan id of this Sales Service record
        /// <summary>
        public int PlanID { get; set; }

        /// <summary>
        /// The plan of this Sales Service record
        /// <summary>
        public string Plan { get; set; }

        /// <summary>
        /// The retail of this Sales Service record
        /// <summary>
        public decimal Retail { get; set; }

        /// <summary>
        /// The cost of this Sales Service record
        /// <summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// The profit of this Sales Service record
        /// <summary>
        public decimal Profit { get; set; }

        /// <summary>
        /// The deductible of this Sales Service record
        /// <summary>
        public decimal Deductible { get; set; }

        /// <summary>
        /// The term of this Sales Service record
        /// <summary>
        public int Term { get; set; }

        /// <summary>
        /// The mileage of this Sales Service record
        /// <summary>
        public int Mileage { get; set; }

        /// <summary>
        /// The dealer number of this Sales Service record
        /// <summary>
        public string DealerNumber { get; set; }

        /// <summary>
        /// The in payment of this Sales Service record
        /// <summary>
        public bool InPayment { get; set; }

        /// <summary>
        /// The in cap of this Sales Service record
        /// <summary>
        public bool InCap { get; set; }

        /// <summary>
        /// The is disappearing deductible of this Sales Service record
        /// <summary>
        public bool IsDisappearingDeductible { get; set; }


    }
}
