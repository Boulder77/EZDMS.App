using System.Collections.Generic;

namespace EZDMS.App
{
    /// <summary>
    /// The design-time data for a <see cref="TruthinLendingDisclosureViewModel"/>
    /// </summary>
    public class TruthInLendingDisclosureDesignModel : TruthinLendingDisclosureViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static TruthInLendingDisclosureDesignModel Instance => new TruthInLendingDisclosureDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public TruthInLendingDisclosureDesignModel()
        {
            Payment = new NumericalEntryViewModel { Label = "47 Payments", OriginalAmount = 203436 };
            FinalPayment = new NumericalEntryViewModel { Label = "Final Payment", OriginalAmount = 203436};
            FinanceCharge = new NumericalEntryViewModel { Label = "Finance Charge", OriginalAmount = 1431798};
            TotalOfPayments = new NumericalEntryViewModel { Label = "Total of Payments", OriginalAmount = 9764928};
            TotalDown = new NumericalEntryViewModel { Label = "Total Down", OriginalAmount = 3500000};
            TotalSalePrice = new NumericalEntryViewModel { Label = "Total Sale Price", OriginalAmount = 10114928};
            
        }

        #endregion
    }
}
