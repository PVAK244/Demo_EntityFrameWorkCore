using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Database.Entities
{
    public class DBProductManagement:DbContext
    {
        private const string connString = "Data Source=localhost;Initial Catalog=DBProductManagement;Persist Security Info=True;User ID=sa;Password=123456";
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connString);
        }
    }
}
