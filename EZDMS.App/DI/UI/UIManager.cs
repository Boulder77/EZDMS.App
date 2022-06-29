﻿using System;
using System.Threading.Tasks;
using EZDMS.App.Core;
using System.Windows;

namespace EZDMS.App
{
    /// <summary>
    /// The applications implementation of the <see cref="IUIManager"/>
    /// </summary>
    public class UIManager : IUIManager
    {
        /// <summary>
        /// Displays a single message box to the user
        /// </summary>
        /// <param name="viewModel">The view model</param>
        /// <returns></returns>
        public Task ShowMessage(MessageBoxDialogViewModel viewModel)
        {
            // Create a task completion source
            var tcs = new TaskCompletionSource<bool>();

            // Run on UI thread
            Application.Current.Dispatcher.Invoke(async () =>
            {
                try
                {
                    // Show the dialog box
                    await new DialogMessageBox().ShowDialog(viewModel);
                }
                finally
                {
                    // Flag we are done
                    tcs.SetResult(true);
                }
            });

            // Return the task once complete
            return tcs.Task;
        }


        /// <summary>
        /// Displays a single message box to the user
        /// </summary>
        /// <param name="viewModel">The view model</param>
        /// <returns></returns>
        public Task ShowProducts(ProductsSalesViewModel viewModel)
        {
            // Create a task completion source
            var tcs = new TaskCompletionSource<bool>();

            // Run on UI thread
            Application.Current.Dispatcher.Invoke(async () =>
            {
                try
                {
                    // Show the dialog box
                    await new ProductsSalesControl().ShowDialog(viewModel);
                }
                finally
                {
                    // Flag we are done
                    tcs.SetResult(true);
                }
            });

            // Return the task once complete
            return tcs.Task;
        }

        public Task ShowCustomers(ProductsSalesViewModel viewModel)
        {
            // Create a task completion source
            var tcs = new TaskCompletionSource<bool>();

            // Run on UI thread
            Application.Current.Dispatcher.Invoke(async () =>
            {
                try
                {
                    // Show the dialog box
                    await new ProductsSalesControl().ShowDialog(viewModel);
                }
                finally
                {
                    // Flag we are done
                    tcs.SetResult(true);
                }
            });

            // Return the task once complete
            return tcs.Task;
        }


    }
}
