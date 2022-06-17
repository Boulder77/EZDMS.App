using EZDMS.App.Core;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EZDMS.App
{
    /// <summary>
    /// The View Model for the products window
    /// </summary>
    public class ProductsWindowViewModel : WindowViewModel
    {
        #region Public Properties

        /// <summary>
        /// The title of this dialog window
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The content to host inside the dialog
        /// </summary>
        public Control Content { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProductsWindowViewModel(Window window) : base(window)
        {
            //// Make minimum size smaller
            //WindowMinimumWidth = 250;
            //WindowMinimumHeight = 100;

            // Make title bar larger
            TitleHeight = 80;
        }

        #endregion
    }
}
