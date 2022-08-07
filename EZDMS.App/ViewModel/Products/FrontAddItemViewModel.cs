﻿using Dna;
using EZDMS.App.Core;
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
        private FrontAddsDataModel mSelectedAdd;

        /// <summary>
        /// The list of all active front adds
        /// </summary>
        protected ObservableCollection<FrontAddsDataModel> mFrontAdds;

        #endregion

        #region Public Properties


        public ObservableCollection<FrontAddsDataModel> FrontAdds
        {
            get => mFrontAdds;
            
            set
            {
                // Make sure list has changed
                if (mFrontAdds == value)
                    return;

                // Update value
                mFrontAdds = value;

                // Update filtered list to match
                FilteredAdds = new ObservableCollection<FrontAddsDataModel>(mFrontAdds);
            }
        }


        public ObservableCollection<FrontAddsDataModel> FilteredAdds { get; set; }

        public FrontAddsDataModel SelectedAdd
        {
            get => mSelectedAdd;

            set
            {
                // Make sure list has changed
                if (mSelectedAdd == value)
                    return;

                // Update value
                mSelectedAdd = value;

                if (value != null)
                    // Update the view model
                    UpdateValuesFromDataModel(mSelectedAdd);

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
        /// The action to run when saving the amount.
        /// Returns true if the commit was successful, or false otherwise.
        /// </summary>
        public Func<Task<bool>> UpdateAction { get; set; }

        #endregion

        #region Public Commands

        /// <summary>
        /// The command to clear the users data from the view model
        /// </summary>
        public ICommand ClearUserDataCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// <summary>
        public FrontAddItemViewModel()
        {

            ClearUserDataCommand = new RelayCommand(ClearUserData);

        }

        #endregion

        private void UpdateValuesFromDataModel(FrontAddsDataModel frontAdd)
        {
            if (frontAdd == null)
                return;
             
            Retail = frontAdd.Retail;
            Cost = frontAdd.Cost;
           
            Taxable = (bool)frontAdd.IsTaxable;
            InPayment = (bool)frontAdd.InPayment;          

        }
              

        public void ClearUserData()
        {
            //// Clear all view models containing the users info
            //SelectedProvider =null;
            //SelectedPlan = null;
            //Retail = 0;
            //Cost.Amount = 0;
            //ContractNumber.Text = "";
            //Term.Text = "";
            //Miles.Text = "";
            //Deductible.Amount = 0;
            //InPayment = false;
            //Taxable = false;
            //IsDisappearingDeductible = false;

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