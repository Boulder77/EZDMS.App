namespace EZDMS.App
{
    /// <summary>
    /// The design-time data for a <see cref="DecimalInputViewModel"/>
    /// </summary>
    public class DecimalInputDesignModel : DecimalInputViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static DecimalInputDesignModel Instance => new DecimalInputDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public DecimalInputDesignModel()
        {
            Label = "Selling Price";
            Amount = 156875.22m;            
            
            Editable = true;
        }

        #endregion
    }
}
