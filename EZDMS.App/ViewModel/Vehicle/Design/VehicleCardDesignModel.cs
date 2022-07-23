
namespace EZDMS.App
{
    /// <summary>
    /// The design-time data for a <see cref="VehicleCardViewModel"/>
    /// </summary>
    public class VehicleCardDesignModel : VehicleCardViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static VehicleCardDesignModel Instance => new VehicleCardDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public VehicleCardDesignModel()

        {

            Description = "2018 Chevrolet Tahoe";
            StockNumber = new TextInputViewModel { Label = "Stock Number", Text = "P1807", Editable = false };
            Type = new TextInputViewModel { Label = "Type", Text = "Used", Editable = false };
            Status = new TextInputViewModel { Label = "Status", Text = "In Stock", Editable = false };
            DaysInStock = new TextInputViewModel { Label = "In Stock", Text = "1,620 days", Editable = false };
            Color = new TextInputViewModel { Label = "Color", Text = "Silver", Editable = false };
            InteriorColor = new TextInputViewModel { Label = "Interior", Text = "Black", Editable = false };
            LotLocation = new TextInputViewModel { Label = "Lot Location", Text = "-", Editable = false };
            Category = new TextInputViewModel { Label = "Category", Text = "-", Editable = false };
            VIN = new TextInputViewModel { Label = "VIN", Text = "1GNSKBKC2JR177272", Editable = false };
            Odometer = new TextInputViewModel { Label = "Odometer", Text = "34,555 miles", Editable = false };
            MSRP = new TextInputViewModel { Label = "MSRP", Text = "$56,875.00", Editable = false };
            ListPrice = new TextInputViewModel { Label = "List Price", Text = "$56,875.00", Editable = false };
            InternetPrice = new TextInputViewModel { Label = "Internet Price", Text = "$56,875.00", Editable = false };

        }

        #endregion
    }
}
