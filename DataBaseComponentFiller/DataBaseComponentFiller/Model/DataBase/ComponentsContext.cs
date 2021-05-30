using DataBaseComponentFiller.Model.Components;
using Microsoft.EntityFrameworkCore;

namespace DataBaseComponentFiller.Model.DataBase
{
    class ComponentsContext : DbContext
    {
        public ComponentsContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\DataBase.mdf;Integrated Security=True";
            optionsBuilder.UseSqlServer(connectionString);
            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
        }

        [Table]
        public virtual DbSet<Processor> Processors { get; set; }
        [Table]
        public virtual DbSet<Motherboard> Motherboards { get; set; }
        [Table]
        public virtual DbSet<VideoCard> VideoCards { get; set; }
        [Table]
        public virtual DbSet<RAM> RAMs { get; set; }
        [Table]
        public virtual DbSet<PowerModule> PowerModules { get; set; }
        [Table]
        public virtual DbSet<ProcessorCooling> ProcessorCoolings { get; set; }
        [Table]
        public virtual DbSet<Case> Cases { get; set; }
        [Table]
        public virtual DbSet<Storage> Storages { get; set; }
        [Table]
        public virtual DbSet<M2> M2Collection { get; set; }
        [Table]
        public virtual DbSet<CaseCooling> CaseCoolings { get; set; }
    }
}
