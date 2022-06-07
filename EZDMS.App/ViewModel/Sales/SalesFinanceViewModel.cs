using Dna;
using EZDMS.App.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using static EZDMS.App.DI;
using static EZDMS.App.Core.CoreDI;
using System.Text;

namespace EZDMS.App
{
    /// <summary>
    /// The view model for a sales finance page
    /// </summary>
    public class SalesFinanceViewModel : BaseViewModel
    {
        #region Private Members

        protected SalesFinanceDataModel mSalesFinanceDeal;

        protected SalesDealsItemDataModel mSalesDealItem;

        protected CustomerDataModel mBuyer;

        protected CustomerDataModel mCoBuyer;

        protected VehicleInventoryDataModel mSaleVehicle;

        #endregion

        #region Public Properties

        /// <summary>
        /// The data model for the sales finance deal
        /// </summary>
        public SalesFinanceDataModel SalesFinanceDeal { 
            get => mSalesFinanceDeal;
            set
            {
                // If datamodel has not changed...
                if (mSalesFinanceDeal == value)
                    // Ignore
                    return;

                // Set the backing datamodel
                mSalesFinanceDeal = value;

                if (value != null)
                    // Reload sales deal view model
                    TaskManager.RunAndForget(LoadAsync);

            }
        
        }

        /// <summary>
        /// The data model for the sales deal item
        /// </summary>
        public SalesDealsItemDataModel SalesDealsItem { 
            get => mSalesDealItem;
            set
            {
                // If datamodel has not changed...
                if (mSalesDealItem == value)
                    // Ignore
                    return;

                // Set the backing datamodel
                mSalesDealItem = value;

                if (value != null)
                    // Reload sales deal view model
                    UpdateValuesOfSalesDealCard(SalesDealsItem);
            }
        
        }

        /// <summary>
        /// The data model for the buyer
        /// </summary>
        public CustomerDataModel Buyer
        {
            get => mBuyer;
            set
            {
                // If datamodel has not changed...
                if (mBuyer == value)
                    // Ignore
                    return;

                // Set the backing datamodel
                mBuyer = value;

                if (value != null)
                    // Reload customer card view model
                    UpdateValuesOfCustomerCard(Buyer);
                    UpdateValuesOfCustomerBasicInfo(Buyer);
                    UpdateValuesOfCustomerAddress(Buyer);
            }

        }

        /// <summary>
        /// The data model for the cobuyer
        /// </summary>
        public CustomerDataModel CoBuyer
        {
            get => mCoBuyer;
            set
            {
                // If datamodel has not changed...
                if (mCoBuyer == value)
                    // Ignore
                    return;

                // Set the backing datamodel
                mCoBuyer = value;

                //if (value != null)
                //    // Reload sales deal view model
                //    UpdateValuesOfSalesDealCard(SalesDealsItem);
            }

        }

