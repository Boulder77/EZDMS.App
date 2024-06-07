using System;

namespace EZDMS.App.Core
{
    /// <summary>
    /// The data model for the sales deal to recall
    /// </summary>
    public class SalesFinanceDataModel
    {

        #region Private members

        /// <summary>
        /// The calculation method for the sales record
        /// </summary>
        private string mCalculationMethod = "Simple Interest";

        #endregion

        #region Public Properties


        /// <summary>
        /// The deal number for the sales record
        /// </summary>
        public int DealNumber { get; set; }

        /// <summary>
        /// The MSRP for this sales record
        /// </summary>
        public decimal MSRP { get; set; }

        /// <summary>
        /// The base price for this sales record
        /// </summary>
        public decimal BasePrice { get; set; }

        /// <summary>
        /// The selling price for this sales record
        /// </summary>
        public decimal SellingPrice { get; set; }

        /// <summary>
        /// The amount financed for this sales record
        /// </summary>
        public decimal AmountFinanced { get; set; }

        /// <summary>
        /// The APR for this sales record
        /// </summary>
        public decimal APR { get; set; }

        /// <summary>
        /// The effective APR for this sales record
        /// </summary>
        public decimal EffectiveAPR { get; set; }

        /// <summary>
        /// The term in months for this sales record
        /// </summary>
        public int Term { get; set; }

        /// <summary>
        /// The finance charge for this sales record
        /// </summary>
        public decimal FinanceCharge { get; set; }

        /// <summary>
        /// The Total of Payments for this sales record
        /// </summary>
        public decimal TotalOfPayments { get; set; }


        /// <summary>
        /// The total sale price for this sales record
        /// </summary>
        public decimal TotalSalePrice { get; set; }

        /// <summary>
        /// The payment amount for this sales record
        /// </summary>
        public decimal Payment { get; set; }

        /// <summary>
        /// The last payment amount for this sales record
        /// </summary>
        public decimal LastPayment { get; set; }

        /// <summary>
        /// The total back adds amount for this sales record
        /// </summary>
        public decimal TotalBackAdds { get; set; }

        /// <summary>
        /// The total front adds amount for this sales record
        /// </summary>
        public decimal TotalFrontAdds { get; set; }

        /// <summary>
        /// The maintenance amount for this sales record
        /// </summary>
        public decimal Maintenance { get; set; }

        /// <summary>
        /// The total taxes for this sales record
        /// </summary>
        public decimal TotalTaxes { get; set; }

        /// <summary>
        /// The status of this sales record
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// The deal date for this sales record
        /// </summary>
        public DateTime DealDate { get; set; }

        /// <summary>
        /// The first payment date for this sales record
        /// </summary>
        public DateTime FirstPaymentDate { get; set; }

        /// <summary>
        /// The last payment date for this sales record
        /// </summary>
        public DateTime LastPaymentDate { get; set; }

        /// <summary>
        /// The days to first payment for this sales record
        /// </summary>
        public int DaysTo1stPayment { get; set; }

        /// <summary>
        /// The gap amount for this sales record
        /// </summary>
        public decimal Gap { get; set; }

        /// <summary>
        /// The VSI amount for this sales record
        /// </summary>
        public decimal VSI { get; set; }

        /// <summary>
        /// The BankFee for this sales record
        /// </summary>
        public decimal BankFee { get; set; }

        /// <summary>
        /// The total down amount for this sales record
        /// </summary>
        public decimal TotalDown { get; set; }

        /// <summary>
        /// The negative equity for this sales record
        /// </summary>
        public decimal NegativeEquity { get; set; }

        /// <summary>
        /// The number of payments for this sales record
        /// </summary>
        public int NumberOfPayments { get; set; }

        /// <summary>
        /// The payment type for this sales record
        /// </summary>
        public string PaymentType { get; set; }

        /// <summary>
        /// The type of sales record
        /// </summary>
        public string SaleType { get; set; }

        /// <summary>
        /// The total of official fees this sales record
        /// </summary>
        public decimal TotalOfficialFees { get; set; }

        /// <summary>
        /// The total of dealer fees this sales record
        /// </summary>
        public decimal TotalDealerFees { get; set; }

        /// <summary>
        /// The service contract amount this sales record
        /// </summary>
        public decimal ServiceContract { get; set; }

        /// <summary>
        /// The warranty amount this sales record
        /// </summary>
        public decimal Warranty { get; set; }

        /// <summary>
        /// The life accident & health insurance this sales record
        /// </summary>
        public decimal LAHInsurance { get; set; }

        /// <summary>
        /// The total of rebates this sales record
        /// </summary>
        public decimal TotalRebates { get; set; }

        /// <summary>
        /// The total cash down this sales record
        /// </summary>
        public decimal TotalCashDown { get; set; }

        /// <summary>
        /// The total trade allowance this sales record
        /// </summary>
        public decimal TotalAllowance { get; set; }

        /// <summary>
        /// The total trade payoff amount this sales record
        /// </summary>
        public decimal TotalPayoff { get; set; }

        /// <summary>
        /// The total trade net allowance this sales record
        /// </summary>
        public decimal TotalNetAllowance { get; set; }

        /// <summary>
        /// The ROS number for this sales record
        /// </summary>
        public string ROSNumber { get; set; }

        /// <summary>
        /// The finalized boolean for this sales record
        /// </summary>
        public bool IsFinalized { get; set; }

        /// <summary>
        /// The finalized date for this sales record
        /// </summary>
        public DateTime FinalizedDate { get; set; }

        /// <summary>
        /// The entry date for this sales record
        /// </summary>
        public DateTime EntryDate { get; set; }

        /// <summary>
        /// The bank id associated with this sales record
        /// </summary>
        public string BankID { get; set; }

        /// <summary>
        /// The bank name associated with this sales record
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// The calculation method associated with this sales record
        /// </summary>
        public string CalculationMethod
        {
            get => mCalculationMethod;
            set
            {
                if (mCalculationMethod == value)
                    return;

                mCalculationMethod = value;

            }
        }

        #endregion

    }
}
