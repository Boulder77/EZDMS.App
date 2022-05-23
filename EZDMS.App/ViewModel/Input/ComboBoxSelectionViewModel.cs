using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EZDMS.App
{
    /// <summary>
    /// The view model for a text entry to edit a string value
    /// <summary>
    public class ComboBoxSelectionViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The label to identify what this combo box is for
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The current items displayed in the combo box selections
        /// </summary>
        public IEnumerable<object> Items { get; set; }

        /// <summary>
        /// The combo box selected item
        /// </summary>
        public string SelectedItem { get; set; } 

        #endregion

        #region Constructor 

        /// <summary>
        /// Default constructor
        /// </summary>
        public ComboBoxSelectionViewModel()
        {
        
        }

        #endregion

    }
}
