using System.Collections.Generic;
using System;
using EZDMS.App.Core;

namespace EZDMS.App
{
    /// <summary>
    /// The design-time data for a <see cref="SalesSummaryDetailsViewModel"/>
    /// </summary>
    public class SalesSummaryDetailsDesignModel : SalesSummaryDetailsViewModel
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
            APR = new TextEntryViewModel { Label = "APR", OriginalText = "8.000"};
            EffectiveAPR = new TextEntryViewModel { Label = "Effective APR", OriginalText = "8.000" };
            TradeDifference = new TextDisplayViewModel { Label = "Trade Difference", DisplayText="$54,475.00"};
            Term = new TextEntryViewModel { Label = "Term", OriginalText = "48" };
            SelectedPaymentType = PaymentType.Monthly;
            PurchaseDate = new DateSelectionViewModel { Label = "Purchase Date", Date = DateTime.Today };
            DaysToFirstPayment = new TextEntryViewModel { Label = "Days To First Payment" };
            PaymentDate = new DateSelectionViewModel { Label = "Payment Date", Date = DateTime.Today.AddDays(30) };

        }

        #endregion
    }
}
