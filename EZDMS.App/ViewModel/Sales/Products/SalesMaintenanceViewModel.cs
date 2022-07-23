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
        public TextInputViewModel DealNumber { get; set; }

        /// <summary>
        /// The SalesMaintenance provider number
        /// <summary>
        public TextInputViewModel ProviderNumber { get; set; }

        /// <summary>
        /// The SalesMaintenance plan i d
        /// <summary>
        public TextInputViewModel PlanID { get; set; }

        /// <summary>
        /// The SalesMaintenance plan
        /// <summary>
        public TextInputViewModel Plan { get; set; }

        /// <summary>
        /// The SalesMaintenance retail
        /// <summary>
        public DecimalInputViewModel Retail { get; set; }

        /// <summary>
        /// The SalesMaintenance cost
        /// <summary>
        public DecimalInputViewModel Cost { get; set; }

        /// <summary>
        /// The SalesMaintenance profit
        /// <summary>
        public DecimalInputViewModel Profit { get; set; }

        /// <summary>
        /// The SalesMaintenance deductible
        /// <summary>
        public DecimalInputViewModel Deductible { get; set; }

        /// <summary>
        /// The SalesMaintenance term
        /// <summary>
        public TextInputViewModel Term { get; set; }

        /// <summary>
        /// The SalesMaintenance mileage
        /// <summary>
        public TextInputViewModel Mileage { get; set; }

        /// <summary>
        /// The SalesMaintenance dealer number
        /// <summary>
        public TextInputViewModel DealerNumber { get; set; }

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
