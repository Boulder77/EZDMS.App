
namespace EZDMS.App
{
    /// <summary>
    /// The design-time data for a <see cref="CustomerCardViewModel"/>
    /// </summary>
    public class CustomerCardDesignModel : CustomerCardViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static CustomerCardDesignModel Instance => new CustomerCardDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public CustomerCardDesignModel()

        {
            CustomerNumber = new TextInputViewModel { Label = "Customer Number", Text = "YCV1000010",Editable=false };
            FullName = "Donald Fred Gomez";
            CreateDate = new TextInputViewModel { Label = "Created", Text = "06/14/2020", Editable = false };
            LastModifiedDate = new TextInputViewModel { Label = "Last Modified", Text = "10/12/2021", Editable = false };
            MainPhone = new TextInputViewModel { Label = "2 Phones", Text = $"(724) 967-4272 {MainPhoneType}", Editable = false  };
            MainEmail = new TextInputViewModel { Label = "1 Email", Text = $"DonaldGomez@nowhere.com {MainEmailType}", Editable = false };
            FullAddress = new TextInputViewModel { Label = "1 Address", Text = $"129 Smith Valley Rd \r\n Fredonia, OH 45011 {FullAddressType}", Editable = false };

        }

        #endregion
    }
}
