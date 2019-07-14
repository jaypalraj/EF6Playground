using Entities;
using System.Data.Entity;

namespace Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnectionString")
        {

        }
        public DbSet<Lead> Leads { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<BankDetail> BankDetails { get; set; }
    }
}
