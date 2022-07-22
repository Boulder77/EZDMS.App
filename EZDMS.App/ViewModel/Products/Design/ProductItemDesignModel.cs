
namespace EZDMS.App
{
    /// <summary>
    /// The design-time data for a <see cref="ProductItemViewModel"/>
    /// </summary>
    public class ProductItemDesignModel : ProductItemViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static ProductItemDesignModel Instance => new ProductItemDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProductItemDesignModel()

        {
            
            Type = new TextDisplayViewModel { Label = "Product", DisplayText = "Service" };
            Provider = new TextEntryViewModel { Label = "Provider", OriginalText = "GMPP" };
            Plan = new TextEntryViewModel { Label = "Plan", OriginalText = "VALUE GUARD" };            
            Retail = new NumericalEntryViewModel { Label = "Retail", OriginalAmount = 2165.00m, Editable = true };
            Cost = new NumericalEntryViewModel { Label = "Cost", OriginalAmount = 1120.00m, Editable = true };
            Deductible = new NumericalEntryViewModel { Label = "Deductible", OriginalAmount = 100.00m, Editable = true };
            Term = new TextEntryViewModel { Label = "Term", OriginalText = "84" };
            Mileage = new TextEntryViewModel { Label = "Mileage", OriginalText = "80000" };
            ContractNumber = new TextEntryViewModel { Label = "Contract No", OriginalText = "myContract No" };
            InPayment = true;
            IsDisappearingDeductible = false;
            Taxable = true;

        }

        #endregion
    }
}
