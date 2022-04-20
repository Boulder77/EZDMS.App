using Dna;
using EZDMS.App.Core;
using System;
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
        /// The sale type of the sale deal
        /// </summary>
        public SaleType SelectedSaleType { get; set; }

        public IEnumerable<SaleType> SaleTypes => (IEnumerable<SaleType>)Enum.GetValues(typeof(SaleType));


        /// <summary>
        /// The US State/Territory of the deal
        /// </summary>
        public States SelectedState { get; set; }


        public IEnumerable<States> AllStates => (IEnumerable<States>)Enum.GetValues(typeof(States));

        /// <summary>
        /// The current lender of the sale
        /// </summary>
        public string Lender { get; set; }

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
        public PaymentType SelectedPaymentType { get; set; }

        public IEnumerable<PaymentType> PaymentTypes => (IEnumerable<PaymentType>)Enum.GetValues(typeof(PaymentType));

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
            // Create the APR
            APR = new TextEntryViewModel
            {
                Label="APR",
                OriginalText="0.00"

            };

            // Create the APR
            EffectiveAPR = new TextEntryViewModel
            {
                Label = "Effective APR",
                OriginalText = "0.00"

            };

            // Create the trade difference
            TradeDifference = new TextDisplayViewModel
            {
                Label = "Trade Difference",
                DisplayText = "0.00"

            };

            // Create the term
            Term = new TextEntryViewModel
            {
                Label = "Term",
                OriginalText="48"

            };

            // Create the purchase date
            PurchaseDate = new DateSelectionViewModel
            {
                Label = "Purchase Date",
                Date = DateTime.Today
            };

            // Create the days to first payment
            DaysToFirstPayment = new TextEntryViewModel
            {
                Label = "Days To First Payment",
                OriginalText = "30"
            };

            // Create the payment date
            PaymentDate = new DateSelectionViewModel
            {
                Label = "Payment Date",
                Date = DateTime.Today.AddMonths(30)
            };












        }

        #endregion




    }

}
