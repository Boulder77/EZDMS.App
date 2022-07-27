using System;
using System.Collections.Generic;
using System.Text;

namespace EZDMS.App.Core
{
    public class SalesGapDataModel
    {

        /// <summary>
        /// The deal number of this SalesGap record
        /// <summary>
        public int DealNumber { get; set; }

        /// <summary>
        /// The provider number of this SalesGap record
        /// <summary>
        public string ProviderNumber { get; set; }

        /// <summary>
        /// The provider name of this SalesGap record
        /// <summary>
        public string ProviderName { get; set; }

        /// <summary>
        /// The plan id of this SalesGap record
        /// <summary>
        public int PlanID { get; set; }

        /// <summary>
        /// The plan description of this SalesGap record
        /// <summary>
        public string Plan { get; set; }

        /// <summary>
        /// The retail price of this SalesGap record
        /// <summary>
        public decimal Retail { get; set; }

        /// <summary>
        /// The cost of this SalesGap record
        /// <summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// The profit of this SalesGap record
        /// <summary>
        public decimal Profit { get; set; }

        /// <summary>
        /// The dealer number of this SalesGap record
        /// <summary>
        public string DealerNumber { get; set; }

        /// <summary>
        /// The inpayment flag of this SalesGap record
        /// <summary>
        public bool InPayment { get; set; }

        /// <summary>
        /// The incap flag of this SalesGap record
        /// <summary>
        public bool InCap { get; set; }

        /// <summary>
        /// The tax flag of this SalesGap record
        /// <summary>
        public bool IsTaxable { get; set; }

        /// <summary>
        /// The contract number of this SalesGap record
        /// <summary>
        public string ContractNumber { get; set; }




    }
}
