namespace EZDMS.App
{
    /// <summary>
    /// The view model for the VehicleDetails control
    /// <summary>
    public class VehicleDetailsViewModel : BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// The VehicleDetails number of doors
        /// <summary>
        public TextEntryViewModel NumberOfDoors { get; set; }

        /// <summary>
        /// The VehicleDetails cylinders
        /// <summary>
        public TextEntryViewModel Cylinders { get; set; }

        /// <summary>
        /// The VehicleDetails fuel type
        /// <summary>
        public TextEntryViewModel FuelType { get; set; }

        /// <summary>
        /// The VehicleDetails fuel system
        /// <summary>
        public TextEntryViewModel FuelSystem { get; set; }

        /// <summary>
        /// The VehicleDetails fuel economy
        /// <summary>
        public TextEntryViewModel FuelEconomy { get; set; }

        /// <summary>
        /// The VehicleDetails transmission type
        /// <summary>
        public TextEntryViewModel TransmissionType { get; set; }

        /// <summary>
        /// The VehicleDetails transmission speed
        /// <summary>
        public TextEntryViewModel TransmissionSpeed { get; set; }

        /// <summary>
        /// The VehicleDetails drivetrain
        /// <summary>
        public TextEntryViewModel Drivetrain { get; set; }

        /// <summary>
        /// The VehicleDetails engine
        /// <summary>
        public TextEntryViewModel Engine { get; set; }

        /// <summary>
        /// The VehicleDetails engine type
        /// <summary>
        public TextEntryViewModel EngineType { get; set; }

        /// <summary>
        /// The VehicleDetails engine serial number
        /// <summary>
        public TextEntryViewModel EngineSerialNumber { get; set; }

        /// <summary>
        /// The VehicleDetails ignition key code
        /// <summary>
        public TextEntryViewModel IgnitionKeyCode { get; set; }

        /// <summary>
        /// The VehicleDetails trunk key code
        /// <summary>
        public TextEntryViewModel TrunkKeyCode { get; set; }

        /// <summary>
        /// The VehicleDetails weight
        /// <summary>
        public TextEntryViewModel Weight { get; set; }

        /// <summary>
        /// The VehicleDetails license plate
        /// <summary>
        public TextEntryViewModel LicensePlate { get; set; }

        /// <summary>
        /// The VehicleDetails license state
        /// <summary>
        public TextEntryViewModel LicenseState { get; set; }

        /// <summary>
        /// The VehicleDetails license expiration date
        /// <summary>
        public DateSelectionViewModel LicenseExpirationDate { get; set; }

        /// <summary>
        /// The VehicleDetails lot location
        /// <summary>
        public TextEntryViewModel LotLocation { get; set; }

        /// <summary>
        /// The VehicleDetails style
        /// <summary>
        public TextEntryViewModel Style { get; set; }

        /// <summary>
        /// The VehicleDetails model code
        /// <summary>
        public TextEntryViewModel ModelCode { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// <summary>
        public VehicleDetailsViewModel()
        {

        }

        #endregion
    }
}
