using System.Collections.Generic;

namespace EZDMS.App
{
    /// <summary>
    /// The design-time data for a <see cref="SalesLocalFeesViewModel"/>
    /// <summary>
    public class SalesLocalFeesDesignModel : SalesLocalFeesViewModel
    {

        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// <summary>
        public static SalesLocalFeesDesignModel Instance => new SalesLocalFeesDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// <summary>
        public SalesLocalFeesDesignModel()
        {
           

            DocumentationFee = new DecimalInputViewModel { Label = "Document", Amount = 12900};
            DocumentationFeeInPayment = true;

            TireFee = new DecimalInputViewModel { Label = "Tire", Amount = 1300 };
            TireFeeInPayment = true;

            InspectionFee = new DecimalInputViewModel { Label = "Inspection", Amount = 6500 };
            InspectionFeeInPayment = true;

            BatteryFee = new DecimalInputViewModel { Label = "Battery", Amount=1825 };
            BatteryFeeInPayment = true;

            SmogStateFee = new DecimalInputViewModel { Label = "Smog", Amount = 3500 };
            SmogStateFeeInPayment = true;

            ElectronicFilingFee = new DecimalInputViewModel { Label = "Electronic Filing", Amount = 6500 };
            ElectronicFilingFeeInPayment=true;

            LocalFee1Name = "Misc";
            LocalFee1 = new DecimalInputViewModel { Label = LocalFee1Name, Amount = 1400 };            
            LocalFee1InPayment = true;
            

            Total = new DecimalInputViewModel { Label = "Total", Amount = 49964 };


        }

        #endregion
    }
}
