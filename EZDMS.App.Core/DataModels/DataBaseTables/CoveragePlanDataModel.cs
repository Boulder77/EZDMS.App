using System;
using System.Collections.Generic;
using System.Text;

namespace EZDMS.App.Core
{
    public class CoveragePlanDataModel
    {

        /// <summary>
        /// The id of this CoveragePlan record
        /// <summary>
        public int ID { get; set; }

        /// <summary>
        /// The provider number of this CoveragePlan record
        /// <summary>
        public string ProviderNumber { get; set; }

        /// <summary>
        /// The create date of this CoveragePlan record
        /// <summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// The last modified date of this CoveragePlan record
        /// <summary>
        public DateTime LastModifiedDate { get; set; }

        /// <summary>
        /// The is active flag of this CoveragePlan record
        /// <summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// The name of this CoveragePlan record
        /// <summary>
        public string Name { get; set; }

        /// <summary>
        /// The retail price of this CoveragePlan record
        /// <summary>
        public decimal Retail { get; set; }

        /// <summary>
        /// The cost of this CoveragePlan record
        /// <summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// The deductible of this CoveragePlan record
        /// <summary>
        public decimal Deductible { get; set; }

        /// <summary>
        /// The term of this CoveragePlan record
        /// <summary>
        public int Term { get; set; }

        /// <summary>
        /// The mileage of this CoveragePlan record
        /// <summary>
        public int Mileage { get; set; }

        /// <summary>
        /// The description of this CoveragePlan record
        /// <summary>
        public string Description { get; set; }

        /// <summary>
        /// The default in payment flag of this CoveragePlan record
        /// <summary>
        public bool DefaultInPayment { get; set; }

        /// <summary>
        /// The is disappearing deductible flag of this CoveragePlan record
        /// <summary>
        public bool IsDisappearingDeductible { get; set; }




    }
}
