namespace EZDMS.App
{
    /// <summary>
    /// The view model for the Trade control
    /// <summary>
    public class TradeViewModel : BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// The Trade year
        /// <summary>
        public NumericalInputViewModel TradeYear { get; set; }

        /// <summary>
        /// The Trade make
        /// <summary>
        public TextEntryViewModel TradeMake { get; set; }

        /// <summary>
        /// The Trade model
        /// <summary>
        public TextEntryViewModel TradeModel { get; set; }

        /// <summary>
        /// The Trade model no
        /// <summary>
        public TextEntryViewModel TradeModelNo { get; set; }

        /// <summary>
        /// The Trade body type
        /// <summary>
        public TextEntryViewModel TradeBodyType { get; set; }

        /// <summary>
        /// The Trade v i n
        /// <summary>
        public TextEntryViewModel TradeVIN { get; set; }

        /// <summary>
        /// The Trade mileage
        /// <summary>
        public NumericalInputViewModel TradeMileage { get; set; }

        /// <summary>
        /// The Trade trim color
        /// <summary>
        public TextEntryViewModel TradeTrimColor { get; set; }

        /// <summary>
        /// The Trade exterior color
        /// <summary>
        public TextEntryViewModel TradeExteriorColor { get; set; }

        /// <summary>
        /// The Trade interior color
        /// <summary>
        public TextEntryViewModel TradeInteriorColor { get; set; }

        /// <summary>
        /// The Trade doors
        /// <summary>
        public NumericalInputViewModel TradeDoors { get; set; }

        /// <summary>
        /// The Trade cylinders
        /// <summary>
        public NumericalInputViewModel TradeCylinders { get; set; }

        /// <summary>
        /// The Trade gross allowance
        /// <summary>
        public DecimalInputViewModel TradeGrossAllowance { get; set; }

        /// <summary>
        /// The Trade payoff
        /// <summary>
        public DecimalInputViewModel TradePayoff { get; set; }

        /// <summary>
        /// The Trade a c v
        /// <summary>
        public DecimalInputViewModel TradeACV { get; set; }

        /// <summary>
        /// The Trade inventory price
        /// <summary>
        public DecimalInputViewModel TradeInventoryPrice { get; set; }

        /// <summary>
        /// The Trade net allowance
        /// <summary>
        public DecimalInputViewModel TradeNetAllowance { get; set; }

        /// <summary>
        /// The Trade engine size
        /// <summary>
        public TextEntryViewModel TradeEngineSize { get; set; }

        /// <summary>
        /// The Trade license no
        /// <summary>
        public TextEntryViewModel TradeLicenseNo { get; set; }

        /// <summary>
        /// The Trade license state
        /// <summary>
        public TextEntryViewModel TradeLicenseState { get; set; }

        /// <summary>
        /// The Trade license exp date
        /// <summary>
        public DateSelectionViewModel TradeLicenseExpDate { get; set; }

        /// <summary>
        /// The Trade transmission
        /// <summary>
        public TextEntryViewModel TradeTransmission { get; set; }

        /// <summary>
        /// The Trade weight
        /// <summary>
        public TextEntryViewModel TradeWeight { get; set; }

        /// <summary>
        /// The Trade fuel type
        /// <summary>
        public TextEntryViewModel TradeFuelType { get; set; }

        /// <summary>
        /// The Trade lienholder
        /// <summary>
        public TextEntryViewModel TradeLienholder { get; set; }

        /// <summary>
        /// The Trade lien contact
        /// <summary>
        public TextEntryViewModel TradeLienContact { get; set; }

        /// <summary>
        /// The Trade lien address
        /// <summary>
        public TextEntryViewModel TradeLienAddress { get; set; }

        /// <summary>
        /// The Trade lien city
        /// <summary>
        public TextEntryViewModel TradeLienCity { get; set; }

        /// <summary>
        /// The Trade lien st
        /// <summary>
        public TextEntryViewModel TradeLienSt { get; set; }

        /// <summary>
        /// The Trade lien zip
        /// <summary>
        public TextEntryViewModel TradeLienZip { get; set; }

        /// <summary>
        /// The Trade lien phone
        /// <summary>
        public TextEntryViewModel TradeLienPhone { get; set; }

        /// <summary>
        /// The Trade good until
        /// <summary>
        public DateSelectionViewModel TradeGoodUntil { get; set; }

        /// <summary>
        /// The Trade daily interest
        /// <summary>
        public DecimalInputViewModel TradeDailyInterest { get; set; }

        /// <summary>
        /// The Trade lien account number
        /// <summary>
        public TextEntryViewModel TradeLienAccountNumber { get; set; }

        /// <summary>
        /// The Trade status
        /// <summary>
        public TextEntryViewModel TradeStatus { get; set; }

        /// <summary>
        /// The Trade lease
        /// <summary>
        public bool TradeLease { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// <summary>
        public TradeViewModel()
        {

        }

        #endregion
    }
}

    
