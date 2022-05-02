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
            BuyerName = new TextDisplayViewModel { Label = "Buyer", DisplayText = "Gomez, Donald" };
            CoBuyerName = new TextDisplayViewModel { Label = "Co-Buyer", DisplayText = "Bell, Betrix" };
            Vehicle = new TextDisplayViewModel { Label = "Vehicle", DisplayText = "P1807 - 2018 Chevrolet Tahoe" };
            Status = new TextDisplayViewModel { Label = "Status", DisplayText = "Working" };
            DealType = new TextDisplayViewModel { Label = "Deal Type", DisplayText = "Retail" };
            Salesperson = new TextDisplayViewModel { Label = "Salesperson", DisplayText = "Matt Islas" };
            SalesManager = new TextDisplayViewModel { Label = "Sales Manager", DisplayText = "Chris Dixon" };
            FinanceManager = new TextDisplayViewModel { Label = "Finance Manager", DisplayText = "Gary Zimmerman" };
            Trades = new TextDisplayViewModel { Label = "Trades", DisplayText = "1900 Toyota Corolla black" };
            CreatedDate = new TextDisplayViewModel { Label = "Created Date", DisplayText = "8/27/2021" };
            DealDate = new TextDisplayViewModel { Label = "Purchase Date", DisplayText = "8/27/2021" };
            LastActivityDate = new TextDisplayViewModel { Label = "Last Activity", DisplayText = "3/18/2022" };

        }

        #endregion
    }
}
