using System;

namespace EZDMS.App.Core
{
    /// <summary>
    /// The data model for the sales deal to recall
    /// </summary>
    public class SalesBankFeesDataModel
    {

        /// <summary>
        /// The deal number of this SalesBankFees record
        /// <summary>
        public int DealNumber { get; set; }

        /// <summary>
        /// The bank fee of this SalesBankFees record
        /// <summary>
        public decimal BankFee { get; set; }

        /// <summary>
        /// The bank fee prepaid of this SalesBankFees record
        /// <summary>
        public bool BankFeePrepaid { get; set; }

        /// <summary>
        /// The v s i fee of this SalesBankFees record
        /// <summary>
        public decimal VSIFee { get; set; }

        /// <summary>
        /// The v s i fee prepaid of this SalesBankFees record
        /// <summary>
        public bool VSIFeePrepaid { get; set; }

    }
}
