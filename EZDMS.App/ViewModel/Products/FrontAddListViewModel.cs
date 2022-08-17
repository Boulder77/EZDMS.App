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
        /// The chat thread items for the list
        /// </summary>
        protected ObservableCollection<FrontAddItemViewModel> mItems;


        #endregion

        /// <summary>
        /// The chat list items for the list
        /// </summary>
        public ObservableCollection<FrontAddItemViewModel> Items { get; set; }

        /// <summary>
        /// The total retail of all front adds 
        /// </summary>
        public decimal Total { get; set; }
    }
}
