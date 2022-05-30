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
        public NumericalEntryViewModel MSRP { get; set; }

        /// <summary>
        /// The inventory price of this vehicle inventory record
        /// <summary>
        public NumericalEntryViewModel InventoryPrice { get; set; }

        /// <summary>
        /// The list price of this vehicle inventory record
        /// <summary>
        public NumericalEntryViewModel ListPrice { get; set; }

        /// <summary>
        /// The internet price of this vehicle inventory record
        /// <summary>
        public NumericalEntryViewModel InternetPrice { get; set; }

        /// <summary>
        /// The accounting cost of this vehicle inventory record
        /// <summary>
        public NumericalEntryViewModel AccountingCost { get; set; }

        /// <summary>
        /// The a c v of this vehicle inventory record
        /// <summary>
        public NumericalEntryViewModel ACV { get; set; }

        /// <summary>
        /// The added costs of this vehicle inventory record
        /// <summary>
        public NumericalEntryViewModel AddedCosts { get; set; }

        /// <summary>
        /// The advertising of this vehicle inventory record
        /// <summary>
        public NumericalEntryViewModel Advertising { get; set; }

        /// <summary>
        /// The reconditioning of this vehicle inventory record
        /// <summary>
        public NumericalEntryViewModel Reconditioning { get; set; }

        /// <summary>
        /// The holdback of this vehicle inventory record
        /// <summary>
        public NumericalEntryViewModel Holdback { get; set; }

        /// <summary>
        /// The dealer pack of this vehicle inventory record
        /// <summary>
        public NumericalEntryViewModel DealerPack { get; set; }

        /// <summary>
        /// The buyer fee of this vehicle inventory record
        /// <summary>
        public NumericalEntryViewModel BuyerFee { get; set; }

        /// <summary>
        /// The invoice price of this vehicle inventory record
        /// <summary>
        public NumericalEntryViewModel InvoicePrice { get; set; }

        /// <summary>
        /// The dealer pack percentage of this vehicle inventory record
        /// <summary>
        public NumericalEntryViewModel DealerPackPercentage { get; set; }


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
