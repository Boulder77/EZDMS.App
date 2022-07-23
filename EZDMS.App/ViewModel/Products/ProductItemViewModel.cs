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
    public class ProductItemViewModel : BaseViewModel
    {

        #region Private Members

        protected CoveragePlanDataModel mSelectedPlan;

        private decimal mRetail;

        #endregion


        #region Public Properties

        public ObservableCollection<CoverageProviderDataModel> Providers { get; set; }

        public ObservableCollection<CoveragePlanDataModel> Plans { get; set; }

        public CoveragePlanDataModel SelectedPlan
        {
            get => mSelectedPlan;

            set
            {
                // Make sure list has changed
                if (mSelectedPlan == value)
                    return;

                // Update value
                mSelectedPlan = value;

                // Update the view model
                UpdateValuesFromDataModel(mSelectedPlan);

            }

        }

        public CoverageProviderDataModel SelectedProvider { get; set; }

        /// <summary>
        /// The product type
        /// <summary>
        public TextInputViewModel Type { get; set; }              

        /// <summary>
        /// The product provider
        /// <summary>
        public TextInputViewModel Provider { get; set; }

        /// <summary>
        /// The product plan
        /// <summary>
        public TextInputViewModel Plan { get; set; }

        /// <summary>
        /// The product contract number
        /// <summary>
        public TextInputViewModel ContractNumber { get; set; }

        /// <summary>
        /// The product plan retail price
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

                Change();
            }    
        }

        /// <summary>
        /// The product cost
        /// <summary>
        public DecimalInputViewModel Cost { get; set; }

        /// <summary>
        /// The product deductible
        /// <summary>
        public DecimalInputViewModel Deductible { get; set; }

        /// <summary>
        /// The product term
        /// <summary>
        public TextInputViewModel Term { get; set; }

        /// <summary>
        /// The product mileage
        /// <summary>
        public TextInputViewModel Mileage { get; set; }

        /// <summary>
        /// The product description
        /// <summary>
        public TextInputViewModel Description { get; set; }

        /// <summary>
        /// The product default in payment flag
        /// <summary>
        public bool InPayment { get; set; }

        /// <summary>
        /// The product disappearing deductible flag
        /// <summary>
        public bool IsDisappearingDeductible { get; set; }

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
        public Func<Task<bool>> ChangeAction { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// <summary>
        public ProductItemViewModel()
        {

        }

        #endregion

        private void UpdateValuesFromDataModel(CoveragePlanDataModel coveragePlan)
        {
            if (coveragePlan == null)
                return;
             
            Retail = coveragePlan.Retail;
            Cost.Amount = coveragePlan.Cost;
            Deductible.Amount = coveragePlan.Deductible;
            Term.Text = coveragePlan.Term.ToString();
            Mileage.Text = coveragePlan.Mileage.ToString();
            Taxable = coveragePlan.IsTaxable;
            InPayment = coveragePlan.DefaultInPayment;
            IsDisappearingDeductible = coveragePlan.IsDisappearingDeductible;


        }


        public void Change()
        {
            // Store the result of a commit call
            var result = default(bool);


            RunCommandAsync(() => Working, async () =>
            {

                //// Commit the changed text
                //// So we can see it while it is working
                //OriginalAmount = Amount;

                // Try and do the work
                result = ChangeAction == null ? true : await ChangeAction();

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
