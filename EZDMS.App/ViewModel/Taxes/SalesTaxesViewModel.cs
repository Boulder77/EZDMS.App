using Dna;
using EZDMS.App.Core;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management.Instrumentation;
using System.Threading.Tasks;
using System.Windows.Input;
using static EZDMS.App.DI;

namespace EZDMS.App
{
    /// <summary>
    /// The view model for the SalesTaxes control
    /// <summary>
    public class SalesTaxesViewModel : BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// The SalesTaxes taxes in payment
        /// <summary>
        public bool TaxesInPayment { get; set; }

        /// <summary>
        /// The state tax view model
        /// <summary>
        public TaxItemViewModel StateTax { get; set; }

        /// <summary>
        /// The county tax view model
        /// <summary>
        public TaxItemViewModel CountyTax { get; set; }

        /// <summary>
        /// The local tax view model
        /// <summary>
        public TaxItemViewModel CityTax { get; set; }

        /// <summary>
        /// The other tax view model
        /// <summary>
        public TaxItemViewModel OtherTax { get; set; }

        /// <summary>
        /// The total tax amount
        /// </summary>
        public DecimalInputViewModel Total { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// <summary>
        public SalesTaxesViewModel()
        {

        }

        #endregion
    }
}
