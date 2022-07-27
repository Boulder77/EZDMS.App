using System;
using System.Collections.Generic;
using System.Text;

namespace EZDMS.App.Core
{
    public class CoveragePlanDataModel
    {

        /// <summary>
        /// The id of this ProductsPlan record
        /// <summary>
        public int ID { get; set; }

        /// <summary>
        /// The type of this ProductsPlan record
        /// <summary>
        public string Type { get; set; }

        /// <summary>
        /// The provider number of this ProductsPlan record
        /// <summary>
        public string ProviderNumber { get; set; }

        /// <summary>
        /// The provider name of this ProductsPlan record
        /// <summary>
        public string ProviderName { get; set; }

        /// <summary>
        /// The create date of this ProductsPlan record
        /// <summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// The last modified date of this ProductsPlan record
        /// <summary>
        public DateTime LastModifiedDate { get; set; }

        /// <summary>
        /// The active flag of this ProductsPlan record
        /// <summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// The name of this ProductsPlan record
        /// <summary>
        public string Name { get; set; }

        /// <summary>
        /// The retail of this ProductsPlan record
        /// <summary>
        public decimal Retail { get; set; }

        /// <summary>
        /// The cost of this ProductsPlan record
        /// <summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// The deductible of this ProductsPlan record
        /// <summary>
        public decimal Deductible { get; set; }

        /// <summary>
        /// The term of this ProductsPlan record
        /// <summary>
        public int Term { get; set; }

        /// <summary>
        /// The mileage of this ProductsPlan record
        /// <summary>
        public int Miles { get; set; }

        /// <summary>
        /// The description of this ProductsPlan record
        /// <summary>
        public string Description { get; set; }

        /// <summary>
        /// The default in payment flag of this ProductsPlan record
        /// <summary>
        public bool DefaultInPayment { get; set; }

        /// <summary>
        /// The disappearing deductible flag of this ProductsPlan record
        /// <summary>
        public bool IsDisappearingDeductible { get; set; }

        /// <summary>
        /// The taxable flag of this ProductsPlan record
        /// <summary>
        public bool IsTaxable { get; set; }

    }
}
