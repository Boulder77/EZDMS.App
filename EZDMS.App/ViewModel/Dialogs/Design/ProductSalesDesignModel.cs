
namespace EZDMS.App
{
    /// <summary>
    /// The design-time data for a <see cref="ProductsSalesDialogViewModel"/>
    /// </summary>
    public class ProductSalesDesignModel : ProductsSalesDialogViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static ProductSalesDesignModel Instance => new ProductSalesDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProductSalesDesignModel()

        {
            Service = new ProductItemViewModel

            {
                Type = new TextInputViewModel { Label = "Product", Text = "Service", Editable = false },
                Provider = new TextInputViewModel { Label = "Provider", Text = "GMPP" },
                Plan = new TextInputViewModel { Label = "Plan", Text = "VALUE GUARD" },
                Retail = 2165.00m,
                Cost = new DecimalInputViewModel { Label = "Cost", Amount = 1120.00m, Editable = true },
                Deductible = new DecimalInputViewModel { Label = "Deductible", Amount = 100.00m, Editable = true },
                Term = new TextInputViewModel { Label = "Term", Text = "84" },
                Miles = new TextInputViewModel { Label = "Mileage", Text = "80000" },
                ContractNumber = new TextInputViewModel { Label = "Contract No", Text = "SV#111" },
                InPayment = true,
                IsDisappearingDeductible = false,
                Taxable = true,
            };

            Warranty = new ProductItemViewModel

            {
                Type = new TextInputViewModel { Label = "Product", Text = "Warranty", Editable = false },
                Provider = new TextInputViewModel { Label = "Provider", Text = "WilliamW" },
                Plan = new TextInputViewModel { Label = "Plan", Text = "WilliamW" },
                Retail = 400.00m,
                Cost = new DecimalInputViewModel { Label = "Cost", Amount = 200.00m, Editable = true },
                Deductible = new DecimalInputViewModel { Label = "Deductible", Amount = 200.00m, Editable = true },
                Term = new TextInputViewModel { Label = "Term", Text = "24" },
                Miles = new TextInputViewModel { Label = "Mileage", Text = "24000" },
                ContractNumber = new TextInputViewModel { Label = "Contract No", Text = "WA#333" },
                InPayment = true,
                IsDisappearingDeductible = false,
                Taxable = true,
            };



            Warranty = new ProductItemViewModel

            {
                Type = new TextInputViewModel { Label = "Product", Text = "Warranty", Editable = false },
                Provider = new TextInputViewModel { Label = "Provider", Text = "WilliamW" },
                Plan = new TextInputViewModel { Label = "Plan", Text = "WilliamW" },
                Retail = 400.00m,
                Cost = new DecimalInputViewModel { Label = "Cost", Amount = 200.00m, Editable = true },
                Deductible = new DecimalInputViewModel { Label = "Deductible", Amount = 200.00m, Editable = true },
                Term = new TextInputViewModel { Label = "Term", Text = "24" },
                Miles = new TextInputViewModel { Label = "Mileage", Text = "24000" },
                ContractNumber = new TextInputViewModel { Label = "Contract No", Text = "WA#333" },
                InPayment = true,
                IsDisappearingDeductible = false,
                Taxable = true,
            };

            Maintenance = new ProductItemViewModel

            {
                Type = new TextInputViewModel { Label = "Product", Text = "Maintenance", Editable = false },
                Provider = new TextInputViewModel { Label = "Provider", Text = "Sheldon214" },
                Plan = new TextInputViewModel { Label = "Plan", Text = "Sheldon214" },
                Retail = 350.00m,
                Cost = new DecimalInputViewModel { Label = "Cost", Amount = 150.00m, Editable = true },
                Deductible = new DecimalInputViewModel { Label = "Deductible", Amount = 0m, Editable = true },
                Term = new TextInputViewModel { Label = "Term", Text = "36" },
                Miles = new TextInputViewModel { Label = "Mileage", Text = "36000" },
                ContractNumber = new TextInputViewModel { Label = "Contract No", Text = "MT#333" },
                InPayment = true,
                IsDisappearingDeductible = true,
                Taxable = true,
            };

            Gap = new ProductItemViewModel

            {
                Type = new TextInputViewModel { Label = "Product", Text = "Gap", Editable = false},
                Provider = new TextInputViewModel { Label = "Provider", Text = "Easy Care" },
                Plan = new TextInputViewModel { Label = "Plan", Text = "GAP" },
                Retail = 895.00m,
                Cost = new DecimalInputViewModel { Label = "Cost", Amount = 350.00m, Editable = true },                
                ContractNumber = new TextInputViewModel { Label = "Contract No", Text = "GP#444" },
                InPayment = true,
                IsDisappearingDeductible = true,
                Taxable = true,
            };

            TotalRetail = new DecimalInputViewModel { Label = "Total Retail", Amount = 3810.00m};


        }

        #endregion
    }
}
