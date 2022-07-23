namespace EZDMS.App
{
    /// <summary>
    ///
    /// <summary>
    public class VehiclePricingViewModel
    {

        #region Public Properties

        /// <summary>
        /// The MSRP of this vehicle inventory record
        /// <summary>
        public DecimalInputViewModel MSRP { get; set; }

        /// <summary>
        /// The inventory price of this vehicle inventory record
        /// <summary>
        public DecimalInputViewModel InventoryPrice { get; set; }

        /// <summary>
        /// The list price of this vehicle inventory record
        /// <summary>
        public DecimalInputViewModel ListPrice { get; set; }

        /// <summary>
        /// The internet price of this vehicle inventory record
        /// <summary>
        public DecimalInputViewModel InternetPrice { get; set; }

        /// <summary>
        /// The accounting cost of this vehicle inventory record
        /// <summary>
        public DecimalInputViewModel AccountingCost { get; set; }

        /// <summary>
        /// The a c v of this vehicle inventory record
        /// <summary>
        public DecimalInputViewModel ACV { get; set; }

        /// <summary>
        /// The added costs of this vehicle inventory record
        /// <summary>
        public DecimalInputViewModel AddedCosts { get; set; }

        /// <summary>
        /// The advertising of this vehicle inventory record
        /// <summary>
        public DecimalInputViewModel Advertising { get; set; }

        /// <summary>
        /// The reconditioning of this vehicle inventory record
        /// <summary>
        public DecimalInputViewModel Reconditioning { get; set; }

        /// <summary>
        /// The holdback of this vehicle inventory record
        /// <summary>
        public DecimalInputViewModel Holdback { get; set; }

        /// <summary>
        /// The dealer pack of this vehicle inventory record
        /// <summary>
        public DecimalInputViewModel DealerPack { get; set; }

        /// <summary>
        /// The buyer fee of this vehicle inventory record
        /// <summary>
        public DecimalInputViewModel BuyerFee { get; set; }

        /// <summary>
        /// The invoice price of this vehicle inventory record
        /// <summary>
        public DecimalInputViewModel InvoicePrice { get; set; }

        /// <summary>
        /// The dealer pack percentage of this vehicle inventory record
        /// <summary>
        public DecimalInputViewModel DealerPackPercentage { get; set; }


        #endregion



        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public VehiclePricingViewModel()
        {

        }

        #endregion
    }
}
