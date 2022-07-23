namespace EZDMS.App
{
    /// <summary>
    /// The view model for the vehicle card control
    /// <summary>
    public class VehicleCardViewModel : BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// The description of the vehicle
        /// </summary>
        public string Description { get; set; }

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
        /// The number of days in stock for the vehicle
        /// </summary>
        public TextInputViewModel DaysInStock { get; set; }

        /// <summary>
        /// The color of the vehicle
        /// </summary>
        public TextInputViewModel Color { get; set; }

        /// <summary>
        /// The interior color of the vehicle
        /// </summary>
        public TextInputViewModel InteriorColor { get; set; }

        /// <summary>
        /// The lot location of the vehicle
        /// </summary>
        public TextInputViewModel LotLocation { get; set; }

        /// <summary>
        /// The category of the vehicle
        /// </summary>
        public TextInputViewModel Category { get; set; }

        /// <summary>
        /// The VIN of the vehicle
        /// </summary>
        public TextInputViewModel VIN { get; set; }

        /// <summary>
        /// The odometer of the vehicle
        /// </summary>
        public TextInputViewModel Odometer { get; set; }

        /// <summary>
        /// The MSRP of the vehicle
        /// </summary>
        public TextInputViewModel MSRP { get; set; }

        /// <summary>
        /// The list price of the vehicle
        /// </summary>
        public TextInputViewModel ListPrice { get; set; }

        /// <summary>
        /// The internet price of the vehicle
        /// </summary>
        public TextInputViewModel InternetPrice { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public VehicleCardViewModel()
        {




        }

        #endregion
    }
}
