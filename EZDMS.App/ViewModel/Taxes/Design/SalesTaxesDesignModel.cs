using System.Collections.Generic;

namespace EZDMS.App
{
    /// <summary>
    /// The design-time data for a <see cref="SalesTaxesViewModel"/>
    /// <summary>
    public class SalesTaxesDesignModel : SalesTaxesViewModel
    {

        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// <summary>
        public static SalesTaxesDesignModel Instance => new SalesTaxesDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// <summary>
        public SalesTaxesDesignModel()
        {

            TaxesInPayment = true;
            StateTaxActive = true;
            StateTaxName = new TextEntryViewModel { Label = "StateTaxName" };
            StateTaxAmount = new DecimalInputViewModel { Label = "StateTaxAmount", Amount = 0 };
            StateTaxRate = new DecimalInputViewModel { Label = "StateTaxRate", Amount = 0 };
            CountyTaxName = new TextEntryViewModel { Label = "CountyTaxName" };
            CountyTaxAmount = new DecimalInputViewModel { Label = "CountyTaxAmount", Amount = 0 };
            CountyTaxRate = new DecimalInputViewModel { Label = "CountyTaxRate", Amount = 0 };
            LocalTaxName = new TextEntryViewModel { Label = "LocalTaxName" };
            LocalTaxAmount = new DecimalInputViewModel { Label = "LocalTaxAmount", Amount = 0 };
            LocalTaxRate = new DecimalInputViewModel { Label = "LocalTaxRate", Amount = 0 };
            OtherTaxName = new TextEntryViewModel { Label = "OtherTaxName" };
            OtherTaxAmount = new DecimalInputViewModel { Label = "OtherTaxAmount", Amount = 0 };
            OtherTaxRate = new DecimalInputViewModel { Label = "OtherTaxRate", Amount = 0 };
        }
    

        #endregion
    }
}
