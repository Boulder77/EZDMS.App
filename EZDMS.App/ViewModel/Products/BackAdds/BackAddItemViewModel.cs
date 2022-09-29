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
    public class BackAddItemViewModel : BaseViewModel
    {

        #region Private Members

        /// <summary>
        ///  The retail amount for the front add item
        /// </summary>
        private decimal mRetail;

        /// <summary>
        /// The selected front add
        /// </summary>
        private SystemBackAddsDataModel mSelectedAdd;

        /// <summary>
        /// The list of all active back adds in the system
        /// </summary>
        protected ObservableCollection<SystemBackAddsDataModel> mBackAdds;

        /// <summary>
        /// The list of all active back adds in the system
        /// </summary>
        protected ObservableCollection<string> mTypes;

        /// <summary>
        /// The selected back add type
        /// </summary>
        private string mSelectedType;

        #endregion

        #region Public Properties

        /// <summary>
        /// The list of back add types
        /// </summary>
        public ObservableCollection<string> Types
        {
            get => mTypes;

            set
            {
                // Make sure list has changed
                if (mTypes == value)
                    return;

                // Update value
                mTypes = value;                               
            }
        }

        public string SelectedType
        {
            get => mSelectedType;

            set
            {
                // Make sure list has changed
                if (mSelectedType == value)
                    return;

                // Update value
                mSelectedType = value;

                if (value != null)
                    // Update the filtered back add list
                    UpdateValuesOfFilteredAdds(value);

            }

        }

        public ObservableCollection<SystemBackAddsDataModel> BackAdds
        {
            get => mBackAdds;
            
            set
            {
                // Make sure list has changed
                if (mBackAdds == value)
                    return;

                // Update value
                mBackAdds = value;

                if (value != null)
                    FilteredAdds = new ObservableCollection<SystemBackAddsDataModel>(value);
                
            }
        }

        public ObservableCollection<SystemBackAddsDataModel> FilteredAdds { get; set; }

        public SystemBackAddsDataModel SelectedAdd
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
        public BackAddItemViewModel()
        {
           


        }

        #endregion

        private void UpdateValuesFromDataModel(SystemBackAddsDataModel backAdd)
        {
            if (backAdd == null)
                return;
             
            Retail = backAdd.Retail;
            Cost = backAdd.Cost;
           
            Taxable = (bool)backAdd.IsTaxable;
            InPayment = (bool)backAdd.InPayment;          

        }

        private void UpdateValuesOfFilteredAdds(string type)
        {
            
            FilteredAdds = new ObservableCollection<SystemBackAddsDataModel>(
                BackAdds.Where(item => item.Type == type));

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
