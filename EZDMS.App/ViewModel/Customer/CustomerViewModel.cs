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
        /// The customer full name
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// The customer number
        /// </summary>
        public TextEntryVertControl CustomerNumber { get; set; }

        /// <summary>
        /// The customer first name
        /// </summary>
        public TextEntryVertControl FirstName { get; set; }

        /// <summary>
        /// The customer middle name
        /// </summary>
        public TextEntryVertControl MiddleName { get; set; }

        /// <summary>
        /// The customer last name
        /// </summary>
        public TextEntryVertControl LastName { get; set; }

        /// <summary>
        /// The customer street address
        /// </summary>
        public TextEntryVertControl StreetAddress { get; set; }

        /// <summary>
        /// The customer city
        /// </summary>
        public TextEntryVertControl City { get; set; }

        /// <summary>
        /// The customer county
        /// </summary>
        public TextEntryVertControl County { get; set; }

        /// <summary>
        /// The customer state
        /// </summary>
        public TextEntryVertControl State { get; set; }

        /// <summary>
        /// The customer zip code
        public TextEntryVertControl Zip { get; set; }

        /// <summary>
        /// The customer home phone
        /// </summary>
        public TextEntryVertControl HomePhone { get; set; }

        /// <summary>
        /// The customer work phone
        /// </summary>
        public TextEntryVertControl WorkPhone { get; set; }

        /// <summary>
        /// The customer cell phone
        /// </summary>
        public TextEntryVertControl CellPhone { get; set; }

        /// <summary>
        /// The customer date of birth
        /// </summary>
        public DateSelectionControl DateOfBirth { get; set; }

        /// <summary>
        /// The customer created date
        /// </summary>
        public DateSelectionControl CreateDate { get; set; }

        /// <summary>
        /// The customer last activity date
        /// </summary>
        public DateSelectionControl LastActivityDate { get; set; }







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
