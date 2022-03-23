using System.Collections.Generic;

namespace EZDMS.App
{
    /// <summary>
    /// The design-time data for a <see cref="SalesFinanceInfoDesignModel"/>
    /// </summary>
    public class SalesFinanceInfoDesignModel : SalesFinanceInfoViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static SalesFinanceInfoDesignModel Instance => new SalesFinanceInfoDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SalesFinanceInfoDesignModel()
        {
            BuyerName = new TextDisplayViewModel { Label = "Buyer", DisplayText = "Gomez, Donald" };
            CoBuyerName = new TextDisplayViewModel { Label = "Co-Buyer", DisplayText = "Bell, Betrix" };
            Vehicle = new TextDisplayViewModel { Label = "Vehicle", DisplayText = "P1807 - 2018 Chevrolet Tahoe" };
            Status = new TextDisplayViewModel { Label = "Status", DisplayText = "Working" };
            DealType = new TextDisplayViewModel { Label = "Deal Type", DisplayText = "Retail" };
            Salesperson = new TextDisplayViewModel { Label = "Salesperson", DisplayText = "Matt Islas" };
            Trades = new TextDisplayViewModel { Label = "Trades", DisplayText = "1900 Toyota Corolla black" };
            CreatedDate = new TextDisplayViewModel { Label = "Created Date", DisplayText = "8/27/2021" };

        }

        #endregion
    }
}
