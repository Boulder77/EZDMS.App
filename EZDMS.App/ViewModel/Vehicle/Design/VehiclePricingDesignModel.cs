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

            MSRP = new NumericalEntryViewModel { Label = "MSRP", OriginalAmount= 56875.00m, Editable = true };
            InventoryPrice = new NumericalEntryViewModel { Label = "Inventory Price", OriginalAmount = 56875.00m, Editable = true };
            ListPrice = new NumericalEntryViewModel { Label = "List Price", OriginalAmount = 56875.00m, Editable = true };
            InternetPrice = new NumericalEntryViewModel { Label = "Internet Price", OriginalAmount = 56875.00m, Editable = true };
            AccountingCost = new NumericalEntryViewModel { Label = "Accounting Cost", OriginalAmount = 0, Editable = false };
            ACV = new NumericalEntryViewModel { Label = "ACV", OriginalAmount = 0, Editable = true };
            Advertising = new NumericalEntryViewModel { Label = "Advertising", OriginalAmount = 555.80m, Editable = true };
            Reconditioning = new NumericalEntryViewModel { Label = "Reconditioning", OriginalAmount =0, Editable = true };
            Holdback = new NumericalEntryViewModel { Label = "Holdback", OriginalAmount = 1667.40m, Editable = true };
            DealerPack = new NumericalEntryViewModel { Label = "Dealer Pack", OriginalAmount = 300, Editable = true };
            BuyerFee = new NumericalEntryViewModel { Label = "Buyer Fee", OriginalAmount = 0, Editable = true };
            DealerPackPercentage = new NumericalEntryViewModel { Label = "Dealer Pack (%)", OriginalAmount = .20m, Editable = true };
            InvoicePrice = new NumericalEntryViewModel { Label = "Invoice Price", OriginalAmount = 54651.80m, Editable = true };

        }      

        #endregion
    }
}
