using System.Collections.Generic;

namespace EZDMS.App
{
    /// <summary>
    /// The design-time data for a <see cref="SalesDeskingInfoDesignModel"/>
    /// </summary>
    public class SalesDeskingInfoDesignModel : SalesDeskingInfoViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static SalesDeskingInfoDesignModel Instance => new SalesDeskingInfoDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SalesDeskingInfoDesignModel()
        {
            SellingPrice = new NumericalEntryViewModel { Label = "Selling Price", OriginalAmount = 5687500 };
            FrontOptions = new NumericalEntryViewModel { Label = "Front Options", OriginalAmount = 319700, Editable = true };
            Taxes = new NumericalEntryViewModel { Label = "Taxes", OriginalAmount = 401925, Editable = true };
            Fees = new NumericalEntryViewModel { Label = "Fees", OriginalAmount = 39265, Editable = true };
            BackOptions = new NumericalEntryViewModel { Label = "Back Options", OriginalAmount = 248400, Editable = true };
            Service = new NumericalEntryViewModel { Label = "Service", OriginalAmount = 374000, Editable = true };
            Gap = new NumericalEntryViewModel { Label = "Gap", OriginalAmount = 89500, Editable = true };
            CreditInsurance = new NumericalEntryViewModel { Label = "Credit Insurance", OriginalAmount = 712840, Editable = true };
            SubTotal = new NumericalEntryViewModel { Label = "SUBTOTAL", OriginalAmount = 7873130 };
            Cash = new NumericalEntryViewModel { Label = "Cash", OriginalAmount = 180000, Editable = true };
            Rebates = new NumericalEntryViewModel { Label = "Rebates", OriginalAmount = 170000, Editable = true };
            TradeAllowance = new NumericalEntryViewModel { Label = "Trade Allowance", OriginalAmount = 240000, Editable = true };
            TradePayoff = new NumericalEntryViewModel { Label = "Trade Payoff", OriginalAmount = 1050000, Editable = true };
            Total = new NumericalEntryViewModel { Label = "TOTAL", OriginalAmount = 7873130 };
            CashFromCustomer = new NumericalEntryViewModel { Label = "Cash From Customer", OriginalAmount = 180000 };
            Payment = new NumericalEntryViewModel { Label = "Payment", OriginalAmount = 203436 };

        }

        #endregion
    }
}
