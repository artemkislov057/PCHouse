using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRTF_bot.model.Components;
using TestRTF_bot.Models.Accessories;

namespace TestRTF_bot.model.database
{
    class ComponentsContext : DbContext
    {
        public ComponentsContext() : this("DataBase.mdf") { }

        public ComponentsContext(string path)
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
        public virtual DbSet<Processor> Processors { get; set; }
        public virtual DbSet<Motherboard> Motherboards { get; set; }
        public virtual DbSet<VideoCard> VideoCards { get; set; }
        public virtual DbSet<RAM> RAMs { get; set; }
        public virtual DbSet<PowerModule> PowerModules { get; set; }
        public virtual DbSet<ProcessorCooling> ProcessorCoolings { get; set; }
        public virtual DbSet<Case> Cases { get; set; }
        public virtual DbSet<Storage> Storages { get; set; }
        public virtual DbSet<M2> M2Collection { get; set; }
        public virtual DbSet<CaseCooling> CaseCoolings { get; set; }
    }
}
