using System.Collections.Generic;
using System;
using EZDMS.App.Core;

namespace EZDMS.App
{
    /// <summary>
    /// The design-time data for a <see cref="CustomerAddressViewModel"/>
    /// </summary>
    public class CustomerAddressDesignModel : CustomerAddressViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static CustomerAddressDesignModel Instance => new CustomerAddressDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public CustomerAddressDesignModel()

        {
            AddressDescription = "Physical Address (Primary)";
            StreetAddress = new TextEntryViewModel { Label = "Address", OriginalText = "129 Smith Valley Rd" };
            City = new TextEntryViewModel { Label = "City", OriginalText = "Fredonia" };
            State = States.OH;
            Zip = new TextEntryViewModel { Label = "Zip", OriginalText = "45011" };
            AddressType = AddressType.Physical;
            County = new TextEntryViewModel { Label = "County", OriginalText = "Butler" };
            CountyCode = new TextEntryViewModel { Label = "County Code",OriginalText = "12345" };

        }

        #endregion
    }
}
