using System;
using System.Collections.Generic;
using System.Text;

namespace EZDMS.App.Core
{
    public class SalesLicensingFeesDataModel
    {

        /// <summary>
        /// The deal number of this SalesLicensingFees record
        /// <summary>
        public int DealNumber { get; set; }

        /// <summary>
        /// The fees in payment of this SalesLicensingFees record
        /// <summary>
        public bool FeesInPayment { get; set; }

        /// <summary>
        /// The license fee of this SalesLicensingFees record
        /// <summary>
        public decimal LicenseFee { get; set; }

        /// <summary>
        /// The plate fee of this SalesLicensingFees record
        /// <summary>
        public decimal PlateFee { get; set; }

        /// <summary>
        /// The title fee of this SalesLicensingFees record
        /// <summary>
        public decimal TitleFee { get; set; }

        /// <summary>
        /// The temp tag fee of this SalesLicensingFees record
        /// <summary>
        public decimal TempTagFee { get; set; }

        /// <summary>
        /// The registration fee of this SalesLicensingFees record
        /// <summary>
        public decimal RegistrationFee { get; set; }

        /// <summary>
        /// The transfer fee of this SalesLicensingFees record
        /// <summary>
        public decimal TransferFee { get; set; }

        /// <summary>
        /// The notary fee of this SalesLicensingFees record
        /// <summary>
        public decimal NotaryFee { get; set; }

        /// <summary>
        /// The filing fee of this SalesLicensingFees record
        /// <summary>
        public decimal FilingFee { get; set; }


    }
}
