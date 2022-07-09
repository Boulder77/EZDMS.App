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
    /// The view model for a sales deal card control
    /// </summary>
    public class CustomerViewModel : BaseViewModel
    {

        #region Public Properties             

        /// <summary>
        /// The customer first name
        /// </summary>
        public TextEntryViewModel FirstName { get; set; }

        /// <summary>
        /// The business name
        /// </summary>
        public TextEntryViewModel Business { get; set; }

        /// <summary>
        /// The customer last name
        /// </summary>
        public TextEntryViewModel LastName { get; set; }

        /// <summary>
        /// The customer full address
        /// </summary>
        public TextEntryViewModel Address { get; set; }
                
        /// <summary>
        /// The customer phone number
        /// </summary>
        public TextEntryViewModel Phone { get; set; }

        /// <summary>
        /// The customer email
        /// </summary>
        public TextEntryViewModel Email { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public CustomerViewModel()
        {

           

        }

        #endregion

    }

}
