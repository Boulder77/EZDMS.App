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
        public TextInputViewModel NumberOfDoors { get; set; }

        /// <summary>
        /// The VehicleDetails cylinders
        /// <summary>
        public TextInputViewModel Cylinders { get; set; }

        /// <summary>
        /// The VehicleDetails fuel type
        /// <summary>
        public TextInputViewModel FuelType { get; set; }

        /// <summary>
        /// The VehicleDetails fuel system
        /// <summary>
        public TextInputViewModel FuelSystem { get; set; }

        /// <summary>
        /// The VehicleDetails fuel economy
        /// <summary>
        public TextInputViewModel FuelEconomy { get; set; }

        /// <summary>
        /// The VehicleDetails transmission type
        /// <summary>
        public TextInputViewModel TransmissionType { get; set; }

        /// <summary>
        /// The VehicleDetails transmission speed
        /// <summary>
        public TextInputViewModel TransmissionSpeed { get; set; }

        /// <summary>
        /// The VehicleDetails drivetrain
        /// <summary>
        public TextInputViewModel Drivetrain { get; set; }

        /// <summary>
        /// The VehicleDetails engine
        /// <summary>
        public TextInputViewModel Engine { get; set; }

        /// <summary>
        /// The VehicleDetails engine type
        /// <summary>
        public TextInputViewModel EngineType { get; set; }

        /// <summary>
        /// The VehicleDetails engine serial number
        /// <summary>
        public TextInputViewModel EngineSerialNumber { get; set; }

        /// <summary>
        /// The VehicleDetails ignition key code
        /// <summary>
        public TextInputViewModel IgnitionKeyCode { get; set; }

        /// <summary>
        /// The VehicleDetails trunk key code
        /// <summary>
        public TextInputViewModel TrunkKeyCode { get; set; }

        /// <summary>
        /// The VehicleDetails weight
        /// <summary>
        public TextInputViewModel Weight { get; set; }

        /// <summary>
        /// The VehicleDetails license plate
        /// <summary>
        public TextInputViewModel LicensePlate { get; set; }

        /// <summary>
        /// The VehicleDetails license state
        /// <summary>
        public TextInputViewModel LicenseState { get; set; }

        /// <summary>
        /// The VehicleDetails license expiration date
        /// <summary>
        public DateSelectionViewModel LicenseExpirationDate { get; set; }

        /// <summary>
        /// The VehicleDetails lot location
        /// <summary>
        public TextInputViewModel LotLocation { get; set; }

        /// <summary>
        /// The VehicleDetails style
        /// <summary>
        public TextInputViewModel Style { get; set; }

        /// <summary>
        /// The VehicleDetails model code
        /// <summary>
        public TextInputViewModel ModelCode { get; set; }

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
