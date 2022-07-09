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
    public class CustomerSelectDialogViewModel : BaseDialogViewModel
    {

        #region Private Members

        /// <summary>
        /// The customer items for the list
        /// </summary>
        protected List<CustomerItemDataModel> mItems;

        /// <summary>
        /// The customer selected from the list
        /// </summary>
        private CustomerItemDataModel mSelectedCustomer;

        /// <summary>
        /// The customer number selected from the list
        /// </summary>
        private string mCustomerNumber;

        #endregion

        #region Public Properties

        public List<CustomerItemDataModel> Items
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
                FilteredItems = new ObservableCollection<CustomerItemDataModel>(mItems);

            }
        }

        /// <summary>
        /// The customer items for the list that include any search filtering
        /// </summary>
        public ObservableCollection<CustomerItemDataModel> FilteredItems { get; set; }

        /// <summary>
        /// The customer record selected from the list
        /// </summary>
        public CustomerItemDataModel SelectedCustomer
        {
            get => mSelectedCustomer;
            set
            {
                if (mSelectedCustomer == value)
                    return;

                mSelectedCustomer = value;
                mCustomerNumber = mSelectedCustomer.Number;
            }
        }

        /// <summary>
        /// Indicates if the customer dialog window is currently being loaded
        /// </summary>
        public bool CustomerWindowLoading { get; set; }

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
        public CustomerSelectDialogViewModel()
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
            await RunCommandAsync(() => CustomerWindowLoading, async () =>
            {
                var mList = await ClientDataStore.GetCustomersAsync();

                var mNewList = new List<CustomerItemDataModel>();

                foreach (var item in mList)
                {
                    if (!(item is CustomerDataModel))
                        return;

                    var newItem = new CustomerItemDataModel
                    {
                        Number = item.Number,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Business = item.BusinessName,
                        Address = $"{item.StreetAddress} {item.City} {item.State} {item.Zip}",
                        Email = item.Email,
                        PhoneNumber = item.HomePhone,
                        Status = item.Status,
                    };

                    mNewList.Add(newItem);

                }

                Items = mNewList;
            });
        }

        #endregion

        #region Private Helpers

        private async Task SelectCustomerAsync(object mCustomer, string mType)
        {

            // return 
            if (!(mCustomer is CustomerItemDataModel))
                return;

            var mNewCustomer = await ClientDataStore.GetCustomerAsync(mCustomerNumber);

            if (mType == "C")

                // set view model
                ViewModelSalesFinance.SecondCustomer = (CustomerDataModel)mNewCustomer;
            else
                ViewModelSalesFinance.Customer = (CustomerDataModel)mNewCustomer;

            await ViewModelSalesFinance.UpdateSalesDealItemAsync(mNewCustomer, "B");

            CloseAction();
        }

        
        #endregion


    }
}
