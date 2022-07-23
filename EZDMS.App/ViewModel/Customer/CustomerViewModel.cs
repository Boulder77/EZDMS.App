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
        public TextInputViewModel FirstName { get; set; }

        /// <summary>
        /// The business name
        /// </summary>
        public TextInputViewModel Business { get; set; }

        /// <summary>
        /// The customer last name
        /// </summary>
        public TextInputViewModel LastName { get; set; }

        /// <summary>
        /// The customer full address
        /// </summary>
        public TextInputViewModel Address { get; set; }
                
        /// <summary>
        /// The customer phone number
        /// </summary>
        public TextInputViewModel Phone { get; set; }

        /// <summary>
        /// The customer email
        /// </summary>
        public TextInputViewModel Email { get; set; }

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
