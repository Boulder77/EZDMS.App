using System.Collections.Generic;
using System;
using EZDMS.App.Core;

namespace EZDMS.App
{
    /// <summary>
    /// The design-time data for a <see cref="CustomerBasicInfoViewModel"/>
    /// </summary>
    public class CustomerBasicInfoDesignModel : CustomerBasicInfoViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static CustomerBasicInfoDesignModel Instance => new CustomerBasicInfoDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public CustomerBasicInfoDesignModel()

        {
            
            FirstName = new TextEntryViewModel { Label = "First Name", OriginalText = "Donald" };
            MiddleName = new TextEntryViewModel { Label = "Middle Name", OriginalText = "Fred" };
            LastName = new TextEntryViewModel { Label = "Last Name", OriginalText = "Gomez" };
            Suffix = new TextEntryViewModel { Label = "Suffix", OriginalText = "" };
            Nickname = new TextEntryViewModel { Label = "Nickname", OriginalText = "Donny" };
            DateOfBirth = new DateSelectionViewModel { Label = "Date of Birth", Date = Convert.ToDateTime("02/05/1991") };
            MaritalStatus = MaritalStatusType.Married;
            SocialSecurityNumber = new TextEntryViewModel { Label = "SSN", OriginalText = "11-22-4454" };
            Email = new TextEntryViewModel { Label = "Email", OriginalText = "DonaldGomez@nowhere.com" };
            EmailType = EmailType.Home;
            HomePhone = new TextEntryViewModel { Label = "Home Phone", OriginalText = "(619) 445-2212" };
            WorkPhone = new TextEntryViewModel { Label = "Work Phone", OriginalText = "(800) 456-2222" };
            CellPhone = new TextEntryViewModel { Label = "Cell Phone", OriginalText = "(619) 112-3332" };

        }

        #endregion
    }
}
