﻿using Dna;
using EZDMS.App.Core;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using static EZDMS.App.DI;

namespace EZDMS.App
{
    /// <summary>
    /// The view model for a customer card control
    /// </summary>
    public class CustomerCardViewModel : BaseViewModel
    {

        #region Public Properties
               
        /// <summary>
        /// The customer number
        /// </summary>
        public TextInputViewModel CustomerNumber { get; set; }

        /// <summary>
        /// The customer full name
        /// </summary>
        public string FullName { get; set; }
        
        /// <summary>
        /// The customer full address
        /// </summary>
        public TextInputViewModel FullAddress { get; set; }

        /// <summary>
        /// The customer full address type
        /// </summary>
        public AddressType FullAddressType { get; set; }

        /// <summary>
        /// The customer main phone number
        /// </summary>
        public TextInputViewModel MainPhone { get; set; }

        /// <summary>
        /// The type of main phone
        /// </summary>
        public PhoneType MainPhoneType { get; set; }

        /// <summary>
        /// The customer created date
        /// </summary>
        public TextInputViewModel CreateDate { get; set; }

        /// <summary>
        /// The customer last modified date
        /// </summary>
        public TextInputViewModel LastModifiedDate { get; set; }

        /// <summary>
        /// The customer main email address
        /// </summary>
        public TextInputViewModel MainEmail { get; set; }

        /// <summary>
        /// The main email address type
        /// </summary>
        public EmailType MainEmailType { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public CustomerCardViewModel()
        {
           
        }

        #endregion

    }

}
