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
        /// The SalesTaxes state tax active
        /// <summary>
        public bool StateTaxActive { get; set; }

        /// <summary>
        /// The SalesTaxes state tax name
        /// <summary>
        public TextEntryViewModel StateTaxName { get; set; }

        /// <summary>
        /// The SalesTaxes state tax base
        /// <summary>
        public DecimalInputViewModel StateTaxBase { get; set; }

        /// <summary>
        /// The SalesTaxes state tax amount
        /// <summary>
        public DecimalInputViewModel StateTaxAmount { get; set; }

        /// <summary>
        /// The SalesTaxes state tax rate
        /// <summary>
        public DecimalInputViewModel StateTaxRate { get; set; }

        /// <summary>
        /// The SalesTaxes county tax active
        /// <summary>
        public bool CountyTaxActive { get; set; }

        /// <summary>
        /// The SalesTaxes county tax name
        /// <summary>
        public TextEntryViewModel CountyTaxName { get; set; }

        /// <summary>
        /// The SalesTaxes county tax base
        /// <summary>
        public DecimalInputViewModel CountyTaxBase { get; set; }

        /// <summary>
        /// The SalesTaxes county tax amount
        /// <summary>
        public DecimalInputViewModel CountyTaxAmount { get; set; }

        /// <summary>
        /// The SalesTaxes county tax rate
        /// <summary>
        public DecimalInputViewModel CountyTaxRate { get; set; }

        /// <summary>
        /// The SalesTaxes local tax active
        /// <summary>
        public bool LocalTaxActive { get; set; }

        /// <summary>
        /// The SalesTaxes local tax name
        /// <summary>
        public TextEntryViewModel LocalTaxName { get; set; }

        /// <summary>
        /// The SalesTaxes local tax base
        /// <summary>
        public DecimalInputViewModel LocalTaxBase { get; set; }

        /// <summary>
        /// The SalesTaxes local tax amount
        /// <summary>
        public DecimalInputViewModel LocalTaxAmount { get; set; }

        /// <summary>
        /// The SalesTaxes local tax rate
        /// <summary>
        public DecimalInputViewModel LocalTaxRate { get; set; }

        /// <summary>
        /// The SalesTaxes other tax active
        /// <summary>
        public bool OtherTaxActive { get; set; }

        /// <summary>
        /// The SalesTaxes other tax name
        /// <summary>
        public TextEntryViewModel OtherTaxName { get; set; }

        /// <summary>
        /// The SalesTaxes other tax base
        /// <summary>
        public DecimalInputViewModel OtherTaxBase { get; set; }

        /// <summary>
        /// The SalesTaxes other tax amount
        /// <summary>
        public DecimalInputViewModel OtherTaxAmount { get; set; }

        /// <summary>
        /// The SalesTaxes other tax rate
        /// <summary>
        public DecimalInputViewModel OtherTaxRate { get; set; }

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
