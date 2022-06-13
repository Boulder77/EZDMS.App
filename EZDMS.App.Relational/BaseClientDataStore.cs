using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EZDMS.App.Core;

namespace EZDMS.App.Relational
{
    /// <summary>
    /// Stores and retrieves information about the client application 
    /// such as login credentials, messages, settings and so on
    /// in an SQLite database
    /// </summary>
    public class BaseClientDataStore : IClientDataStore
    {
        
        #region Protected Members

        /// <summary>
        /// The database context for the client data store
        /// </summary>
        protected ClientDataStoreDbContext mDbContext;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="dbContext">The database to use</param>
        public BaseClientDataStore(ClientDataStoreDbContext dbContext)
        {
            // Set local member
            mDbContext = dbContext;
        }

        #endregion

        #region Interface Implementation

        /// <summary>
        /// Determines if the current user has logged in credentials
        /// </summary>
        public async Task<bool> HasCredentialsAsync()
        {
            return await GetLoginCredentialsAsync() != null;
        }

        /// <summary>
        /// Makes sure the client data store is correctly set up
        /// </summary>
        /// <returns>Returns a task that will finish once setup is complete</returns>
        public async Task EnsureDataStoreAsync()    
        {
            // Make sure the database exists and is created
            await mDbContext.Database.EnsureCreatedAsync();
        }

        /// <summary>
        /// Gets the stored login credentials for this client
        /// </summary>
        /// <returns>Returns the login credentials if they exist, or null if none exist</returns>
        public Task<LoginCredentialsDataModel> GetLoginCredentialsAsync()
        {
            // Get the first column in the login credentials table, or null if none exist
            return Task.FromResult(mDbContext.LoginCredentials.FirstOrDefault());
        }

        /// <summary>
        /// Stores the given login credentials to the backing data store
        /// </summary>
        /// <param name="loginCredentials">The login credentials to save</param>
        /// <returns>Returns a task that will finish once the save is complete</returns>
        public async Task SaveLoginCredentialsAsync(LoginCredentialsDataModel loginCredentials)
        {
            // Clear all entries
            mDbContext.LoginCredentials.RemoveRange(mDbContext.LoginCredentials);

            // Add new one
            mDbContext.LoginCredentials.Add(loginCredentials);

            // Save changes
            await mDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Removes all login credentials stored in the data store
        /// </summary>
        /// <returns></returns>
        public async Task ClearAllLoginCredentialsAsync()
        {
            // Clear all entries
            mDbContext.LoginCredentials.RemoveRange(mDbContext.LoginCredentials);

            // Save changes
            await mDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Gets a single sales finance deal
        /// </summary>
        /// <param name="dealNumber"></param>
        /// <returns>SalesFinanceDataModel</returns>
        public Task<SalesFinanceDataModel> GetSalesFinanceDealAsync(int dealNumber)
        {
            // Gets a single sales record
            return Task.FromResult(mDbContext.SalesFinance.FirstOrDefault(u=> u.DealNumber==dealNumber));

        }

        /// <summary>
        /// Creates a new sales finance record
        /// </summary>
        /// <returns>SalesFinanceDataModel</returns>
        public Task<SalesFinanceDataModel> CreateSalesFinanceDeal()
        {
            var mDataModel = new SalesFinanceDataModel();
            // Gets a single sales record
            mDbContext.SalesFinance.Add(mDataModel);
            mDbContext.SaveChanges();

            return Task.FromResult(mDataModel);
        }

        /// <summary>
        /// Gets a single vehicle record from the inventory table
        /// </summary>
        /// <param name="stockNumber"></param>
        /// <returns>VehicleInventoryDataModel</returns>
        public Task<VehicleInventoryDataModel> GetVehicleInventoryAsync(string stockNumber)
        {
            // Gets a single sales record
            return Task.FromResult(mDbContext.VehicleInventory.FirstOrDefault(u => u.StockNumber == stockNumber));
        }

        /// <summary>
        /// Gets a single customer record from the customer table
        /// </summary>
        /// <param name="customerNumber"></param>
        /// <returns>CustomerDataModel</returns>
        public Task<CustomerDataModel> GetCustomerAsync(string customerNumber)
        {
            // Gets a single sales record
            return Task.FromResult(mDbContext.Customer.FirstOrDefault(u => u.Number == customerNumber));

        }

        /// <summary>
        /// Returns all records in SearchDeals table
        /// </summary>
        public Task<List<SalesDealsItemDataModel>> GetSalesDealRecallsAsync()
        {
            // Gets all the sales                      
            return Task.FromResult(mDbContext.SalesDealsInfo.ToList());            
        }

        /// <summary>
        /// Returns all records in vehicle inventory table
        /// </summary>
        public Task<List<VehicleInventoryDataModel>> GetVehicleInventoryAsync()
        {
            // Gets all the sales                      
            return Task.FromResult(mDbContext.VehicleInventory.ToList());
        }

        /// <summary>
        /// Returns all records in customer table
        /// </summary>
        public Task<List<CustomerDataModel>> GetCustomersAsync()
        {
            // Gets all the sales                      
            return Task.FromResult(mDbContext.Customer.ToList());
        }

        public async Task AddNewSalesRecordAsync(object mDataModel, DbTableNames type)
        {
            // return if no data model
            if (mDataModel == null)
                    return;
                       
            switch (type)
            {
                // Add new login entry
                case DbTableNames.LoginCredentials:
                    mDbContext.LoginCredentials.Add(mDataModel as LoginCredentialsDataModel);
                    break;
                                    
                case DbTableNames.SalesDealsInfo:
                    // Add new sales deals list entry
                    mDbContext.SalesDealsInfo.Add(mDataModel as SalesDealsItemDataModel);
                    break;

                case DbTableNames.SalesFinance:
                    //Add new sales finance entry
                    mDbContext.SalesFinance.Add(mDataModel as SalesFinanceDataModel);
                    break;

                case DbTableNames.VehicleInventory:
                    //Add new vehicle inventory entry
                    mDbContext.VehicleInventory.Add(mDataModel as VehicleInventoryDataModel);
                    break;

                case DbTableNames.Customer:
                    //Add new customer entry
                    mDbContext.Customer.Add(mDataModel as CustomerDataModel);
                    break;

                case DbTableNames.CoverageProvider:
                    //Add new customer entry
                    mDbContext.CoverageProvider.Add(mDataModel as CoverageProviderDataModel);
                    break;

                case DbTableNames.CoveragePlan:
                    //Add new customer entry
                    mDbContext.CoveragePlan.Add(mDataModel as CoveragePlanDataModel);
                    break;


                default:
                    throw new Exception();
                    break;
            }
            
            // Save changes
            await mDbContext.SaveChangesAsync();

        }

        #endregion
    }
}
