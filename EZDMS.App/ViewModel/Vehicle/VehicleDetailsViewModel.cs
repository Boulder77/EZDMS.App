namespace EZDMS.App
{
    /// <summary>
    /// The view model for the vehicle details control
    /// <summary>
    public class VehicleDetailsViewModel : BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// The vehicle lot location
        /// <summary>
        public TextEntryViewModel LotLocation { get; set; }

        /// <summary>
        /// The style of the vehicle
        /// </summary>
        public TextEntryViewModel Style { get; set; }

        /// <summary>
        /// The vehicle number of doors
        /// <summary>
        public TextEntryViewModel NumberOfDoors { get; set; }

        /// <summary>
        /// The vehicle cylinders
        /// <summary>
        public TextEntryViewModel Cylinders { get; set; }

        /// <summary>
        /// The vehicle fuel type
        /// <summary>
        public TextEntryViewModel FuelType { get; set; }

        /// <summary>
        /// The vehicle fuel system
        /// <summary>
        public TextEntryViewModel FuelSystem { get; set; }

        /// <summary>
        /// The vehicle fuel economy
        /// <summary>
        public TextEntryViewModel FuelEconomy { get; set; }

        /// <summary>
        /// The vehicle transmission type
        /// <summary>
        public TextEntryViewModel TransmissionType { get; set; }

        /// <summary>
        /// The vehicle transmission speed
        /// <summary>
        public TextEntryViewModel TransmissionSpeed { get; set; }

        /// <summary>
        /// The vehicle drivetrain
        /// <summary>
        public TextEntryViewModel Drivetrain { get; set; }

        /// <summary>
        /// The vehicle engine
        /// <summary>
        public TextEntryViewModel Engine { get; set; }

        /// <summary>
        /// The vehicle engine type
        /// <summary>
        public TextEntryViewModel EngineType { get; set; }

        /// <summary>
        /// The vehicle engine serial number
        /// <summary>
        public TextEntryViewModel EngineSerialNumber { get; set; }

        /// <summary>
        /// The vehicle ignition key code
        /// <summary>
        public TextEntryViewModel IgnitionKeyCode { get; set; }

        /// <summary>
        /// The vehicle trunk key code
        /// <summary>
        public TextEntryViewModel TrunkKeyCode { get; set; }

        /// <summary>
        /// The vehicle weight
        /// <summary>
        public TextEntryViewModel Weight { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public VehicleDetailsViewModel()
        {

        }

        #endregion
    }
}
