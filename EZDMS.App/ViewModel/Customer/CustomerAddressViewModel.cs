using Dna;
using EZDMS.App.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using static EZDMS.App.DI;

namespace EZDMS.App
{
    /// <summary>
    /// The view model for a customer address control
    /// </summary>
    public class CustomerAddressViewModel : BaseViewModel
    {

        #region Public Properties             

        /// <summary>
        /// The list US States/Providences
        /// </summary>
        public IEnumerable<States> AllStates => Enum.GetValues(typeof(States)).Cast<States>();

        /// <summary>
        /// The list of address types
        /// </summary>
        public IEnumerable<AddressType> AddressTypes => Enum.GetValues(typeof(AddressType)).Cast<AddressType>();

        /// <summary>
        /// The description of the address
        /// </summary>
        public string AddressDescription { get; set; }

        /// <summary>
        /// The customer address type
        /// </summary>
        public AddressType AddressType { get; set; }
        
        /// <summary>
        /// The customer street address
        /// </summary>
        public TextEntryViewModel StreetAddress { get; set; }

        /// <summary>
        /// The customer city
        /// </summary>
        public TextEntryViewModel City { get; set; }

        /// <summary>
        /// The customer state
        /// </summary>
        public States State { get; set; }
             
        /// <summary>
        /// The customer zip code
        public TextEntryViewModel Zip { get; set; }

        /// <summary>
        /// The customer county
        /// </summary>
        public TextEntryViewModel County { get; set; }

        /// <summary>
        /// The customer county code
        /// </summary>
        public TextEntryViewModel CountyCode { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public CustomerAddressViewModel()
        {
           
        }

        #endregion

    }

}
