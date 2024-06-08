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
        /// Indicates if the settings details are currently being loaded
        /// </summary>
        public bool SalesDealRecallPageLoading { get; set; }

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

            // Add a new record to the SalesFinance table
            SalesDeal = await ClientDataStore.CreateSalesFinanceDeal();

            // Create new instance of sales desking view model
            ViewModelSalesFinance.SalesFinanceDeal = SalesDeal;

            // Create new sales search records
            var salesDealItem = new SalesDealsItemDataModel
            {
                DealNumber = SalesDeal.DealNumber,
                CreatedDate = SalesDeal.DealDate,
                DealDate = SalesDeal.DealDate,
                LastActivityDate = SalesDeal.DealDate,
                IsActive=true,
                IsFinalized=false,
                Status="Quote",

            };

            await ClientDataStore.AddNewSalesRecordAsync(salesDealItem, DbTableNames.SalesDealsInfo);

            ViewModelSalesFinance.SalesDealsItem = salesDealItem;

            // Go to sales desking page
            ViewModelApplication.GoToPage(ApplicationPage.SalesFinance, ViewModelSalesFinance);

        }

        private async Task RecallSalesDealAsync(object salesDeal)
        {
            if (!(salesDeal is SalesDealsItemDataModel))
                return;

            ViewModelSalesFinance.SalesDealsItem = (SalesDealsItemDataModel)salesDeal;            
            ViewModelSalesFinance.Customer = await ClientDataStore.GetCustomerAsync(ViewModelSalesFinance.SalesDealsItem?.BuyerNumber);
            ViewModelSalesFinance.SecondCustomer = await ClientDataStore.GetCustomerAsync(ViewModelSalesFinance.SalesDealsItem?.CoBuyerNumber);
            ViewModelSalesFinance.SaleVehicle = await ClientDataStore.GetVehicleInventoryAsync(ViewModelSalesFinance.SalesDealsItem?.StockNumber);
            ViewModelSalesFinance.SalesFinanceDeal = await ClientDataStore.GetSalesFinanceDealAsync(mDealNumber);

            // Go to sales desking page
            ViewModelApplication.GoToPage(ApplicationPage.SalesFinance, ViewModelSalesFinance);

        }

        #endregion

        #region Private Helpers

        #endregion

    }

}
