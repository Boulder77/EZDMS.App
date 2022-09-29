using EZDMS.App.Core;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace EZDMS.App
{
    /// <summary>
    /// The design-time data for a <see cref="BackAddItemListViewModel"/>
    /// </summary>
    public class BackAddListDesignModel : BackAddItemListViewModel
    {

        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static BackAddListDesignModel Instance => new BackAddListDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BackAddListDesignModel()
        {
            Items = new ObservableCollection<BackAddItemViewModel>
            {
                 new BackAddItemViewModel
                    {
                        SelectedAdd = new SystemBackAddsDataModel { Name = "Bedliner- Drop In" },
                        Retail = 999.00m,
                        Cost = 650.00m,
                        InPayment = true,
                        Taxable = true,
                    },

                 new BackAddItemViewModel
                    {
                        SelectedAdd = new SystemBackAddsDataModel { Name = "Step bar" },
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
