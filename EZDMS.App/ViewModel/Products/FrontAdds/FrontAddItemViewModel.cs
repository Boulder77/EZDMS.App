﻿using Dna;
using EZDMS.App.Core;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using static EZDMS.App.DI;

namespace EZDMS.App
{
    /// <summary>
    /// The view model for the product item control
    /// <summary>
    public class FrontAddItemViewModel : BaseViewModel
    {

        #region Private Members

        /// <summary>
        ///  The retail amount for the front add item
        /// </summary>
        private decimal mRetail;

        /// <summary>
        /// The selected front add
        /// </summary>
        private SystemFrontAddsDataModel mSelectedItem;

        /// <summary>
        /// The list of all active front adds in the system
        /// </summary>
        protected ObservableCollection<SystemFrontAddsDataModel> mItems;

        #endregion

        #region Public Properties


        public ObservableCollection<SystemFrontAddsDataModel> Items
        {
            get => mItems;
            
            set
            {
                // Make sure list has changed
                if (mItems == value)
                    return;

                // Update value
                mItems = value;
                               

            }
        }

        public SystemFrontAddsDataModel SelectedItem
        {
            get => mSelectedItem;

            set
            {
                // Make sure list has changed
                if (mSelectedItem == value)
                    return;

                // Update value
                mSelectedItem = value;

                if (value != null)
                    // Update the view model
                    UpdateValuesFromDataModel(mSelectedItem);

            }

        }

        /// <summary>
        /// The retail amount for the front add item
        /// <summary>
        public decimal Retail  
        {
            get => mRetail;
            
            set
            {
                // Make sure list has changed
                if (mRetail == value)
                    return;

                // Update value
                mRetail = value;

                // Update view model
                Update();
            }    
        }

        /// <summary>
        /// The product cost
        /// <summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// The product default in payment flag
        /// <summary>
        public bool InPayment { get; set; }
               
        /// <summary>
        /// The product taxable flag
        /// <summary>
        public bool Taxable { get; set; }

        /// <summary>
        /// The flag to indicate that the application is doing something
        /// <summary>
        public bool Working { get; set; }

        /// <summary>
        /// The flag to indicate if the front add is the last item on the list
        /// <summary>
        public bool LastItem { get; set; }

        /// <summary>
        /// The action to run when saving the amount.
        /// Returns true if the commit was successful, or false otherwise.
        /// </summary>
        public Func<Task<bool>> UpdateAction { get; set; }

        #endregion

        #region Public Commands

       
        /// The command to add an item
        /// </summary>
        public ICommand AddCommand { get; set; }

        public DelegateCommand<object> DeleteCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// <summary>
        public FrontAddItemViewModel()
        {
           


        }

        #endregion

        private void UpdateValuesFromDataModel(SystemFrontAddsDataModel frontAdd)
        {
            if (frontAdd == null)
                return;
             
            Retail = frontAdd.Retail;
            Cost = frontAdd.Cost;
           
            Taxable = (bool)frontAdd.IsTaxable;
            InPayment = (bool)frontAdd.InPayment;          

        }
                      
        private void Update()
        {
            // Store the result of a commit call
            var result = default(bool);


            RunCommandAsync(() => Working, async () =>
            {

                //// Commit the changed text
                //// So we can see it while it is working
                //OriginalAmount = Amount;

                // Try and do the work
                result = UpdateAction == null ? true : await UpdateAction();

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




    }
}
