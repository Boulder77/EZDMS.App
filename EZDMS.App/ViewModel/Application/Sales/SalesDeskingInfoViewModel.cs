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

        // The subtotal amount of the deal
        private decimal mSubtotal;

        // The total amount of the deal
        private decimal mTotal;

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
        public NumericalEntryViewModel SellingPrice { get; set; }

        /// <summary>
        /// The current front options total amount
        /// </summary>
        public NumericalEntryViewModel FrontOptions { get; set; }

        /// <summary>
        /// The current taxes amount
        /// </summary>
        public NumericalEntryViewModel Taxes { get; set; }

        /// <summary>
        /// The current fees total amount
        /// </summary>
        public NumericalEntryViewModel Fees { get; set; }

        /// <summary>
        /// The current back options total amount
        /// </summary>
        public NumericalEntryViewModel BackOptions { get; set; }

        /// <summary>
        /// The current service/warranty/maintenance total amount
        /// </summary>
        public NumericalEntryViewModel Service { get; set; }

        /// <summary>
        /// The current gap amount
        /// </summary>
        public NumericalEntryViewModel Gap { get; set; }

        /// <summary>
        /// The current credit insurance total amount
        /// </summary>
        public NumericalEntryViewModel CreditInsurance { get; set; }

        /// <summary>
        /// The current subtotal amount
        /// </summary>
        public NumericalEntryViewModel SubTotal { get; set; }

        /// <summary>
        /// The current cash total amount
        /// </summary>
        public NumericalEntryViewModel Cash { get; set; }

        /// <summary>
        /// The current rebates total amount
        /// </summary>
        public NumericalEntryViewModel Rebates { get; set; }

        /// <summary>
        /// The current trade allowance amount
        /// </summary>
        public NumericalEntryViewModel TradeAllowance { get; set; }

        /// <summary>
        /// The current trade payoff amount
        /// </summary>
        public NumericalEntryViewModel TradePayoff { get; set; }

        /// <summary>
        /// The cash due from customer amount
        /// </summary>
        public NumericalEntryViewModel CashFromCustomer { get; set; }

        /// <summary>
        /// The total sale amount
        /// </summary>
        public NumericalEntryViewModel Total { get; set; }

        /// <summary>
        /// The payment amount
        /// </summary>
        public NumericalEntryViewModel Payment { get; set; }

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

        public async Task UpdateValuesFromCurrentDealAsync(int dealNumber)
        {
            // Get the current sales finance deal info from client data store
            await RunCommandAsync(() => SalesFinanceInfoPageLoading, async () =>
            {
                WorkingDeal = await ClientDataStore.GetSalesFinanceDealAsync(dealNumber);
            });

            // Subtotal amount
            mSubtotal = WorkingDeal.SellingPrice
                        + WorkingDeal.TotalFrontAdds
                        + WorkingDeal.TotalTaxes
                        + WorkingDeal.TotalOfficialFees
                        + WorkingDeal.TotalBackAdds
                        + WorkingDeal.ServiceContract
                        + WorkingDeal.Maintenance
                        + WorkingDeal.Warranty
                        + WorkingDeal.Gap
                        + WorkingDeal.LAHInsurance;

            //Total amount
            mTotal = mSubtotal
                    - WorkingDeal.TotalRebates
                    - WorkingDeal.TotalNetAllowance
                    - WorkingDeal.TotalCashDown;
                                    


            WorkingDealNumber = WorkingDeal.DealNumber;
            SellingPrice = new NumericalEntryViewModel { Label = "Selling Price", OriginalAmount = WorkingDeal.SellingPrice };
            FrontOptions = new NumericalEntryViewModel { Label = "Front Options", OriginalAmount = WorkingDeal.TotalFrontAdds, Editable = true };
            Taxes = new NumericalEntryViewModel { Label = "Taxes", OriginalAmount = WorkingDeal.TotalTaxes, Editable = true };
            Fees = new NumericalEntryViewModel { Label = "Fees", OriginalAmount = (WorkingDeal.TotalOfficialFees+WorkingDeal.TotalDealerFees), Editable = true };
            BackOptions = new NumericalEntryViewModel { Label = "Back Options", OriginalAmount = WorkingDeal.TotalBackAdds, Editable = true };
            Service = new NumericalEntryViewModel { Label = "Service", OriginalAmount = (WorkingDeal.ServiceContract+ WorkingDeal.Maintenance+ WorkingDeal.Warranty), Editable = true };
            Gap = new NumericalEntryViewModel { Label = "Gap", OriginalAmount = WorkingDeal.Gap, Editable = true };
            CreditInsurance = new NumericalEntryViewModel { Label = "Credit Insurance", OriginalAmount = WorkingDeal.LAHInsurance, Editable = true };
            SubTotal = new NumericalEntryViewModel { Label = "SUBTOTAL", OriginalAmount = mSubtotal };
            Cash = new NumericalEntryViewModel { Label = "Cash", OriginalAmount = WorkingDeal.TotalCashDown, Editable = true };
            Rebates = new NumericalEntryViewModel { Label = "Rebates", OriginalAmount = WorkingDeal.TotalRebates, Editable = true };
            TradeAllowance = new NumericalEntryViewModel { Label = "Trade Allowance", OriginalAmount = WorkingDeal.TotalAllowance, Editable = true };
            TradePayoff = new NumericalEntryViewModel { Label = "Trade Payoff", OriginalAmount = WorkingDeal.TotalPayoff, Editable = true };
            Total = new NumericalEntryViewModel { Label = "TOTAL", OriginalAmount = mTotal };
            CashFromCustomer = new NumericalEntryViewModel { Label = "Cash From Customer", OriginalAmount = WorkingDeal.TotalCashDown };
            Payment = new NumericalEntryViewModel { Label = "Payment", OriginalAmount = WorkingDeal.Payment };



        }



    }

}
