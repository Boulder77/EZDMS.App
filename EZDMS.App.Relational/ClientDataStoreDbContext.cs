﻿using EZDMS.App.Core;
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

        /// <summary>
        /// The FrontAdds table
        /// <summary>
        public DbSet<SystemFrontAddsDataModel> SystemFrontAdds { get; set; }

        /// <summary>
        /// The SalesFrontAdds table
        /// <summary>
        public DbSet<SalesFrontAddsDataModel> SalesFrontAdds { get; set; }

        /// <summary>
        /// The FrontAdds table
        /// <summary>
        public DbSet<SystemBackAddsDataModel> SystemBackAdds { get; set; }

        /// <summary>
        /// The SalesBackAdds table
        /// <summary>
        public DbSet<SalesBackAddsDataModel> SalesBackAdds { get; set; }

        /// <summary>
        /// The sales licensing fees table
        /// <summary>
        public DbSet<SalesLicensingFeesDataModel> SalesLicensingFees { get; set; }

        /// <summary>
        /// The system licensing fees table
        /// <summary>
        public DbSet<SystemLicensingFeesDataModel> SystemLicensingFees { get; set; }

        /// <summary>
        /// The sales local fees table
        /// <summary>
        public DbSet<SalesLocalFeesDataModel> SalesLocalFees { get; set; }

        /// <summary>
        /// The system local fees table
        /// <summary>
        public DbSet<SystemLocalFeesDataModel> SystemLocalFees { get; set; }

        /// <summary>
        /// The sales local fees table
        /// <summary>
        public DbSet<SalesBankFeesDataModel> SalesBankFees { get; set; }

        /// <summary>
        /// The system local fees table
        /// <summary>
        public DbSet<SystemBankFeesDataModel> SystemBankFees { get; set; }

        /// <summary>
        /// The sales local fees table
        /// <summary>
        public DbSet<SalesTaxesDataModel> SalesTaxes { get; set; }

        /// <summary>
        /// The system local fees table
        /// <summary>
        public DbSet<SystemTaxesDataModel> SystemTaxes { get; set; }

        /// <summary>
        /// The trade table
        /// <summary>
        public DbSet<TradeVehicleDataModel> TradeVehicle { get; set; }


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

            modelBuilder.Entity<SystemFrontAddsDataModel>().HasKey(a => a.Number);

            modelBuilder.Entity<SalesFrontAddsDataModel>().HasKey(a => a.DealNumber);

            modelBuilder.Entity<SystemBackAddsDataModel>().HasKey(a => a.Number);

            modelBuilder.Entity<SalesBackAddsDataModel>().HasKey(a => a.DealNumber);

            modelBuilder.Entity<SalesLicensingFeesDataModel>().HasKey(a => a.DealNumber);

            modelBuilder.Entity<SystemLicensingFeesDataModel>().HasKey(a => a.ID); 

            modelBuilder.Entity<SalesLocalFeesDataModel>().HasKey(a => a.DealNumber);

            modelBuilder.Entity<SystemLocalFeesDataModel>().HasKey(a => a.ID);

            modelBuilder.Entity<SalesBankFeesDataModel>().HasKey(a => a.DealNumber);

            modelBuilder.Entity<SystemBankFeesDataModel>().HasKey(a => a.ID);

            modelBuilder.Entity<SalesTaxesDataModel>().HasKey(a => a.DealNumber);

            modelBuilder.Entity<SystemTaxesDataModel>().HasKey(a => a.ID);

            modelBuilder.Entity<TradeVehicleDataModel>().HasKey(a => a.DealNumber);


            // TODO: Set up limits
            //modelBuilder.Entity<LoginCredentialsDataModel>().Property(a => a.FirstName).HasMaxLength(50);

            // Setup computed columns
            modelBuilder.Entity<VehicleInventoryDataModel>().Property(p => p.StockNumber).HasComputedColumnSql("[PreFixID]+right('0000'+CONVERT([nvarchar](4),[ID]),(4))");

            modelBuilder.Entity<CustomerDataModel>().Property(p => p.Number).HasComputedColumnSql("[PreFixID]+right('0000000'+CONVERT([nvarchar](7),[Id]),(7))");

            modelBuilder.Entity<CoverageProviderDataModel>().Property(p => p.Number).HasComputedColumnSql("[PreFixID]+right('000'+CONVERT([nvarchar](3),[Id]),(3))");

            modelBuilder.Entity<SystemFrontAddsDataModel>().Property(p => p.Id).HasComputedColumnSql("[PreFixID]+right('100'+CONVERT([nvarchar](4),[Number]),(4))");

            modelBuilder.Entity<SystemBackAddsDataModel>().Property(p => p.Id).HasComputedColumnSql("'BA'+right('100'+CONVERT([nvarchar](4),[Number]),(4))");

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }


        #endregion
    }
}
