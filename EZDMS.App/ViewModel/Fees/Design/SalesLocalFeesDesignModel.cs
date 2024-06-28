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

            DocumentationFee = new LocalFeeViewModel { Label = "Document", Amount = 12900, Active=true};
            TireFee = new LocalFeeViewModel { Label = "Tire", Amount = 1300, Active = true };
            InspectionFee = new LocalFeeViewModel { Label = "Inspection", Amount = 6500, Active = true };
            BatteryFee = new LocalFeeViewModel { Label = "Battery", Amount=1825 , Active = true };
            SmogStateFee = new LocalFeeViewModel { Label = "Smog", Amount = 3500 , Active = true };       
            ElectronicFilingFee = new LocalFeeViewModel { Label = "Electronic Filing", Amount = 6500 , Active = true };             
            LocalFee1 = new LocalFeeViewModel { Label = "Misc", Amount = 1400 , Active = true};        
            Total = new DecimalInputViewModel { Label = "Total", Amount = 49964 };

        }

        #endregion
    }
}
