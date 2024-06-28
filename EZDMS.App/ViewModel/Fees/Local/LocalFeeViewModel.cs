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
        #region Private Members

        private decimal mAmount;

        #endregion

        #region Public Properties

        /// <summary>
        /// The name of the local fee
        /// </summary>
        public string Label { get; set; }

        public decimal Amount
        {
            get => mAmount;

            set
            {
                // Make sure list has changed
                if (mAmount == value)
                    return;


                // Update value
                mAmount = value;

                // Update view model                                
                Save();

            }

        }

        /// <summary>
        /// Indicates if the local fee can be edited
        /// </summary>
        public bool Editable { get; set; } = true;

        /// <summary>
        /// Indicates if the local fee is financed
        /// </summary>
        public bool InPayment { get; set; }

        /// <summary>
        /// Indicates if the local fee is taxable
        /// </summary>
        public bool Taxable { get; set; }

        /// <summary>
        /// Indicates if the local fee is active
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
        public LocalFeeViewModel()
        {
        
        }

        #endregion
    
    }
}