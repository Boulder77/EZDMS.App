namespace EZDMS.App
{
    /// <summary>
    /// The design-time data for a <see cref="TextInputViewModel"/>
    /// </summary>
    public class TextInputDesignModel : TextInputViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static TextInputDesignModel Instance => new TextInputDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public TextInputDesignModel()
        {
            Label = "Name";
            Text = "Sienna Islas";
            
        }

        #endregion
    }
}
