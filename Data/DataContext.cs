using Microsoft.EntityFrameworkCore;
using RedBrowBackend.Models;

namespace RedBrowBackend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString: "workstation id=JohnnyR.mssql.somee.com;packet size=4096;user id=JohnnyR_SQLLogin_1;pwd=9aq35llr4k;data source=JohnnyR.mssql.somee.com;persist security info=False;initial catalog=JohnnyR;Encrypt=False");
        }

        public DbSet<Users> Users { get; set; }
    }
}
