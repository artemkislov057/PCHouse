using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRTF_bot.model.database
{
    class ConfigurationContext : DbContext
    {
        public ConfigurationContext() : this("Configurations.mdf")
        {

        }

        public ConfigurationContext(string path)
        {
            Path = path;
            connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\" + path + ";Integrated Security=True";
            Database.EnsureCreated();
        }

        public readonly string Path;
        private string connectionString;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
        }

        public virtual DbSet<Configuration> Configurations { get; set; }
    }
}
