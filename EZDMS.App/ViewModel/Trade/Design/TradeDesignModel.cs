using System.Collections.Generic;
using System;
using EZDMS.App.Core;

namespace EZDMS.App
{
    /// <summary>
    /// The design-time data for a <see cref="TradeViewModel"/>
    /// </summary>
    public class TradeDesignModel : TradeViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static TradeDesignModel Instance => new TradeDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public TradeDesignModel()

        {
            
            StockNumber = new TextInputViewModel { Label = "Stock Number", Text = "P1807" };
            VIN = new TextInputViewModel { Label = "VIN", Text = "1GNSKBKC2JR177272" };            
            Status = new TextInputViewModel { Label = "Status", Text = "In Stock" };
            Year = new NumericalInputViewModel { Label = "Year", Number = 2018 };            
            Make = new TextInputViewModel { Label = "Make", Text = "Chevrolet" };
            Model = new TextInputViewModel { Label = "Model", Text = "Tahoe" };
            Trim = new TextInputViewModel { Label = "Trim", Text = "LT" };
            BodyType = new TextInputViewModel { Label = "Body", Text = "Utility" };
            ExteriorColor = new TextInputViewModel { Label = "Exterior Color", Text = "Silver" };
            InteriorColor = new TextInputViewModel { Label = "Interior Color", Text = "Black" };
            Class = new TextInputViewModel { Label = "Class", Text = "Passenger" };
            Odometer = new NumericalInputViewModel { Label = "Odometer", Number = 34555 };
           
        }

        #endregion
    }
}
