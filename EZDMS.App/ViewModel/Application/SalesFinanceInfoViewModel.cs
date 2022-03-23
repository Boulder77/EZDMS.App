﻿using Dna;
using EZDMS.App.Core;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using static EZDMS.App.DI;

namespace EZDMS.App
{
    /// <summary>
    /// The View Model for a Sales Recall screen
    /// </summary>
    public class SalesFinanceInfoViewModel : BaseViewModel
    {
        #region Private Members


        /// <summary>
        /// The current working sales deal 
        /// </summary>
        private SalesFinanceDataModel mWorkingDeal;

        #endregion

        #region Public Properties
        /// <summary>
        /// The current working sales deal 
        /// </summary>
        public SalesFinanceDataModel WorkingDeal
        {
            get => mWorkingDeal;
            set
            {
                if (mWorkingDeal == value)
                    return;

                mWorkingDeal = value;
            }
        }

        /// <summary>
        /// The current working sales deal number
        /// </summary>
        public int WorkingDealNumber { get; set; }

        /// <summary>
        /// The current buyer name
        /// </summary>
        public TextDisplayViewModel BuyerName { get; set; }

        /// <summary>
        /// The current Co-Buyer name
        /// </summary>
        public TextDisplayViewModel CoBuyerName { get; set; }

        /// <summary>
        /// The current vehicle info
        /// </summary>
        public TextDisplayViewModel Vehicle { get; set; }

        /// <summary>
        /// The current status of the sales deal
        /// </summary>
        public TextDisplayViewModel Status { get; set; }

        /// <summary>
        /// The current type of the sales deal
        /// </summary>
        public TextDisplayViewModel DealType { get; set; }

        /// <summary>
        /// The current salesperson name
        /// </summary>
        public TextDisplayViewModel Salesperson { get; set; }

        /// <summary>
        /// The current trade vehicle(s) info
        /// </summary>
        public TextDisplayViewModel Trades { get; set; }

        /// <summary>
        /// The current created Date
        /// </summary>
        public TextDisplayViewModel CreatedDate { get; set; }

        /// <summary>
        /// Indicates if the sales finance deal details are currently being loaded
        /// </summary>
        public bool SalesFinanceInfoPageLoading { get; set; } 

        #endregion



        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SalesFinanceInfoViewModel()
        {
            // Create commands

            // Task.Run(GetSalesRecallDealsAsync);

        }

        #endregion

        public async Task CreateNewSalesFinanceDealAsync()
        {
            await Task.Delay(1);
        }


    }

}
