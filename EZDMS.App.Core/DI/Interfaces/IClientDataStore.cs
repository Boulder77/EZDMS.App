using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace EZDMS.App.Core
{
    /// <summary>
    /// Stores and retrieves information about the client application 
    /// such as login credentials, messages, settings and so on
    /// </summary>
    public interface IClientDataStore
    {
        /// <summary>
        /// Determines if the current user has logged in credentials
        /// </summary>
        Task<bool> HasCredentialsAsync();

        /// <summary>
        /// Makes sure the client data store is correctly set up
        /// </summary>
        /// <returns>Returns a task that will finish once setup is complete</returns>
        Task EnsureDataStoreAsync();

        /// <summary>
        /// Gets the stored login credentials for this client
        /// </summary>
        /// <returns>Returns the login credentials if they exist, or null if none exist</returns>
        Task<LoginCredentialsDataModel> GetLoginCredentialsAsync();

        /// <summary>
        /// Stores the given login credentials to the backing data store
        /// </summary>
        /// <param name="loginCredentials">The login credentials to save</param>
        /// <returns>Returns a task that will finish once the save is complete</returns>
        Task SaveLoginCredentialsAsync(LoginCredentialsDataModel loginCredentials);

        /// <summary>
        /// Removes all login credentials stored in the data store
        /// </summary>
        /// <returns></returns>
        Task ClearAllLoginCredentialsAsync();

        /// <summary>
        /// gets the stored deals list for this client
        /// </summary>
        /// <returns></returns>
        Task<List<SalesDealsItemDataModel>> GetSalesDealRecallsAsync();

        /// <summary>
        /// Gets a single sales record
        /// </summary>
        /// <param name="dealNumber">the deal number of the sales record</param>
        /// <returns></returns>
        Task<SalesFinanceDataModel> GetSalesFinanceDealAsync(int dealNumber);

        /// <summary>
        /// add new record to a data store table
        /// </summary>
        /// <param name="mDataModel">the datamodel to add</param>
        /// <param name="type">the table to add the datamodel to</param>
        /// <returns>Returns a task that will finish once record has been added</returns>
        Task AddNewSalesRecordAsync(object mDataModel, DbTableNames type);

        /// <summary>
        /// add new record to a data store table
        /// </summary>
        /// <param name="mDataModel">the datamodel to add</param>
        /// <param name="type">the table to add the datamodel to</param>
        /// <returns>Returns a task that will finish once record has been added</returns>
        Task SaveSalesRecordAsync(object mDataModel, DbTableNames type);

        /// <summary>
        /// add new record to sales finance table and returns record
        /// </summary>
        /// <param name="mDataModel">the datamodel to add</param>
        /// <param name="type">the type of DbTable</param>
        /// <returns>new SalesFinanceDataModel</returns>
        Task<SalesFinanceDataModel> CreateSalesFinanceDeal();

        /// <summary>
        /// Stores the sales finance deal to the backing data store
        /// </summary>
        /// <param name="salesFinance">The sales finance deal to save</param>
        /// <returns>Returns a task that will finish once the save is complete</returns>
        Task SaveSalesFinanceDealAsync(SalesFinanceDataModel salesFinance);

        /// <summary>
        /// Gets a single customer record from the customer table
        /// </summary>
        /// <param name="customerNumber"></param>
        /// <returns>CustomerDataModel</returns>
        Task<CustomerDataModel> GetCustomerAsync(string customerNumber);

        /// <summary>
        /// Gets a single vehicle record from the inventory table
        /// </summary>
        /// <param name="stockNumber"></param>
        /// <returns>VehicleInventoryDataModel</returns>
        Task<VehicleInventoryDataModel> GetVehicleInventoryAsync(string stockNumber);

        /// <summary>
        /// Returns all records in vehicle inventory table
        /// </summary>
        Task<List<VehicleInventoryDataModel>> GetVehicleInventoryAsync();

        /// <summary>
        /// Returns all records in customer table
        /// </summary>
        Task<List<CustomerDataModel>> GetCustomersAsync();

    }
}
