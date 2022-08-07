using Dna;
using EZDMS.App.Core;
using static EZDMS.App.Core.CoreDI;
using System.Windows.Input;
using static EZDMS.App.DI;
using static Dna.FrameworkDI;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace EZDMS.App
{
    /// <summary>
    /// The view model for the <see cref="DialogFrontBackAdds"/>
    /// <summary>
    public class FrontBackAddsDialogViewModel:BaseDialogViewModel
    {

        #region Private Members

       
               

        #endregion

        #region Public Properties
            
        /// <summary>
        /// The sales maintenance data model
        /// </summary>
        public FrontAddListViewModel FrontAdds { get; set; }
        
        /// <summary>
        /// The text for the total front adds 
        /// </summary>
        public DecimalInputViewModel TotalFrontAdds { get; set; }

        /// <summary>
        /// The text for the total back adds 
        /// </summary>
        public decimal TotalBackAdds { get; set; }


        /// <summary>
        /// Indicates if there is a save action
        /// </summary>
        public bool Saving { get; set; }

        /// <summary>
        /// Indicates if the dialog has loaded
        /// </summary>
        public bool AddsLoading { get; set; }

        #endregion

        #region Public Commands

        /// <summary>
        /// The command to save the info
        /// </summary>
        public ICommand SaveCommand { get; set; }

        /// <summary>
        /// The command to cancel the dialog
        /// </summary>
        public ICommand CancelCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public FrontBackAddsDialogViewModel()
        {
            // Create commands
            //SaveCommand = new RelayCommand(async () => await SaveProductsAsync());
                
            Task.Run(LoadProductsAsync);
        }

        #endregion

        #region Public Commands

        /// <summary>
        /// Initialize products view models and controls 
        /// </summary>
        /// <returns></returns>
        public async Task LoadProductsAsync()
        {
            await RunCommandAsync(() => AddsLoading, async () =>
            {
                FrontAdds = FrontAddListDesignModel.Instance;
                TotalFrontAdds = new DecimalInputViewModel
                {
                    Label = "Total Front Adds",

                    Amount = 1123.00m

                };

                

            });


        }

        

        #endregion

        public async Task<bool> UpdateTotalRetailAsync()
        {

       //     UpdateTotalRetail();

            // Lock this command to ignore any other requests while processing
            await Task.Delay(1);
            return true;
            
        }

       
}
}
