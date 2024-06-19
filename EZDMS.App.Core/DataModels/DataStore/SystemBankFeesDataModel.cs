using System;
using System.Collections.Generic;
using System.Text;

namespace EZDMS.App.Core
{
    public class SystemBankFeesDataModel
    {

        /// <summary>
        /// The id of this SystemBankFees record
        /// <summary>
        public int ID { get; set; }

        /// <summary>
        /// The store id of this SystemBankFees record
        /// <summary>
        public string StoreID { get; set; }

        /// <summary>
        /// The bank i d of this SystemBankFees record
        /// <summary>
        public string BankID { get; set; }

        /// <summary>
        /// The bank fee of this SystemBankFees record
        /// <summary>
        public decimal BankFee { get; set; }

        /// <summary>
        /// The bank active of this SystemBankFees record
        /// <summary>
        public bool BankActive { get; set; }

        /// <summary>
        /// The bank prepaid of this SystemBankFees record
        /// <summary>
        public bool BankPrepaid { get; set; }

        /// <summary>
        /// The v s i fee of this SystemBankFees record
        /// <summary>
        public decimal VSIFee { get; set; }

        /// <summary>
        /// The v s i fee active of this SystemBankFees record
        /// <summary>
        public bool VSIFeeActive { get; set; }

        /// <summary>
        /// The v s i prepaid of this SystemBankFees record
        /// <summary>
        public bool VSIPrepaid { get; set; }

    }
}
