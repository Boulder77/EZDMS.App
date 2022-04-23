namespace EZDMS.App
{
    /// <summary>
    /// The design-time data for a <see cref="TextEntryViewModel"/>
    /// </summary>
    public class NumericalEntryDesignModel : NumericalEntryViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static NumericalEntryDesignModel Instance => new NumericalEntryDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public NumericalEntryDesignModel()
        {
            Label = "Selling Price";
            OriginalAmount = 15687522;            
            EditedText = "Editing...";
            Editable = true;
        }

        #endregion
    }
}
