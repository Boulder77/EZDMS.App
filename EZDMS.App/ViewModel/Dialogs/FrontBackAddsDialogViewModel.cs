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
                
        #region Public Properties

        /// <summary>
        /// The sales maintenance data model
        /// </summary>
        public FrontAddListViewModel FrontAdds { get; set; }
               
        /// <summary>
        /// Indicates if there is a save action
        /// </summary>
        public bool Saving { get; set; }

        /// <summary>
        /// Indicates if the dialog has loaded
        /// </summary>
        public bool Loading { get; set; }

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
            SaveCommand = new RelayCommand(async () => await SaveSalesAddsAsync());
 
            Task.Run(LoadSalesAddsAsync);
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Initialize products view models and controls 
        /// </summary>
        /// <returns></returns>
        public async Task LoadSalesAddsAsync()
        {
            await RunCommandAsync(() => Loading, async () =>
            {

                // Load the front adds
                FrontAdds = new FrontAddListViewModel
                {
                    //Items = new ObservableCollection<FrontAddItemViewModel>(),

                };




                await Task.Delay(1);
                
            });


        }

        /// <summary>
        /// Initialize products view models and controls 
        /// </summary>
        /// <returns></returns>
        public async Task SaveSalesAddsAsync()
        {
            await RunCommandAsync(() => Saving, async () =>
            {

                await FrontAdds.SaveAddsAsync();

            });

            // Update sales finance view model
            ViewModelSalesFinance.SalesFinanceDeal.TotalFrontAdds = FrontAdds.Total;

            // Close the dialog
            CloseAction();

        }

        #endregion

    }
}
