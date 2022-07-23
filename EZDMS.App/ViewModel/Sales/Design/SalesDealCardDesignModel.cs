using System.Collections.Generic;

namespace EZDMS.App
{
    /// <summary>
    /// The design-time data for a <see cref="SalesDealCardViewModel"/>
    /// </summary>
    public class SalesDealCardDesignModel : SalesDealCardViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static SalesDealCardDesignModel Instance => new SalesDealCardDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SalesDealCardDesignModel()
        {
            BuyerName = new TextInputViewModel { Label = "Buyer", Text = "Gomez, Donald", Editable = false };
            CoBuyerName = new TextInputViewModel { Label = "Co-Buyer", Text = "Bell, Betrix", Editable = false };
            Vehicle = new TextInputViewModel { Label = "Vehicle", Text = "P1807 - 2018 Chevrolet Tahoe", Editable = false };
            Status = new TextInputViewModel { Label = "Status", Text = "Working", Editable = false };
            DealType = new TextInputViewModel { Label = "Deal Type", Text = "Retail", Editable = false };
            Salesperson = new TextInputViewModel { Label = "Salesperson", Text = "Matt Islas", Editable = false };
            SalesManager = new TextInputViewModel { Label = "Sales Manager", Text = "Chris Dixon", Editable = false };
            FinanceManager = new TextInputViewModel { Label = "Finance Manager", Text = "Gary Zimmerman", Editable = false };
            Trades = new TextInputViewModel { Label = "Trades", Text = "1900 Toyota Corolla black", Editable = false };
            CreatedDate = new TextInputViewModel { Label = "Created Date", Text = "8/27/2021", Editable = false };
            DealDate = new TextInputViewModel { Label = "Purchase Date", Text = "8/27/2021", Editable = false };
            LastActivityDate = new TextInputViewModel { Label = "Last Activity", Text = "3/18/2022", Editable = false };

        }

        #endregion
    }
}
