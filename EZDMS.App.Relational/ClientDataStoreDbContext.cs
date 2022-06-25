using EZDMS.App.Core;
using Microsoft.EntityFrameworkCore;

namespace EZDMS.App.Relational
{
    /// <summary>
    /// The database context for the client data store
    /// </summary>
    public class ClientDataStoreDbContext : DbContext
    {
        #region DbSets 

        /// <summary>
        /// The client login credentials
        /// </summary>
        public DbSet<LoginCredentialsDataModel> LoginCredentials { get; set; }

        /// <summary>
        /// The recall deals table
        /// </summary>
        public DbSet<SalesDealsItemDataModel> SalesDealsInfo { get; set; }

        /// <summary>
        /// The sales finance info table
        /// </summary>
        public DbSet<SalesFinanceDataModel> SalesFinance { get; set; }

        /// <summary>
        /// The vehicle inventory table
        /// </summary>
        public DbSet<VehicleInventoryDataModel> VehicleInventory { get; set; }

        /// <summary>
        /// The customer table
        /// </summary>
        public DbSet<CustomerDataModel> Customer { get; set; }

        /// <summary>
        /// The coverage provider table
        /// </summary>
        public DbSet<CoverageProviderDataModel> CoverageProvider { get; set; }

        /// <summary>
        /// The coverage plan table
        /// </summary>
        public DbSet<CoveragePlanDataModel> CoveragePlan { get; set; }

        /// <summary>
        /// The SalesGap table
        /// <summary>
        public DbSet<SalesGapDataModel> SalesGap { get; set; }

        /// <summary>
        /// The SalesMaintenance table
        /// <summary>
        public DbSet<SalesMaintenanceDataModel> SalesMaintenance { get; set; }

        /// <summary>
        /// The SalesMaintenance table
        /// <summary>
        public DbSet<SalesServiceDataModel> SalesService { get; set; }

        /// <summary>
        /// The SalesWarranty table
        /// <summary>
        public DbSet<SalesWarrantyDataModel> SalesWarranty { get; set; }


        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ClientDataStoreDbContext(DbContextOptions<ClientDataStoreDbContext> options) : base(options) { }

        #endregion

        #region Model Creating

        /// <summary>
        /// Configures the database structure and relationships
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent API

            // Configure LoginCredentials
            // --------------------------
            //
            // Set Id as primary key
            modelBuilder.Entity<LoginCredentialsDataModel>().HasKey(a => a.Id);

            modelBuilder.Entity<SalesDealsItemDataModel>().HasKey(a => a.DealNumber);

            modelBuilder.Entity<SalesFinanceDataModel>().HasKey(a => a.DealNumber);

            modelBuilder.Entity<VehicleInventoryDataModel>().HasKey(a => a.ID);

            modelBuilder.Entity<CustomerDataModel>().HasKey(a => a.ID);

            modelBuilder.Entity<CoverageProviderDataModel>().HasKey(a => a.ID);

            modelBuilder.Entity<CoveragePlanDataModel>().HasKey(a => a.ID);

            modelBuilder.Entity<SalesGapDataModel>().HasKey(a => a.DealNumber);

            modelBuilder.Entity<SalesMaintenanceDataModel>().HasKey(a => a.DealNumber);

            modelBuilder.Entity<SalesServiceDataModel>().HasKey(a => a.DealNumber);

            modelBuilder.Entity<SalesWarrantyDataModel>().HasKey(a => a.DealNumber);


            // TODO: Set up limits
            //modelBuilder.Entity<LoginCredentialsDataModel>().Property(a => a.FirstName).HasMaxLength(50);
        }

        #endregion
    }
}
