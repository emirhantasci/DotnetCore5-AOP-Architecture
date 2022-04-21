using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmirApi.Entities.Concrete;
using EmirApi.Entities.Concrete;

namespace EmirApi.DataAccess.Concrete.EntityFramework.Contexts
{
    public class DbEmirContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            string dbConnectionString = configuration.GetConnectionString("DbConnection");

            optionsBuilder.UseSqlServer(dbConnectionString);
        }

        public DbSet<XTest> xTest { get; set; }



    }
}
