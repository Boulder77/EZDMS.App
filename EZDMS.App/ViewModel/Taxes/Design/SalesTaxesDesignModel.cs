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
           StateTax =  new TaxItemViewModel { Name = "State", Base =35000.00m, Rate = 8.25m, Amount = 2887.50m, Active = true };
           CountyTax = new TaxItemViewModel { Name = "County", Base = 35000.00m, Rate = 2.25m, Amount = 787.50m, Active = true };
           CityTax = new TaxItemViewModel { Name = "City", Base = 35000.00m, Rate = 1m, Amount = 350.00m, Active = true };
           OtherTax = new TaxItemViewModel { Name = "Other", Base = 35000.00m, Rate = .5m, Amount = 175.00m, Active = true };
           Total = new DecimalInputViewModel { Label = "Total", Amount = 4200m };
        }
    

        #endregion
    }
}
