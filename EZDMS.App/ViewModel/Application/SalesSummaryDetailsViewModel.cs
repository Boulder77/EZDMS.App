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
    public class SalesSummaryDetailsViewModel : BaseViewModel
    {
        
        #region Public Properties
       

        /// <summary>
        /// The current deal type
        /// </summary>
        public ComboBoxSelectionViewModel DealType { get; set; }

        /// <summary>
        /// The current state of the sale
        /// </summary>
        public ComboBoxSelectionViewModel State { get; set; }

        /// <summary>
        /// The current lender of the sale
        /// </summary>
        public ComboBoxSelectionViewModel Lender { get; set; }

        /// <summary>
        /// The APR of the sale
        /// </summary>
        public TextEntryViewModel APR { get; set; }

        /// <summary>
        /// The effective APR of the sale
        /// </summary>
        public TextEntryViewModel EffectiveAPR { get; set; }

        /// <summary>
        /// The trade difference of the sale
        /// </summary>
        public TextDisplayViewModel TradeDifference { get; set; }

        /// <summary>
        /// The term of the sale
        /// </summary>
        public TextEntryViewModel Term { get; set; }

        /// <summary>
        /// The payment schedule type of the sale
        /// </summary>
        public ComboBoxSelectionViewModel PaymentType { get; set; }

        /// <summary>
        /// The purchase date of the sale
        /// </summary>
        public DateSelectionViewModel PurchaseDate { get; set; }

        /// <summary>
        /// The number of days to the first payment of the sale
        /// </summary>
        public TextEntryViewModel DaysToFirstPayment { get; set; }

        /// <summary>
        /// The payment date of the sale
        /// </summary>
        public DateSelectionViewModel PaymentDate { get; set; }

        
        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SalesSummaryDetailsViewModel()
        {
            // Create Deal Type
            DealType = new ComboBoxSelectionViewModel
            {
                
                Label = "Deal Type",
                
            };
            DealType.Items.Add("Retail");
            DealType.Items.Add("Lease");



        }

        #endregion




    }

}
