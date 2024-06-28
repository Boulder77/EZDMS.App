using System.Collections.Generic;

namespace EZDMS.App
{
    /// <summary>
    /// The design-time data for a <see cref="TaxItemViewModel"/>
    /// <summary>
    public class TaxItemDesignModel : TaxItemViewModel
    {

        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// <summary>
        public static TaxItemDesignModel Instance => new TaxItemDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// <summary>
        public TaxItemDesignModel()
        {
            Name = "State";
            Rate = 8.25m;
            Base = 350000m;
            Active = true;
            Amount = (Rate/100)*Base;
        }

        #endregion
    }
}
