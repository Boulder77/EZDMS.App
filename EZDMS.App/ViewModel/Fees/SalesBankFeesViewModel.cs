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
    /// The view model for the SalesBankFees control
    /// <summary>
    public class SalesBankFeesViewModel : BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// The SalesBankFees deal number
        /// <summary>
        public int DealNumber { get; set; }

        /// <summary>
        /// The SalesBankFees bank fee
        /// <summary>
        public string BankFee { get; set; }

        /// <summary>
        /// The SalesBankFees bank fee prepaid
        /// <summary>
        public bool BankFeePrepaid { get; set; }

        /// <summary>
        /// The SalesBankFees v s i fee
        /// <summary>
        public DecimalInputViewModel VSIFee { get; set; }

        /// <summary>
        /// The SalesBankFees v s i fee prepaid
        /// <summary>
        public bool VSIFeePrepaid { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// <summary>
        public SalesBankFeesViewModel()
        {

        }

        #endregion
    }
}
