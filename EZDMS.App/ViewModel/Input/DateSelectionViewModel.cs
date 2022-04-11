using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EZDMS.App
{
    /// <summary>
    /// The view model for a date selection control
    /// <summary>
    public class DateSelectionViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The label to identify what this date is for
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The current selected date
        /// </summary>
        public DateTime Date { get; set; }

        #endregion

        #region Constructor 

        /// <summary>
        /// Default constructor
        /// </summary>
        public DateSelectionViewModel()
        {
        
        }

        #endregion

    }
}
