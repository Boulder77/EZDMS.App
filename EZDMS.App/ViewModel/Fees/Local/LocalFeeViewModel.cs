using Dna;
using EZDMS.App.Core;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using static EZDMS.App.DI;

namespace EZDMS.App
{
    /// <summary>
    /// The view model for the product item control
    /// <summary>
    public class LocalFeeViewModel : BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// The label to identify what this value is for
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The current saved amount
        /// </summary>
        public decimal Amount { get; set; }        

        /// <summary>
        /// Indicates if the current amount can be edited
        /// </summary>
        public bool Editable { get; set; } = true;

        /// <summary>
        /// Indicates if the current amount is financed
        /// </summary>
        public bool InPayment { get; set; }

        /// <summary>
        /// Indicates if the current amount is taxable
        /// </summary>
        public bool Taxable { get; set; }

        #endregion

        

        #region Constructor 

        /// <summary>
        /// Default constructor
        /// </summary>
        public LocalFeeViewModel()
        {
        
        }

        #endregion

    
    }
}