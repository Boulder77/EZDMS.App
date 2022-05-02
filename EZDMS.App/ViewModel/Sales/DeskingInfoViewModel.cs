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
    /// The view model for a desking page
    /// </summary>
    public class DeskingInfoViewModel : BaseViewModel
    {
        #region Private Members

        /// <summary>
        /// The current working sales deal 
        /// </summary>
        private SalesFinanceDataModel mWorkingDeal;

        #endregion

        #region Public Properties
        /// <summary>
        /// The current working sales deal 
        /// </summary>
        public SalesFinanceDataModel WorkingDeal
        {
            get => mWorkingDeal;
            set
            {
                if (mWorkingDeal == value)
                    return;

                mWorkingDeal = value;
            }
        }

        /// <summary>
        /// The view model for the sales summary control
        /// </summary>
        public SalesSummaryViewModel SalesSummary { get; set; }

        /// <summary>
        /// The view model for the truth in lending disclosure control
        /// </summary>
        public TruthinLendingDisclosureViewModel TruthinLending { get; set; }

        /// <summary>
        /// The view model for the desking totals control
        /// </summary>
        public SalesDeskingTotalsViewModel DeskingTotals { get; set; } 

        #endregion


        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public DeskingInfoViewModel()
        {
            // Create commands

            // Task.Run(GetSalesRecallDealsAsync);

        }

        #endregion               

    }

}
