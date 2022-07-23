using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EZDMS.App
{
    /// <summary>
    /// The view model for a text entry to edit a string value
    /// <summary>
    public class TextInputViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The label to identify what this value is for
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The value of the text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Indicates if the current control is pending an update (in progress)
        /// </summary>
        public bool Working { get; set; }

        /// <summary>
        /// Indicates if the current control is pending an update (in progress)
        /// </summary>
        public bool Editable { get; set; } = true;


        /// <summary>
        /// The action to run when saving the text.
        /// Returns true if the commit was successful, or false otherwise.
        /// </summary>
        public Func<Task<bool>> CommitAction { get; set; }

        #endregion

        #region Constructor 

        /// <summary>
        /// Default constructor
        /// </summary>
        public TextInputViewModel()
        {


        }

        #endregion

    }
        
}
