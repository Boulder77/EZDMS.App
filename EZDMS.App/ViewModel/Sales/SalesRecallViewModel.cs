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
    public class SalesRecallViewModel : BaseViewModel
    {
        #region Private Members

        /// <summary>
        /// The sales search deals items for the list
        /// </summary>
        protected List<SalesDealsItemDataModel> mItems;

        /// <summary>
        /// The deal item selected from the list
        /// </summary>
        private SalesDealsItemDataModel mSelectedDeal;

        /// <summary>
        /// The deal number selected from the list
        /// </summary>
        private int mDealNumber;


        #endregion
        
        #region Public Properties

        public List<SalesDealsItemDataModel> Items
        {

            get => mItems;
            set
            {
                // Make sure list has changed
                if (mItems == value)
                    return;

                // Update value
                mItems = value;

                // Update filtered list to match
                FilteredItems = new ObservableCollection<SalesDealsItemDataModel>(mItems);

            }
        }

        /// <summary>
        /// The chat thread items for the list that include any search filtering
        /// </summary>
        public ObservableCollection<SalesDealsItemDataModel> FilteredItems { get; set; }

        /// <summary>
        /// The deal number selected from the list
        /// </summary>
        public SalesDealsItemDataModel SelectedDeal
        {
            get => mSelectedDeal;
            set
            {
                if (mSelectedDeal == value)
                    return;

                mSelectedDeal = value;
                mDealNumber = mSelectedDeal.DealNumber;
            }
        }


        public SalesFinanceDataModel SalesDeal { get; set; }

        /// <summary>
        /// Indicates if the deal recall details are currently being loaded
        /// </summary>
        public bool SalesDealRecallPageLoading { get; set; }

        /// <summary>
        /// Indicates if new records are being created
        /// </summary>
        public bool NewRecords { get; set; }

        #endregion

        #region Public Commands

        /// <summary>
        /// The command to create a new deal
        /// </summary>
        public ICommand NewDealCommand { get; set; }

        /// <summary>
        /// The command to recall a saved deal
        /// </summary>
        public ICommand RecallDealCommand { get; set; }
              
        #endregion
                
        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SalesRecallViewModel()
        {
            // Create commands
            NewDealCommand = new RelayCommand(async () => await CreateNewSalesDealAsync());
            RecallDealCommand = new RelayCommand(async () => await RecallSalesDealAsync(SelectedDeal));

            Task.Run(GetSalesRecallDealsAsync);
           
        }

        #endregion

        #region Command Methods

        public async Task GetSalesRecallDealsAsync()
        {

            // Store single transcient instance of client data store
            await RunCommandAsync(() => SalesDealRecallPageLoading, async () =>
            {
                Items = await ClientDataStore.GetSalesDealRecallsAsync();
            });

        }

        public async Task CreateNewSalesDealAsync()
        {

            await RunCommandAsync(() => SalesDealRecallPageLoading, async () =>
            {
                // Add a new record to the SalesFinance table
                SalesDeal = await ClientDataStore.CreateSalesFinanceDeal();

                await CreateDefaultFeesAsync(SalesDeal.DealNumber);

                await CreateDefaultTaxesAsync(SalesDeal.DealNumber);


                // Create new instance of sales desking view model
                ViewModelSalesFinance.SalesFinanceDeal = SalesDeal;

                // Create new sales search records
                var salesDealItem = new SalesDealsItemDataModel
                {
                    DealNumber = SalesDeal.DealNumber,
                    CreatedDate = SalesDeal.DealDate,
                    DealDate = SalesDeal.DealDate,
                    LastActivityDate = SalesDeal.DealDate,
                    IsActive = true,
                    IsFinalized = false,
                    Status = "Quote",

                };

                await ClientDataStore.AddNewSalesRecordAsync(salesDealItem, DbTableNames.SalesDealsInfo);

                ViewModelSalesFinance.SalesDealsItem = salesDealItem;

            });

            // Go to sales desking page
            ViewModelApplication.GoToPage(ApplicationPage.SalesFinance, ViewModelSalesFinance);

        }

        private async Task RecallSalesDealAsync(object salesDeal)
        {

            await RunCommandAsync(() => SalesDealRecallPageLoading, async () =>
            {
                if (!(salesDeal is SalesDealsItemDataModel))
                    return;

                ViewModelSalesFinance.SalesDealsItem = (SalesDealsItemDataModel)salesDeal;
                ViewModelSalesFinance.Customer = await ClientDataStore.GetCustomerAsync(ViewModelSalesFinance.SalesDealsItem?.BuyerNumber);
                ViewModelSalesFinance.SecondCustomer = await ClientDataStore.GetCustomerAsync(ViewModelSalesFinance.SalesDealsItem?.CoBuyerNumber);
                ViewModelSalesFinance.SaleVehicle = await ClientDataStore.GetVehicleInventoryAsync(ViewModelSalesFinance.SalesDealsItem?.StockNumber);
                ViewModelSalesFinance.SalesFinanceDeal = await ClientDataStore.GetSalesFinanceDealAsync(mDealNumber);

                //var salesTaxesDM = await ClientDataStore.GetSalesTaxesAsync(mDealNumber);
                //if (salesTaxesDM == null)
                //{

                //    await CreateDefaultTaxesAsync(mDealNumber);

                //}

            });

            // Go to sales desking page
            ViewModelApplication.GoToPage(ApplicationPage.SalesFinance, ViewModelSalesFinance);

        }

        #endregion

        #region Private Helpers

        private async Task CreateDefaultFeesAsync(int dealNumber)
        {
            if (dealNumber == 0)
                return;

            await RunCommandAsync(() => NewRecords, async () =>
            {
                
                // Create new licensing record from default licensing info
                
                // Get default system licensing info
                var systemLicensing = await ClientDataStore.GetSystemLicensingAsync("STORE01");


                var newSalesLicensing = new SalesLicensingFeesDataModel
                {
                    DealNumber = dealNumber,
                    FeesInPayment = systemLicensing.LicenseFeeInPayment,
                    LicenseFee = systemLicensing.LicenseFee,
                    RegistrationFee = systemLicensing.RegistrationFee,
                    TitleFee = systemLicensing.TitleFee,
                    FilingFee = systemLicensing.FilingFee,
                    TempTagFee = systemLicensing.TempTagFee,
                    PlateFee = systemLicensing.PlateFee,
                    NotaryFee = systemLicensing.NotaryFee,
                    TransferFee = systemLicensing.TransferFee,
                };
                // Add licensing record to datastore
                await ClientDataStore.AddNewSalesRecordAsync(newSalesLicensing, DbTableNames.SalesLicensing);
                
                // Create new local fees records from default local fees info

                // Get default local fees info
                var systemLocalFees = await ClientDataStore.GetSystemLocalFeesAsync("STORE01");

                    // create new local fees dm
                    var newSalesLocalFees = new SalesLocalFeesDataModel
                    {
                        DealNumber = dealNumber,
                        DocumentationFee = systemLocalFees.DocumentationFee,
                        DocumentationFeeInPayment = systemLocalFees.DocumentationFeeInPayment,
                        DocumentationFeeTaxable = systemLocalFees.DocumentationFeeTaxable,
                        TireFee = systemLocalFees.TireFee,
                        TireFeeInPayment = systemLocalFees.TireFeeInPayment,
                        TireFeeTaxable = systemLocalFees.TireFeeTaxable,
                        InspectionFee = systemLocalFees.InspectionFee,
                        InspectionFeeInPayment = systemLocalFees.InspectionFeeInPayment,
                        InspectionFeeTaxable = systemLocalFees.InspectionFeeTaxable,
                        MessengerFee = systemLocalFees.MessengerFee,
                        MessengerFeeInPayment = systemLocalFees.MessengerFeeInPayment,
                        MessengerFeeTaxable = systemLocalFees.MessengerFeeTaxable,
                        BatteryFee = systemLocalFees.BatteryFee,
                        BatteryFeeInPayment = systemLocalFees.BatteryFeeInPayment,
                        BatteryFeeTaxable = systemLocalFees.BatteryFeeTaxable,
                        SmogToSellerFee = systemLocalFees.SmogToSellerFee,
                        SmogToSellerFeeInPayment = systemLocalFees.SmogToSellerFeeInPayment,
                        SmogToSellerFeeTaxable = systemLocalFees.SmogToSellerFeeTaxable,
                        DocStampsFee = systemLocalFees.DocStampsFee,
                        DocStampsFeeInPayment = systemLocalFees.DocStampsFeeInPayment,
                        DocStampsFeeTaxable = systemLocalFees.DocStampsFeeTaxable,
                        EVChargingFee = systemLocalFees.EVChargingFee,
                        EVChargingFeeInPayment = systemLocalFees.EVChargingFeeInPayment,
                        EVChargingFeeTaxable = systemLocalFees.EVChargingFeeTaxable,
                        StateInspectionFee = systemLocalFees.StateInspectionFee,
                        StateInspectionFeeInPayment = systemLocalFees.StateInspectionFeeInPayment,
                        StateInspectionFeeTaxable = systemLocalFees.StateInspectionFeeTaxable,
                        SmogStateFee = systemLocalFees.SmogStateFee,
                        SmogStateFeeInPayment = systemLocalFees.SmogStateFeeInPayment,
                        SmogStateFeeTaxable = systemLocalFees.SmogStateFeeTaxable,
                        SmogAbatementFee = systemLocalFees.SmogAbatementFee,
                        SmogAbatementFeeInPayment = systemLocalFees.SmogAbatementFeeInPayment,
                        SmogAbatementFeeTaxable = systemLocalFees.SmogAbatementFeeTaxable,
                        EmissionsFee = systemLocalFees.EmissionsFee,
                        EmissionsFeeInPayment = systemLocalFees.EmissionsFeeInPayment,
                        EmissionsFeeTaxable = systemLocalFees.EmissionsFeeTaxable,
                        ElectronicFilingFee = systemLocalFees.ElectronicFilingFee,
                        ElectronicFilingFeeInPayment = systemLocalFees.ElectronicFilingFeeInPayment,
                        ElectronicFilingFeeTaxable = systemLocalFees.ElectronicFilingFeeTaxable,
                        LocalFee1Name = systemLocalFees.LocalFee1Name,
                        LocalFee1 = systemLocalFees.LocalFee1,
                        LocalFee1InPayment = systemLocalFees.LocalFee1InPayment,
                        LocalFee1Taxable = systemLocalFees.LocalFee1Taxable,
                        LocalFee2Name = systemLocalFees.LocalFee2Name,
                        LocalFee2 = systemLocalFees.LocalFee2,
                        LocalFee2InPayment = systemLocalFees.LocalFee2InPayment,
                        LocalFee2Taxable = systemLocalFees.LocalFee2Taxable,
                        LocalFee3Name = systemLocalFees.LocalFee3Name,
                        LocalFee3 = systemLocalFees.LocalFee3,
                        LocalFee3InPayment = systemLocalFees.LocalFee3InPayment,
                        LocalFee3Taxable = systemLocalFees.LocalFee3Taxable,
                        LocalFee4Name = systemLocalFees.LocalFee4Name,
                        LocalFee4 = systemLocalFees.LocalFee4,
                        LocalFee4InPayment = systemLocalFees.LocalFee4InPayment,
                        LocalFee4Taxable = systemLocalFees.LocalFee4Taxable,
                        LocalFee5Name = systemLocalFees.LocalFee5Name,
                        LocalFee5 = systemLocalFees.LocalFee5,
                        LocalFee5InPayment = systemLocalFees.LocalFee5InPayment,
                        LocalFee5Taxable = systemLocalFees.LocalFee5Taxable,
                        LocalFee6Name = systemLocalFees.LocalFee6Name,
                        LocalFee6 = systemLocalFees.LocalFee6,
                        LocalFee6InPayment = systemLocalFees.LocalFee6InPayment,
                        LocalFee6Taxable = systemLocalFees.LocalFee6Taxable,
                        LocalFee7Name = systemLocalFees.LocalFee7Name,
                        LocalFee7 = systemLocalFees.LocalFee7,
                        LocalFee7InPayment = systemLocalFees.LocalFee7InPayment,
                        LocalFee7Taxable = systemLocalFees.LocalFee7Taxable,
                        LocalFee8Name = systemLocalFees.LocalFee8Name,
                        LocalFee8 = systemLocalFees.LocalFee8,
                        LocalFee8InPayment = systemLocalFees.LocalFee8InPayment,
                        LocalFee8Taxable = systemLocalFees.LocalFee8Taxable,
                        LocalFee9Name = systemLocalFees.LocalFee9Name,
                        LocalFee9 = systemLocalFees.LocalFee9,
                        LocalFee9InPayment = systemLocalFees.LocalFee9InPayment,
                        LocalFee9Taxable = systemLocalFees.LocalFee9Taxable,
                        LocalFee10Name = systemLocalFees.LocalFee10Name,
                        LocalFee10 = systemLocalFees.LocalFee10,
                        LocalFee10InPayment = systemLocalFees.LocalFee10InPayment,
                        LocalFee10Taxable = systemLocalFees.LocalFee10Taxable,

                    };


                // Add licensing record to datastore
                await ClientDataStore.AddNewSalesRecordAsync(newSalesLocalFees, DbTableNames.SalesLocalFees);               


            });       

        }


        private async Task CreateDefaultTaxesAsync(int dealNumber)
        {

            if (dealNumber == 0)
                return;

            await RunCommandAsync(() => NewRecords, async () =>
            {


                // Get the system tax info
                var systemTaxes = await ClientDataStore.GetSystemTaxesAsync("STORE01");

                // Exit if no system tax 
                if (systemTaxes == null)
                    return;

                var newSalesTax = new SalesTaxesDataModel
                {
                    DealNumber = dealNumber,
                    StateTaxActive = systemTaxes.StateTaxActive,
                    StateTaxRate = systemTaxes.StateTaxActive == true ? systemTaxes.StateTaxRate : 0,
                    StateTaxName = systemTaxes.StateTaxName,
                    CountyTaxActive = systemTaxes.CountyTaxActive,
                    CountyTaxRate = systemTaxes.CountyTaxActive == true ? systemTaxes.CountyTaxRate : 0,
                    CountyTaxName = systemTaxes.CountyTaxName,
                    CityTaxActive = systemTaxes.CountyTaxActive,
                    CityTaxRate = systemTaxes.CityTaxActive == true ? systemTaxes.CityTaxRate : 0,
                    CityTaxName = systemTaxes.CityTaxName,
                    OtherTaxName = systemTaxes.OtherTaxName,
                    OtherTaxActive = systemTaxes.OtherTaxActive,
                    OtherTaxRate = systemTaxes.OtherTaxActive == true ? systemTaxes.OtherTaxRate : 0,

                };

                // Save the sales taxes record
                await ClientDataStore.AddNewSalesRecordAsync(newSalesTax, DbTableNames.SalesTaxes);

            });

        }

        #endregion






    }

}
