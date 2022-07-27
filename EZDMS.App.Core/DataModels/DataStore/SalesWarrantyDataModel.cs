using System;
using System.Collections.Generic;
using System.Text;

namespace EZDMS.App.Core
{
    public class SalesWarrantyDataModel
    {

        /// <summary>
        /// The deal number of this Sales  record
        /// <summary>
        public int DealNumber { get; set; }

        /// <summary>
        /// The provider number of this Sales Warranty record
        /// <summary>
        public string ProviderNumber { get; set; }

        /// <summary>
        /// The provider name of this Sales Warranty record
        /// <summary>
        public string ProviderName { get; set; }

        /// <summary>
        /// The plan id of this Sales Warranty record
        /// <summary>
        public int PlanID { get; set; }

        /// <summary>
        /// The plan of this Sales Warranty record
        /// <summary>
        public string Plan { get; set; }

        /// <summary>
        /// The retail of this Sales Warranty record
        /// <summary>
        public decimal Retail { get; set; }

        /// <summary>
        /// The cost of this Sales Warranty record
        /// <summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// The profit of this Sales Warranty record
        /// <summary>
        public decimal Profit { get; set; }

        /// <summary>
        /// The deductible of this Sales Warranty record
        /// <summary>
        public decimal Deductible { get; set; }

        /// <summary>
        /// The term of this Sales Warranty record
        /// <summary>
        public int Term { get; set; }

        /// <summary>
        /// The mileage of this Sales Warranty record
        /// <summary>
        public int Miles { get; set; }

        /// <summary>
        /// The dealer number of this Sales Warranty record
        /// <summary>
        public string DealerNumber { get; set; }

        /// <summary>
        /// The in payment of this Sales Warranty record
        /// <summary>
        public bool InPayment { get; set; }

        /// <summary>
        /// The in cap of this Sales Warranty record
        /// <summary>
        public bool InCap { get; set; }

        /// <summary>
        /// The is disappearing deductible of this Sales Warranty record
        /// <summary>
        public bool IsDisappearingDeductible { get; set; }

        /// <summary>
        /// The tax flag of this Sales Warranty record
        /// <summary>
        public bool IsTaxable { get; set; }

        /// <summary>
        /// The contract number of this Sales Warranty record
        /// <summary>
        public string ContractNumber { get; set; }


    }
}
