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
        Task<List<VehicleInventoryDataModel>> GetVehicleInventoryListAsync();

        /// <summary>
        /// Returns all records in customer table
        /// </summary>
        Task<List<CustomerDataModel>> GetCustomersAsync();

        /// <summary>
        /// Returns all records in coverage provider table
        /// </summary>
        Task<List<CoverageProviderDataModel>> GetCoverageProvidersAsync();

        /// <summary>
        /// Gets a single provider record from the coverage provider table
        /// </summary>
        /// <param name="providerNumber"></param>
        /// <returns>CoverageProviderDataModel</returns>
        Task<CoverageProviderDataModel> GetCoverageProviderAsync(string providerNumber);

        /// <summary>
        /// Returns all records in coverage plan table
        /// </summary>
        Task<List<CoveragePlanDataModel>> GetCoveragePlansAsync();

        /// <summary>
        /// Gets a single provider plan record from the coverage plan table
        /// </summary>
        /// <param name="providerNumber"></param>
        /// <returns>CoveragePlanDataModel</returns>
        Task<CoveragePlanDataModel> GetCoveragePlanAsync(string providerNumber);

        /// <summary>
        /// Gets a single sales service contract record from the sales service table
        /// </summary>
        /// <param name="dealNumber"></param>
        /// <returns>SalesServiceDataModel</returns>
        Task<SalesServiceDataModel> GetSalesServiceAsync(int dealNumber);

        /// <summary>
        /// Gets a single sales maintenance contract record from the sales service table
        /// </summary>
        /// <param name="dealNumber"></param>
        /// <returns>SalesMaintenanceDataModel</returns>
        Task<SalesMaintenanceDataModel> GetSalesMaintenanceAsync(int dealNumber);

        /// <summary>
        /// Gets a single sales warranty contract record from the sales service table
        /// </summary>
        /// <param name="dealNumber"></param>
        /// <returns>SalesWarrantyDataModel</returns>
        Task<SalesWarrantyDataModel> GetSalesWarrantyAsync(int dealNumber);


        /// <summary>
        /// Gets a single sales gap contract record from the sales service table
        /// </summary>
        /// <param name="dealNumber"></param>
        /// <returns>SalesGapDataModel</returns>
        Task<SalesGapDataModel> GetSalesGapAsync(int dealNumber);

        /// <summary>
        /// Returns all records in front adds table
        /// </summary>
        Task<List<SystemFrontAddsDataModel>> GetSystemFrontAddsAsync();

        /// <summary>
        /// Returns a single front add record from the sales front adds table
        /// </summary>
        Task<SalesFrontAddsDataModel> GetSalesFrontAddsAsync(int dealNumber);

        /// <summary>
        /// Returns all records in back adds table
        /// </summary>
        Task<List<SystemBackAddsDataModel>> GetSystemBackAddsAsync();

        /// <summary>
        /// Returns a single back add record from the sales front adds table
        /// </summary>
        Task<SalesBackAddsDataModel> GetSalesBackAddsAsync(int dealNumber);

    }
}
