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
        public DecimalInputViewModel DocumentationFee { get; set; }

        /// <summary>
        /// The SalesLocalFees documentation fee in payment
        /// <summary>
        public bool DocumentationFeeInPayment { get; set; }

        /// <summary>
        /// The SalesLocalFees documentation fee taxable
        /// <summary>
        public bool DocumentationFeeTaxable { get; set; }

        /// <summary>
        /// The SalesLocalFees tire fee
        /// <summary>
        public DecimalInputViewModel TireFee { get; set; }

        /// <summary>
        /// The SalesLocalFees tire fee in payment
        /// <summary>
        public bool TireFeeInPayment { get; set; }

        /// <summary>
        /// The SalesLocalFees tire fee taxable
        /// <summary>
        public bool TireFeeTaxable { get; set; }

        /// <summary>
        /// The SalesLocalFees inspection fee
        /// <summary>
        public DecimalInputViewModel InspectionFee { get; set; }

        /// <summary>
        /// The SalesLocalFees inspection fee in payment
        /// <summary>
        public bool InspectionFeeInPayment { get; set; }

        /// <summary>
        /// The SalesLocalFees inspection fee taxable
        /// <summary>
        public bool InspectionFeeTaxable { get; set; }

        /// <summary>
        /// The SalesLocalFees messenger fee
        /// <summary>
        public DecimalInputViewModel MessengerFee { get; set; }

        /// <summary>
        /// The SalesLocalFees messenger fee in payment
        /// <summary>
        public bool MessengerFeeInPayment { get; set; }

        /// <summary>
        /// The SalesLocalFees messenger fee taxable
        /// <summary>
        public bool MessengerFeeTaxable { get; set; }

        /// <summary>
        /// The SalesLocalFees battery fee
        /// <summary>
        public DecimalInputViewModel BatteryFee { get; set; }

        /// <summary>
        /// The SalesLocalFees battery fee in payment
        /// <summary>
        public bool BatteryFeeInPayment { get; set; }

        /// <summary>
        /// The SalesLocalFees battery fee taxable
        /// <summary>
        public bool BatteryFeeTaxable { get; set; }

        /// <summary>
        /// The SalesLocalFees smog to seller fee
        /// <summary>
        public DecimalInputViewModel SmogToSellerFee { get; set; }

        /// <summary>
        /// The SalesLocalFees smog to seller fee in payment
        /// <summary>
        public bool SmogToSellerFeeInPayment { get; set; }

        /// <summary>
        /// The SalesLocalFees smog to seller fee taxable
        /// <summary>
        public bool SmogToSellerFeeTaxable { get; set; }

        /// <summary>
        /// The SalesLocalFees doc stamps fee
        /// <summary>
        public DecimalInputViewModel DocStampsFee { get; set; }

        /// <summary>
        /// The SalesLocalFees doc stamps fee in payment
        /// <summary>
        public bool DocStampsFeeInPayment { get; set; }

        /// <summary>
        /// The SalesLocalFees doc stamps fee taxable
        /// <summary>
        public bool DocStampsFeeTaxable { get; set; }

        /// <summary>
        /// The SalesLocalFees e v charging fee
        /// <summary>
        public DecimalInputViewModel EVChargingFee { get; set; }

        /// <summary>
        /// The SalesLocalFees e v charging fee in payment
        /// <summary>
        public bool EVChargingFeeInPayment { get; set; }

        /// <summary>
        /// The SalesLocalFees e v charging fee taxable
        /// <summary>
        public bool EVChargingFeeTaxable { get; set; }

        /// <summary>
        /// The SalesLocalFees state inspection fee
        /// <summary>
        public DecimalInputViewModel StateInspectionFee { get; set; }

        /// <summary>
        /// The SalesLocalFees state inspection fee in payment
        /// <summary>
        public bool StateInspectionFeeInPayment { get; set; }

        /// <summary>
        /// The SalesLocalFees state inspection fee taxable
        /// <summary>
        public bool StateInspectionFeeTaxable { get; set; }

        /// <summary>
        /// The SalesLocalFees smog state fee
        /// <summary>
        public DecimalInputViewModel SmogStateFee { get; set; }

        /// <summary>
        /// The SalesLocalFees smog state fee in payment
        /// <summary>
        public bool SmogStateFeeInPayment { get; set; }

        /// <summary>
        /// The SalesLocalFees smog state fee taxable
        /// <summary>
        public bool SmogStateFeeTaxable { get; set; }

        /// <summary>
        /// The SalesLocalFees smog abatement fee
        /// <summary>
        public DecimalInputViewModel SmogAbatementFee { get; set; }

        /// <summary>
        /// The SalesLocalFees smog abatement fee in payment
        /// <summary>
        public bool SmogAbatementFeeInPayment { get; set; }

        /// <summary>
        /// The SalesLocalFees smog abatement fee taxable
        /// <summary>
        public bool SmogAbatementFeeTaxable { get; set; }

        /// <summary>
        /// The SalesLocalFees emissions fee
        /// <summary>
        public DecimalInputViewModel EmissionsFee { get; set; }

        /// <summary>
        /// The SalesLocalFees emissions fee in payment
        /// <summary>
        public bool EmissionsFeeInPayment { get; set; }

        /// <summary>
        /// The SalesLocalFees emissions fee taxable
        /// <summary>
        public bool EmissionsFeeTaxable { get; set; }

        /// <summary>
        /// The SalesLocalFees electronic filing fee
        /// <summary>
        public DecimalInputViewModel ElectronicFilingFee { get; set; }

        /// <summary>
        /// The SalesLocalFees electronic filing fee in payment
        /// <summary>
        public bool ElectronicFilingFeeInPayment { get; set; }

        /// <summary>
        /// The SalesLocalFees electronic filing fee taxable
        /// <summary>
        public bool ElectronicFilingFeeTaxable { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee1 name
        /// <summary>
        public string LocalFee1Name { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee1
        /// <summary>
        public DecimalInputViewModel LocalFee1 { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee1 in payment
        /// <summary>
        public bool LocalFee1InPayment { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee1 taxable
        /// <summary>
        public bool LocalFee1Taxable { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee2 name
        /// <summary>
        public string LocalFee2Name { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee2
        /// <summary>
        public DecimalInputViewModel LocalFee2 { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee2 in payment
        /// <summary>
        public bool LocalFee2InPayment { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee2 taxable
        /// <summary>
        public bool LocalFee2Taxable { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee3 name
        /// <summary>
        public string LocalFee3Name { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee3
        /// <summary>
        public DecimalInputViewModel LocalFee3 { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee3 in payment
        /// <summary>
        public bool LocalFee3InPayment { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee3 taxable
        /// <summary>
        public bool LocalFee3Taxable { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee4 name
        /// <summary>
        public string LocalFee4Name { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee4
        /// <summary>
        public DecimalInputViewModel LocalFee4 { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee4 in payment
        /// <summary>
        public bool LocalFee4InPayment { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee4 taxable
        /// <summary>
        public bool LocalFee4Taxable { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee5 name
        /// <summary>
        public string LocalFee5Name { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee5
        /// <summary>
        public DecimalInputViewModel LocalFee5 { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee5 in payment
        /// <summary>
        public bool LocalFee5InPayment { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee5 taxable
        /// <summary>
        public bool LocalFee5Taxable { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee6 name
        /// <summary>
        public string LocalFee6Name { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee6
        /// <summary>
        public DecimalInputViewModel LocalFee6 { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee6 in payment
        /// <summary>
        public bool LocalFee6InPayment { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee6 taxable
        /// <summary>
        public bool LocalFee6Taxable { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee7 name
        /// <summary>
        public string LocalFee7Name { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee7
        /// <summary>
        public DecimalInputViewModel LocalFee7 { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee7 in payment
        /// <summary>
        public bool LocalFee7InPayment { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee7 taxable
        /// <summary>
        public bool LocalFee7Taxable { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee8 name
        /// <summary>
        public string LocalFee8Name { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee8
        /// <summary>
        public DecimalInputViewModel LocalFee8 { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee8 in payment
        /// <summary>
        public bool LocalFee8InPayment { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee8 taxable
        /// <summary>
        public bool LocalFee8Taxable { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee9 name
        /// <summary>
        public string LocalFee9Name { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee9
        /// <summary>
        public DecimalInputViewModel LocalFee9 { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee9 in payment
        /// <summary>
        public bool LocalFee9InPayment { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee9 taxable
        /// <summary>
        public bool LocalFee9Taxable { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee10 name
        /// <summary>
        public string LocalFee10Name { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee10
        /// <summary>
        public DecimalInputViewModel LocalFee10 { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee10 in payment
        /// <summary>
        public bool LocalFee10InPayment { get; set; }

        /// <summary>
        /// The SalesLocalFees local fee10 taxable
        /// <summary>
        public bool LocalFee10Taxable { get; set; }

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
