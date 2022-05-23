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
    /// The view model for a sales deal card control
    /// </summary>
    public class CustomerBasicInfoViewModel : BaseViewModel
    {

        #region Public Properties    

        /// <summary>
        /// The list of prefixes
        /// </summary>
        public IEnumerable<PrefixType> Prefixes => Enum.GetValues(typeof(PrefixType)).Cast<PrefixType>();

        /// <summary>
        /// The list of marital statuses
        /// </summary>
        public IEnumerable<MaritalStatusType> MaritalStatuses => Enum.GetValues(typeof(MaritalStatusType)).Cast<MaritalStatusType>();

        /// <summary>
        /// The list of gender types
        /// </summary>
        public IEnumerable<GenderType> Genders => Enum.GetValues(typeof(GenderType)).Cast<GenderType>();

        /// <summary>
        /// The list of customer contact types
        /// </summary>
        public IEnumerable<CustomerContactType> ContactTypes => Enum.GetValues(typeof(CustomerContactType)).Cast<CustomerContactType>();

        /// <summary>
        /// The list of customer contact types
        /// </summary>
        public IEnumerable<CustomerPrivacyType> PrivacyTypes => Enum.GetValues(typeof(CustomerPrivacyType)).Cast<CustomerPrivacyType>();

        /// <summary>
        /// The list of customer email types
        /// </summary>
        public IEnumerable<EmailType> EmailTypes => Enum.GetValues(typeof(EmailType)).Cast<EmailType>();

        /// <summary>
        /// The customer prefix
        /// </summary>
        public ComboBoxSelectionViewModel Prefix { get; set; }

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
        public TextEntryViewModel Suffix { get; set; }

        /// <summary>
        /// The customer gender
        /// </summary>
        public GenderType Gender { get; set; }

        /// <summary>
        /// The customer nickname
        /// </summary>
        public TextEntryViewModel Nickname { get; set; }

        /// <summary>
        /// The customer date of birth
        /// </summary>
        public DateSelectionViewModel DateOfBirth { get; set; }

        /// <summary>
        /// The customer marital status
        /// </summary>
        public MaritalStatusType MaritalStatus { get; set; }

        /// <summary>
        /// The customer social security number
        /// </summary>
        public TextEntryViewModel SocialSecurityNumber { get; set; }

        /// <summary>
        /// The customer contact type
        /// </summary>
        public CustomerContactType ContactType { get; set; }

        /// <summary>
        /// The customer privacy type
        /// </summary>
        public CustomerPrivacyType PrivacyType { get; set; }

        /// <summary>
        /// The customer email
        /// </summary>
        public TextEntryViewModel Email { get; set; }

        /// <summary>
        /// The type of email
        /// </summary>
        public EmailType EmailType { get; set; }

        /// <summary>
        /// The customer home phone number
        /// </summary>
        public TextEntryViewModel HomePhone { get; set; }

        /// <summary>
        /// The customer cell phone number
        /// </summary>
        public TextEntryViewModel CellPhone { get; set; }

        /// <summary>
        /// The customer work phone number
        /// </summary>
        public TextEntryViewModel WorkPhone { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public CustomerBasicInfoViewModel()
        {

    
           

        }

        #endregion

    }

}
