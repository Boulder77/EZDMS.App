
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
                Type = new TextDisplayViewModel { Label = "Product", DisplayText = "Service" },
                Provider = new TextEntryViewModel { Label = "Provider", OriginalText = "GMPP" },
                Plan = new TextEntryViewModel { Label = "Plan", OriginalText = "VALUE GUARD" },
                Retail = new NumericalEntryViewModel { Label = "Retail", OriginalAmount = 2165.00m, Editable = true },
                Cost = new NumericalEntryViewModel { Label = "Cost", OriginalAmount = 1120.00m, Editable = true },
                Deductible = new NumericalEntryViewModel { Label = "Deductible", OriginalAmount = 100.00m, Editable = true },
                Term = new TextEntryViewModel { Label = "Term", OriginalText = "84" },
                Mileage = new TextEntryViewModel { Label = "Mileage", OriginalText = "80000" },
                ContractNumber = new TextEntryViewModel { Label = "Contract No", OriginalText = "SV#111" },
                InPayment = true,
                IsDisappearingDeductible = false,
                Taxable = true,
            };

            Warranty = new ProductItemViewModel

            {
                Type = new TextDisplayViewModel { Label = "Product", DisplayText = "Warranty" },
                Provider = new TextEntryViewModel { Label = "Provider", OriginalText = "WilliamW" },
                Plan = new TextEntryViewModel { Label = "Plan", OriginalText = "WilliamW" },
                Retail = new NumericalEntryViewModel { Label = "Retail", OriginalAmount = 400.00m, Editable = true },
                Cost = new NumericalEntryViewModel { Label = "Cost", OriginalAmount = 200.00m, Editable = true },
                Deductible = new NumericalEntryViewModel { Label = "Deductible", OriginalAmount = 200.00m, Editable = true },
                Term = new TextEntryViewModel { Label = "Term", OriginalText = "24" },
                Mileage = new TextEntryViewModel { Label = "Mileage", OriginalText = "24000" },
                ContractNumber = new TextEntryViewModel { Label = "Contract No", OriginalText = "WA#333" },
                InPayment = true,
                IsDisappearingDeductible = false,
                Taxable = true,
            };



            Warranty = new ProductItemViewModel

            {
                Type = new TextDisplayViewModel { Label = "Product", DisplayText = "Warranty" },
                Provider = new TextEntryViewModel { Label = "Provider", OriginalText = "WilliamW" },
                Plan = new TextEntryViewModel { Label = "Plan", OriginalText = "WilliamW" },
                Retail = new NumericalEntryViewModel { Label = "Retail", OriginalAmount = 400.00m, Editable = true },
                Cost = new NumericalEntryViewModel { Label = "Cost", OriginalAmount = 200.00m, Editable = true },
                Deductible = new NumericalEntryViewModel { Label = "Deductible", OriginalAmount = 200.00m, Editable = true },
                Term = new TextEntryViewModel { Label = "Term", OriginalText = "24" },
                Mileage = new TextEntryViewModel { Label = "Mileage", OriginalText = "24000" },
                ContractNumber = new TextEntryViewModel { Label = "Contract No", OriginalText = "WA#333" },
                InPayment = true,
                IsDisappearingDeductible = false,
                Taxable = true,
            };

            Maintenance = new ProductItemViewModel

            {
                Type = new TextDisplayViewModel { Label = "Product", DisplayText = "Maintenance" },
                Provider = new TextEntryViewModel { Label = "Provider", OriginalText = "Sheldon214" },
                Plan = new TextEntryViewModel { Label = "Plan", OriginalText = "Sheldon214" },
                Retail = new NumericalEntryViewModel { Label = "Retail", OriginalAmount = 350.00m, Editable = true },
                Cost = new NumericalEntryViewModel { Label = "Cost", OriginalAmount = 150.00m, Editable = true },
                Deductible = new NumericalEntryViewModel { Label = "Deductible", OriginalAmount = 0m, Editable = true },
                Term = new TextEntryViewModel { Label = "Term", OriginalText = "36" },
                Mileage = new TextEntryViewModel { Label = "Mileage", OriginalText = "36000" },
                ContractNumber = new TextEntryViewModel { Label = "Contract No", OriginalText = "MT#333" },
                InPayment = true,
                IsDisappearingDeductible = true,
                Taxable = true,
            };

            Gap = new ProductItemViewModel

            {
                Type = new TextDisplayViewModel { Label = "Product", DisplayText = "Gap" },
                Provider = new TextEntryViewModel { Label = "Provider", OriginalText = "Easy Care" },
                Plan = new TextEntryViewModel { Label = "Plan", OriginalText = "GAP" },
                Retail = new NumericalEntryViewModel { Label = "Retail", OriginalAmount = 895.00m, Editable = true },
                Cost = new NumericalEntryViewModel { Label = "Cost", OriginalAmount = 350.00m, Editable = true },                
                ContractNumber = new TextEntryViewModel { Label = "Contract No", OriginalText = "GP#444" },
                InPayment = true,
                IsDisappearingDeductible = true,
                Taxable = true,
            };

            TotalRetailAmount = 3810.00m;

            TotalRetail = new NumericalEntryViewModel { Label = "Total Retail", OriginalAmount =TotalRetailAmount};


        }

        #endregion
    }
}
