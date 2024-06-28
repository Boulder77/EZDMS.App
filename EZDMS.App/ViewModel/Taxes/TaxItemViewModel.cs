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

        #region Private Members

        private decimal mRate;

        #endregion

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
        public decimal Rate
        {
            get => mRate;

            set
            {
                // Make sure list has changed
                if (mRate  == value)
                    return;


                // Update value
                mRate = value;

                // Update view model                                
                Save();

            }

        }

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

        /// <summary>
        /// Indicates if the local fee is being saved
        /// </summary>
        public bool Saving { get; set; }

        /// <summary>
        /// The action to run when saving the amount.
        /// Returns true if the commit was successful, or false otherwise.
        /// </summary>
        public Func<Task<bool>> SaveAction { get; set; }

        #endregion

        #region Command Methods

        public void Save()
        {
            // Store the result of a commit call
            var result = default(bool);


            RunCommandAsync(() => Saving, async () =>
            {

                //// Commit the changed text
                //// So we can see it while it is working
                //OriginalAmount = Amount;

                // Try and do the work
                result = SaveAction == null ? true : await SaveAction();

            }).ContinueWith(t =>
            {
                // If we succeeded...
                // Nothing to do
                // If we fail...
                if (!result)
                {
                    //// Restore original value
                    //OriginalAmount = currentSavedValue;

                }
            });
        }

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