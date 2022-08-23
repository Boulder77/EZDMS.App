
using Dna;
using EZDMS.App.Core;
using static EZDMS.App.Core.CoreDI;
using static EZDMS.App.DI;
using static Dna.FrameworkDI;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace EZDMS.App
{
    /// <summary>
    /// The view model for the overview front add list
    /// <summary>
    public class FrontAddListViewModel : BaseViewModel
    {

        #region Protected Members

        /// <summary>
        /// The front add items for the list
        /// </summary>
        protected ObservableCollection<FrontAddItemViewModel> mFrontAddItems;

        /// <summary>
        /// The front add datamodel list
        /// </summary>
        protected List<FrontAddsDataModel> mFrontAddList;

        #endregion

        /// <summary>
        /// The front add items list
        /// </summary>
        public ObservableCollection<FrontAddItemViewModel> FrontAddItems         
        {
            
            get => mFrontAddItems;
            
            set
            {
                // Make sure list has changed
                if (mFrontAddItems == value)
                    return;

                // Update value
                mFrontAddItems = value;

                // Update filtered list to match
                FilteredFrontAddItems = new ObservableCollection<FrontAddItemViewModel>(mFrontAddItems);
            }
        }

        /// <summary>
        /// The chat thread items for the list that include any search filtering
        /// </summary>
        public ObservableCollection<FrontAddItemViewModel> FilteredFrontAddItems { get; set; }

        /// <summary>
        /// The front add datamodel list
        /// </summary>
        public List<FrontAddsDataModel> FrontAddList
        {
            get => mFrontAddList;
            set
            {
                // Make sure list has changed
                if (mFrontAddList == value)
                    return;

                // Update value
                mFrontAddList = value;

                // Update filtered list to match
                FilteredFrontAddList = new List<FrontAddsDataModel>(mFrontAddList);
            }
        }

        /// <summary>
        /// The chat thread items for the list that include any search filtering
        /// </summary>
        public List<FrontAddsDataModel> FilteredFrontAddList { get; set; }

        /// <summary>
        /// The total retail of all front adds 
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// The flag indicating that the items are loading
        /// </summary>
        public bool Loading { get; set; }

        #region Constructor

        public FrontAddListViewModel()
        {


        }

        #endregion


        /// <summary>
        /// Initialize products view models and controls 
        /// </summary>
        /// <returns></returns>
        public async void LoadFrontAddsAsync()
        {
            
            FrontAddList = await ClientDataStore.GetFrontAddsAsync();

        }

    }
}
