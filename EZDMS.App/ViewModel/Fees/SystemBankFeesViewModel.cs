using Dna;
using EZDMS.App.Core;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using static EZDMS.App.DI;

namespace EZDMS.App
{
    /// <summary>
    /// The view model for the SystemBankFees control
    /// <summary>
    public class SystemBankFeesViewModel : BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// The SystemBankFees i d
        /// <summary>
        public int ID { get; set; }

        /// <summary>
        /// The SystemBankFees store i d
        /// <summary>
        public string StoreID { get; set; }

        /// <summary>
        /// The SystemBankFees bank i d
        /// <summary>
        public string BankID { get; set; }

        /// <summary>
        /// The SystemBankFees bank fee
        /// <summary>
        public DecimalInputViewModel BankFee { get; set; }

        /// <summary>
        /// The SystemBankFees bank active
        /// <summary>
        public bool BankActive { get; set; }

        /// <summary>
        /// The SystemBankFees bank prepaid
        /// <summary>
        public bool BankPrepaid { get; set; }

        /// <summary>
        /// The SystemBankFees v s i fee
        /// <summary>
        public DecimalInputViewModel VSIFee { get; set; }

        /// <summary>
        /// The SystemBankFees v s i fee active
        /// <summary>
        public bool VSIFeeActive { get; set; }

        /// <summary>
        /// The SystemBankFees v s i prepaid
        /// <summary>
        public bool VSIPrepaid { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// <summary>
        public SystemBankFeesViewModel()
        {

        }

        #endregion
    }
}
