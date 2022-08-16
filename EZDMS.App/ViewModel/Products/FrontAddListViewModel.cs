using System.Collections.Generic;

namespace EZDMS.App
{
    /// <summary>
    /// The view model for the overview front add list
    /// <summary>
    public class FrontAddListViewModel : BaseViewModel
    {

        /// <summary>
        /// The chat list items for the list
        /// </summary>
        public List<FrontAddItemViewModel> Items { get; set; }

        /// <summary>
        /// The total retail of all front adds 
        /// </summary>
        public decimal Total { get; set; }
    }
}
