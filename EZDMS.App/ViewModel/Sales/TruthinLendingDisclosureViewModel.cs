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
    /// The View Model for a Truth in Lending Disclosure control
    /// </summary>
    public class TruthinLendingDisclosureViewModel : BaseViewModel
    {
        
        #region Public Properties

        /// <summary>
        /// The number of payments
        /// </summary>
        public int NumberOfPayments { get; set; }

        /// <summary>
        /// The payment amount
        /// </summary>
        public NumericalEntryViewModel Payments { get; set; }

        /// <summary>
        /// The final payment amount
        /// </summary>
        public NumericalEntryViewModel FinalPayment { get; set; }

        /// <summary>
        /// The finance charge amount
        /// </summary>
        public NumericalEntryViewModel FinanceCharge { get; set; }

        /// <summary>
        /// The total of payments amount
        /// </summary>
        public NumericalEntryViewModel TotalOfPayments { get; set; }

        /// <summary>
        /// The total down amount
        /// </summary>
        public NumericalEntryViewModel TotalDown { get; set; }

        /// <summary>
        /// The total sale price
        /// </summary>
        public NumericalEntryViewModel TotalSalePrice { get; set; }
        
        #endregion


        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public TruthinLendingDisclosureViewModel()
        {
            // Create commands

            // Task.Run(GetSalesRecallDealsAsync);

        }

        #endregion




    }

}
