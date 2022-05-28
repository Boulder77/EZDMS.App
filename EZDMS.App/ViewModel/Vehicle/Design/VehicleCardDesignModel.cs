
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
            StockNumber = new TextDisplayViewModel { Label = "Stock Number", DisplayText = "P1807" };
            Type = new TextDisplayViewModel { Label = "Type", DisplayText = "Used" };
            Status = new TextDisplayViewModel { Label = "Status", DisplayText = "In Stock" };
            DaysInStock = new TextDisplayViewModel { Label = "In Stock", DisplayText = "1,620 days" };
            Color = new TextDisplayViewModel { Label = "Color", DisplayText = "Silver" };
            InteriorColor = new TextDisplayViewModel { Label = "Interior", DisplayText = "Black" };
            LotLocation = new TextDisplayViewModel { Label = "Lot Location", DisplayText = "-" };
            Category = new TextDisplayViewModel { Label = "Category", DisplayText = "-" };
            VIN = new TextDisplayViewModel { Label = "VIN", DisplayText = "1GNSKBKC2JR177272" };
            Odometer = new TextDisplayViewModel { Label = "Odometer", DisplayText = "34,555 miles" };
            MSRP = new TextDisplayViewModel { Label = "MSRP", DisplayText = "$56,875.00" };
            ListPrice = new TextDisplayViewModel { Label = "List Price", DisplayText = "$56,875.00" };
            InternetPrice = new TextDisplayViewModel { Label = "Internet Price", DisplayText = "$56,875.00" };

        }

        #endregion
    }
}
