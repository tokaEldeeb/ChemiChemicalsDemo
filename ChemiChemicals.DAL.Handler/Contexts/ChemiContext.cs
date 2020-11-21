using ChemiChemicals.Repository.Entities;
using ChemiChemicals.Repository.Helper;
using Microsoft.EntityFrameworkCore;


namespace ChemiChemicals.Repository.Contexts
{
    public class ChemiContext : DbContext
    {
        private string _connectionString;
        public ChemiContext()
        {
            //get the connection string from the singleton instance of connectionstringbuilder
            _connectionString = ConnectionStringBuilder.getInstance().GetConnectionString();
            if (string.IsNullOrEmpty(_connectionString))
            {
                //throw exception if no connection was set before
                throw new System.Exception("No connection was set");
            }
        }

        public ChemiContext(DbContextOptions<ChemiContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //set a default option builder if no option was registered
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        //set the dbsets
        public virtual DbSet<Product> Products { get; set; }
    }
}
