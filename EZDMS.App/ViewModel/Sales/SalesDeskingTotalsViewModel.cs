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
        /// The current selling price
        /// </summary>
        public DecimalInputViewModel SellingPrice { get; set; }

        /// <summary>
        /// The current front options total amount
        /// </summary>
        public DecimalInputViewModel FrontOptions { get; set; }

        /// <summary>
        /// The current taxes amount
        /// </summary>
        public DecimalInputViewModel Taxes { get; set; }

        /// <summary>
        /// The current fees total amount
        /// </summary>
        public DecimalInputViewModel Fees { get; set; }

        /// <summary>
        /// The current back options total amount
        /// </summary>
        public DecimalInputViewModel BackOptions { get; set; }

        /// <summary>
        /// The current service/warranty/maintenance total amount
        /// </summary>
        public DecimalInputViewModel Service { get; set; }

        /// <summary>
        /// The current gap amount
        /// </summary>
        public DecimalInputViewModel Gap { get; set; }

        /// <summary>
        /// The current credit insurance total amount
        /// </summary>
        public DecimalInputViewModel CreditInsurance { get; set; }

        /// <summary>
        /// The current subtotal amount
        /// </summary>
        public DecimalInputViewModel SubTotal { get; set; }

        /// <summary>
        /// The current cash total amount
        /// </summary>
        public DecimalInputViewModel Cash { get; set; }

        /// <summary>
        /// The current rebates total amount
        /// </summary>
        public DecimalInputViewModel Rebates { get; set; }

        /// <summary>
        /// The current trade allowance amount
        /// </summary>
        public DecimalInputViewModel TradeAllowance { get; set; }

        /// <summary>
        /// The current trade payoff amount
        /// </summary>
        public DecimalInputViewModel TradePayoff { get; set; }

        /// <summary>
        /// The cash due from customer amount
        /// </summary>
        public DecimalInputViewModel CashFromCustomer { get; set; }

        /// <summary>
        /// The total sale amount
        /// </summary>
        public DecimalInputViewModel Total { get; set; }

        /// <summary>
        /// The payment amount
        /// </summary>
        public DecimalInputViewModel Payment { get; set; }

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
