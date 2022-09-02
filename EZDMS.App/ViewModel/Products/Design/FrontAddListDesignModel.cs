using EZDMS.App.Core;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace EZDMS.App
{
    /// <summary>
    /// The design-time data for a <see cref="FrontAddListViewModel"/>
    /// </summary>
    public class FrontAddListDesignModel : FrontAddListViewModel
    {

        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static FrontAddListDesignModel Instance => new FrontAddListDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public FrontAddListDesignModel()
        {
            Items = new ObservableCollection<FrontAddItemViewModel>
            {
                 new FrontAddItemViewModel
                    {
                        SelectedItem = new FrontAddsDataModel { Name = "Bedliner- Drop In" },
                        Retail = 999.00m,
                        Cost = 650.00m,
                        InPayment = true,
                        Taxable = true,
                    },

                 new FrontAddItemViewModel
                    {
                        SelectedItem = new FrontAddsDataModel { Name = "Step bar" },
                        Retail = 259.00m,
                        Cost = 120.00m,
                        InPayment = true,
                        Taxable = true,
                    },

            };

            Total = Items.Sum(item => item.Retail);
        }
        #endregion
    }
}
