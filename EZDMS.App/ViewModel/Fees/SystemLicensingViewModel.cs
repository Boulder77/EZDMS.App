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
    /// The view model for the SystemLicensingFees control
    /// <summary>
    public class SystemLicensingViewModel : BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// The SystemLicensingFees license fee
        /// <summary>
        public DecimalInputViewModel LicenseFee { get; set; }

        /// <summary>
        /// The SystemLicensingFees license fee active
        /// <summary>
        public bool LicenseFeeActive { get; set; }

        /// <summary>
        /// The SystemLicensingFees license fee in payment
        /// <summary>
        public bool LicenseFeeInPayment { get; set; }

        /// <summary>
        /// The SystemLicensingFees license fee in cap
        /// <summary>
        public bool LicenseFeeInCap { get; set; }

        /// <summary>
        /// The SystemLicensingFees plate fee
        /// <summary>
        public DecimalInputViewModel PlateFee { get; set; }

        /// <summary>
        /// The SystemLicensingFees plate fee active
        /// <summary>
        public bool PlateFeeActive { get; set; }

        /// <summary>
        /// The SystemLicensingFees plate fee in payment
        /// <summary>
        public bool PlateFeeInPayment { get; set; }

        /// <summary>
        /// The SystemLicensingFees plate fee in cap
        /// <summary>
        public bool PlateFeeInCap { get; set; }

        /// <summary>
        /// The SystemLicensingFees title fee
        /// <summary>
        public DecimalInputViewModel TitleFee { get; set; }

        /// <summary>
        /// The SystemLicensingFees title fee active
        /// <summary>
        public bool TitleFeeActive { get; set; }

        /// <summary>
        /// The SystemLicensingFees title fee in payment
        /// <summary>
        public bool TitleFeeInPayment { get; set; }

        /// <summary>
        /// The SystemLicensingFees title fee in cap
        /// <summary>
        public bool TitleFeeInCap { get; set; }

        /// <summary>
        /// The SystemLicensingFees temp tag fee
        /// <summary>
        public DecimalInputViewModel TempTagFee { get; set; }

        /// <summary>
        /// The SystemLicensingFees temp tag fee active
        /// <summary>
        public bool TempTagFeeActive { get; set; }

        /// <summary>
        /// The SystemLicensingFees temp tag fee in payment
        /// <summary>
        public bool TempTagFeeInPayment { get; set; }

        /// <summary>
        /// The SystemLicensingFees temp tag fee in cap
        /// <summary>
        public bool TempTagFeeInCap { get; set; }

        /// <summary>
        /// The SystemLicensingFees registration fee
        /// <summary>
        public DecimalInputViewModel RegistrationFee { get; set; }

        /// <summary>
        /// The SystemLicensingFees registration fee active
        /// <summary>
        public bool RegistrationFeeActive { get; set; }

        /// <summary>
        /// The SystemLicensingFees registration fee in payment
        /// <summary>
        public bool RegistrationFeeInPayment { get; set; }

        /// <summary>
        /// The SystemLicensingFees registration fee in cap
        /// <summary>
        public bool RegistrationFeeInCap { get; set; }

        /// <summary>
        /// The SystemLicensingFees transfer fee
        /// <summary>
        public DecimalInputViewModel TransferFee { get; set; }

        /// <summary>
        /// The SystemLicensingFees transfer fee active
        /// <summary>
        public bool TransferFeeActive { get; set; }

        /// <summary>
        /// The SystemLicensingFees transfer fee in payment
        /// <summary>
        public bool TransferFeeInPayment { get; set; }

        /// <summary>
        /// The SystemLicensingFees transfer fee in cap
        /// <summary>
        public bool TransferFeeInCap { get; set; }

        /// <summary>
        /// The SystemLicensingFees notary fee
        /// <summary>
        public DecimalInputViewModel NotaryFee { get; set; }

        /// <summary>
        /// The SystemLicensingFees notary fee active
        /// <summary>
        public bool NotaryFeeActive { get; set; }

        /// <summary>
        /// The SystemLicensingFees notary fee in payment
        /// <summary>
        public bool NotaryFeeInPayment { get; set; }

        /// <summary>
        /// The SystemLicensingFees notary fee in cap
        /// <summary>
        public bool NotaryFeeInCap { get; set; }

        /// <summary>
        /// The SystemLicensingFees filing fee
        /// <summary>
        public DecimalInputViewModel FilingFee { get; set; }

        /// <summary>
        /// The SystemLicensingFees filing fee active
        /// <summary>
        public bool FilingFeeActive { get; set; }

        /// <summary>
        /// The SystemLicensingFees filing fee in payment
        /// <summary>
        public bool FilingFeeInPayment { get; set; }

        /// <summary>
        /// The SystemLicensingFees filing fee in cap
        /// <summary>
        public bool FilingFeeInCap { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// <summary>
        public SystemLicensingViewModel()
        {

        }

        #endregion
    }
}

