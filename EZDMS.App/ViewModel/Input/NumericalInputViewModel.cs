using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EZDMS.App
{
    /// <summary>
    /// The view model for a numerical entry to edit a string value
    /// <summary>
    public class NumericalInputViewModel : BaseViewModel
    {

        private int mNumber;

        #region Public Properties

        /// <summary>
        /// The label to identify what this value is for
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The current saved number
        /// </summary>
        public int Number
        {
            get => mNumber;


            set
            {

                // Make sure list has changed
                if (mNumber == value)
                    return;
                              
                // Update value
                mNumber = value;

                // Update view model
                Save();

            }

        }

        /// <summary>
        /// Indicates if the 
        /// </summary>
        public bool Working { get; set; }

        /// <summary>
        /// Indicates if the current amount can be edited
        /// </summary>
        public bool Editable { get; set; } = false;
                
        /// <summary>
        /// The action to run when saving the amount.
        /// Returns true if the commit was successful, or false otherwise.
        /// </summary>
        public Func<Task<bool>> CommitAction { get; set; }

        /// <summary>
        /// The action to run when showing a dialog window.
        /// Returns true if the commit was successful, or false otherwise.
        /// </summary>
        public Func<Task<bool>> DialogAction { get; set; }

        #endregion

        #region Public Commands
                
        /// <summary>
        /// Shows a dialog window
        /// </summary>
        public ICommand ShowDialogCommand { get; set; }

        #endregion

        #region Constructor 

        /// <summary>
        /// Default constructor
        /// </summary>
        public NumericalInputViewModel()
        {
            // Create commands
            ShowDialogCommand = new RelayCommand(ShowDialog);
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Shows a dialog window and saves the new amount on return
        /// </summary>
        public void Save()
        {
            // Store the result of a commit call
            var result = default(bool);

           
            RunCommandAsync(() => Working, async () =>
            {

                //// Commit the changed text
                //// So we can see it while it is working
                //OriginalAmount = Amount;

                // Try and do the work
                result = CommitAction == null ? true : await CommitAction();

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


        /// <summary>
        /// Shows a dialog window and saves the new amount on return
        /// </summary>
        public void ShowDialog()
        {
            // Store the result of a commit call
            var result = default(bool);

            // Save currently saved value
            var currentSavedValue = Number;

            RunCommandAsync(() => Working, async () =>
            {
               
                //// Commit the changed text
                //// So we can see it while it is working
                //OriginalAmount = Amount;

                // Try and do the work
                result = DialogAction == null ? true : await DialogAction();

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
    }
}
