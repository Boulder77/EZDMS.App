using System.Collections.Generic;
using System;
using EZDMS.App.Core;

namespace EZDMS.App
{
    /// <summary>
    /// The design-time data for a <see cref="SalesSummaryViewModel"/>
    /// </summary>
    public class SalesSummaryDetailsDesignModel : SalesSummaryViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static SalesSummaryDetailsDesignModel Instance => new SalesSummaryDetailsDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SalesSummaryDetailsDesignModel()
        {
            SelectedSaleType = SaleType.Retail;
            SelectedState = States.OH;
            Lender = "GALAXY FCU";
            APR = new DecimalInputViewModel { Label = "APR", Amount = 800};
            EffectiveAPR = new DecimalInputViewModel { Label = "Effective APR", Amount = 800 };
            TradeDifference = new TextInputViewModel { Label = "Trade Difference", Text="$54,475.00", Editable = false };
            Term = new NumericalInputViewModel { Label = "Term", Number = 48 };
            SelectedPaymentType = PaymentType.Monthly;
            PurchaseDate = new DateSelectionViewModel { Label = "Purchase Date", Date = DateTime.Today };
            DaysToFirstPayment = new NumericalInputViewModel { Label = "Days To First Payment", Number = 30 };
            PaymentDate = new DateSelectionViewModel { Label = "Payment Date", Date = DateTime.Today.AddDays(30) };

        }

        #endregion
    }
}
