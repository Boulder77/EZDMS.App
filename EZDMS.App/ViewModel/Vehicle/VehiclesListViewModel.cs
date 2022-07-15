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
    /// The view model for a vehicles list page
    /// </summary>
    public class VehiclesListViewModel : BaseViewModel
    {
        #region Private Members

        /// <summary>
        /// The sales search deals items for the list
        /// </summary>
        protected List<VehicleInventoryDataModel> mItems;

        /// <summary>
        /// The deal item selected from the list
        /// </summary>
        private VehicleInventoryDataModel mSelectedVehicle;

        /// <summary>
        /// The vehicle ID selected from the list
        /// </summary>
        private int mVehicleID;


        #endregion
        
        #region Public Properties

        public List<VehicleInventoryDataModel> Items
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
                FilteredItems = new ObservableCollection<VehicleInventoryDataModel>(mItems);

            }
        }

        /// <summary>
        /// The chat thread items for the list that include any search filtering
        /// </summary>
        public ObservableCollection<VehicleInventoryDataModel> FilteredItems { get; set; }

        /// <summary>
        /// The vehicle record selected from the list
        /// </summary>
        public VehicleInventoryDataModel SelectedVehicle
        {
            get => mSelectedVehicle;
            set
            {
                if (mSelectedVehicle == value)
                    return;

                mSelectedVehicle = value;
                mVehicleID = mSelectedVehicle.ID;
            }
        }

        /// <summary>
        /// Indicates if the vehicles list is currently being loaded
        /// </summary>
        public bool VehiclesListPageLoading { get; set; }

        #endregion

        #region Public Commands

        /// <summary>
        /// The command to create a new vehicle
        /// </summary>
        public ICommand NewVehicleCommand { get; set; }

        /// <summary>
        /// The command to get a saved vehicle
        /// </summary>
        public ICommand GetVehicleCommand { get; set; }
              
        #endregion
                
        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public VehiclesListViewModel()
        {
            // Create commands
            //NewDealCommand = new RelayCommand(async () => await CreateNewSalesDealAsync());
            //RecallDealCommand = new RelayCommand(async () => await RecallSalesDealAsync(SelectedDeal));

            Task.Run(GetVehiclesListAsync);
           
        }

        #endregion

        #region Command Methods

        public async Task GetVehiclesListAsync()
        {
            // Store single transcient instance of client data store
            await RunCommandAsync(() => VehiclesListPageLoading, async () =>
            {
                Items = await ClientDataStore.GetVehicleInventoryListAsync();
            });

        }

        //public async Task CreateNewSalesDealAsync()
        //{

        //    // Add a new record to the SalesFinance table
        //    SalesDeal = await ClientDataStore.CreateSalesFinanceDeal();

        //    // Create new instance of sales desking view model
        //    ViewModelSalesFinance.SalesFinanceDeal = SalesDeal;

        //    // Go to sales desking page
        //    ViewModelApplication.GoToPage(ApplicationPage.SalesFinance, ViewModelSalesFinance);

        //}

        //private async Task RecallSalesDealAsync(object salesDeal)
        //{
        //    if (!(salesDeal is SalesDealsItemDataModel))
        //        return;

        //    ViewModelSalesFinance.SalesDealsItem = (SalesDealsItemDataModel)salesDeal;
        //    ViewModelSalesFinance.SalesFinanceDeal = await ClientDataStore.GetSalesFinanceDealAsync(mDealNumber);

        //    // Go to sales desking page
        //    ViewModelApplication.GoToPage(ApplicationPage.SalesFinance, ViewModelSalesFinance);

        //}

        #endregion

        #region Private Helpers

        #endregion

    }

}
