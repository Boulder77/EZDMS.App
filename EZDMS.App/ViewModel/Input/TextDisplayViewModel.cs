using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EZDMS.App
{
    /// <summary>
    /// The view model for a text entry to edit a string value
    /// <summary>
    public class TextDisplayViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The label to identify what this text is for
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The current displayed text
        /// </summary>
        public string DisplayText { get; set; }        

        #endregion

        

        #region Constructor 

        /// <summary>
        /// Default constructor
        /// </summary>
        public TextDisplayViewModel()
        {
        
        }

        #endregion

     
    }
}
