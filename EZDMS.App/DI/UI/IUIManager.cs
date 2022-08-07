using System.Threading.Tasks;

namespace EZDMS.App
{
    /// <summary>
    /// The UI manager that handles any UI interaction in the application
    /// </summary>
    public interface IUIManager
    {
        /// <summary>
        /// Displays a single message box to the user
        /// </summary>
        /// <param name="viewModel">The view model</param>
        /// <returns></returns>
        Task ShowMessage(MessageBoxDialogViewModel viewModel);


        /// <summary>
        /// Displays a products window to the user
        /// </summary>
        /// <param name="viewModel">The view model</param>
        /// <returns></returns>
        Task ShowProducts(ProductsSalesDialogViewModel viewModel);

        /// <summary>
        /// Displays a customer select window to the user
        /// </summary>
        /// <param name="viewModel">The view model</param>
        /// <returns></returns>
        Task ShowCustomers(CustomerSelectDialogViewModel viewModel);

        /// <summary>
        /// Displays a customer select window to the user
        /// </summary>
        /// <param name="viewModel">The view model</param>
        /// <returns></returns>
        Task ShowVehicles(VehicleSelectDialogViewModel viewModel);

        /// <summary>
        /// Displays a customer select window to the user
        /// </summary>
        /// <param name="viewModel">The view model</param>
        /// <returns></returns>
        Task ShowAdds(FrontBackAddsDialogViewModel viewModel);


    }


}
