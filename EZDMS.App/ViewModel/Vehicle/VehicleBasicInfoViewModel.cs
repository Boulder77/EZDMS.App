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
        public TextInputViewModel VIN { get; set; }

        /// <summary>
        /// The stock number of the vehicle
        /// </summary>
        public TextInputViewModel StockNumber { get; set; }

        /// <summary>
        /// The type of the vehicle
        /// </summary>
        public TextInputViewModel Type { get; set; }

        /// <summary>
        /// The status of the vehicle
        /// </summary>
        public TextInputViewModel Status { get; set; }

        /// <summary>
        /// The year of the vehicle
        /// </summary>
        public TextInputViewModel Year { get; set; }

        /// <summary>
        /// The make of the vehicle
        /// </summary>
        public TextInputViewModel Make { get; set; }

        /// <summary>
        /// The model of the vehicle
        /// </summary>
        public TextInputViewModel Model { get; set; }

        /// <summary>
        /// The body of the vehicle
        /// </summary>
        public TextInputViewModel Body { get; set; }

        /// <summary>
        /// The trim of the vehicle
        /// </summary>
        public TextInputViewModel Trim { get; set; }

        /// <summary>
        /// The exterior color of the vehicle
        /// </summary>
        public TextInputViewModel ExteriorColor { get; set; }

        /// <summary>
        /// The interior color of the vehicle
        /// </summary>
        public TextInputViewModel InteriorColor { get; set; }

        /// <summary>
        /// The class of the vehicle
        /// </summary>
        public TextInputViewModel Class { get; set; }

        /// <summary>
        /// The odometer of the vehicle
        /// </summary>
        public TextInputViewModel Odometer { get; set; }

        /// <summary>
        /// The odometer status of the vehicle
        /// </summary>
        public TextInputViewModel OdometerStatus { get; set; }

        /// <summary>
        /// The boolean if vehicle is covered under factory warranty
        /// </summary>
        public bool HasFactoryWarranty { get; set; }

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
