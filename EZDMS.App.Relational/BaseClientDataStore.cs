using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EZDMS.App.Core;
using Microsoft.EntityFrameworkCore;

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
        /// Makes sure the client data store is correctly set up
        /// </summary>
        /// <returns>Returns a task that will finish once setup is complete</returns>
        public async Task EnsureDataStoreAsync()
        {
            // Make sure the database exists and is created
            await mDbContext.Database.EnsureCreatedAsync();
        }


        /// <summary>
        /// Add a new record to the appropriate data store table
        /// </summary>
        /// <param name="mDataModel"></param>
        /// <param name="type"></param>
        /// <returns>Task completed</returns>
        /// <exception cref="Exception"></exception>
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

                case DbTableNames.SalesGap:
                    // Add new SalesGap entry
                    mDbContext.SalesGap.Add(mDataModel as SalesGapDataModel);
                    break;

                case DbTableNames.SalesMaintenance:
                    // Add new SalesMaintenance entry
                    mDbContext.SalesMaintenance.Add(mDataModel as SalesMaintenanceDataModel);
                    break;

                case DbTableNames.SalesService:
                    // Add new SalesService entry
                    mDbContext.SalesService.Add(mDataModel as SalesServiceDataModel);
                    break;

                case DbTableNames.SalesWarranty:
                    // Add new SalesService entry
                    mDbContext.SalesWarranty.Add(mDataModel as SalesWarrantyDataModel);
                    break;

                case DbTableNames.FrontAdds:
                    // Add new FrontAdds entry
                    mDbContext.FrontAdds.Add(mDataModel as FrontAddsDataModel);
                    break;

                case DbTableNames.SalesFrontAdds:
                    // Add new FrontAdds entry
                    mDbContext.SalesFrontAdds.Add(mDataModel as SalesFrontAddsDataModel);
                    break;

                default:
                    throw new Exception();
                    break;
            }

            // Save changes
            await mDbContext.SaveChangesAsync();

        }

        /// <summary>
        /// Add a new record to the appropriate data store table
        /// </summary>
        /// <param name="mDataModel"></param>
        /// <param name="type"></param>
        /// <returns>Task completed</returns>
        /// <exception cref="Exception"></exception>
        public async Task SaveSalesRecordAsync(object mDataModel, DbTableNames type)
        {
            // return if no data model
            if (mDataModel == null)
                return;

            switch (type)
            {
                //  // Update the data store record
                case DbTableNames.LoginCredentials:

                    mDbContext.Update(mDataModel as LoginCredentialsDataModel);
                    break;

                case DbTableNames.SalesDealsInfo:

                    mDbContext.Update(mDataModel as SalesDealsItemDataModel);
                    //mDbContext.Attach(mDataModel as SalesDealsItemDataModel);
                    //mDbContext.Entry(mDataModel as SalesDealsItemDataModel).State = EntityState.Modified;
                    break;

                case DbTableNames.SalesFinance:
                    
                    mDbContext.Update(mDataModel as SalesFinanceDataModel);
                    break;

                case DbTableNames.VehicleInventory:

                    mDbContext.Update(mDataModel as VehicleInventoryDataModel);
                    break;

                case DbTableNames.Customer:

                    mDbContext.Update(mDataModel as CustomerDataModel);
                    break;

                case DbTableNames.CoverageProvider:

                    mDbContext.Update(mDataModel as CoverageProviderDataModel);
                    break;

                case DbTableNames.CoveragePlan:

                    mDbContext.Update(mDataModel as CoveragePlanDataModel);
                    break;

                case DbTableNames.SalesGap:

                    mDbContext.Update(mDataModel as SalesGapDataModel);
                    break;

                case DbTableNames.SalesMaintenance:

                    mDbContext.Update(mDataModel as SalesMaintenanceDataModel);
                    break;

                case DbTableNames.SalesService:

                    mDbContext.Update(mDataModel as SalesServiceDataModel);
                    break;

                case DbTableNames.SalesWarranty:

                    mDbContext.Update(mDataModel as SalesWarrantyDataModel);
                    break;

                case DbTableNames.FrontAdds:

                    mDbContext.Update(mDataModel as FrontAddsDataModel);
                    break;

                case DbTableNames.SalesFrontAdds:

                    mDbContext.Update(mDataModel as SalesFrontAddsDataModel);
                    break;

                default:
                    throw new Exception();
                    break;
            }

            // Save changes
            await mDbContext.SaveChangesAsync();

        }

        #region Login Credentials Methods

        /// <summary>
        /// Determines if the current user has logged in credentials
        /// </summary>
        public async Task<bool> HasCredentialsAsync()
        {
            return await GetLoginCredentialsAsync() != null;
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


        #endregion

        #region Sales Finance Methods

        /// <summary>
        /// Gets a single sales finance deal
        /// </summary>
        /// <param name="dealNumber"></param>
        /// <returns>SalesFinanceDataModel</returns>
        public Task<SalesFinanceDataModel> GetSalesFinanceDealAsync(int dealNumber)
        {
            // Gets a single sales record
            return Task.FromResult(mDbContext.SalesFinance.FirstOrDefault(u => u.DealNumber == dealNumber));

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
        /// Returns all records in SearchDeals table
        /// </summary>
        public Task<List<SalesDealsItemDataModel>> GetSalesDealRecallsAsync()
        {
            // Gets all the sales                      
            return Task.FromResult(mDbContext.SalesDealsInfo.ToList());
        }

        #endregion

        #region Vehicle Inventory Methods

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
        /// Returns all records in vehicle inventory table
        /// </summary>
        public Task<List<VehicleInventoryDataModel>> GetVehicleInventoryListAsync()
        {
            // Gets all the sales                      
            return Task.FromResult(mDbContext.VehicleInventory.ToList());
        }

        #endregion

        #region Customer Methods

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
        /// Returns all records in customer table
        /// </summary>
        public Task<List<CustomerDataModel>> GetCustomersAsync()
        {
            // Gets all the sales                      
            return Task.FromResult(mDbContext.Customer.ToList());
        }

        #endregion
        
        #region Products Methods

        /// <summary>
        /// Returns all records in coverage provider table
        /// </summary>
        public Task<List<CoverageProviderDataModel>> GetCoverageProvidersAsync()
        {
            // Gets all the sales                      
            return Task.FromResult(mDbContext.CoverageProvider.Where(e => e.IsActive == true).ToList());
        }

        /// <summary>
        /// Gets a single provider record from the coverage provider table
        /// </summary>
        /// <param name="providerNumber"></param>
        /// <returns>CoverageProviderDataModel</returns>
        public Task<CoverageProviderDataModel> GetCoverageProviderAsync(string providerNumber)
        {
            // Gets a single provider record
            return Task.FromResult(mDbContext.CoverageProvider.FirstOrDefault(u => u.Number == providerNumber));

        }

        /// <summary>
        /// Returns all records in coverage plan table
        /// </summary>
        public Task<List<CoveragePlanDataModel>> GetCoveragePlansAsync()
        {
            // Gets all the sales                      
            return Task.FromResult(mDbContext.CoveragePlan.Where(e => e.IsActive == true).ToList());
        }
              
        /// <summary>
        /// Gets a single provider plan record from the coverage plan table
        /// </summary>
        /// <param name="providerNumber"></param>
        /// <returns>CoveragePlanDataModel</returns>
        public Task<CoveragePlanDataModel> GetCoveragePlanAsync(string providerNumber)
        {
            // Gets a single plan record
            return Task.FromResult(mDbContext.CoveragePlan.FirstOrDefault(u => u.ProviderNumber == providerNumber));

        }

        /// <summary>
        /// Gets a single sales service contract record from the sales service table
        /// </summary>
        /// <param name="dealNumber"></param>
        /// <returns>SalesServiceDataModel</returns>
        public Task<SalesServiceDataModel> GetSalesServiceAsync(int dealNumber)
        {
            // Gets a single sales record
            return Task.FromResult(mDbContext.SalesService.FirstOrDefault(u => u.DealNumber == dealNumber));

        }

        /// <summary>
        /// Gets a single sales maintenance contract record from the sales service table
        /// </summary>
        /// <param name="dealNumber"></param>
        /// <returns>SalesMaintenanceDataModel</returns>
        public Task<SalesMaintenanceDataModel> GetSalesMaintenanceAsync(int dealNumber)
        {
            // Gets a single sales record
            return Task.FromResult(mDbContext.SalesMaintenance.FirstOrDefault(u => u.DealNumber == dealNumber));

        }

        /// <summary>
        /// Gets a single sales warranty contract record from the sales service table
        /// </summary>
        /// <param name="dealNumber"></param>
        /// <returns>SalesWarrantyDataModel</returns>
        public Task<SalesWarrantyDataModel> GetSalesWarrantyAsync(int dealNumber)
        {
            // Gets a single sales record
            return Task.FromResult(mDbContext.SalesWarranty.FirstOrDefault(u => u.DealNumber == dealNumber));

        }

        /// <summary>
        /// Gets a single sales gap contract record from the sales service table
        /// </summary>
        /// <param name="dealNumber"></param>
        /// <returns>SalesGapDataModel</returns>
        public Task<SalesGapDataModel> GetSalesGapAsync(int dealNumber)
        {
            // Gets a single sales record
            return Task.FromResult(mDbContext.SalesGap.FirstOrDefault(u => u.DealNumber == dealNumber));

        }

        /// <summary>
        /// Returns a single front add record from the sales front adds table
        /// </summary>
        /// <param name="dealNumber"></param>
        /// <returns>SalesFrontAddsDataModel</returns>
        public Task<SalesFrontAddsDataModel> GetSalesFrontAddsAsync(int dealNumber)
        {
            // Gets a single sales record
            return Task.FromResult(mDbContext.SalesFrontAdds.FirstOrDefault(u => u.DealNumber == dealNumber));

        }

        /// <summary>
        /// Returns all records in front adds table
        /// </summary>
        public Task<List<FrontAddsDataModel>> GetFrontAddsAsync()
        {
            // Gets all the sales                      
            return Task.FromResult(mDbContext.FrontAdds.Where(e => e.IsActive == true).ToList());
        }

        #endregion

        #endregion
    }
}
