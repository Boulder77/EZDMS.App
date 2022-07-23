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
    /// The view model for a sales deal card control
    /// </summary>
    public class SalesDealCardViewModel : BaseViewModel
    {
        
        #region Private Members

        /// <summary>
        /// The text to show as default
        /// </summary>
        private string mDefaultText = "-";

        #endregion

        #region Public Properties

        /// <summary>
        /// The current working sales deal number
        /// </summary>
        public int DealNumber { get; set; }

        /// <summary>
        /// The current buyer name
        /// </summary>
        public TextInputViewModel BuyerName { get; set; }

        /// <summary>
        /// The current Co-Buyer name
        /// </summary>
        public TextInputViewModel CoBuyerName { get; set; }

        /// <summary>
        /// The current vehicle info
        /// </summary>
        public TextInputViewModel Vehicle { get; set; }

        /// <summary>
        /// The current status of the sales deal
        /// </summary>
        public TextInputViewModel Status { get; set; }

        /// <summary>
        /// The current type of the sales deal
        /// </summary>
        public TextInputViewModel DealType { get; set; }

        /// <summary>
        /// The salesperson name on the deal
        /// </summary>
        public TextInputViewModel Salesperson { get; set; }
                
        /// <summary>
        /// The sales manager name on the deal
        /// </summary>
        public TextInputViewModel SalesManager { get; set; }

        /// <summary>
        /// The finance manager name on the deal
        /// </summary>
        public TextInputViewModel FinanceManager { get; set; }

        /// <summary>
        /// The current trade vehicle(s) info
        /// </summary>
        public TextInputViewModel Trades { get; set; }

        /// <summary>
        /// The current created Date
        /// </summary>
        public TextInputViewModel CreatedDate { get; set; }

        /// <summary>
        /// The last activity date on the deal
        /// </summary>
        public TextInputViewModel LastActivityDate { get; set; }

        /// <summary>
        /// The date of the deal
        /// </summary>
        public TextInputViewModel DealDate { get; set; }

        /// <summary>
        /// Indicates if the sales finance deal details are currently being loaded
        /// </summary>
        public bool SalesFinanceInfoPageLoading { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SalesDealCardViewModel()
        {
            BuyerName = new TextInputViewModel
            {
                Label = "Buyer Name",
                Text = mDefaultText,
                Editable = false
            };

            CoBuyerName = new TextInputViewModel
            {
                Label = "CoBuyer Name",
                Text = mDefaultText,
                Editable = false
            };

            Vehicle = new TextInputViewModel
            {
                Label = "Vehicle",
                Text = mDefaultText,
                Editable = false
            };

            Status = new TextInputViewModel
            {
                Label = "Status",
                Text = mDefaultText,
                Editable = false
            };

            DealType = new TextInputViewModel
            {
                Label = "Deal Type",
                Text = mDefaultText,
                Editable = false
            };

            Salesperson = new TextInputViewModel
            {
                Label = "Sales Person",
                Text = mDefaultText,
                Editable = false
            };

            SalesManager = new TextInputViewModel
            {
                Label = "Sales Manager",
                Text = mDefaultText,
                Editable = false
            };

            FinanceManager = new TextInputViewModel
            {
                Label = "Finance Manager",
                Text = mDefaultText,
                Editable = false
            };

            Trades = new TextInputViewModel
            {
                Label = "Trades",
                Text = mDefaultText,
                Editable = false
            };

            CreatedDate = new TextInputViewModel
            {
                Label = "Created Date",
                Text = mDefaultText,
                Editable = false
            };

            LastActivityDate = new TextInputViewModel
            {
                Label = "Last Activity Date",
                Text = mDefaultText,
                Editable = false
            };

            DealDate = new TextInputViewModel
            {
                Label = "Deal Date",
                Text = mDefaultText,
                Editable = false
            };

        }

        #endregion

    }

}
