namespace EZDMS.App
{
    /// <summary>
    /// The view model for the vehicle basic info control
    /// <summary>
    public class VehicleBasicInfoViewModel : BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// The description of the vehicle
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The VIN of the vehicle
        /// </summary>
        public TextEntryViewModel VIN { get; set; }

        /// <summary>
        /// The stock number of the vehicle
        /// </summary>
        public TextEntryViewModel StockNumber { get; set; }

        /// <summary>
        /// The type of the vehicle
        /// </summary>
        public TextEntryViewModel Type { get; set; }

        /// <summary>
        /// The status of the vehicle
        /// </summary>
        public TextEntryViewModel Status { get; set; }

        /// <summary>
        /// The year of the vehicle
        /// </summary>
        public TextEntryViewModel Year { get; set; }

        /// <summary>
        /// The make of the vehicle
        /// </summary>
        public TextEntryViewModel Make { get; set; }

        /// <summary>
        /// The model of the vehicle
        /// </summary>
        public TextEntryViewModel Model { get; set; }

        /// <summary>
        /// The body of the vehicle
        /// </summary>
        public TextEntryViewModel Body { get; set; }

        /// <summary>
        /// The trim of the vehicle
        /// </summary>
        public TextEntryViewModel Trim { get; set; }

        /// <summary>
        /// The exterior color of the vehicle
        /// </summary>
        public TextEntryViewModel ExteriorColor { get; set; }

        /// <summary>
        /// The interior color of the vehicle
        /// </summary>
        public TextEntryViewModel InteriorColor { get; set; }

        /// <summary>
        /// The class of the vehicle
        /// </summary>
        public TextEntryViewModel Class { get; set; }

        /// <summary>
        /// The odometer of the vehicle
        /// </summary>
        public TextEntryViewModel Odometer { get; set; }

        /// <summary>
        /// The odometer status of the vehicle
        /// </summary>
        public TextEntryViewModel OdometerStatus { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public VehicleBasicInfoViewModel()
        {




        }

        #endregion
    }
}
