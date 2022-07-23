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
            StreetAddress = new TextInputViewModel { Label = "Address", Text = "129 Smith Valley Rd" };
            City = new TextInputViewModel { Label = "City", Text = "Fredonia" };
            State = States.OH;
            Zip = new TextInputViewModel { Label = "Zip", Text = "45011" };
            AddressType = AddressType.Physical;
            County = new TextInputViewModel { Label = "County", Text = "Butler" };
            CountyCode = new TextInputViewModel { Label = "County Code",Text = "12345" };

        }

        #endregion
    }
}
