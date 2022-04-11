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
        protected List<SalesDealRecallDataModel> mItems;

        /// <summary>
        /// The deal number selected from the list
        /// </summary>
        private SalesDealRecallDataModel mSelectedDeal;

        #endregion

        public List<SalesDealRecallDataModel> Items { 
            
            get => mItems;
            set
            {
                // Make sure list has changed
                if (mItems == value)
                    return;

                // Update value
                mItems = value;

                // Update filtered list to match
                FilteredItems = new ObservableCollection<SalesDealRecallDataModel>(mItems);


            }
        }

        /// <summary>
        /// The chat thread items for the list that include any search filtering
        /// </summary>
        public ObservableCollection<SalesDealRecallDataModel> FilteredItems { get; set; }

        /// <summary>
        /// The deal number selected from the list
        /// </summary>
        public SalesDealRecallDataModel SelectedDeal 
        { get => mSelectedDeal;
            set
            {
                if (mSelectedDeal == value)
                    return;
                
                mSelectedDeal = value;                
            }
        }



        /// <summary>
        /// Indicates if the settings details are currently being loaded
        /// </summary>
        public bool SalesDealRecallPageLoading { get; set; }



        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SalesRecallViewModel()
        {
            // Create commands

            Task.Run(GetSalesRecallDealsAsync);



        }

        #endregion

        public async Task GetSalesRecallDealsAsync()
        {

            // Store single transcient instance of client data store
            await RunCommandAsync(() => SalesDealRecallPageLoading, async () =>
            {
                Items = await ClientDataStore.GetSalesDealRecallsAsync();
            });

        }
    }
}
