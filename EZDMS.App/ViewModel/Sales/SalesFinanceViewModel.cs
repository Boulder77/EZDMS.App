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
    /// The view model for a sales finance page
    /// </summary>
    public class SalesFinanceViewModel : BaseViewModel
    {
        #region Private Members

        /// <summary>
        /// The current sales deal number
        /// </summary>
        private int mDealNumber;

        #endregion

        #region Public Properties
        /// <summary>
        /// The current sales deal number
        /// </summary>
        public int DealNumber
        {
            get => mDealNumber;
            set
            {
                if (mDealNumber == value)
                    return;

                mDealNumber = value;
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

        /// <summary>
        /// The view model for the sales deal card control
        /// </summary>
        public SalesDealCardViewModel SalesDealCard {get; set; }

        /// <summary>
        /// Indicates if the sales finance deal details are currently being loaded
        /// </summary>
        public bool SalesFinanceInfoPageLoading { get; set; }

        #endregion

        #region Public Commands

        /// <summary>
        /// Loads the sales finance data from the client data store
        /// </summary>
        public ICommand LoadDealCommand { get; set; }   

        /// <summary>
        /// Saves the current sales finance to the server
        /// </summary>
        public ICommand SaveDealCommand { get; set; }

        /// <summary>
        /// The command to clear the users data from the view model
        /// </summary>
        public ICommand ClearUserDataCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SalesFinanceViewModel()
        {
            // Create commands

            

        



        }

        #endregion


        //public async Task UpdateValuesFromCurrentDealAsync(int dealNumber)
        //{
        //    // Get the current sales finance deal info from client data store
        //    await RunCommandAsync(() => SalesFinanceInfoPageLoading, async () =>
        //    {
        //        WorkingDeal = await ClientDataStore.GetSalesFinanceDealAsync(dealNumber);
        //    });

        //    // Subtotal amount
        //    mSubtotal = WorkingDeal.SellingPrice
        //                + WorkingDeal.TotalFrontAdds
        //                + WorkingDeal.TotalTaxes
        //                + WorkingDeal.TotalOfficialFees
        //                + WorkingDeal.TotalBackAdds
        //                + WorkingDeal.ServiceContract
        //                + WorkingDeal.Maintenance
        //                + WorkingDeal.Warranty
        //                + WorkingDeal.Gap
        //                + WorkingDeal.LAHInsurance;

        //    //Total amount
        //    mTotal = mSubtotal
        //            - WorkingDeal.TotalRebates
        //            - WorkingDeal.TotalNetAllowance
        //            - WorkingDeal.TotalCashDown;

        //    DealNumber = WorkingDeal.DealNumber;
        //    SellingPrice = new NumericalEntryViewModel { Label = "Selling Price", OriginalAmount = WorkingDeal.SellingPrice };
        //    FrontOptions = new NumericalEntryViewModel { Label = "Front Options", OriginalAmount = WorkingDeal.TotalFrontAdds, Editable = true };
        //    Taxes = new NumericalEntryViewModel { Label = "Taxes", OriginalAmount = WorkingDeal.TotalTaxes, Editable = true };
        //    Fees = new NumericalEntryViewModel { Label = "Fees", OriginalAmount = (WorkingDeal.TotalOfficialFees + WorkingDeal.TotalDealerFees), Editable = true };
        //    BackOptions = new NumericalEntryViewModel { Label = "Back Options", OriginalAmount = WorkingDeal.TotalBackAdds, Editable = true };
        //    Service = new NumericalEntryViewModel { Label = "Service", OriginalAmount = (WorkingDeal.ServiceContract + WorkingDeal.Maintenance + WorkingDeal.Warranty), Editable = true };
        //    Gap = new NumericalEntryViewModel { Label = "Gap", OriginalAmount = WorkingDeal.Gap, Editable = true };
        //    CreditInsurance = new NumericalEntryViewModel { Label = "Credit Insurance", OriginalAmount = WorkingDeal.LAHInsurance, Editable = true };
        //    SubTotal = new NumericalEntryViewModel { Label = "SUBTOTAL", OriginalAmount = mSubtotal };
        //    Cash = new NumericalEntryViewModel { Label = "Cash", OriginalAmount = WorkingDeal.TotalCashDown, Editable = true };
        //    Rebates = new NumericalEntryViewModel { Label = "Rebates", OriginalAmount = WorkingDeal.TotalRebates, Editable = true };
        //    TradeAllowance = new NumericalEntryViewModel { Label = "Trade Allowance", OriginalAmount = WorkingDeal.TotalAllowance, Editable = true };
        //    TradePayoff = new NumericalEntryViewModel { Label = "Trade Payoff", OriginalAmount = WorkingDeal.TotalPayoff, Editable = true };
        //    Total = new NumericalEntryViewModel { Label = "TOTAL", OriginalAmount = mTotal };
        //    CashFromCustomer = new NumericalEntryViewModel { Label = "Cash From Customer", OriginalAmount = WorkingDeal.TotalCashDown };
        //    Payment = new NumericalEntryViewModel { Label = "Payment", OriginalAmount = WorkingDeal.Payment };

        //}

        #region Private Helper Methods

        /// <summary>
        /// Loads the sales finance deal from the local data store and binds it
        /// to this view model
        /// </summary>
        /// <returns></returns>
        //private async Task UpdateValuesFromLocalStoreAsync(IClientDataStore clientDataStore,int dealNumber)
        //{
        //    // Get the stored credentials
        //    var storedFinanceDeal = await clientDataStore.GetSalesFinanceDealAsync(dealNumber);


        //}





        #endregion





    }

}
