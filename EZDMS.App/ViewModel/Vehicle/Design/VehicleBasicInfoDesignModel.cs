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
            
            StockNumber = new TextInputViewModel { Label = "Stock Number", Text = "P1807" };
            VIN = new TextInputViewModel { Label = "VIN", Text = "1GNSKBKC2JR177272" };
            Type = new TextInputViewModel { Label = "Type", Text = "Used" };
            Status = new TextInputViewModel { Label = "Status", Text = "In Stock" };
            Year = new TextInputViewModel { Label = "Year", Text = "2018" };            
            Make = new TextInputViewModel { Label = "Make", Text = "Chevrolet" };
            Model = new TextInputViewModel { Label = "Model", Text = "Tahoe" };
            Trim = new TextInputViewModel { Label = "Trim", Text = "LT" };
            Body = new TextInputViewModel { Label = "Body", Text = "Utility" };
            ExteriorColor = new TextInputViewModel { Label = "Exterior Color", Text = "Silver" };
            InteriorColor = new TextInputViewModel { Label = "Interior Color", Text = "Black" };
            Class = new TextInputViewModel { Label = "Class", Text = "Passenger" };
            Odometer = new TextInputViewModel { Label = "Odometer", Text = "34,555" };
            OdometerStatus = new TextInputViewModel { Label = "Odometer Status", Text = "Actual Miles" };
            HasFactoryWarranty = true;
        }

        #endregion
    }
}