        /// <summary>
        /// The data model for the vehicle on the sale
        /// </summary>
        public VehicleInventoryDataModel SaleVehicle
        {
            get => mSaleVehicle;
            set
            {
                // If datamodel has not changed...
                if (mSaleVehicle == value)
                    // Ignore
                    return;

                // Set the backing datamodel
                mSaleVehicle = value;

                //if (value != null)
                //    // Reload sales deal view model
                //    UpdateValuesOfSalesDealCard(SalesDealsItem);
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
        /// The view model for the customer card control
        /// </summary>
        public CustomerCardViewModel CustomerCard { get; set; }

        /// <summary>
        /// The view model for the customer basic info control
        /// </summary>
        public CustomerBasicInfoViewModel CustomerBasicInfo { get; set; }

        /// <summary>
        /// The view model for the customer address control
        /// </summary>
        public CustomerAddressViewModel CustomerAddress { get; set; }

        /// <summary>
        /// The view model for the vehicle card control
        /// </summary>
        public VehicleCardViewModel VehicleCard { get; set; }

        /// <summary>
        /// The view model for the vehicle info control
        /// </summary>
        public VehicleBasicInfoViewModel VehicleBasicInfo { get; set; }

        /// <summary>
        /// The view model for the vehicle details control
        /// </summary>
        public VehicleDetailsViewModel VehicleDetails { get; set; }

        /// <summary>
        /// The view model for the vehicle pricing control
        /// </summary>
        public VehiclePricingViewModel VehiclePricing { get; set; }


        /// <summary>
        /// Indicates if the sales finance deal details are currently being loaded
        /// </summary>
        public bool SalesFinancePageLoading { get; set; }

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


        /// <summary>
        /// Saves the current buyer info to the server
        /// </summary>
        public ICommand SaveBuyerCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SalesFinanceViewModel()
        {
            // Create commands
            LoadDealCommand = new RelayCommand(async () => await LoadAsync());
           

        }

        #endregion

        #region Command Methods

        public async Task LoadAsync()
        {
            // Lock this command to ignore any other requests while processing
            await RunCommandAsync(() => SalesFinancePageLoading, () => {
                UpdateValuesOfDeskingTotals(SalesFinanceDeal);
                UpdateValuesOfSalesSummary(SalesFinanceDeal);
                UpdateValuesOfTruthinLending(SalesFinanceDeal);
                //UpdateValuesOfSalesDealCard(SalesDealsItem);
                return Task.CompletedTask;
            });

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
                    DisplayText = salesDeal?.BuyerName
                },

                CoBuyerName = new TextDisplayViewModel
                {
                    Label = "CoBuyer Name",
                    DisplayText = salesDeal?.CoBuyerName
                },

                Vehicle = new TextDisplayViewModel
                {
                    Label = "Vehicle",
                    DisplayText = salesDeal?.VehicleInfo
                },

                Status = new TextDisplayViewModel
                {
                    Label = "Status",
                    DisplayText = salesDeal?.Status
                },

                DealType = new TextDisplayViewModel
                {
                    Label = "Deal Type",
                    DisplayText = salesDeal?.Type
                },

                Salesperson = new TextDisplayViewModel
                {
                    Label = "Sales Person",
                    DisplayText = $"{salesDeal?.SalesPerson} \r\n {salesDeal?.SalesPerson2}"
                },

                SalesManager = new TextDisplayViewModel
                {
                    Label = "Sales Manager",
                    DisplayText = salesDeal?.SalesManager
                },

                FinanceManager = new TextDisplayViewModel
                {
                    Label = "Finance Manager",
                    DisplayText = salesDeal?.FinanceManager
                },

                Trades = new TextDisplayViewModel
                {
                    Label = "Trades",
                    DisplayText = $"{salesDeal?.Trade1Info} \r\n {salesDeal?.Trade2Info} \r\n {salesDeal?.Trade3Info}"
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

        private void UpdateValuesOfCustomerCard(CustomerDataModel Buyer)
        {
            var phoneCount=0;
            var phoneLabel = new StringBuilder();
            var mainPhone="";

            // count the number of phone numbers
            if(Buyer.HomePhone!=null)
            {
                phoneCount += 1;
            }

            if (Buyer.WorkPhone!=null)
            {
                phoneCount += 1;
            }
            if (Buyer.CellPhone!=null)
            {
                phoneCount += 1;
            }
            
            // Update label with phone count info
            phoneLabel.Append($"{phoneCount.ToString()} Phone");
            phoneLabel.Append((phoneCount > 1) ? "s":null);

            Enum.TryParse(Buyer?.MainPhoneType,out PhoneType phoneType);

            // Main phone type
            switch(phoneType)
            {
                case PhoneType.Home:
                    mainPhone = Buyer?.HomePhone;
                    break;

                case PhoneType.Work:
                    mainPhone = Buyer?.WorkPhone;
                    break;

                case PhoneType.Cell:
                    mainPhone = Buyer?.CellPhone;
                    break;

            }

            // Update customer card VM with values
            CustomerCard = new CustomerCardViewModel

            {

                CustomerNumber = new TextDisplayViewModel { Label = "Customer Number", DisplayText = Buyer?.Number },
                FullName = $"{Buyer?.FirstName} {Buyer?.MiddleName} {Buyer?.LastName}",
                CreateDate = new TextDisplayViewModel { Label = "Created", DisplayText = Buyer.CreateDate.ToString("MM/dd/yyyy") },
                LastModifiedDate = new TextDisplayViewModel { Label = "Last Modified", DisplayText = Buyer.LastModifiedDate.ToString("MM/dd/yyyy") },
                MainPhone = new TextDisplayViewModel { Label = phoneLabel.ToString(), DisplayText = $"{mainPhone} {Buyer?.MainPhoneType}" },
                MainEmail = new TextDisplayViewModel { Label = "1 Email", DisplayText = $"{Buyer?.Email} {Buyer?.EmailType}" },
                FullAddress = new TextDisplayViewModel { Label = "1 Address", DisplayText = $"{Buyer?.StreetAddress} \r\n {Buyer?.City} , {Buyer?.State} {Buyer?.Zip}"},

            };

        }

        private void UpdateValuesOfCustomerBasicInfo(CustomerDataModel Buyer)
        {

            // Update Customer basic info VM with values
            CustomerBasicInfo = new CustomerBasicInfoViewModel

            {
                FirstName = new TextEntryViewModel { Label = "First Name", OriginalText = Buyer?.FirstName },
                MiddleName = new TextEntryViewModel { Label = "Middle Name", OriginalText = Buyer?.MiddleName },
                LastName = new TextEntryViewModel { Label = "Last Name", OriginalText = Buyer?.LastName },
                Suffix = new TextEntryViewModel { Label = "Suffix", OriginalText = Buyer?.Suffix },
                Nickname = new TextEntryViewModel { Label = "Nickname", OriginalText = Buyer?.Nickname },
                DateOfBirth = new DateSelectionViewModel { Label = "Date of Birth", Date = Buyer.DateOfBirth },
                MaritalStatus=(MaritalStatusType)Enum.Parse(typeof(MaritalStatusType),Buyer?.MaritalStatus),
                SocialSecurityNumber = new TextEntryViewModel { Label = "SSN", OriginalText = Buyer?.SSN },
                Email = new TextEntryViewModel { Label = "Email", OriginalText = Buyer?.Email },
                EmailType = (EmailType)Enum.Parse(typeof(EmailType), Buyer?.EmailType),
                HomePhone = new TextEntryViewModel { Label = "Home Phone", OriginalText = Buyer?.HomePhone },
                WorkPhone = new TextEntryViewModel { Label = "Work Phone", OriginalText = Buyer?.WorkPhone },
                CellPhone = new TextEntryViewModel { Label = "Cell Phone", OriginalText = Buyer?.CellPhone },

        };

        }

        private void UpdateValuesOfCustomerAddress(CustomerDataModel Buyer)
        {
            // Update Customer address VM with values
            CustomerAddress = new CustomerAddressViewModel

            {
                AddressDescription = "Physical Address (Primary)",
                StreetAddress = new TextEntryViewModel { Label = "Address", OriginalText = Buyer?.StreetAddress },
                City = new TextEntryViewModel { Label = "City", OriginalText = Buyer?.City },
                State = States.OH,
                Zip = new TextEntryViewModel { Label = "Zip", OriginalText = Buyer?.Zip },
                AddressType = AddressType.Physical,
                County = new TextEntryViewModel { Label = "County", OriginalText = Buyer?.County },
                CountyCode = new TextEntryViewModel { Label = "County Code", OriginalText = Buyer.CountyCode },

            };

        }

        private void UpdateValuesOfVehicleCard(VehicleInventoryDataModel Vehicle)
        {
            // Update Customer address VM with values
            VehicleCard = new VehicleCardViewModel

            {
                StockNumber = new TextDisplayViewModel { Label = "Stock Number", DisplayText = Vehicle?.StockNumber },
                Type = new TextDisplayViewModel { Label = "Type", DisplayText = Vehicle?.Type },
                Status = new TextDisplayViewModel { Label = "Status", DisplayText = Vehicle?.Status },
                DaysInStock = new TextDisplayViewModel { Label = "In Stock", DisplayText = $"{Vehicle?.DaysInStock} days" },
                Color = new TextDisplayViewModel { Label = "Color", DisplayText = Vehicle?.Color },
                InteriorColor = new TextDisplayViewModel { Label = "Interior", DisplayText = Vehicle?.InteriorColor },
                LotLocation = new TextDisplayViewModel { Label = "Lot Location", DisplayText = Vehicle?.LotLocation },
                Category = new TextDisplayViewModel { Label = "Category", DisplayText = Vehicle?.Category },
                VIN = new TextDisplayViewModel { Label = "VIN", DisplayText = Vehicle?.VIN },
                Odometer = new TextDisplayViewModel { Label = "Odometer", DisplayText = $"{Vehicle?.Odometer} miles" },
                MSRP = new TextDisplayViewModel { Label = "MSRP", DisplayText = Vehicle?.MSRP.ToString() },
                ListPrice = new TextDisplayViewModel { Label = "List Price", DisplayText = Vehicle?.ListPrice.ToString() },
                InternetPrice = new TextDisplayViewModel { Label = "Internet Price", DisplayText = Vehicle?.InternetPrice.ToString() },


            };

        }

        private void UpdateValuesOfVehicleBasicInfo(VehicleInventoryDataModel Vehicle)
        {
            // Update Customer address VM with values
            VehicleBasicInfo = new VehicleBasicInfoViewModel

            {
                StockNumber = new TextEntryViewModel { Label = "Stock Number", OriginalText = Vehicle?.StockNumber },
                VIN = new TextEntryViewModel { Label = "VIN", OriginalText = Vehicle?.VIN },
                Type = new TextEntryViewModel { Label = "Type", OriginalText = Vehicle?.Type },
                Status = new TextEntryViewModel { Label = "Status", OriginalText = Vehicle?.Status },
                Year = new TextEntryViewModel { Label = "Year", OriginalText = Vehicle?.Year.ToString() },
                Make = new TextEntryViewModel { Label = "Make", OriginalText = Vehicle?.Make },
                Model = new TextEntryViewModel { Label = "Status", OriginalText = Vehicle?.Model },
                Trim = new TextEntryViewModel { Label = "Trim", OriginalText = Vehicle?.TrimColor },
                Body = new TextEntryViewModel { Label = "Body", OriginalText = Vehicle?.BodyStyle },                
                ExteriorColor = new TextEntryViewModel { Label = "Exterior Color", OriginalText = Vehicle?.Color },
                InteriorColor = new TextEntryViewModel { Label = "Interior Color", OriginalText = Vehicle?.InteriorColor },
                Class = new TextEntryViewModel { Label = "Class", OriginalText = Vehicle?.Class },
                Odometer = new TextEntryViewModel { Label = "Odometer", OriginalText = $"{Vehicle?.Odometer} miles" },
                OdometerStatus = new TextEntryViewModel { Label = "Odometer Status", OriginalText = Vehicle?.OdometerStatus },
                HasFactoryWarranty = (bool)Vehicle?.HasFactoryWarranty               
            };

        }


        #endregion





    }

}
