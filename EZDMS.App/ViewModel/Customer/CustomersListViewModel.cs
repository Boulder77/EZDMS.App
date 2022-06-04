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
        /// The sales search deals items for the list
        /// </summary>
        protected List<CustomerDataModel> mItems;

        /// <summary>
        /// The deal item selected from the list
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
        /// The chat thread items for the list that include any search filtering
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
                if (SelectedCustomer == value)
                    return;

                SelectedCustomer = value;
                mCustomerID = mSelectedCustomer.ID;
            }
        }




        /// <summary>
        /// Indicates if the customers list are currently being loaded
        /// </summary>
        public bool CustomersListPageLoading { get; set; }

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
              
        #endregion
                
        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public CustomersListViewModel()
        {
            // Create commands
            //NewDealCommand = new RelayCommand(async () => await CreateNewSalesDealAsync());
            //RecallDealCommand = new RelayCommand(async () => await RecallSalesDealAsync(SelectedDeal));

            Task.Run(GetCustomersListAsync);
           
        }

        #endregion

        #region Command Methods

        public async Task GetCustomersListAsync()
        {

            // Store single transcient instance of client data store
            await RunCommandAsync(() => CustomersListPageLoading, async () =>
            {
                Items = await ClientDataStore.GetCustomersAsync();
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
