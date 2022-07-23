using Dna;
using EZDMS.App.Core;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using static EZDMS.App.DI;

namespace EZDMS.App
{
    /// <summary>
    /// The view model for the SalesGap control
    /// <summary>
    public class SalesGapViewModel : BaseViewModel
    {

        #region Public Properties
               
       
        /// <summary>
        /// The SalesGap plan
        /// <summary>
        public TextInputViewModel Plan { get; set; }

        /// <summary>
        /// The SalesGap retail
        /// <summary>
        public DecimalInputViewModel Retail { get; set; }

        /// <summary>
        /// The SalesGap cost
        /// <summary>
        public DecimalInputViewModel Cost { get; set; }

        /// <summary>
        /// The SalesGap profit
        /// <summary>
        public DecimalInputViewModel Profit { get; set; }

        /// <summary>
        /// The SalesGap dealer number
        /// <summary>
        public TextInputViewModel DealerNumber { get; set; }

        /// <summary>
        /// The SalesGap in payment
        /// <summary>
        public bool InPayment { get; set; }

        /// <summary>
        /// The SalesGap in cap
        /// <summary>
        public bool InCap { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// <summary>
        public SalesGapViewModel()
        {

        }

        #endregion
    }
}

