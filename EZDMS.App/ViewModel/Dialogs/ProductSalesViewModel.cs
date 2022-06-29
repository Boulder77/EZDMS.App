
namespace EZDMS.App
{
    /// <summary>
    /// The view model for the <see cref="ProductsSalesControl"/>
    /// <summary>
    public class ProductsSalesViewModel:BaseDialogViewModel
    {
    
        #region Public Properties

        /// <summary>
        /// The view model for the service contract
        /// </summary>
        public ProductItemViewModel Service { get; set; }

        /// <summary>
        /// The view model for the warranty
        /// </summary>
        public ProductItemViewModel Warranty { get; set; }

        /// <summary>
        /// The view model for the maintenance
        /// </summary>
        public ProductItemViewModel Maintenance { get; set; }

        /// <summary>
        /// The view model for Gap
        /// </summary>
        public ProductItemViewModel Gap { get; set; }

        /// <summary>
        /// The text for the total retail 
        /// </summary>
        public NumericalEntryViewModel TotalRetail { get; set; }

        /// <summary>
        /// The total of all the retail prices
        /// </summary>
        public decimal TotalRetailAmount { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProductsSalesViewModel()
        {
            
        }

        #endregion
    }
}
