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
    /// The view model for the SalesLocalFees control
    /// <summary>
    public class SalesLocalFeesViewModel : BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// The SalesLocalFees deal number
        /// <summary>
        public int DealNumber { get; set; }

        /// <summary>
        /// The SalesLocalFees documentation fee
        /// <summary>
        public LocalFeeViewModel DocumentationFee { get; set; }


        /// <summary>
        /// The SalesLocalFees tire fee
        /// <summary>
        public LocalFeeViewModel TireFee { get; set; }


        /// <summary>
        /// The SalesLocalFees inspection fee
        /// <summary>
        public LocalFeeViewModel InspectionFee { get; set; }

        /// <summary>
        
        /// <summary>
        /// The SalesLocalFees messenger fee
        /// <summary>
        public LocalFeeViewModel MessengerFee { get; set; }

        /// <summary>
        /// The SalesLocalFees battery fee
        /// <summary>
        public LocalFeeViewModel BatteryFee { get; set; }

        /// <summary>
        /// The SalesLocalFees smog to seller fee
        /// <summary>
        public LocalFeeViewModel SmogToSellerFee { get; set; }

        /// <summary>
        /// The SalesLocalFees doc stamps fee
        /// <summary>
        public LocalFeeViewModel DocStampsFee { get; set; }

        /// <summary>
        /// The SalesLocalFees e v charging fee
        /// <summary>
        public LocalFeeViewModel EVChargingFee { get; set; }

        /// <summary>
        /// The SalesLocalFees state inspection fee
        /// <summary>
        public LocalFeeViewModel StateInspectionFee { get; set; }

        /// <summary>
        /// The SalesLocalFees smog state fee
        /// <summary>
        public LocalFeeViewModel SmogStateFee { get; set; }

        /// <summary>
        /// The SalesLocalFees smog abatement fee
        /// <summary>
        public LocalFeeViewModel SmogAbatementFee { get; set; }

        /// <summary>
        /// The SalesLocalFees emissions fee
        /// <summary>
        public LocalFeeViewModel EmissionsFee { get; set; }

        /// <summary>
        /// The SalesLocalFees electronic filing fee
        /// <summary>
        public LocalFeeViewModel ElectronicFilingFee { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee1
        /// <summary>
        public LocalFeeViewModel LocalFee1 { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee2
        /// <summary>
        public LocalFeeViewModel LocalFee2 { get; set; }

          /// <summary>
        /// The SalesLocalFees local fee3
        /// <summary>
        public LocalFeeViewModel LocalFee3 { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee4
        /// <summary>
        public LocalFeeViewModel LocalFee4 { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee5
        /// <summary>
        public LocalFeeViewModel LocalFee5 { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee6
        /// <summary>
        public LocalFeeViewModel LocalFee6 { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee7
        /// <summary>
        public LocalFeeViewModel LocalFee7 { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee8
        /// <summary>
        public LocalFeeViewModel LocalFee8 { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee9
        /// <summary>
        public LocalFeeViewModel LocalFee9 { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee10
        /// <summary>
        public LocalFeeViewModel LocalFee10 { get; set; }

        /// <summary>
        /// The total local fees
        /// </summary>
        public DecimalInputViewModel Total { get; set; }


        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// <summary>
        public SalesLocalFeesViewModel()
        {

        }

        #endregion
    }
}
