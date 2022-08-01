
namespace EZDMS.App
{
    /// <summary>
    /// The design-time data for a <see cref="FrontAddItemViewModel"/>
    /// </summary>
    public class FrontAddItemDesignModel : FrontAddItemViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static FrontAddItemDesignModel Instance => new FrontAddItemDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public FrontAddItemDesignModel()

        {
            
                     
            Retail = 999.00m;
            Cost = 650.00m;            
            InPayment = true;            
            Taxable = true;

        }

        #endregion
    }
}
