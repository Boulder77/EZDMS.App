using System.Collections.Generic;

namespace EZDMS.App
{
    /// <summary>
    /// The design-time data for a <see cref="SalesLicensingViewModel"/>
    /// <summary>
    public class SalesLicensingFeesDesignModel : SalesLicensingViewModel
    {

        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// <summary>
        public static SalesLicensingFeesDesignModel Instance => new SalesLicensingFeesDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// <summary>
        public SalesLicensingFeesDesignModel()
        {
            FeesInPayment = true;           

            LicenseFee = new DecimalInputViewModel { Label = "License", Amount = 3400 };            

            TitleFee = new DecimalInputViewModel { Label = "Title", Amount = 6500 };

            PlateFee = new DecimalInputViewModel { Label = "Plates", Amount = 6500 };

            TempTagFee = new DecimalInputViewModel { Label = "Temp Tag", Amount=1325 };           
           
            RegistrationFee = new DecimalInputViewModel { Label = "Registration", Amount = 24639 };

            TransferFee = new DecimalInputViewModel { Label = "Transfer", Amount = 1200 };

            NotaryFee = new DecimalInputViewModel { Label = "Notary", Amount = 1400 };

            FilingFee = new DecimalInputViewModel { Label = "Filing", Amount = 5000 };            


        }

        #endregion
    }
}
