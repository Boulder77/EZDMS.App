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
        /// The customer middle name
        /// </summary>
        public TextEntryViewModel MiddleName { get; set; }

        /// <summary>
        /// The customer last name
        /// </summary>
        public TextEntryViewModel LastName { get; set; }

        /// <summary>
        /// The customer street address
        /// </summary>
        public TextEntryViewModel StreetAddress { get; set; }

        /// <summary>
        /// The customer city
        /// </summary>
        public TextEntryViewModel City { get; set; }

        /// <summary>
        /// The customer county
        /// </summary>
        public TextEntryViewModel County { get; set; }

        /// <summary>
        /// The customer state
        /// </summary>
        public States State { get; set; }

        /// <summary>
        /// The customer zip code
        public TextEntryViewModel Zip { get; set; }      

        /// <summary>
        /// The customer home phone number
        /// </summary>
        public TextEntryViewModel HomePhone { get; set; }

        /// <summary>
        /// The customer work phone number
        /// </summary>
        public TextEntryViewModel WorkPhone { get; set; }

        /// <summary>
        /// The customer cell phone number
        /// </summary>
        public TextEntryViewModel CellPhone { get; set; }

        /// <summary>
        /// The customer date of birth
        /// </summary>
        public DateSelectionViewModel DateOfBirth { get; set; }

        /// <summary>
        /// The customer email
        /// </summary>
        public TextEntryViewModel Email { get; set; }

        /// <summary>
        /// The type of email
        /// </summary>
        public EmailType EmailType { get; set; }

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
