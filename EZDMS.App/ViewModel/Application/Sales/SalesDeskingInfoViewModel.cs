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
    /// The View Model for a Sales Recall screen
    /// </summary>
    public class SalesDeskingInfoViewModel : BaseViewModel
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
        /// The current working sales deal number
        /// </summary>
        public int WorkingDealNumber { get; set; }

        /// <summary>
        /// The current selling price
        /// </summary>
        public TextEntryViewModel SellingPrice { get; set; }

        /// <summary>
        /// The current front options total amount
        /// </summary>
        public TextEntryViewModel FrontOptions { get; set; }

        /// <summary>
        /// The current taxes amount
        /// </summary>
        public TextEntryViewModel Taxes { get; set; }

        /// <summary>
        /// The current fees total amount
        /// </summary>
        public TextEntryViewModel Fees { get; set; }

        /// <summary>
        /// The current back options total amount
        /// </summary>
        public TextEntryViewModel BackOptions { get; set; }

        /// <summary>
        /// The current service/warranty/maintenance total amount
        /// </summary>
        public TextEntryViewModel Service { get; set; }

        /// <summary>
        /// The current gap amount
        /// </summary>
        public TextEntryViewModel Gap { get; set; }

        /// <summary>
        /// The current credit insurance total amount
        /// </summary>
        public TextEntryViewModel CreditInsurance { get; set; }

        /// <summary>
        /// The current subtotal amount
        /// </summary>
        public TextEntryViewModel SubTotal { get; set; }

        /// <summary>
        /// The current cash total amount
        /// </summary>
        public TextEntryViewModel Cash { get; set; }

        /// <summary>
        /// The current rebates total amount
        /// </summary>
        public TextEntryViewModel Rebates { get; set; }

        /// <summary>
        /// The current trade allowance amount
        /// </summary>
        public TextEntryViewModel TradeAllowance { get; set; }

        /// <summary>
        /// The current trade payoff amount
        /// </summary>
        public TextEntryViewModel TradePayoff { get; set; }

        /// <summary>
        /// The cash due from customer amount
        /// </summary>
        public TextEntryViewModel CashFromCustomer { get; set; }

        /// <summary>
        /// The total sale amount
        /// </summary>
        public TextEntryViewModel Total { get; set; }

        /// <summary>
        /// The payment amount
        /// </summary>
        public TextEntryViewModel Payment { get; set; }

        /// <summary>
        /// Indicates if the sales finance deal details are currently being loaded
        /// </summary>
        public bool SalesFinanceInfoPageLoading { get; set; } 

        #endregion


        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SalesDeskingInfoViewModel()
        {
            // Create commands

            // Task.Run(GetSalesRecallDealsAsync);

        }

        #endregion

        public async Task CreateNewSalesFinanceDealAsync()
        {
            await Task.Delay(1);
        }


    }

}
