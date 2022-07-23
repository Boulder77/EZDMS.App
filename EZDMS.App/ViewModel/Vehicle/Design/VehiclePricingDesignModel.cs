using System.Collections.Generic;
using System;
using EZDMS.App.Core;

namespace EZDMS.App
{
    /// <summary>
    /// The design-time data for a <see cref="VehiclePricingDesignModel"/>
    /// </summary>
    public class VehiclePricingDesignModel : VehiclePricingViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static VehiclePricingDesignModel Instance => new VehiclePricingDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public VehiclePricingDesignModel()

        {

            MSRP = new DecimalInputViewModel { Label = "MSRP", Amount= 56875.00m, Editable = true };
            InventoryPrice = new DecimalInputViewModel { Label = "Inventory Price", Amount = 56875.00m, Editable = true };
            ListPrice = new DecimalInputViewModel { Label = "List Price", Amount = 56875.00m, Editable = true };
            InternetPrice = new DecimalInputViewModel { Label = "Internet Price", Amount = 56875.00m, Editable = true };
            AccountingCost = new DecimalInputViewModel { Label = "Accounting Cost", Amount = 0, Editable = false };
            ACV = new DecimalInputViewModel { Label = "ACV", Amount = 0, Editable = true };
            Advertising = new DecimalInputViewModel { Label = "Advertising", Amount = 555.80m, Editable = true };
            Reconditioning = new DecimalInputViewModel { Label = "Reconditioning", Amount =0, Editable = true };
            Holdback = new DecimalInputViewModel { Label = "Holdback", Amount = 1667.40m, Editable = true };
            DealerPack = new DecimalInputViewModel { Label = "Dealer Pack", Amount = 300, Editable = true };
            BuyerFee = new DecimalInputViewModel { Label = "Buyer Fee", Amount = 0, Editable = true };
            DealerPackPercentage = new DecimalInputViewModel { Label = "Dealer Pack (%)", Amount = .20m, Editable = true };
            InvoicePrice = new DecimalInputViewModel { Label = "Invoice Price", Amount = 54651.80m, Editable = true };

        }      

        #endregion
    }
}
