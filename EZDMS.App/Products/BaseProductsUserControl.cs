using EZDMS.App.Core;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EZDMS.App
{
    /// <summary>
    /// The base class for any content that is being used inside of a <see cref="ProductsWindow"/>
    /// </summary>
    public class BaseProductsUserControl : UserControl
    {
        #region Private Members

        /// <summary>
        /// The products window we will be contained within
        /// </summary>
        private ProductsWindow mProductsWindow;

        #endregion

        #region Public Commands

        /// <summary>
        /// Closes this dialog
        /// </summary>
        public ICommand CloseCommand { get; private set; }

        #endregion

        #region Public Properties

        /// <summary>
        /// The minimum width of this product
        /// </summary>
        public int WindowMinimumWidth { get; set; } = 250;

        /// <summary>
        /// The minimum height of this product
        /// </summary>
        public int WindowMinimumHeight { get; set; } = 100;

        /// <summary>
        /// The height of the title bar
        /// </summary>
        public int TitleHeight { get; set; } = 30;

        /// <summary>
        /// The title for this product
        /// </summary>
        public string Title { get; set; }

        #endregion

        #region Constructor
        
        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseProductsUserControl()
        {
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                // Create a new dialog window
                mProductsWindow = new ProductsWindow();
                mProductsWindow.ViewModel = new ProductsWindowViewModel(mProductsWindow);

                // Create close command
                CloseCommand = new RelayCommand(() => mProductsWindow.Close());
            }
        }

        #endregion

        #region Public Dialog Show Methods

        /// <summary>
        /// Displays a products window to the user
        /// </summary>
        /// <param name="viewModel">The view model</param>
        /// <typeparam name="T">The view model type for this control</typeparam>
        /// <returns></returns>
        public Task ShowDialog<T>(T viewModel)
            where T : BaseProductsViewModel
        {
            // Create a task to await the dialog closing
            var tcs = new TaskCompletionSource<bool>();

            // Run on UI thread
            Application.Current.Dispatcher.Invoke(() =>
            {
                try
                {
                    // Match controls expected sizes to the products windows view model
                    mProductsWindow.ViewModel.WindowMinimumWidth = WindowMinimumWidth;
                    mProductsWindow.ViewModel.WindowMinimumHeight = WindowMinimumHeight;
                    mProductsWindow.ViewModel.TitleHeight = TitleHeight;
                    mProductsWindow.ViewModel.Title = string.IsNullOrEmpty(viewModel.Title) ? Title : viewModel.Title;

                    // Set this control to the products window content
                    mProductsWindow.ViewModel.Content = this;

                    // Setup this controls data context binding to the view model
                    DataContext = viewModel;

                    // Show in the center of the parent
                    mProductsWindow.Owner = Application.Current.MainWindow;
                    mProductsWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                    // Show dialog
                    mProductsWindow.ShowDialog();
                }
                finally
                {
                    // Let caller know we finished
                    tcs.TrySetResult(true);
                }
            });

            return tcs.Task;
        }

        #endregion
    }
}
