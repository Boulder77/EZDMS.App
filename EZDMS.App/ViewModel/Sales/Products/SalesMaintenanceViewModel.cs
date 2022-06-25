using Dna;
using EZDMS.App.Core;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using static EZDMS.App.DI;

namespace EZDMS.App
{
    /// <summary>
    /// The view model for the SalesMaintenance control
    /// <summary>
    public class SalesMaintenanceViewModel : BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// The SalesMaintenance deal number
        /// <summary>
        public TextEntryViewModel DealNumber { get; set; }

        /// <summary>
        /// The SalesMaintenance provider number
        /// <summary>
        public TextEntryViewModel ProviderNumber { get; set; }

        /// <summary>
        /// The SalesMaintenance plan i d
        /// <summary>
        public TextEntryViewModel PlanID { get; set; }

        /// <summary>
        /// The SalesMaintenance plan
        /// <summary>
        public TextEntryViewModel Plan { get; set; }

        /// <summary>
        /// The SalesMaintenance retail
        /// <summary>
        public NumericalEntryViewModel Retail { get; set; }

        /// <summary>
        /// The SalesMaintenance cost
        /// <summary>
        public NumericalEntryViewModel Cost { get; set; }

        /// <summary>
        /// The SalesMaintenance profit
        /// <summary>
        public NumericalEntryViewModel Profit { get; set; }

        /// <summary>
        /// The SalesMaintenance deductible
        /// <summary>
        public NumericalEntryViewModel Deductible { get; set; }

        /// <summary>
        /// The SalesMaintenance term
        /// <summary>
        public TextEntryViewModel Term { get; set; }

        /// <summary>
        /// The SalesMaintenance mileage
        /// <summary>
        public TextEntryViewModel Mileage { get; set; }

        /// <summary>
        /// The SalesMaintenance dealer number
        /// <summary>
        public TextEntryViewModel DealerNumber { get; set; }

        /// <summary>
        /// The SalesMaintenance in payment
        /// <summary>
        public bool InPayment { get; set; }

        /// <summary>
        /// The SalesMaintenance in cap
        /// <summary>
        public bool InCap { get; set; }

        /// <summary>
        /// The SalesMaintenance is disappearing deductible
        /// <summary>
        public bool IsDisappearingDeductible { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// <summary>
        public SalesMaintenanceViewModel()
        {

        }

        #endregion
    }
}
