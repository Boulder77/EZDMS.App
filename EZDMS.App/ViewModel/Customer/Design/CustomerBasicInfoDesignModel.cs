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
            
            FirstName = new TextInputViewModel { Label = "First Name", Text = "Donald" };
            MiddleName = new TextInputViewModel { Label = "Middle Name", Text = "Fred" };
            LastName = new TextInputViewModel { Label = "Last Name", Text = "Gomez" };
            Suffix = new TextInputViewModel { Label = "Suffix", Text = "" };
            Nickname = new TextInputViewModel { Label = "Nickname", Text = "Donny" };
            DateOfBirth = new DateSelectionViewModel { Label = "Date of Birth", Date = Convert.ToDateTime("02/05/1991") };
            MaritalStatus = MaritalStatusType.Married;
            SocialSecurityNumber = new TextInputViewModel { Label = "SSN", Text = "11-22-4454" };
            Email = new TextInputViewModel { Label = "Email", Text = "DonaldGomez@nowhere.com" };
            EmailType = EmailType.Home;
            HomePhone = new TextInputViewModel { Label = "Home Phone", Text = "(619) 445-2212" };
            WorkPhone = new TextInputViewModel { Label = "Work Phone", Text = "(800) 456-2222" };
            CellPhone = new TextInputViewModel { Label = "Cell Phone", Text = "(619) 112-3332" };

        }

        #endregion
    }
}
