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
            Payment = new DecimalInputViewModel { Label = "47 Payments", Amount = 203436 };
            FinalPayment = new DecimalInputViewModel { Label = "Final Payment", Amount = 203436};
            FinanceCharge = new DecimalInputViewModel { Label = "Finance Charge", Amount = 1431798};
            TotalOfPayments = new DecimalInputViewModel { Label = "Total of Payments", Amount = 9764928};
            TotalDown = new DecimalInputViewModel { Label = "Total Down", Amount = 3500000};
            TotalSalePrice = new DecimalInputViewModel { Label = "Total Sale Price", Amount = 10114928};
            
        }

        #endregion
    }
}
