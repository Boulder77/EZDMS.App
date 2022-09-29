using Dna;
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

        protected CoverageProviderDataModel mSelectedProvider;

        private decimal mRetail;

        /// <summary>
        /// The plans for the list
        /// </summary>
        protected ObservableCollection<CoveragePlanDataModel> mPlans;

        #endregion

        #region Public Properties

        public ObservableCollection<CoverageProviderDataModel> Providers { get; set; }

        public ObservableCollection<CoveragePlanDataModel> Plans
        {
            get => mPlans;
            set
            {
                // Make sure list has changed
                if (mPlans == value)
                    return;

                // Update value
                mPlans = value;

                // Update filtered list to match
                FilteredPlans = new ObservableCollection<CoveragePlanDataModel>(mPlans);
            }
        }


        public ObservableCollection<CoveragePlanDataModel> FilteredPlans { get; set; }

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

                if (value != null)
                    // Update the view model
                    UpdateValuesFromDataModel(mSelectedPlan);

            }

        }

        public CoverageProviderDataModel SelectedProvider
        {
            get => mSelectedProvider;

            set
            {
                // Make sure list has changed
                if (mSelectedProvider == value)
                    return;

                // Update value
                mSelectedProvider = value;

                if (value != null)
                    // Update the view model
                    UpdateValuesOfFilteredPlans(mSelectedProvider.Number);

            }

        }

        /// <summary>
        /// The product type
        /// <summary>
        public TextInputViewModel Type { get; set; }              

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

                // Update view model
                Update();
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
        public TextInputViewModel Miles { get; set; }

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
        public ProductItemViewModel()
        {

            ClearUserDataCommand = new RelayCommand(ClearUserData);

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
            Miles.Text = coveragePlan.Miles.ToString();
            Taxable = coveragePlan.IsTaxable;
            InPayment = coveragePlan.DefaultInPayment;
            IsDisappearingDeductible = coveragePlan.IsDisappearingDeductible;


        }

        private void UpdateValuesOfFilteredPlans(string providerNumber)
        {
            FilteredPlans = new ObservableCollection<CoveragePlanDataModel>(
                Plans.Where(item => item.ProviderNumber == providerNumber));

        }

        public void ClearUserData()
        {
            // Clear all view models containing the users info
            SelectedProvider =null;
            SelectedPlan = null;
            Retail = 0;
            Cost.Amount = 0;
            ContractNumber.Text = "";
            Term.Text = "";
            Miles.Text = "";
            Deductible.Amount = 0;
            InPayment = false;
            Taxable = false;
            IsDisappearingDeductible = false;

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
