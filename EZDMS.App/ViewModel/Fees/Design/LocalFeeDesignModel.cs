using System.Collections.Generic;

namespace EZDMS.App
{
    /// <summary>
    /// The design-time data for a <see cref="LocalFeeViewModel"/>
    /// <summary>
    public class LocalFeeDesignModel : LocalFeeViewModel
    {

        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// <summary>
        public static LocalFeeDesignModel Instance => new LocalFeeDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// <summary>
        public LocalFeeDesignModel()
        {
            Label = "Document Fee";
            Amount = 29500;
            InPayment = true;
            Taxable = true;
        }

        #endregion
    }
}
