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
    /// The view model for a sales finance page
    /// </summary>
    public class SalesFinanceViewModel : BaseViewModel
    {

        #region Public Properties
        
        /// <summary>
        /// The data model for the sales finance deal
        /// </summary>
        public SalesFinanceDataModel SalesFinanceDeal { get; set; }

        /// <summary>
        /// The data model for the sales deal item
        /// </summary>
        public SalesDealsItemDataModel SalesDealsItem { get; set; } 

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



            UpdateValuesOfDeskingTotals(SalesFinanceDeal);



        }

        #endregion   

        #region Private Helper Methods

                        
        private void UpdateValuesOfDeskingTotals(SalesFinanceDataModel salesFinance)
        {
            if (salesFinance == null)
                return;

            // The amount to bind for the subtotal NumericalEntryViewModel
            var SubTotalAmount = salesFinance.SellingPrice
                                + salesFinance.TotalFrontAdds
                                + salesFinance.TotalTaxes
                                + salesFinance.TotalOfficialFees
                                + salesFinance.TotalBackAdds
                                + salesFinance.ServiceContract
                                + salesFinance.Maintenance
                                + salesFinance.Warranty
                                + salesFinance.Gap
                                + salesFinance.LAHInsurance;

            // The amount to bind for the total NumericalEntryViewModel
            var TotalAmount = SubTotalAmount
                    - salesFinance.TotalRebates
                    - salesFinance.TotalNetAllowance
                    - salesFinance.TotalCashDown;
                        
            DeskingTotals = new SalesDeskingTotalsViewModel
            {

                SellingPrice = new NumericalEntryViewModel 
                { 
                    Label = "Selling Price",
                    OriginalAmount = salesFinance.SellingPrice
                },
                                   
                FrontOptions = new NumericalEntryViewModel 
                { 
                    Label = "Front Options", 
                    OriginalAmount = salesFinance.TotalFrontAdds, 
                    Editable = true 
                },
                    
                Taxes = new NumericalEntryViewModel 
                { 
                    Label = "Taxes", 
                    OriginalAmount = salesFinance.TotalTaxes,
                    Editable = true 
                },
                    
                Fees = new NumericalEntryViewModel 
                { 
                    Label = "Fees",
                    OriginalAmount = (salesFinance.TotalOfficialFees + salesFinance.TotalDealerFees),
                    Editable = true
                },
                  
                BackOptions = new NumericalEntryViewModel 
                { 
                    Label = "Back Options",
                    OriginalAmount = salesFinance.TotalBackAdds,
                    Editable = true 
                },
                    
                Service = new NumericalEntryViewModel 
                { 
                    Label = "Service", 
                    OriginalAmount = (salesFinance.ServiceContract + salesFinance.Maintenance + salesFinance.Warranty),
                    Editable = true 
                },
                  
                Gap = new NumericalEntryViewModel 
                { 
                    Label = "Gap", 
                    OriginalAmount = salesFinance.Gap,
                    Editable = true 
                },
                  
                CreditInsurance = new NumericalEntryViewModel 
                { 
                    Label = "Credit Insurance", 
                    OriginalAmount = salesFinance.LAHInsurance, 
                    Editable = true 
                },
                  
                SubTotal = new NumericalEntryViewModel 
                {
                    Label = "SUBTOTAL",
                    OriginalAmount = SubTotalAmount
                },
                  
                Cash = new NumericalEntryViewModel 
                { 
                    Label = "Cash", 
                    OriginalAmount = salesFinance.TotalCashDown, 
                    Editable = true 
                },
                  
                Rebates = new NumericalEntryViewModel 
                { 
                    Label = "Rebates",
                    OriginalAmount = salesFinance.TotalRebates,
                    Editable = true 
                },
                  
                TradeAllowance = new NumericalEntryViewModel 
                { 
                    Label = "Trade Allowance",
                    OriginalAmount = salesFinance.TotalAllowance,
                    Editable = true 
                },
                  
                TradePayoff = new NumericalEntryViewModel 
                { 
                    Label = "Trade Payoff",
                    OriginalAmount = salesFinance.TotalPayoff,
                    Editable = true 
                },
                  
                Total = new NumericalEntryViewModel 
                { 
                    Label = "TOTAL",
                    OriginalAmount = TotalAmount 
                },
                  
                CashFromCustomer = new NumericalEntryViewModel 
                { 
                    Label = "Cash From Customer",
                    OriginalAmount = salesFinance.TotalCashDown
                },
                  
                Payment = new NumericalEntryViewModel 
                { 
                    Label = "Payment",
                    OriginalAmount = salesFinance.Payment 
                },

            };

        }

        private void UpdateValuesOfSalesSummary(SalesFinanceDataModel salesFinance)
        {
            // return if null
            if (salesFinance == null)
                return;

            // The amount for the trade difference TextDisplayViewModel
            var tradeDifference = salesFinance.SellingPrice - salesFinance.TotalAllowance;


            SalesSummary = new SalesSummaryViewModel
            {
                // Create the APR
                APR = new TextEntryViewModel
                {
                    Label = "APR",
                    OriginalText = salesFinance.APR.ToString("#.00")
                },

                // Create the APR
                EffectiveAPR = new TextEntryViewModel
                
                {
                    Label = "Effective APR",
                     OriginalText = salesFinance.EffectiveAPR.ToString("#.00")

                },

                // Create the trade difference
                TradeDifference = new TextDisplayViewModel
                {
                    Label = "Trade Difference",
                    DisplayText = tradeDifference.ToString("#.00")

                },

                // Create the term
                Term = new TextEntryViewModel
                {
                    Label = "Term",
                    OriginalText = salesFinance.Term.ToString("###")

                },

                // Create the purchase date
                PurchaseDate = new DateSelectionViewModel
                {
                    Label = "Purchase Date",
                    Date = salesFinance.DealDate
                },

                // Create the days to first payment
                DaysToFirstPayment = new TextEntryViewModel
                {
                    Label = "Days To First Payment",
                    OriginalText = salesFinance.DaysTo1stPayment.ToString("###")
                },

                // Create the payment date
                PaymentDate = new DateSelectionViewModel
                {
                    Label = "Payment Date",
                    Date = salesFinance.FirstPaymentDate
                },

            };

        }

        private void UpdateValuesOfTruthinLending(SalesFinanceDataModel salesFinance)
        {
            // return if null            
            if (salesFinance == null)
                return;

            TruthinLending = new TruthinLendingDisclosureViewModel
            {
                NumberOfPayments=salesFinance.NumberOfPayments,

                Payment = new NumericalEntryViewModel
                {
                    Label = $"{salesFinance.NumberOfPayments} Payments of {salesFinance.Payment}",
                    OriginalAmount = salesFinance.Payment
                },

                FinalPayment = new NumericalEntryViewModel
                {
                    Label = "Final Payment",
                    OriginalAmount = salesFinance.LastPayment
                },

                FinanceCharge = new NumericalEntryViewModel
                {
                    Label = "Finance Charge",
                    OriginalAmount = salesFinance.FinanceCharge
                },

                TotalOfPayments = new NumericalEntryViewModel
                {
                    Label = "Total Of Payments",
                    OriginalAmount = salesFinance.TotalOfPayments
                },

                TotalDown = new NumericalEntryViewModel
                {
                    Label = "Total Down",
                    OriginalAmount = salesFinance.TotalDown
                },

                TotalSalePrice = new NumericalEntryViewModel
                {
                    Label = "Total Sale Price",
                    OriginalAmount = salesFinance.TotalSalePrice
                },

            };

        }

        private void UpdateValuesOfSalesDealCard(SalesDealsItemDataModel salesDeal)
        {
            // return if null
            if (salesDeal == null)
                return;

            SalesDealCard = new SalesDealCardViewModel
            {
                BuyerName = new TextDisplayViewModel
                {
                    Label = "Buyer Name",
                    DisplayText = salesDeal.BuyerName
                },

                CoBuyerName = new TextDisplayViewModel
                {
                    Label = "CoBuyer Name",
                    DisplayText = salesDeal.CoBuyerName
                },

                Vehicle = new TextDisplayViewModel
                {
                    Label = "Vehicle",
                    DisplayText = salesDeal.VehicleInfo
                },

                Status = new TextDisplayViewModel
                {
                    Label = "Status",
                    DisplayText = salesDeal.Status
                },

                DealType = new TextDisplayViewModel
                {
                    Label = "Deal Type",
                    DisplayText = salesDeal.Type
                },

                Salesperson = new TextDisplayViewModel
                {
                    Label = "Sales Person",
                    DisplayText = $"{salesDeal.SalesPerson} +\r\n+ {salesDeal.SalesPerson2}"
                },

                SalesManager = new TextDisplayViewModel
                {
                    Label = "Sales Manager",
                    DisplayText = salesDeal.SalesManager
                },

                FinanceManager = new TextDisplayViewModel
                {
                    Label = "Finance Manager",
                    DisplayText = salesDeal.FinanceManager
                },

                Trades = new TextDisplayViewModel
                {
                    Label = "Trades",
                    DisplayText = $"{salesDeal.Trade1Info} +\r\n+ {salesDeal.Trade2Info}+\r\n+ {salesDeal.Trade3Info}"
                },

                CreatedDate = new TextDisplayViewModel
                {
                    Label = "Created Date",
                    DisplayText = salesDeal.CreatedDate.ToString("MM/dd/yyyy")
                },

                LastActivityDate = new TextDisplayViewModel
                {
                    Label = "Last Activity Date",
                    DisplayText = salesDeal.LastActivityDate.ToString("MM/dd/yyyy")
                },

                DealDate = new TextDisplayViewModel
                {
                    Label = "Deal Date",
                    DisplayText = salesDeal.DealDate.ToString("MM/dd/yyyy")
                },

            };


        }


        #endregion





    }

}
