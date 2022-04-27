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
        public DbSet<SalesDealRecallDataModel> SalesDealsList { get; set; }

        /// <summary>
        /// The sales finance info table
        /// </summary>
        public DbSet<SalesFinanceDataModel> SalesFinance { get; set; }

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

            modelBuilder.Entity<SalesDealRecallDataModel>().HasKey(a => a.DealNumber);

            modelBuilder.Entity<SalesFinanceDataModel>().HasKey(a => a.DealNumber);

            // TODO: Set up limits
            //modelBuilder.Entity<LoginCredentialsDataModel>().Property(a => a.FirstName).HasMaxLength(50);
        }

        #endregion
    }
}
