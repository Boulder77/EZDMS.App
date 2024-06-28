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
    /// The view model for the SystemLocalFees control
    /// <summary>
    public class SystemLocalFeesViewModel : BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// The SystemLocalFees documentation fee
        /// <summary>
        public DecimalInputViewModel DocumentationFee { get; set; }

        /// <summary>
        /// The SystemLocalFees documentation fee active
        /// <summary>
        public bool DocumentationFeeActive { get; set; }

        /// <summary>
        /// The SystemLocalFees documentation fee in payment
        /// <summary>
        public bool DocumentationFeeInPayment { get; set; }

        /// <summary>
        /// The SystemLocalFees documentation fee in cap
        /// <summary>
        public bool DocumentationFeeInCap { get; set; }

        /// <summary>
        /// The SystemLocalFees documentation fee taxable
        /// <summary>
        public bool DocumentationFeeTaxable { get; set; }

        /// <summary>
        /// The SystemLocalFees tire fee
        /// <summary>
        public DecimalInputViewModel TireFee { get; set; }

        /// <summary>
        /// The SystemLocalFees tire fee active
        /// <summary>
        public bool TireFeeActive { get; set; }

        /// <summary>
        /// The SystemLocalFees tire fee in payment
        /// <summary>
        public bool TireFeeInPayment { get; set; }

        /// <summary>
        /// The SystemLocalFees tire fee in cap
        /// <summary>
        public bool TireFeeInCap { get; set; }

        /// <summary>
        /// The SystemLocalFees tire fee taxable
        /// <summary>
        public bool TireFeeTaxable { get; set; }

        /// <summary>
        /// The SystemLocalFees inspection fee
        /// <summary>
        public DecimalInputViewModel InspectionFee { get; set; }

        /// <summary>
        /// The SystemLocalFees inspection fee active
        /// <summary>
        public bool InspectionFeeActive { get; set; }

        /// <summary>
        /// The SystemLocalFees inspection fee in payment
        /// <summary>
        public bool InspectionFeeInPayment { get; set; }

        /// <summary>
        /// The SystemLocalFees inspection fee in cap
        /// <summary>
        public bool InspectionFeeInCap { get; set; }

        /// <summary>
        /// The SystemLocalFees inspection fee taxable
        /// <summary>
        public bool InspectionFeeTaxable { get; set; }

        /// <summary>
        /// The SystemLocalFees messenger fee
        /// <summary>
        public DecimalInputViewModel MessengerFee { get; set; }

        /// <summary>
        /// The SystemLocalFees messenger fee active
        /// <summary>
        public bool MessengerFeeActive { get; set; }

        /// <summary>
        /// The SystemLocalFees messenger fee in payment
        /// <summary>
        public bool MessengerFeeInPayment { get; set; }

        /// <summary>
        /// The SystemLocalFees messenger fee in cap
        /// <summary>
        public bool MessengerFeeInCap { get; set; }

        /// <summary>
        /// The SystemLocalFees messenger fee taxable
        /// <summary>
        public bool MessengerFeeTaxable { get; set; }

        /// <summary>
        /// The SystemLocalFees battery fee
        /// <summary>
        public DecimalInputViewModel BatteryFee { get; set; }

        /// <summary>
        /// The SystemLocalFees battery fee active
        /// <summary>
        public bool BatteryFeeActive { get; set; }

        /// <summary>
        /// The SystemLocalFees battery fee in payment
        /// <summary>
        public bool BatteryFeeInPayment { get; set; }

        /// <summary>
        /// The SystemLocalFees battery fee in cap
        /// <summary>
        public bool BatteryFeeInCap { get; set; }

        /// <summary>
        /// The SystemLocalFees battery fee taxable
        /// <summary>
        public bool BatteryFeeTaxable { get; set; }

        /// <summary>
        /// The SystemLocalFees smog to seller fee
        /// <summary>
        public DecimalInputViewModel SmogToSellerFee { get; set; }

        /// <summary>
        /// The SystemLocalFees smog to seller fee active
        /// <summary>
        public bool SmogToSellerFeeActive { get; set; }

        /// <summary>
        /// The SystemLocalFees smog to seller fee in payment
        /// <summary>
        public bool SmogToSellerFeeInPayment { get; set; }

        /// <summary>
        /// The SystemLocalFees smog to seller fee in cap
        /// <summary>
        public bool SmogToSellerFeeInCap { get; set; }

        /// <summary>
        /// The SystemLocalFees smog to seller fee taxable
        /// <summary>
        public bool SmogToSellerFeeTaxable { get; set; }

        /// <summary>
        /// The SystemLocalFees doc stamps fee
        /// <summary>
        public DecimalInputViewModel DocStampsFee { get; set; }

        /// <summary>
        /// The SystemLocalFees doc stamps fee active
        /// <summary>
        public bool DocStampsFeeActive { get; set; }

        /// <summary>
        /// The SystemLocalFees doc stamps fee in payment
        /// <summary>
        public bool DocStampsFeeInPayment { get; set; }

        /// <summary>
        /// The SystemLocalFees doc stamps fee in cap
        /// <summary>
        public bool DocStampsFeeInCap { get; set; }

        /// <summary>
        /// The SystemLocalFees doc stamps fee taxable
        /// <summary>
        public bool DocStampsFeeTaxable { get; set; }

        /// <summary>
        /// The SystemLocalFees e v charging fee
        /// <summary>
        public DecimalInputViewModel EVChargingFee { get; set; }

        /// <summary>
        /// The SystemLocalFees e v charging fee active
        /// <summary>
        public bool EVChargingFeeActive { get; set; }

        /// <summary>
        /// The SystemLocalFees e v charging fee in payment
        /// <summary>
        public bool EVChargingFeeInPayment { get; set; }

        /// <summary>
        /// The SystemLocalFees e v charging fee in cap
        /// <summary>
        public bool EVChargingFeeInCap { get; set; }

        /// <summary>
        /// The SystemLocalFees e v charging fee taxable
        /// <summary>
        public bool EVChargingFeeTaxable { get; set; }

        /// <summary>
        /// The SystemLocalFees state inspection fee
        /// <summary>
        public DecimalInputViewModel StateInspectionFee { get; set; }

        /// <summary>
        /// The SystemLocalFees state inspection fee active
        /// <summary>
        public bool StateInspectionFeeActive { get; set; }

        /// <summary>
        /// The SystemLocalFees state inspection fee in payment
        /// <summary>
        public bool StateInspectionFeeInPayment { get; set; }

        /// <summary>
        /// The SystemLocalFees state inspection fee in cap
        /// <summary>
        public bool StateInspectionFeeInCap { get; set; }

        /// <summary>
        /// The SystemLocalFees state inspection fee taxable
        /// <summary>
        public bool StateInspectionFeeTaxable { get; set; }

        /// <summary>
        /// The SystemLocalFees smog state fee
        /// <summary>
        public DecimalInputViewModel SmogStateFee { get; set; }

        /// <summary>
        /// The SystemLocalFees smog state fee active
        /// <summary>
        public bool SmogStateFeeActive { get; set; }

        /// <summary>
        /// The SystemLocalFees smog state fee in payment
        /// <summary>
        public bool SmogStateFeeInPayment { get; set; }

        /// <summary>
        /// The SystemLocalFees smog state fee in cap
        /// <summary>
        public bool SmogStateFeeInCap { get; set; }

        /// <summary>
        /// The SystemLocalFees smog state taxable
        /// <summary>
        public bool SmogStateTaxable { get; set; }

        /// <summary>
        /// The SystemLocalFees smog abatement fee
        /// <summary>
        public DecimalInputViewModel SmogAbatementFee { get; set; }

        /// <summary>
        /// The SystemLocalFees smog abatement fee active
        /// <summary>
        public bool SmogAbatementFeeActive { get; set; }

        /// <summary>
        /// The SystemLocalFees smog abatement fee in payment
        /// <summary>
        public bool SmogAbatementFeeInPayment { get; set; }

        /// <summary>
        /// The SystemLocalFees smog abatement fee in cap
        /// <summary>
        public bool SmogAbatementFeeInCap { get; set; }

        /// <summary>
        /// The SystemLocalFees smog abatement fee taxable
        /// <summary>
        public bool SmogAbatementFeeTaxable { get; set; }

        /// <summary>
        /// The SystemLocalFees emissions fee
        /// <summary>
        public DecimalInputViewModel EmissionsFee { get; set; }

        /// <summary>
        /// The SystemLocalFees emissions fee active
        /// <summary>
        public bool EmissionsFeeActive { get; set; }

        /// <summary>
        /// The SystemLocalFees emissions fee in payment
        /// <summary>
        public bool EmissionsFeeInPayment { get; set; }

        /// <summary>
        /// The SystemLocalFees emissions fee in cap
        /// <summary>
        public bool EmissionsFeeInCap { get; set; }

        /// <summary>
        /// The SystemLocalFees emissions fee taxable
        /// <summary>
        public bool EmissionsFeeTaxable { get; set; }

        /// <summary>
        /// The SystemLocalFees electronic filing fee
        /// <summary>
        public DecimalInputViewModel ElectronicFilingFee { get; set; }

        /// <summary>
        /// The SystemLocalFees electronic filing fee active
        /// <summary>
        public bool ElectronicFilingFeeActive { get; set; }

        /// <summary>
        /// The SystemLocalFees electronic filing fee in payment
        /// <summary>
        public bool ElectronicFilingFeeInPayment { get; set; }

        /// <summary>
        /// The SystemLocalFees electronic filing fee in cap
        /// <summary>
        public bool ElectronicFilingFeeInCap { get; set; }

        /// <summary>
        /// The SystemLocalFees electronic filing fee taxable
        /// <summary>
        public bool ElectronicFilingFeeTaxable { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee1 name
        /// <summary>
        public TextEntryViewModel LocalFee1Name { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee1
        /// <summary>
        public DecimalInputViewModel LocalFee1 { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee1 active
        /// <summary>
        public bool LocalFee1Active { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee1 in payment
        /// <summary>
        public bool LocalFee1InPayment { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee1 in cap
        /// <summary>
        public bool LocalFee1InCap { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee1 taxable
        /// <summary>
        public bool LocalFee1Taxable { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee2 name
        /// <summary>
        public TextEntryViewModel LocalFee2Name { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee2
        /// <summary>
        public DecimalInputViewModel LocalFee2 { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee2 active
        /// <summary>
        public bool LocalFee2Active { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee2 in payment
        /// <summary>
        public bool LocalFee2InPayment { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee2 in cap
        /// <summary>
        public bool LocalFee2InCap { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee2 taxable
        /// <summary>
        public bool LocalFee2Taxable { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee3 name
        /// <summary>
        public TextEntryViewModel LocalFee3Name { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee3
        /// <summary>
        public DecimalInputViewModel LocalFee3 { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee3 active
        /// <summary>
        public bool LocalFee3Active { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee3 in payment
        /// <summary>
        public bool LocalFee3InPayment { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee3 in cap
        /// <summary>
        public bool LocalFee3InCap { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee3 taxable
        /// <summary>
        public bool LocalFee3Taxable { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee4 name
        /// <summary>
        public TextEntryViewModel LocalFee4Name { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee4
        /// <summary>
        public DecimalInputViewModel LocalFee4 { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee4 active
        /// <summary>
        public bool LocalFee4Active { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee4 in payment
        /// <summary>
        public bool LocalFee4InPayment { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee4 in cap
        /// <summary>
        public bool LocalFee4InCap { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee4 taxable
        /// <summary>
        public bool LocalFee4Taxable { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee5 name
        /// <summary>
        public TextEntryViewModel LocalFee5Name { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee5
        /// <summary>
        public DecimalInputViewModel LocalFee5 { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee5 active
        /// <summary>
        public bool LocalFee5Active { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee5 in payment
        /// <summary>
        public bool LocalFee5InPayment { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee5 in cap
        /// <summary>
        public bool LocalFee5InCap { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee5 taxable
        /// <summary>
        public bool LocalFee5Taxable { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee6 name
        /// <summary>
        public TextEntryViewModel LocalFee6Name { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee6
        /// <summary>
        public DecimalInputViewModel LocalFee6 { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee6 active
        /// <summary>
        public bool LocalFee6Active { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee6 in payment
        /// <summary>
        public bool LocalFee6InPayment { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee6 in cap
        /// <summary>
        public bool LocalFee6InCap { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee6 taxable
        /// <summary>
        public bool LocalFee6Taxable { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee7 name
        /// <summary>
        public TextEntryViewModel LocalFee7Name { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee7
        /// <summary>
        public DecimalInputViewModel LocalFee7 { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee7 active
        /// <summary>
        public bool LocalFee7Active { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee7 in payment
        /// <summary>
        public bool LocalFee7InPayment { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee7 in cap
        /// <summary>
        public bool LocalFee7InCap { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee7 taxable
        /// <summary>
        public bool LocalFee7Taxable { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee8 name
        /// <summary>
        public TextEntryViewModel LocalFee8Name { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee8
        /// <summary>
        public DecimalInputViewModel LocalFee8 { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee8 active
        /// <summary>
        public bool LocalFee8Active { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee8 in payment
        /// <summary>
        public bool LocalFee8InPayment { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee8 in cap
        /// <summary>
        public bool LocalFee8InCap { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee8 taxable
        /// <summary>
        public bool LocalFee8Taxable { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee9 name
        /// <summary>
        public TextEntryViewModel LocalFee9Name { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee9
        /// <summary>
        public DecimalInputViewModel LocalFee9 { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee9 active
        /// <summary>
        public bool LocalFee9Active { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee9 in payment
        /// <summary>
        public bool LocalFee9InPayment { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee9 in cap
        /// <summary>
        public bool LocalFee9InCap { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee9 taxable
        /// <summary>
        public bool LocalFee9Taxable { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee10 name
        /// <summary>
        public TextEntryViewModel LocalFee10Name { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee10
        /// <summary>
        public DecimalInputViewModel LocalFee10 { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee10 active
        /// <summary>
        public bool LocalFee10Active { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee10 in payment
        /// <summary>
        public bool LocalFee10InPayment { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee10 in cap
        /// <summary>
        public bool LocalFee10InCap { get; set; }

        /// <summary>
        /// The SystemLocalFees local fee10 taxable
        /// <summary>
        public bool LocalFee10Taxable { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// <summary>
        public SystemLocalFeesViewModel()
        {

        }

        #endregion
    }
}


