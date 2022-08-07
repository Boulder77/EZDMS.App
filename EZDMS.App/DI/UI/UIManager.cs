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
        /// Show the products dialog window
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public Task ShowProducts(ProductsSalesDialogViewModel viewModel)
        {
            // Create a task completion source
            var tcs = new TaskCompletionSource<bool>();

            // Run on UI thread
            Application.Current.Dispatcher.Invoke(async () =>
            {
                try
                {
                    // Show the dialog box
                    await new DialogProductsSales().ShowDialog(viewModel);
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
        /// Show the customer list dialog window
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>

        public Task ShowCustomers(CustomerSelectDialogViewModel viewModel)
        {
            // Create a task completion source
            var tcs = new TaskCompletionSource<bool>();

            // Run on UI thread
            Application.Current.Dispatcher.Invoke(async () =>
            {
                try
                {
                    // Show the dialog box
                    await new DialogCustomerSelect().ShowDialog(viewModel);
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
        /// Show the vehicles list dialog window
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public Task ShowVehicles(VehicleSelectDialogViewModel viewModel)
        {
            // Create a task completion source
            var tcs = new TaskCompletionSource<bool>();

            // Run on UI thread
            Application.Current.Dispatcher.Invoke(async () =>
            {
                try
                {
                    // Show the dialog box
                    await new DialogVehicleSelect().ShowDialog(viewModel);
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
        /// Show the products dialog window
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public Task ShowAdds(FrontBackAddsDialogViewModel viewModel)
        {
            // Create a task completion source
            var tcs = new TaskCompletionSource<bool>();

            // Run on UI thread
            Application.Current.Dispatcher.Invoke(async () =>
            {
                try
                {
                    // Show the dialog box
                    await new DialogFrontBackAdds().ShowDialog(viewModel);
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
