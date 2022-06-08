using System.Windows;

namespace EZDMS.App
{
    /// <summary>
    /// Interaction logic for ProductsWindow.xaml
    /// </summary>
    public partial class ProductsWindow : Window
    {
        #region Private Members

        /// <summary>
        /// The view model for this window
        /// </summary>
        private ProductsWindowViewModel mViewModel;

        #endregion

        #region Public Properties

        /// <summary>
        /// The view model for this window
        /// </summary>
        public ProductsWindowViewModel ViewModel
        {
            get => mViewModel;
            set
            {
                // Set new value
                mViewModel = value;

                // Update data context
                DataContext = mViewModel;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProductsWindow()
        {
            InitializeComponent();
        }

        #endregion
    }
}
