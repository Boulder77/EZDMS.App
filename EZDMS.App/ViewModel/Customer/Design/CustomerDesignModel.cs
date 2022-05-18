using System.Collections.Generic;
using System;

namespace EZDMS.App
{
    /// <summary>
    /// The design-time data for a <see cref="CustomerViewModel"/>
    /// </summary>
    public class CustomerDesignModel : CustomerViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static CustomerDesignModel Instance => new CustomerDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public CustomerDesignModel()

        {
            //CustomerNumber = new TextDisplayViewModel { Label = "Customer Number", DisplayText="YCV1000010" };
            //FullName = "Donald Fred Gomez";
            //CreateDate = new DateSelectionViewModel { Label = "Created", Date = Convert.ToDateTime("06/14/2020") };
            //LastModifiedDate = new DateSelectionViewModel { Label = "Last Modified", Date = Convert.ToDateTime("10/12/2021") };
            //MainPhone = new TextDisplayViewModel { Label = "2 Phones", DisplayText = $"(724) 967-4272 { MainPhoneType }" };
            






        }

        #endregion
    }
}
