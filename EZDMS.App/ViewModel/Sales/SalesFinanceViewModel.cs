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
using static Dna.FrameworkDI;
using System.Linq.Expressions;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Query.Expressions;

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

        protected CustomerDataModel mCustomer;

        protected CustomerDataModel mSecondCustomer;

        protected VehicleInventoryDataModel mSaleVehicle;
        
        private SalesSummaryViewModel mSalesSummary;

        private SalesDeskingTotalsViewModel mDeskingTotals;

        

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
                    UpdateValuesOfSalesDealCard(value);
            }

        }

        /// <summary>
        /// The data model for the buyer
        /// </summary>
        public CustomerDataModel Customer
        {
            get => mCustomer;

            set
            {
                // If datamodel has not changed...
                if (mCustomer == value)
                    // Ignore
                    return;

                // Set the backing datamodel
                mCustomer = value;

                if (value != null)
                    // Reload customer card view model
                    UpdateValuesOfCustomerCard(value);
                    UpdateValuesOfCustomerBasicInfo(value);
                    UpdateValuesOfCustomerAddress(value);
            }

        }

        /// <summary>
        /// The data model for the cobuyer
        /// </summary>
        public CustomerDataModel SecondCustomer
        {

            get => mSecondCustomer;

            set
            {
                // If datamodel has not changed...
                if (mSecondCustomer == value)
                    // Ignore
                    return;

                // Set the backing datamodel
                mSecondCustomer = value;

                //if (value != null)
                //    // Reload sales deal view model
                //    UpdateValuesOfSalesDealCard(value);
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

                if (value != null)
                // Reload vehicle view models                                
                {
                    UpdateValuesOfVehicleCard(value);
                    UpdateValuesOfVehicleDetails(value);
                    UpdateValuesOfVehiclePricing(value);
                    UpdateValuesOfVehicleBasicInfo(value);
                }
            }

        }

        /// <summary>
        /// The sales service contract data model
        /// </summary>
        public SalesServiceDataModel SalesService {get; set;}

        /// <summary>
        /// The sales maintenance data model
        /// </summary>
        public SalesMaintenanceDataModel SalesMaintenance { get; set; }

        /// <summary>
        /// The sales warranty data model
        /// </summary>
        public SalesWarrantyDataModel SalesWarranty { get; set; }

        /// <summary>
        /// The sales gap data model
        /// </summary>
        public SalesGapDataModel SalesGap { get; set; }

        /// <summary>
        /// The view model for the sales summary control
        /// </summary>
        public SalesSummaryViewModel SalesSummary { 
            
            get=> mSalesSummary; 

            set
            {

                // If datamodel has not changed...
                if (mSalesSummary == value)
                    // Ignore
                    return;



                if (mSalesSummary != null & value != null)
                {
                    if (value.APR != mSalesSummary.APR | value.Term != mSalesSummary.Term | value.EffectiveAPR != mSalesSummary.EffectiveAPR | value.DaysToFirstPayment != mSalesSummary.DaysToFirstPayment)
                    {

                        var _result = UpdateFinanceAsync();
                    }
                }
                // Set the backing datamodel
                mSalesSummary = value;

            }
        
        }

        /// <summary>
        /// The view model for the truth in lending disclosure control
        /// </summary>
        public TruthinLendingDisclosureViewModel TruthinLending { get; set; }

        /// <summary>
        /// The view model for the desking totals control
        /// </summary>
        public SalesDeskingTotalsViewModel DeskingTotals
        {

            get => mDeskingTotals;

            set
            {

                // If datamodel has not changed...
                if (mDeskingTotals == value)
                    // Ignore
                    return;



                //if (mDeskingTotals != null & value != null)
                //{
                //    if (value.Cash != mDeskingTotals.Cash | value.Rebates != mDeskingTotals.Rebates | value.TradeAllowance != mDeskingTotals.TradeAllowance)
                //    {

                //    UpdateFinanceAsync();
                //    }
                //}
                //// Set the backing datamodel
                mDeskingTotals = value;

            }

        }

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

        /// <summary>
        /// Indicates if a dialog window is currently being loaded
        /// </summary>
        public bool DialogWindowLoading { get; set; }

        /// <summary>
        /// Indicates if there is a save action
        /// </summary>
        public bool SavingInfo { get; set; }

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
        public ICommand SaveCustomerCommand { get; set; }

        /// <summary>
        /// Saves the current buyer info to the server
        /// </summary>
        public ICommand SelectCustomerCommand { get; set; }

        /// <summary>
        /// Saves the current vehicle info to the server
        /// </summary>
        public ICommand SaveVehicleCommand { get; set; }

        /// <summary>
        /// Saves the current vehicle info to the server
        /// </summary>
        public ICommand SelectVehicleCommand { get; set; }

        /// <summary>
        /// Shows a products dialog window
        /// </summary>
        public ICommand ShowProductsDialogCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SalesFinanceViewModel()
        {
            // Create commands
            LoadDealCommand = new RelayCommand(async () => await LoadAsync());
            SaveCustomerCommand = new RelayCommand(async () => await SaveCustomerAsync());
            SelectCustomerCommand =  new RelayCommand(async () => await SelectCustomerAsync());
            SaveVehicleCommand = new RelayCommand(async () => await SaveVehicleAsync());
            SelectVehicleCommand = new RelayCommand(async () => await SelectVehicleAsync());
            ShowProductsDialogCommand = new RelayCommand(async () => await ShowProductsDialogAsync());

            SalesDealCard = new SalesDealCardViewModel();
        }

        #endregion

        #region Command Methods

        public async Task LoadAsync()
        {
            // Lock this command to ignore any other requests while processing
            await RunCommandAsync(() => SalesFinancePageLoading, async () => {

                

                await Task.Delay(1);
                UpdateValuesOfDeskingTotals(SalesFinanceDeal);
                UpdateValuesOfSalesSummary(SalesFinanceDeal);
                UpdateValuesOfTruthinLending(SalesFinanceDeal);

                //UpdateValuesOfSalesDealCard(SalesDealsItem);

                

                return Task.CompletedTask;
            });

        }

        public async Task<bool> UpdateFinanceAsync()
        {
            // Lock this command to ignore any other requests while processing
            return await RunCommandAsync(() => SavingInfo, async () =>  
            {

                // Update data model
                await Task.Run(UpdateSalesFinanceDM);
                
                // Update view models
                UpdateValuesOfDeskingTotals(SalesFinanceDeal);
                UpdateValuesOfSalesSummary(SalesFinanceDeal);
                UpdateValuesOfTruthinLending(SalesFinanceDeal);

                // Save to db and return result
                await ClientDataStore.SaveSalesRecordAsync(SalesFinanceDeal, DbTableNames.SalesFinance);

                return true;

            });

        }

        public async Task<bool> ShowProductsDialogAsync()
        {

            return await RunCommandAsync(() => DialogWindowLoading, async () =>
            {

                // Lock this command to ignore any other requests while processing
                await UI.ShowProducts(new ProductsSalesDialogViewModel
                {
                    Title = "Products",
                   
                });

                // Update view model
                await UpdateFinanceAsync();
                return true;            
            });
            
        }

        public async Task<bool> ShowFeesDialogAsync()
        {

            return await RunCommandAsync(() => DialogWindowLoading, async () =>
            {

                // Lock this command to ignore any other requests while processing
                await UI.ShowFees(new TotalFeesSalesDialogViewModel
                {
                    Title = "Fees",
                    

                });

                // Update view model
                await UpdateFinanceAsync();
                return true;
            });

        }


        /// <summary>
        /// Update the customer datamodel then save to the data store
        /// </summary>
        /// <returns></returns>
        public async Task SaveCustomerAsync()
        {

            await RunCommandAsync(() => SavingInfo, async () =>
            {

                // Update data model
                await Task.Run(UpdateCustomerDM);

                // save to data store
                await ClientDataStore.SaveSalesRecordAsync(Customer, DbTableNames.Customer);

            });
        }

        public async Task SelectCustomerAsync()
        {
            await UI.ShowCustomers(new CustomerSelectDialogViewModel 
            {
                
                Title = "Customers",
               

            });


        }

        public async Task SaveVehicleAsync()
        {


            await RunCommandAsync(() => SavingInfo, async () =>
            {
                // Update data model
                await Task.Run(UpdateVehicleDM);

                // Update sales finance view model

                await UpdateFinanceAsync();


                // Save to datastore
                await ClientDataStore.SaveSalesRecordAsync(SaleVehicle, DbTableNames.VehicleInventory);

            });
        }

        public async Task SelectVehicleAsync()
        {
            await UI.ShowVehicles(new VehicleSelectDialogViewModel
            {

                Title = "Sale Vehicles",


            });


        }

        public async Task<bool> ShowFrontBackAddsAsync()
        {

            return await RunCommandAsync(() => DialogWindowLoading, async () =>
            {

                // Lock this command to ignore any other requests while processing
                await UI.ShowAdds(new FrontBackAddsDialogViewModel
                {
                    Title = "Adds",

                });

                // Update view model
                await UpdateFinanceAsync();

                // return success
                return true;
            });

        }

        public async Task UpdateSalesDealItemAsync(object mDataModel, string mType = null)
        {
           
             // return if no data model
            if (mDataModel == null)
                return;

            if (mDataModel is CustomerDataModel)
            {
                // Update view model
                if (mType == "C")
                {
                    SalesDealsItem.CoBuyerName = $"{(mDataModel as CustomerDataModel).FirstName} {(mDataModel as CustomerDataModel).LastName}";
                    SalesDealsItem.CoBuyerNumber = (mDataModel as CustomerDataModel).Number;
                }
                else
                {
                    SalesDealsItem.BuyerName = $"{(mDataModel as CustomerDataModel).FirstName} {(mDataModel as CustomerDataModel).LastName}";
                    SalesDealsItem.BuyerNumber = (mDataModel as CustomerDataModel).Number;
                }

            }
            else if (mDataModel is VehicleInventoryDataModel)
            {
                if (mType == "S")
                {
                    SalesDealsItem.StockNumber = (mDataModel as VehicleInventoryDataModel).StockNumber;
                    SalesDealsItem.VehicleInfo = $"{(mDataModel as VehicleInventoryDataModel).Year} {(mDataModel as VehicleInventoryDataModel).Make} {(mDataModel as VehicleInventoryDataModel).Model}";
                }
            }
            else
                return;

            // Update sales card view model
            UpdateValuesOfSalesDealCard(SalesDealsItem);

            // Update client datastore record
            await ClientDataStore.SaveSalesRecordAsync(SalesDealsItem, DbTableNames.SalesDealsInfo);

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
            
            var TotalTaxes = (TotalAmount * 9) / 100;

            SubTotalAmount += TotalTaxes;

            salesFinance.TotalTaxes = TotalTaxes;


            switch (salesFinance.CalculationMethod)
            {
                
                case "Federal":
                    var rateCalc = (salesFinance.APR/100)/12;
                    var moPct = TotalAmount * rateCalc;
                    var termCalc = Math.Pow((double)(1 - (1 + rateCalc)),-salesFinance.Term);
                    var payment = Math.Round((moPct / (decimal)termCalc), 2, MidpointRounding.AwayFromZero);
                    var principal = TotalAmount / salesFinance.Term;
                    var interest = payment - principal;
                    var financeCharge = (payment * salesFinance.Term) - TotalAmount;

                    SalesFinanceDeal.Payment = payment;
                    SalesFinanceDeal.FinanceCharge = financeCharge;

                    break;

                // Simple Interest
                default:
                                        
                    SalesFinanceDeal.FinanceCharge = (TotalAmount * (SalesFinanceDeal.APR / 100)) * (SalesFinanceDeal.Term / 12);
                    SalesFinanceDeal.Payment = (TotalAmount + SalesFinanceDeal.FinanceCharge)/ SalesFinanceDeal.Term;


                    break;


            }

            SalesFinanceDeal.AmountFinanced = TotalAmount;
            SalesFinanceDeal.NumberOfPayments = salesFinance.Term;
            SalesFinanceDeal.TotalOfPayments = SalesFinanceDeal.AmountFinanced + SalesFinanceDeal.FinanceCharge;
            SalesFinanceDeal.TotalSalePrice = SalesFinanceDeal.TotalOfPayments + SalesFinanceDeal.TotalDown;


        DeskingTotals = new SalesDeskingTotalsViewModel
            {

                SellingPrice = new DecimalInputViewModel 
                { 
                    Label = "Selling Price",
                    Amount = salesFinance.SellingPrice,
                   
                },
                                   
                FrontOptions = new DecimalInputViewModel 
                { 
                    Label = "Front Options", 
                    Amount = salesFinance.TotalFrontAdds, 
                    Editable = true,
                    DialogAction = ShowFrontBackAddsAsync

                },
                    
                Taxes = new DecimalInputViewModel 
                { 
                    Label = "Taxes", 
                    Amount = salesFinance.TotalTaxes,
                    Editable = true 
                },
                    
                Fees = new DecimalInputViewModel 
                { 
                    Label = "Fees",
                    Amount = (salesFinance.TotalOfficialFees + salesFinance.TotalDealerFees),
                    Editable = true,
                    DialogAction = ShowFeesDialogAsync
                },
                  
                BackOptions = new DecimalInputViewModel 
                { 
                    Label = "Back Options",
                    Amount = salesFinance.TotalBackAdds,
                    Editable = true,
                    DialogAction = ShowFrontBackAddsAsync

                },
                    
                Service = new DecimalInputViewModel 
                { 
                    Label = "Service", 
                    Amount = (salesFinance.ServiceContract + salesFinance.Maintenance + salesFinance.Warranty),
                    Editable = true,
                    DialogAction = ShowProductsDialogAsync
                },
                  
                Gap = new DecimalInputViewModel 
                { 
                    Label = "Gap", 
                    Amount = salesFinance.Gap,
                    Editable = true,
                    DialogAction = ShowProductsDialogAsync
                },
                  
                CreditInsurance = new DecimalInputViewModel 
                { 
                    Label = "Credit Insurance", 
                    Amount = salesFinance.LAHInsurance, 
                    Editable = true,
                    DialogAction = ShowProductsDialogAsync
                },
                  
                SubTotal = new DecimalInputViewModel 
                {
                    Label = "SUBTOTAL",
                    Amount = SubTotalAmount
                },
                  
                Cash = new DecimalInputViewModel 
                { 
                    Label = "Cash", 
                    Amount = salesFinance.TotalCashDown, 
                    Editable = true,
                    CommitAction = UpdateFinanceAsync
                },
                  
                Rebates = new DecimalInputViewModel 
                { 
                    Label = "Rebates",
                    Amount = salesFinance.TotalRebates,
                    Editable = true 
                },
                  
                TradeAllowance = new DecimalInputViewModel 
                { 
                    Label = "Trade Allowance",
                    Amount = salesFinance.TotalAllowance,
                    Editable = true 
                },
                  
                TradePayoff = new DecimalInputViewModel 
                { 
                    Label = "Trade Payoff",
                    Amount = salesFinance.TotalPayoff,
                    Editable = true 
                },
                  
                Total = new DecimalInputViewModel 
                { 
                    Label = "TOTAL",
                    Amount = TotalAmount 
                },
                  
                CashFromCustomer = new DecimalInputViewModel 
                { 
                    Label = "Cash From Customer",
                    Amount = salesFinance.TotalCashDown
                },
                  
                Payment = new DecimalInputViewModel 
                { 
                    Label = "Payment",
                    Amount = salesFinance.Payment 
                },

            };

        }

        private void UpdateValuesOfSalesSummary(SalesFinanceDataModel salesFinance)
        {
            // return if null
            if (salesFinance == null)
                return;

            // The amount for the trade difference 
            var tradeDifference = salesFinance.SellingPrice - salesFinance.TotalAllowance;


            SalesSummary = new SalesSummaryViewModel
            {
                // Create the APR
                APR = new DecimalInputViewModel
                {
                    Label = "APR",
                    Amount = salesFinance.APR == 0 ? Convert.ToDecimal(8.00): Convert.ToDecimal(salesFinance.APR),
                    Editable = true



                },

                // Create the APR
                EffectiveAPR = new DecimalInputViewModel

                {
                    Label = "Effective APR",
                    Amount = salesFinance.EffectiveAPR == 0 ? Convert.ToDecimal(8.00) : Convert.ToDecimal(salesFinance.EffectiveAPR),
                    Editable = true

                },

                // Create the trade difference
                TradeDifference = new TextInputViewModel
                {
                    Label = "Trade Difference",
                    Text = tradeDifference.ToString("#.00"),                    
                    Editable = true

                },

                // Create the term
                Term = new NumericalInputViewModel
                {
                    Label = "Term",
                    Number = salesFinance.Term == 0 ? 48 : salesFinance.Term,                   
                    Editable = true

                },

                // Create the purchase date
                PurchaseDate = new DateSelectionViewModel
                {
                    Label = "Purchase Date",
                    Date = salesFinance.DealDate == DateTime.MinValue ? DateTime.Today : salesFinance.DealDate
                },

                // Create the days to first payment
                DaysToFirstPayment = new NumericalInputViewModel 
                {
                    Label = "Days To First Payment",
                    Number = salesFinance.DaysTo1stPayment == 0 ? 30 : salesFinance.DaysTo1stPayment,
                    Editable = true
                },

                // Create the payment date
                PaymentDate = new DateSelectionViewModel
                {
                    Label = "Payment Date",
                    Date = salesFinance.FirstPaymentDate == DateTime.MinValue ? DateTime.Today.AddDays(30) : salesFinance.FirstPaymentDate
                },

                // Create the lender name
                Lender = "CCU"
                

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

                Payment = new DecimalInputViewModel
                {
                    Label = $"{salesFinance.NumberOfPayments} Payments of ",
                    Amount = salesFinance.Payment
                },

                FinalPayment = new DecimalInputViewModel
                {
                    Label = "Final Payment",
                    Amount = salesFinance.Payment
                },

                FinanceCharge = new DecimalInputViewModel
                {
                    Label = "Finance Charge",
                    Amount = salesFinance.FinanceCharge
                },

                TotalOfPayments = new DecimalInputViewModel
                {
                    Label = "Total Of Payments",
                    Amount = salesFinance.TotalOfPayments
                },

                TotalDown = new DecimalInputViewModel
                {
                    Label = "Total Down",
                    Amount = salesFinance.TotalDown
                },

                TotalSalePrice = new DecimalInputViewModel
                {
                    Label = "Total Sale Price",
                    Amount = salesFinance.TotalSalePrice
                },

            };

        }

        private void UpdateValuesOfSalesDealCard(SalesDealsItemDataModel salesDeal)
        {
            // return if null
            if (salesDeal == null)
                return;

            SalesDealCard.BuyerName.Text = salesDeal?.BuyerName;
            SalesDealCard.CoBuyerName.Text = salesDeal?.CoBuyerName;
            SalesDealCard.Vehicle.Text = salesDeal?.VehicleInfo;
            SalesDealCard.Status.Text = salesDeal?.Status;
            SalesDealCard.Vehicle.Text = salesDeal?.VehicleInfo;
            SalesDealCard.DealType.Text = salesDeal?.Type;
            SalesDealCard.CreatedDate.Text = salesDeal.CreatedDate.ToString("MM/dd/yyyy");
            SalesDealCard.DealDate.Text = salesDeal.DealDate.ToString("MM/dd/yyyy");
            SalesDealCard.LastActivityDate.Text = salesDeal.LastActivityDate.ToString("MM/dd/yyyy");
            SalesDealCard.Trades.Text = $"{salesDeal?.Trade1Info} \r\n {salesDeal?.Trade2Info} \r\n {salesDeal?.Trade3Info}";
            SalesDealCard.Salesperson.Text = $"{salesDeal?.SalesPerson} \r\n {salesDeal?.SalesPerson2}";
            SalesDealCard.SalesManager.Text = salesDeal?.SalesManager;
            SalesDealCard.FinanceManager.Text = salesDeal?.FinanceManager;

            //SalesDealCard = new SalesDealCardViewModel
            //{
            //    BuyerName = new TextInputViewModel
            //    {
            //        Label = "Buyer Name",
            //        Text = salesDeal?.BuyerName
            //    },

            //    CoBuyerName = new TextInputViewModel
            //    {
            //        Label = "CoBuyer Name",
            //        Text = salesDeal?.CoBuyerName
            //    },

            //    Vehicle = new TextInputViewModel
            //    {
            //        Label = "Vehicle",
            //        Text = salesDeal?.VehicleInfo
            //    },

            //    Status = new TextInputViewModel
            //    {
            //        Label = "Status",
            //        Text = salesDeal?.Status
            //    },

            //    DealType = new TextInputViewModel
            //    {
            //        Label = "Deal Type",
            //        Text = salesDeal?.Type
            //    },

            //    Salesperson = new TextInputViewModel
            //    {
            //        Label = "Sales Person",
            //        Text = $"{salesDeal?.SalesPerson} \r\n {salesDeal?.SalesPerson2}"
            //    },

            //    SalesManager = new TextInputViewModel
            //    {
            //        Label = "Sales Manager",
            //        Text = salesDeal?.SalesManager
            //    },

            //    FinanceManager = new TextInputViewModel
            //    {
            //        Label = "Finance Manager",
            //        Text = salesDeal?.FinanceManager
            //    },

            //    Trades = new TextInputViewModel
            //    {
            //        Label = "Trades",
            //        Text = $"{salesDeal?.Trade1Info} \r\n {salesDeal?.Trade2Info} \r\n {salesDeal?.Trade3Info}"
            //    },

            //    CreatedDate = new TextInputViewModel
            //    {
            //        Label = "Created Date",
            //        Text = salesDeal.CreatedDate.ToString("MM/dd/yyyy")
            //    },

            //    LastActivityDate = new TextInputViewModel
            //    {
            //        Label = "Last Activity Date",
            //        Text = salesDeal.LastActivityDate.ToString("MM/dd/yyyy")
            //    },

            //    DealDate = new TextInputViewModel
            //    {
            //        Label = "Deal Date",
            //        Text = salesDeal.DealDate.ToString("MM/dd/yyyy")
            //    },

            //};


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

                CustomerNumber = new TextInputViewModel { Label = "Customer Number", Text = Buyer?.Number, Editable = false },
                FullName = $"{Buyer?.FirstName} {Buyer?.MiddleName} {Buyer?.LastName}",
                CreateDate = new TextInputViewModel { Label = "Created", Text = Buyer.CreateDate.ToString("MM/dd/yyyy"), Editable = false },
                LastModifiedDate = new TextInputViewModel { Label = "Last Modified", Text = Buyer.LastModifiedDate.ToString("MM/dd/yyyy"), Editable = false },
                MainPhone = new TextInputViewModel { Label = phoneLabel.ToString(), Text = $"{mainPhone} {Buyer?.MainPhoneType}", Editable = false },
                MainEmail = new TextInputViewModel { Label = "1 Email", Text = $"{Buyer?.Email} {Buyer?.EmailType}", Editable = false },
                FullAddress = new TextInputViewModel { Label = "1 Address", Text = $"{Buyer?.StreetAddress} \r\n {Buyer?.City} , {Buyer?.State} {Buyer?.Zip}", Editable = false },

            };

        }

        private void UpdateValuesOfCustomerBasicInfo(CustomerDataModel Buyer)
        {

            // Update Customer basic info VM with values
            CustomerBasicInfo = new CustomerBasicInfoViewModel

            {
                FirstName = new TextInputViewModel { Label = "First Name", Text = Buyer?.FirstName },
                MiddleName = new TextInputViewModel { Label = "Middle Name", Text = Buyer?.MiddleName },
                LastName = new TextInputViewModel { Label = "Last Name", Text = Buyer?.LastName },
                Suffix = new TextInputViewModel { Label = "Suffix", Text = Buyer?.Suffix },
                Nickname = new TextInputViewModel { Label = "Nickname", Text = Buyer?.Nickname },
                //DateOfBirth = new DateSelectionViewModel { Label = "Date of Birth", Date = Convert.ToDateTime(Buyer?.DateOfBirth) },
                //MaritalStatus=(MaritalStatusType)Enum.Parse(typeof(MaritalStatusType),Buyer?.MaritalStatus),
                SocialSecurityNumber = new TextInputViewModel { Label = "SSN", Text = Buyer?.SSN },
                Email = new TextInputViewModel { Label = "Email", Text = Buyer?.Email },
                //EmailType = (EmailType)Enum.Parse(typeof(EmailType), Buyer?.EmailType),
                HomePhone = new TextInputViewModel { Label = "Home Phone", Text = Buyer?.HomePhone },
                WorkPhone = new TextInputViewModel { Label = "Work Phone", Text = Buyer?.WorkPhone },
                CellPhone = new TextInputViewModel { Label = "Cell Phone", Text = Buyer?.CellPhone },
            };

        }

        private void UpdateValuesOfCustomerAddress(CustomerDataModel Buyer)
        {
            // Update Customer address VM with values
            CustomerAddress = new CustomerAddressViewModel

            {
                AddressDescription = "Physical Address (Primary)",
                StreetAddress = new TextInputViewModel { Label = "Address", Text = Buyer?.StreetAddress },
                City = new TextInputViewModel { Label = "City", Text = Buyer?.City },
                State = States.OH,
                Zip = new TextInputViewModel { Label = "Zip", Text = Buyer?.Zip },
                AddressType = AddressType.Physical,
                County = new TextInputViewModel { Label = "County", Text = Buyer?.County },
                CountyCode = new TextInputViewModel { Label = "County Code", Text = Buyer.CountyCode },

            };

        }

        private void UpdateValuesOfVehicleCard(VehicleInventoryDataModel Vehicle)
        {
            // Update vehicle card VM with values
            VehicleCard = new VehicleCardViewModel

            {
                StockNumber = new TextInputViewModel { Label = "Stock Number", Text = Vehicle?.StockNumber, Editable = false },
                Type = new TextInputViewModel { Label = "Type", Text = Vehicle?.Type, Editable = false },
                Status = new TextInputViewModel { Label = "Status", Text = Vehicle?.Status, Editable = false },
                DaysInStock = new TextInputViewModel { Label = "In Stock", Text = $"{Vehicle?.DaysInStock} days", Editable = false },
                Color = new TextInputViewModel { Label = "Color", Text = Vehicle?.Color, Editable = false },
                InteriorColor = new TextInputViewModel { Label = "Interior", Text = Vehicle?.InteriorColor, Editable = false },
                LotLocation = new TextInputViewModel { Label = "Lot Location", Text = Vehicle?.LotLocation, Editable = false },
                Category = new TextInputViewModel { Label = "Category", Text = Vehicle?.Category, Editable = false },
                VIN = new TextInputViewModel { Label = "VIN", Text = Vehicle?.VIN, Editable = false },
                Odometer = new TextInputViewModel { Label = "Odometer", Text = $"{Vehicle?.Odometer} miles", Editable = false },
                MSRP = new TextInputViewModel { Label = "MSRP", Text = Vehicle?.MSRP.ToString(), Editable = false },
                ListPrice = new TextInputViewModel { Label = "List Price", Text = Vehicle?.ListPrice.ToString(), Editable = false },
                InternetPrice = new TextInputViewModel { Label = "Internet Price", Text = Vehicle?.InternetPrice.ToString(), Editable = false },


            };

        }

        private void UpdateValuesOfVehicleBasicInfo(VehicleInventoryDataModel Vehicle)
        {
            // Update vehicle basic info VM with values
            VehicleBasicInfo = new VehicleBasicInfoViewModel

            {
                StockNumber = new TextInputViewModel { Label = "Stock Number", Text = Vehicle?.StockNumber },
                VIN = new TextInputViewModel { Label = "VIN", Text = Vehicle?.VIN },
                Type = new TextInputViewModel { Label = "Type", Text = Vehicle?.Type },
                Status = new TextInputViewModel { Label = "Status", Text = Vehicle?.Status },
                Year = new TextInputViewModel { Label = "Year", Text = Vehicle?.Year.ToString() },
                Make = new TextInputViewModel { Label = "Make", Text = Vehicle?.Make },
                Model = new TextInputViewModel { Label = "Status", Text = Vehicle?.Model },
                Trim = new TextInputViewModel { Label = "Trim", Text = Vehicle?.TrimColor },
                Body = new TextInputViewModel { Label = "Body", Text = Vehicle?.BodyStyle },                
                ExteriorColor = new TextInputViewModel { Label = "Exterior Color", Text = Vehicle?.Color },
                InteriorColor = new TextInputViewModel { Label = "Interior Color", Text = Vehicle?.InteriorColor },
                Class = new TextInputViewModel { Label = "Class", Text = Vehicle?.Class },
                //Odometer = new TextInputViewModel { Label = "Odometer", Text = $"{Vehicle?.Odometer} miles" },
                Odometer = new TextInputViewModel { Label = "Odometer", Text = Vehicle?.Odometer.ToString() },
                OdometerStatus = new TextInputViewModel { Label = "Odometer Status", Text = Vehicle?.OdometerStatus },
                HasFactoryWarranty = (bool)Vehicle?.HasFactoryWarranty               
            };

        }

        private void UpdateValuesOfVehiclePricing(VehicleInventoryDataModel Vehicle)
        {
            // Update vehicle pricing VM with values
            VehiclePricing = new VehiclePricingViewModel

            {
                MSRP = new DecimalInputViewModel { Label = "MSRP", Amount = Vehicle.MSRP },
                InventoryPrice = new DecimalInputViewModel { Label = "Inventory Price", Amount = Vehicle.InventoryPrice },
                ListPrice = new DecimalInputViewModel { Label = "List Price", Amount = Vehicle.ListPrice == 0 ? Vehicle.MSRP : Vehicle.ListPrice },
                InternetPrice = new DecimalInputViewModel { Label = "Internet Price", Amount = Vehicle.InternetPrice },
                AccountingCost = new DecimalInputViewModel { Label = "Accounting Cost", Amount = Vehicle.AccountingCost },
                ACV = new DecimalInputViewModel { Label = "ACV", Amount = Vehicle.ACV },
                AddedCosts = new DecimalInputViewModel { Label = "Added Costs", Amount = Vehicle.AddedCosts },
                Advertising = new DecimalInputViewModel { Label = "Advertising", Amount = Vehicle.Advertising },
                Reconditioning = new DecimalInputViewModel { Label = "Reconditioning", Amount = Vehicle.Reconditioning },
                Holdback = new DecimalInputViewModel { Label = "Holdback", Amount = Vehicle.Holdback },
                DealerPack = new DecimalInputViewModel { Label = "Dealer Pack", Amount = Vehicle.DealerPack },
                BuyerFee = new DecimalInputViewModel { Label = "Buyer Fee", Amount = Vehicle.BuyerFee },
                InvoicePrice = new DecimalInputViewModel { Label = "Invoice Price", Amount = Vehicle.InvoicePrice },
                DealerPackPercentage = new DecimalInputViewModel { Label = "Dealer Pack(%)", Amount = Vehicle.InvoicePrice },
                
            };

        }

        private void UpdateValuesOfVehicleDetails(VehicleInventoryDataModel Vehicle)
        {
            // Update vehicle details VM with values
            VehicleDetails = new VehicleDetailsViewModel

            {
                NumberOfDoors = new TextInputViewModel { Label = "Number Of Doors", Text = Vehicle?.NumberOfDoors.ToString() },
                Cylinders = new TextInputViewModel { Label = "Cylinders", Text = Vehicle?.Cylinders.ToString() },
                FuelType = new TextInputViewModel { Label = "Fuel Type", Text = Vehicle?.FuelType },
                FuelSystem = new TextInputViewModel { Label = "Fuel System", Text = Vehicle?.FuelSystem },
                FuelEconomy = new TextInputViewModel { Label = "Fuel Economy", Text = Vehicle?.FuelEconomy },
                TransmissionType = new TextInputViewModel { Label = "Transmission Type", Text = Vehicle?.TransmissionType },
                TransmissionSpeed = new TextInputViewModel { Label = "Transmission Speed", Text = Vehicle?.TransmissionSpeed },
                Drivetrain = new TextInputViewModel { Label = "Drivetrain", Text = Vehicle?.Drivetrain },
                Engine = new TextInputViewModel { Label = "Engine", Text = Vehicle?.Engine },
                EngineType = new TextInputViewModel { Label = "Engine Type", Text = Vehicle?.EngineType },
                EngineSerialNumber = new TextInputViewModel { Label = "Engine Serial Number", Text = Vehicle?.EngineSerialNumber },
                IgnitionKeyCode = new TextInputViewModel { Label = "Ignition Key Code", Text = Vehicle?.IgnitionKeyCode },
                TrunkKeyCode = new TextInputViewModel { Label = "Trunk Key Code", Text = Vehicle?.TrunkKeyCode },
                Weight = new TextInputViewModel { Label = "Weight", Text = Vehicle?.Weight.ToString() },
                LicensePlate = new TextInputViewModel { Label = "License Plate", Text = Vehicle?.LicensePlate },
                LicenseState = new TextInputViewModel { Label = "License State", Text = Vehicle?.LicenseState },
                //LicenseExpirationDate = new DateSelectionViewModel { Label = "License Expiration Date", Date = Convert.ToDateTime(Vehicle?.LicenseExpirationDate) },
                LotLocation = new TextInputViewModel { Label = "Lot Location", Text = Vehicle?.LotLocation },
                Style = new TextInputViewModel { Label = "Style", Text = Vehicle?.Style },
                ModelCode = new TextInputViewModel { Label = "Model Code", Text = Vehicle?.ModelCode },

            };

        }

        private void UpdateCustomerDM()
        {
            
            //Customer.Prefix = CustomerBasicInfo.Prefix.ToString();
            Customer.Suffix = CustomerBasicInfo.Suffix.Text;
            //Customer.Status = CustomerBasicInfo.MaritalStatus.ToString();
            Customer.FirstName = CustomerBasicInfo.FirstName.Text;
            Customer.MiddleName = CustomerBasicInfo.MiddleName.Text;
            Customer.LastName = CustomerBasicInfo.LastName.Text;
            //Customer.Gender = CustomerBasicInfo.Gender.ToString();
            Customer.Email = CustomerBasicInfo.Email.Text;
            //Customer.EmailType = CustomerBasicInfo.EmailType.ToString();
            //Customer.PrivacyType = CustomerBasicInfo.PrivacyType.ToString();
            //Customer.ContactType = CustomerBasicInfo.ContactType.ToString();
            Customer.Nickname = CustomerBasicInfo.Nickname.Text;
            //Customer.DateOfBirth = CustomerBasicInfo.DateOfBirth.Date.ToString("mm/dd/yyyy");
            Customer.HomePhone = CustomerBasicInfo.HomePhone.Text;
            Customer.WorkPhone = CustomerBasicInfo.WorkPhone.Text;
            Customer.CellPhone = CustomerBasicInfo.CellPhone.Text;

            Customer.StreetAddress = CustomerAddress.StreetAddress.Text;
            Customer.City = CustomerAddress.City.Text;
            //Customer.State = CustomerAddress.State.ToString();
            Customer.Zip = CustomerAddress.Zip.Text;
            Customer.County = CustomerAddress.County.Text;
            Customer.CountyCode = CustomerAddress.CountyCode.Text;

        }

        private void UpdateSecondCustomerDM()
        {
            // customer basic info view model
            SecondCustomer.Prefix = CustomerBasicInfo.Prefix.ToString();
            SecondCustomer.Suffix = CustomerBasicInfo.Suffix.Text;
            SecondCustomer.Status = CustomerBasicInfo.MaritalStatus.ToString();
            SecondCustomer.FirstName = CustomerBasicInfo.FirstName.Text;
            SecondCustomer.MiddleName = CustomerBasicInfo.MiddleName.Text;
            SecondCustomer.LastName = CustomerBasicInfo.LastName.Text;
            SecondCustomer.Gender = CustomerBasicInfo.Gender.ToString();
            SecondCustomer.Email = CustomerBasicInfo.Email.Text;
            SecondCustomer.EmailType = CustomerBasicInfo.EmailType.ToString();
            SecondCustomer.PrivacyType = CustomerBasicInfo.PrivacyType.ToString();
            SecondCustomer.ContactType = CustomerBasicInfo.ContactType.ToString();
            SecondCustomer.Nickname = CustomerBasicInfo.Nickname.Text;
            SecondCustomer.DateOfBirth = CustomerBasicInfo.DateOfBirth.Date.ToString("mm/dd/yyyy");
            SecondCustomer.HomePhone = CustomerBasicInfo.HomePhone.Text;
            SecondCustomer.WorkPhone = CustomerBasicInfo.WorkPhone.Text;
            SecondCustomer.CellPhone = CustomerBasicInfo.CellPhone.Text;
            // customer address view model
            SecondCustomer.StreetAddress = CustomerAddress.StreetAddress.Text;
            SecondCustomer.City = CustomerAddress.City.Text;
            SecondCustomer.State = CustomerAddress.State.ToString();
            SecondCustomer.Zip = CustomerAddress.Zip.Text;
            SecondCustomer.County = CustomerAddress.County.Text;
            SecondCustomer.CountyCode = CustomerAddress.CountyCode.Text;

        }

        private void UpdateVehicleDM()
        {
            if (SaleVehicle == null)
                return;

            // Update values from vehicle basic info view model
            SaleVehicle.VIN = VehicleBasicInfo.VIN.Text;
            SaleVehicle.Type = VehicleBasicInfo.Type.Text;
            SaleVehicle.Status = VehicleBasicInfo.Status.Text;
            SaleVehicle.Year = Convert.ToInt32(VehicleBasicInfo.Year.Text);
            SaleVehicle.Make = VehicleBasicInfo.Make.Text;
            SaleVehicle.Model = VehicleBasicInfo.Model.Text;
            SaleVehicle.BodyStyle = VehicleBasicInfo.Body.Text;
            SaleVehicle.TrimColor = VehicleBasicInfo.Trim.Text;
            SaleVehicle.Color = VehicleBasicInfo.ExteriorColor.Text;
            SaleVehicle.Class = VehicleBasicInfo.Class.Text;
            SaleVehicle.Odometer = Convert.ToInt32(VehicleBasicInfo.Odometer.Text);
            SaleVehicle.OdometerStatus = VehicleBasicInfo.OdometerStatus.Text;
            SaleVehicle.HasFactoryWarranty = VehicleBasicInfo.HasFactoryWarranty;
            SaleVehicle.Color = VehicleBasicInfo.ExteriorColor.Text;
            // Update values from vehicle details view model
            SaleVehicle.NumberOfDoors = Convert.ToInt32(VehicleDetails.NumberOfDoors.Text);
            SaleVehicle.Cylinders = Convert.ToInt32(VehicleDetails.Cylinders.Text);
            SaleVehicle.FuelType = VehicleDetails.FuelType.Text;
            SaleVehicle.FuelSystem = VehicleDetails.FuelSystem.Text;
            SaleVehicle.FuelEconomy = VehicleDetails.FuelEconomy.Text;
            SaleVehicle.TransmissionType = VehicleDetails.TransmissionType.Text;
            SaleVehicle.TransmissionSpeed = VehicleDetails.TransmissionSpeed.Text;
            SaleVehicle.Drivetrain = VehicleDetails.Drivetrain.Text;
            SaleVehicle.Engine = VehicleDetails.Engine.Text;
            SaleVehicle.EngineType = VehicleDetails.EngineType.Text;
            SaleVehicle.EngineSerialNumber = VehicleDetails.EngineSerialNumber.Text;
            SaleVehicle.IgnitionKeyCode = VehicleDetails.IgnitionKeyCode.Text;
            SaleVehicle.TrunkKeyCode = VehicleDetails.TrunkKeyCode.Text;
            SaleVehicle.Weight = Convert.ToInt32(VehicleDetails.Weight.Text);
            SaleVehicle.LicensePlate = VehicleDetails.LicensePlate.Text;
            SaleVehicle.LicenseState = VehicleDetails.LicenseState.Text;
            SaleVehicle.LotLocation = VehicleDetails.LotLocation.Text;
            SaleVehicle.Style = VehicleDetails.Style.Text;
            SaleVehicle.ModelCode = VehicleDetails.ModelCode.Text;
            //SaleVehicle.LicenseExpirationDate = VehicleDetails.LicenseExpirationDate.Date.ToShortDateString();
            // Update values from the vehicle pricing view model
            SaleVehicle.MSRP = VehiclePricing.MSRP.Amount;
            SaleVehicle.InventoryPrice = VehiclePricing.InventoryPrice.Amount;
            SaleVehicle.ListPrice = VehiclePricing.ListPrice.Amount;
            SaleVehicle.InternetPrice = VehiclePricing.InternetPrice.Amount;
            SaleVehicle.AccountingCost = VehiclePricing.AccountingCost.Amount;
            SaleVehicle.ACV = VehiclePricing.ACV.Amount;
            SaleVehicle.AddedCosts = VehiclePricing.AddedCosts.Amount;
            SaleVehicle.Advertising = VehiclePricing.Advertising.Amount;
            SaleVehicle.Reconditioning = VehiclePricing.Reconditioning.Amount;
            SaleVehicle.Holdback = VehiclePricing.Holdback.Amount;
            SaleVehicle.DealerPack = VehiclePricing.DealerPack.Amount;
            SaleVehicle.BuyerFee = VehiclePricing.BuyerFee.Amount;
            SaleVehicle.InvoicePrice = VehiclePricing.InvoicePrice.Amount;
            SaleVehicle.DealerPackPercentage = VehiclePricing.DealerPackPercentage.Amount;
            
            //SaleVehicle.

        }

        private void UpdateSalesFinanceDM()
        {

            // Update salesFinance view model


            SalesFinanceDeal.SellingPrice = SaleVehicle.ListPrice;
            SalesFinanceDeal.Term = SalesSummary.Term.Number;
            SalesFinanceDeal.APR = SalesSummary.APR.Amount;
            SalesFinanceDeal.EffectiveAPR = SalesSummary.EffectiveAPR.Amount;
            SalesFinanceDeal.MSRP = SaleVehicle.MSRP;
            SalesFinanceDeal.BasePrice = SaleVehicle.InventoryPrice;
            SalesFinanceDeal.AmountFinanced = DeskingTotals.Total.Amount;
            //SalesFinanceDeal.FinanceCharge = TruthinLending.FinanceCharge.Amount;
            //SalesFinanceDeal.TotalOfPayments = TruthinLending.TotalOfPayments.Amount;
            //SalesFinanceDeal.Payment = TruthinLending.Payment.Amount;
            //SalesFinanceDeal.LastPayment = TruthinLending.FinalPayment.Amount;
            //SalesFinanceDeal.TotalBackAdds = DeskingTotals.BackOptions.Amount;
            //SalesFinanceDeal.TotalFrontAdds = DeskingTotals.FrontOptions.Amount;
            //SalesFinanceDeal.Maintenance = 0;
            //SalesFinanceDeal.TotalTaxes =  DeskingTotals.Taxes.Amount;
            SalesFinanceDeal.DaysTo1stPayment = SalesSummary.DaysToFirstPayment.Number;
            SalesFinanceDeal.Status = "Working";
            SalesFinanceDeal.DealDate = SalesSummary.PurchaseDate.Date;
            SalesFinanceDeal.FirstPaymentDate = SalesFinanceDeal.DealDate.Date.AddDays(SalesFinanceDeal.DaysTo1stPayment);
            SalesFinanceDeal.LastPaymentDate = SalesSummary.PaymentDate.Date.AddMonths(SalesSummary.Term.Number-1);
            SalesFinanceDeal.NumberOfPayments = SalesSummary.Term.Number;
            SalesFinanceDeal.PaymentType = Convert.ToString(SalesSummary.SelectedPaymentType);
            SalesFinanceDeal.SaleType = Convert.ToString(SalesSummary.SelectedSaleType);
            //SalesFinanceDeal.TotalOfficialFees = DeskingTotals.Fees.Amount;
            //SalesFinanceDeal.ServiceContract = DeskingTotals.Service.Amount;
            //SalesFinanceDeal.Gap = DeskingTotals.Gap.Amount;
            //SalesFinanceDeal.LAHInsurance = DeskingTotals.CreditInsurance.Amount;
            SalesFinanceDeal.TotalCashDown = DeskingTotals.Cash.Amount;
            SalesFinanceDeal.TotalRebates = DeskingTotals.Rebates.Amount;
            SalesFinanceDeal.TotalAllowance = DeskingTotals.TradeAllowance.Amount;
            SalesFinanceDeal.TotalDown = SalesFinanceDeal.TotalCashDown + SalesFinanceDeal.TotalRebates + SalesFinanceDeal.TotalAllowance;


        }







        /// <summary>
        /// Updates a specific value from the client data store for the user profile details
        /// and attempts to update the server to match those details.
        /// For example, updating the first name of the user.
        /// </summary>
        /// <param name="displayName">The display name for logging and display purposes of the property we are updating</param>
        /// <param name="propertyToUpdate">The property from the <see cref="LoginCredentialsDataModel"/> to be updated</param>
        /// <param name="newValue">The new value to update the property to</param>
        /// <param name="setApiModel">Sets the correct property in the <see cref="UpdateUserProfileApiModel"/> model that this property maps to</param>
        /// <returns></returns>
        private async Task<bool> UpdateSalesFinanceValueAsync(string displayName, Expression<Func<SalesFinanceDataModel, string>> propertyToUpdate, string newValue, Action<SalesFinanceDataModel, string> saveDeal)
        {
            // Log it
            Logger.LogDebugSource($"Saving {displayName}...");

            // Get the current known credentials
            var salesfinance = await ClientDataStore.GetSalesFinanceDealAsync(SalesFinanceDeal.DealNumber);

            // Get the property to update from the credentials
            var toUpdate = propertyToUpdate.GetPropertyValue(salesfinance);

            // Log it
            Logger.LogDebugSource($"{displayName} currently {toUpdate}, updating to {newValue}");

            // Check if the value is the same. If so...
            if (toUpdate == newValue)
            {
                // Log it
                Logger.LogDebugSource($"{displayName} is the same, ignoring");

                // Return true
                return true;
            }

            // Set the property
            propertyToUpdate.SetPropertyValue(newValue, salesfinance);

            // Create update details
            var updateApiModel = new SalesFinanceDataModel();

            // Ask caller to set appropriate value
            ;

            //var result = true;
            //// Update the server with the details
            //var result = await WebRequests.PostAsync<ApiResponse>(
            //    // Set URL
            //    RouteHelpers.GetAbsoluteRoute(ApiRoutes.UpdateUserProfile),
            //    // Pass the Api model
            //    updateApiModel,
            //    // Pass in user Token
            //    bearerToken: credentials.Token);

            //// If the response has an error...
            //if (await result.HandleErrorIfFailedAsync($"Update {displayName}"))
            //{
            //    // Log it
            //    Logger.LogDebugSource($"Failed to update {displayName}. {result.ErrorMessage}");

            //    // Return false
            //    return false;
            //}

            // Log it
            Logger.LogDebugSource($"Successfully updated {displayName}. Saving to local database cache...");

            // Store the new user credentials the data store
            await ClientDataStore.SaveSalesRecordAsync(salesfinance, DbTableNames.SalesFinance);

            // Return successful
            return true;
        }

        #endregion

    }

}
