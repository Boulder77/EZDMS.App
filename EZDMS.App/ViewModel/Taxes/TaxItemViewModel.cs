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
    /// The view model for the tax item control
    /// <summary>
    public class TaxItemViewModel : BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// The name of the tax item
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The tax item base
        /// </summary>
        public decimal Base { get; set; }

        /// <summary>
        /// The tax item rate
        /// </summary>
        public decimal Rate { get; set; }

        /// <summary>
        /// The tax item saved amount
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Indicates if the tax item can be edited
        /// </summary>
        public bool Editable { get; set; } = true;

        /// <summary>
        /// Indicates if the tax item is active
        /// </summary>
        public bool Active { get; set; }



        #endregion

        #region Constructor 

        /// <summary>
        /// Default constructor
        /// </summary>
        public TaxItemViewModel()
        {
        
        }

        #endregion
    
    }
}