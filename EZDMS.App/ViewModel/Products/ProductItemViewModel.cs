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
        public TextDisplayViewModel Type { get; set; }              

        /// <summary>
        /// The product provider
        /// <summary>
        public TextEntryViewModel Provider { get; set; }

        /// <summary>
        /// The product plan
        /// <summary>
        public TextEntryViewModel Plan { get; set; }

        /// <summary>
        /// The product contract number
        /// <summary>
        public TextEntryViewModel ContractNumber { get; set; }

        /// <summary>
        /// The product plan retail price
        /// <summary>
        public NumericalEntryViewModel Retail { get; set; }

        /// <summary>
        /// The product cost
        /// <summary>
        public NumericalEntryViewModel Cost { get; set; }

        /// <summary>
        /// The product deductible
        /// <summary>
        public NumericalEntryViewModel Deductible { get; set; }

        /// <summary>
        /// The product term
        /// <summary>
        public TextEntryViewModel Term { get; set; }

        /// <summary>
        /// The product mileage
        /// <summary>
        public TextEntryViewModel Mileage { get; set; }

        /// <summary>
        /// The product description
        /// <summary>
        public TextEntryViewModel Description { get; set; }

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

            Retail.OriginalAmount = coveragePlan.Retail;
            Cost.OriginalAmount = coveragePlan.Cost;
            Deductible.OriginalAmount = coveragePlan.Deductible;
            Term.OriginalText = coveragePlan.Term.ToString();
            Mileage.OriginalText = coveragePlan.Mileage.ToString();
            Taxable = coveragePlan.IsTaxable;
            InPayment = coveragePlan.DefaultInPayment;
            IsDisappearingDeductible = coveragePlan.IsDisappearingDeductible;


        }


    }
}
