using EZDMS.App.Core;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using static EZDMS.App.DI;

namespace EZDMS.App
{
    /// <summary>
    /// The design-time data for a <see cref="FrontAddItemViewModel"/>
    /// </summary>
    public class FrontAddItemDesignModel : FrontAddItemViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static FrontAddItemDesignModel Instance => new FrontAddItemDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public FrontAddItemDesignModel()

        {

            SelectedItem = new FrontAddsDataModel { Name = "Bedliner- Drop In" };
            Retail = 999.00m;
            Cost = 650.00m;            
            InPayment = true;            
            Taxable = true;

        }

        #endregion
    }
}
