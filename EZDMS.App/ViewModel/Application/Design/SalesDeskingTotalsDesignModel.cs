using System.Collections.Generic;

namespace EZDMS.App
{
    /// <summary>
    /// The design-time data for a <see cref="SalesDeskingTotalsViewModel"/>
    /// </summary>
    public class SalesDeskingTotalsDesignModel : SalesDeskingTotalsViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static SalesDeskingTotalsDesignModel Instance => new SalesDeskingTotalsDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SalesDeskingTotalsDesignModel()
        {
            SellingPrice = new NumericalEntryViewModel { Label = "Selling Price", OriginalAmount = 56875 };
            FrontOptions = new NumericalEntryViewModel { Label = "Front Options", OriginalAmount = 3197, Editable = true };
            Taxes = new NumericalEntryViewModel { Label = "Taxes", OriginalAmount = 4019.25m, Editable = true };
            Fees = new NumericalEntryViewModel { Label = "Fees", OriginalAmount = 39265, Editable = true };
            BackOptions = new NumericalEntryViewModel { Label = "Back Options", OriginalAmount = 2484, Editable = true };
            Service = new NumericalEntryViewModel { Label = "Service", OriginalAmount = 3740, Editable = true };
            Gap = new NumericalEntryViewModel { Label = "Gap", OriginalAmount = 895, Editable = true };
            CreditInsurance = new NumericalEntryViewModel { Label = "Credit Insurance", OriginalAmount = 7128.40m, Editable = true };
            SubTotal = new NumericalEntryViewModel { Label = "SUBTOTAL", OriginalAmount = 78731.30m };
            Cash = new NumericalEntryViewModel { Label = "Cash", OriginalAmount = 1800, Editable = true };
            Rebates = new NumericalEntryViewModel { Label = "Rebates", OriginalAmount = 1700, Editable = true };
            TradeAllowance = new NumericalEntryViewModel { Label = "Trade Allowance", OriginalAmount = 2400, Editable = true };
            TradePayoff = new NumericalEntryViewModel { Label = "Trade Payoff", OriginalAmount = 10500, Editable = true };
            Total = new NumericalEntryViewModel { Label = "TOTAL", OriginalAmount = 83331.30m };
            CashFromCustomer = new NumericalEntryViewModel { Label = "Cash From Customer", OriginalAmount = 1800 };
            Payment = new NumericalEntryViewModel { Label = "Payment", OriginalAmount = 2034.36m };

        }

        #endregion
    }
}
