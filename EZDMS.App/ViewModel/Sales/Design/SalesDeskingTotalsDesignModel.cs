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
            SellingPrice = new DecimalInputViewModel { Label = "Selling Price", Amount = 56875 };
            FrontOptions = new DecimalInputViewModel { Label = "Front Options", Amount = 3197, Editable = true };
            Taxes = new DecimalInputViewModel { Label = "Taxes", Amount = 4019.25m, Editable = true };
            Fees = new DecimalInputViewModel { Label = "Fees", Amount = 39265, Editable = true };
            BackOptions = new DecimalInputViewModel { Label = "Back Options", Amount = 2484, Editable = true };
            Service = new DecimalInputViewModel { Label = "Service", Amount = 3740, Editable = true };
            Gap = new DecimalInputViewModel { Label = "Gap", Amount = 895, Editable = true };
            CreditInsurance = new DecimalInputViewModel { Label = "Credit Insurance", Amount = 7128.40m, Editable = true };
            SubTotal = new DecimalInputViewModel { Label = "SUBTOTAL", Amount = 78731.30m };
            Cash = new DecimalInputViewModel { Label = "Cash", Amount = 1800, Editable = true };
            Rebates = new DecimalInputViewModel { Label = "Rebates", Amount = 1700, Editable = true };
            TradeAllowance = new DecimalInputViewModel { Label = "Trade Allowance", Amount = 2400, Editable = true };
            TradePayoff = new DecimalInputViewModel { Label = "Trade Payoff", Amount = 10500, Editable = true };
            Total = new DecimalInputViewModel { Label = "TOTAL", Amount = 83331.30m };
            CashFromCustomer = new DecimalInputViewModel { Label = "Cash From Customer", Amount = 1800 };
            Payment = new DecimalInputViewModel { Label = "Payment", Amount = 2034.36m };

        }

        #endregion
    }
}
