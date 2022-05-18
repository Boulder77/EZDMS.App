
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
            CustomerNumber = new TextDisplayViewModel { Label = "Customer Number", DisplayText = "YCV1000010" };
            FullName = "Donald Fred Gomez";
            CreateDate = new TextDisplayViewModel { Label = "Created", DisplayText = "06/14/2020" };
            LastModifiedDate = new TextDisplayViewModel { Label = "Last Modified", DisplayText = "10/12/2021" };
            MainPhone = new TextDisplayViewModel { Label = "2 Phones", DisplayText = $"(724) 967-4272 {MainPhoneType}" };
            MainEmail = new TextDisplayViewModel { Label = "1 Email", DisplayText = $"DonaldGomez@nowhere.com {MainEmailType}" };
            FullAddress = new TextDisplayViewModel { Label = "1 Address", DisplayText = $"129 Smith Valley Rd \r\n Fredonia, OH 45011 {FullAddressType}" };

        }

        #endregion
    }
}
