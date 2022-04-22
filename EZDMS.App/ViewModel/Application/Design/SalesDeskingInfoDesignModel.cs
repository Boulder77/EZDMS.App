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
            SellingPrice = new TextEntryViewModel { Label = "Selling Price", OriginalText = "56875.00" };
            FrontOptions = new TextEntryViewModel { Label = "Front Options", OriginalText = "3197.00" };
            Taxes = new TextEntryViewModel { Label = "Taxes", OriginalText = "4019.25" };
            Fees = new TextEntryViewModel { Label = "Fees", OriginalText = "392.65" };
            BackOptions = new TextEntryViewModel { Label = "Back Options", OriginalText = "2484.00" };
            Service = new TextEntryViewModel { Label = "Service", OriginalText = "3740.00" };
            Gap = new TextEntryViewModel { Label = "Gap", OriginalText = "895.00" };
            CreditInsurance = new TextEntryViewModel { Label = "Credit Insurance", OriginalText = "7128.40" };
            SubTotal = new TextEntryViewModel { Label = "SUBTOTAL", OriginalText = "78731.30" };
            Cash = new TextEntryViewModel { Label = "Cash", OriginalText = "1800.00" };
            Rebates = new TextEntryViewModel { Label = "Rebates", OriginalText = "1700.00" };
            TradeAllowance = new TextEntryViewModel { Label = "Trade Allowance", OriginalText = "2400.00" };
            TradePayoff = new TextEntryViewModel { Label = "Trade Payoff", OriginalText = "10500.00" };
            Total = new TextEntryViewModel { Label = "TOTAL", OriginalText = "7873130" };
            CashFromCustomer = new TextEntryViewModel { Label = "Cash From Customer", OriginalText = "1800.00" };
            Payment = new TextEntryViewModel { Label = "Payment", OriginalText = "2034.36" };

        }

        #endregion
    }
}
