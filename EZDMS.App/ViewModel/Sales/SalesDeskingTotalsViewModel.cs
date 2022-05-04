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
    public class SalesDeskingTotalsViewModel : BaseViewModel
    {

        #region Public Properties        

        /// <summary>
        /// The subtotal amount for NumericalEntryViewModel Subtotal
        /// </summary>
        public decimal SubtotalAmount { get; set; }

        /// <summary>
        /// The total amount for NumericalEntryViewModel Total
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// The current working sales deal number
        /// </summary>
        public int DealNumber { get; set; }

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

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SalesDeskingTotalsViewModel()
        {


        }

        #endregion              

    }

}
