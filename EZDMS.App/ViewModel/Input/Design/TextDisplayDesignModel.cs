namespace EZDMS.App
{
    /// <summary>
    /// The design-time data for a <see cref="TextDisplayViewModel"/>
    /// </summary>
    public class TextDisplayDesignModel : TextDisplayViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static TextDisplayDesignModel Instance => new TextDisplayDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public TextDisplayDesignModel()
        {
            Label = "Buyer";
            DisplayText = "Gomez, Donald";         
        }

        #endregion
    }
}
