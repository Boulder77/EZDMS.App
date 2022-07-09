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
    /// The view model for a customers list page
    /// </summary>
    public class CustomersListViewModel : BaseViewModel
    {

        #region Private Members

        /// <summary>
        /// The customer items for the list
        /// </summary>
        protected List<CustomerDataModel> mItems;

        /// <summary>
        /// The customer selected from the list
        /// </summary>
        private CustomerDataModel mSelectedCustomer;

        /// <summary>
        /// The customer ID selected from the list
        /// </summary>
        private int mCustomerID;

        #endregion
        
        #region Public Properties

        public List<CustomerDataModel> Items
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
                FilteredItems = new ObservableCollection<CustomerDataModel>(mItems);

            }
        }

        /// <summary>
        /// The customer items for the list that include any search filtering
        /// </summary>
        public ObservableCollection<CustomerDataModel> FilteredItems { get; set; }

        /// <summary>
        /// The customer record selected from the list
        /// </summary>
        public CustomerDataModel SelectedCustomer
        {
            get => mSelectedCustomer;
            set
            {
                if (mSelectedCustomer == value)
                    return;

                mSelectedCustomer = value;
                mCustomerID = mSelectedCustomer.ID;
            }
        }

        /// <summary>
        /// Indicates if the customers list are currently being loaded
        /// </summary>
        public bool CustomersListPageLoading { get; set; }

        /// <summary>
        /// The string for the entry count label
        /// </summary>
        public string EntryCount { get; set; }

        #endregion

        #region Public Commands

        /// <summary>
        /// The command to create a new customer
        /// </summary>
        public ICommand NewCustomerCommand { get; set; }

        /// <summary>
        /// The command to get a saved customer
        /// </summary>
        public ICommand GetCustomerCommand { get; set; }

        /// <summary>
        /// The command to select a customer
        /// </summary>
        public ICommand SelectCustomerCommand { get; set; }

        /// <summary>
        /// The command to search the customer list
        /// </summary>
        public ICommand SearchCustomerCommand { get; set; }

        /// <summary>
        /// The command to search the customer list
        /// </summary>
        public ICommand ClearSearchCommand { get; set; }

        /// <summary>
        /// The command to cancel the selection of a customer and exit the window
        /// </summary>
        public ICommand CancelSelectCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public CustomersListViewModel()
        {
            // Create commands

            SelectCustomerCommand = new RelayCommand(async () => await SelectCustomerAsync(SelectedCustomer, "B"));
            Task.Run(GetCustomersListAsync);
           
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Gets the customer list from the data store
        /// </summary>
        /// <returns></returns>
        public async Task GetCustomersListAsync()
        {
            // Sets items with the customer list
            await RunCommandAsync(() => CustomersListPageLoading, async () =>
            {  
                Items = await ClientDataStore.GetCustomersAsync();
            });
        }

        #endregion

        #region Private Helpers

        /// <summary>
        /// Select the customer item and update sales finance view model
        /// </summary>
        /// <param name="mCustomer"></param>
        /// <param name="mType"></param>
        /// <returns></returns>
        public async Task SelectCustomerAsync(object mCustomer, string mType)
        {
           
            // return 
            if (!(mCustomer is CustomerDataModel))

            // update view model
            if (mType == "C")
                
                ViewModelSalesFinance.SecondCustomer = (CustomerDataModel)mCustomer;
            else
                ViewModelSalesFinance.Customer = (CustomerDataModel)mCustomer;

            await Task.Delay(1);
            
        }

        #endregion

    }

}
