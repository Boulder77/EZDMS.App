using System;
namespace EZDMS.App
{
    /// <summary>
    /// The design-time data for a <see cref="ComboBoxSelectionViewModel"/>
    /// </summary>
    public class ComboBoxDisplayDesignModel : ComboBoxSelectionViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static ComboBoxDisplayDesignModel Instance => new ComboBoxDisplayDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ComboBoxDisplayDesignModel()
        {
            // Label 
            Label = "Deal Type";

            // Items to add
            Items.Add("Retail");
            Items.Add("Lease");
            Items.Add("Cash");
            Items.Add("Wholesale");
            Items.Add("Fleet");
        }

        #endregion
    }
}
