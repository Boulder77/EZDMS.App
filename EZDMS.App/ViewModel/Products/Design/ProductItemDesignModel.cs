
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
            
            Type = new TextInputViewModel { Label = "Product", Text = "Service", Editable = false };                  
            Retail = 2165.00m;
            Cost = new DecimalInputViewModel { Label = "Cost", Amount = 1120.00m, Editable = true };
            Deductible = new DecimalInputViewModel { Label = "Deductible", Amount = 100.00m, Editable = true };
            Term = new TextInputViewModel { Label = "Term", Text = "84" };
            Miles = new TextInputViewModel { Label = "Mileage", Text = "80000" };
            ContractNumber = new TextInputViewModel { Label = "Contract No", Text = "myContract No" };
            InPayment = true;
            IsDisappearingDeductible = false;
            Taxable = true;

        }

        #endregion
    }
}
