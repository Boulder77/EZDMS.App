using Dna;
using EZDMS.App.Core;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management.Instrumentation;
using System.Threading.Tasks;
using System.Windows.Input;
using static EZDMS.App.DI;

namespace EZDMS.App
{
    /// <summary>
    /// The view model for the SalesLicensingFees control
    /// <summary>
    public class SalesLicensingViewModel : BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// The SalesLicensingFees fees in payment
        /// <summary>
        public bool FeesInPayment { get; set; }

        /// <summary>
        /// The SalesLicensingFees license fee
        /// <summary>
        public DecimalInputViewModel LicenseFee { get; set; }

        /// <summary>
        /// The SalesLicensingFees plate fee
        /// <summary>
        public DecimalInputViewModel PlateFee { get; set; }

        /// <summary>
        /// The SalesLicensingFees title fee
        /// <summary>
        public DecimalInputViewModel TitleFee { get; set; }

        /// <summary>
        /// The SalesLicensingFees temp tag fee
        /// <summary>
        public DecimalInputViewModel TempTagFee { get; set; }

        /// <summary>
        /// The SalesLicensingFees registration fee
        /// <summary>
        public DecimalInputViewModel RegistrationFee { get; set; }

        /// <summary>
        /// The SalesLicensingFees transfer fee
        /// <summary>
        public DecimalInputViewModel TransferFee { get; set; }

        /// <summary>
        /// The SalesLicensingFees notary fee
        /// <summary>
        public DecimalInputViewModel NotaryFee { get; set; }

        /// <summary>
        /// The SalesLicensingFees filing fee
        /// <summary>
        public DecimalInputViewModel FilingFee { get; set; }

        /// <summary>
        /// The total retail of all licensing fees
        /// </summary>
        public DecimalInputViewModel Total { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// <summary>
        public SalesLicensingViewModel()

        {
            
        }

        #endregion
    }
}
