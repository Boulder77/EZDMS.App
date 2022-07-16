using Dna;
using EZDMS.App.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using static EZDMS.App.DI;
using static Dna.FrameworkDI;

namespace EZDMS.App
{
    /// <summary>
    /// The view model for the <see cref="DialogCustomerSelect"/>
    /// <summary>
    public class VehicleSelectDialogViewModel : BaseDialogViewModel
    {

        #region Private Members

        /// <summary>
        /// The vehicle items for the list
        /// </summary>
        protected List<VehicleInventoryDataModel> mItems;

        /// <summary>
        /// The vehicle selected from the list
        /// </summary>
        private VehicleInventoryDataModel mSelectedVehicle;

        /// <summary>
        /// The stock number selected from the list
        /// </summary>
        private string mStockNumber;

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
        /// The customer items for the list that include any search filtering
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
                mStockNumber = mSelectedVehicle.StockNumber;
            }
        }

        /// <summary>
        /// Indicates if the customer dialog window is currently being loaded
        /// </summary>
        public bool VehicleWindowLoading { get; set; }

        /// <summary>
        /// The string for the entry count label
        /// </summary>
        public string EntryCount { get; set; }

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

        /// <summary>
        /// The command to select a vehicle
        /// </summary>
        public ICommand SelectVehicleCommand { get; set; }

        /// <summary>
        /// The command to search the list
        /// </summary>
        public ICommand SearchVehicleCommand { get; set; }

        /// <summary>
        /// The command to search the list
        /// </summary>
        public ICommand ClearSearchCommand { get; set; }

        /// <summary>
        /// The command to cancel the selection of a vehicle and exit the window
        /// </summary>
        public ICommand CancelSelectCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public VehicleSelectDialogViewModel()
        {

            // Create commands
            SelectVehicleCommand = new RelayCommand(async () => await SelectVehicleAsync(SelectedVehicle));
            Task.Run(GetVehiclesListAsync);

        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Gets the vehicle list from the data store
        /// </summary>
        /// <returns></returns>
        public async Task GetVehiclesListAsync()
        {
            // Sets items with the vehicle list
            await RunCommandAsync(() => VehicleWindowLoading, async () =>
            {
                Items = await ClientDataStore.GetVehicleInventoryListAsync();

            });
        }

        #endregion

        #region Private Helpers

        private async Task SelectVehicleAsync(object mVehicle)
        {

            // return 
            if (!(mVehicle is VehicleInventoryDataModel))
                return;

            //var mNewVehicle = await ClientDataStore.GetVehicleInventoryAsync(mStockNumber);

            // set view model                
            ViewModelSalesFinance.SaleVehicle = (mVehicle as VehicleInventoryDataModel);

            await ViewModelSalesFinance.UpdateSalesDealItemAsync(mVehicle, "S");

            CloseAction();
            
        }
                
        #endregion

    }
}
