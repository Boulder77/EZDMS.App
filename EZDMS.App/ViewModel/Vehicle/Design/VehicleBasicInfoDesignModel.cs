using System.Collections.Generic;
using System;
using EZDMS.App.Core;

namespace EZDMS.App
{
    /// <summary>
    /// The design-time data for a <see cref="VehicleBasicInfoDesignModel"/>
    /// </summary>
    public class VehicleBasicInfoDesignModel : VehicleBasicInfoViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static VehicleBasicInfoDesignModel Instance => new VehicleBasicInfoDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public VehicleBasicInfoDesignModel()

        {
            
            StockNumber = new TextEntryViewModel { Label = "Stock Number", OriginalText = "P1807" };
            VIN = new TextEntryViewModel { Label = "VIN", OriginalText = "1GNSKBKC2JR177272" };
            Type = new TextEntryViewModel { Label = "Type", OriginalText = "Used" };
            Status = new TextEntryViewModel { Label = "Status", OriginalText = "In Stock" };
            Year = new TextEntryViewModel { Label = "Year", OriginalText = "2018" };            
            Make = new TextEntryViewModel { Label = "Make", OriginalText = "Chevrolet" };
            Model = new TextEntryViewModel { Label = "Model", OriginalText = "Tahoe" };
            Trim = new TextEntryViewModel { Label = "Trim", OriginalText = "LT" };
            Body = new TextEntryViewModel { Label = "Body", OriginalText = "Utility" };
            ExteriorColor = new TextEntryViewModel { Label = "Exterior Color", OriginalText = "Silver" };
            InteriorColor = new TextEntryViewModel { Label = "Interior Color", OriginalText = "Black" };
            Class = new TextEntryViewModel { Label = "Class", OriginalText = "Passenger" };
            Odometer = new TextEntryViewModel { Label = "Odometer", OriginalText = "34,555" };
            OdometerStatus = new TextEntryViewModel { Label = "Odometer Status", OriginalText = "Actual Miles" };

        }

        #endregion
    }
}
