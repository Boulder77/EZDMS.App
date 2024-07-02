namespace EZDMS.App
{
    /// <summary>
    /// The view model for the Trade control
    /// <summary>
    public class TradeVehicleViewModel : BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// The trade vehicle stock number
        /// <summary>
        public TextInputViewModel StockNumber { get; set; }

        /// <summary>
        /// The trade vehicle year
        /// <summary>
        public NumericalInputViewModel Year { get; set; }

        /// <summary>
        /// The trade vehicle make
        /// <summary>
        public TextInputViewModel Make { get; set; }

        /// <summary>
        /// The trade vehicle model
        /// <summary>
        public TextInputViewModel Model { get; set; }

        /// <summary>
        /// The trade vehicle model no
        /// <summary>
        public TextInputViewModel ModelNumber { get; set; }

        /// <summary>
        /// The trade vehicle body type
        /// <summary>
        public TextInputViewModel BodyType { get; set; }

        /// <summary>
        /// The trade vehicle class
        /// <summary>
        public TextInputViewModel Class { get; set; }

        /// <summary>
        /// The trade vehicle v i n
        /// <summary>
        public TextInputViewModel VIN { get; set; }

        /// <summary>
        /// The trade vehicle mileage
        /// <summary>
        public NumericalInputViewModel Odometer { get; set; }

        /// <summary>
        /// The trade vehicle trim color
        /// <summary>
        public TextInputViewModel TrimColor { get; set; }

        /// <summary>
        /// The trade vehicle trim
        /// <summary>
        public TextInputViewModel Trim { get; set; }

        /// <summary>
        /// The trade vehicle exterior color
        /// <summary>
        public TextInputViewModel ExteriorColor { get; set; }

        /// <summary>
        /// The trade vehicle interior color
        /// <summary>
        public TextInputViewModel InteriorColor { get; set; }

        /// <summary>
        /// The trade vehicle doors
        /// <summary>
        public NumericalInputViewModel Doors { get; set; }

        /// <summary>
        /// The trade vehicle cylinders
        /// <summary>
        public NumericalInputViewModel Cylinders { get; set; }

        /// <summary>
        /// The trade vehicle gross allowance
        /// <summary>
        public DecimalInputViewModel GrossAllowance { get; set; }

        /// <summary>
        /// The trade vehicle payoff
        /// <summary>
        public DecimalInputViewModel Payoff { get; set; }

        /// <summary>
        /// The trade vehicle a c v
        /// <summary>
        public DecimalInputViewModel ACV { get; set; }

        /// <summary>
        /// The trade vehicle inventory price
        /// <summary>
        public DecimalInputViewModel InventoryPrice { get; set; }

        /// <summary>
        /// The trade vehicle net allowance
        /// <summary>
        public DecimalInputViewModel NetAllowance { get; set; }

        /// <summary>
        /// The trade vehicle engine size
        /// <summary>
        public TextInputViewModel EngineSize { get; set; }

        /// <summary>
        /// The trade vehicle license no
        /// <summary>
        public TextInputViewModel LicenseNumber { get; set; }

        /// <summary>
        /// The trade vehicle license state
        /// <summary>
        public TextInputViewModel LicenseState { get; set; }

        /// <summary>
        /// The trade vehicle license exp date
        /// <summary>
        public DateSelectionViewModel LicenseExpirationDate { get; set; }

        /// <summary>
        /// The trade vehicle transmission
        /// <summary>
        public TextInputViewModel Transmission { get; set; }

        /// <summary>
        /// The trade vehicle weight
        /// <summary>
        public TextInputViewModel Weight { get; set; }

        /// <summary>
        /// The trade vehicle fuel type
        /// <summary>
        public TextInputViewModel FuelType { get; set; }

        /// <summary>
        /// The trade vehicle lienholder
        /// <summary>
        public TextInputViewModel Lienholder { get; set; }

        /// <summary>
        /// The trade vehicle lien contact
        /// <summary>
        public TextInputViewModel LienContact { get; set; }

        /// <summary>
        /// The trade vehicle lien address
        /// <summary>
        public TextInputViewModel LienAddress { get; set; }

        /// <summary>
        /// The trade vehicle lien city
        /// <summary>
        public TextInputViewModel LienCity { get; set; }

        /// <summary>
        /// The trade vehicle lien st
        /// <summary>
        public TextInputViewModel LienSt { get; set; }

        /// <summary>
        /// The trade vehicle lien zip
        /// <summary>
        public TextInputViewModel LienZip { get; set; }

        /// <summary>
        /// The trade vehicle lien phone
        /// <summary>
        public TextInputViewModel LienPhone { get; set; }

        /// <summary>
        /// The trade vehicle good until
        /// <summary>
        public DateSelectionViewModel GoodUntilDate { get; set; }

        /// <summary>
        /// The trade vehicle daily interest
        /// <summary>
        public DecimalInputViewModel DailyInterest { get; set; }

        /// <summary>
        /// The trade vehicle lien account number
        /// <summary>
        public TextInputViewModel LienAccountNumber { get; set; }

        /// <summary>
        /// The trade vehicle status
        /// <summary>
        public TextInputViewModel Status { get; set; }

        /// <summary>
        /// The trade vehicle lease
        /// <summary>
        public bool Lease { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// <summary>
        public TradeVehicleViewModel()
        {

        }

        #endregion
    }
}

    
