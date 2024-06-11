namespace EZDMS.App
{
    /// <summary>
    /// The design-time data for a <see cref="NumericalInputViewModel"/>
    /// </summary>
    public class NumericalInputDesignModel : NumericalInputViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static NumericalInputDesignModel Instance => new NumericalInputDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public NumericalInputDesignModel()
        {
            Label = "Term";
            Number = 30;            
            
            Editable = true;
        }

        #endregion
    }
}
