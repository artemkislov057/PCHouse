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

        [Table("Процессор")]
        public virtual DbSet<Processor> Processors { get; set; }

        [Table("Материнская плата")]
        public virtual DbSet<Motherboard> Motherboards { get; set; }

        [Table("Видеокарта")]
        public virtual DbSet<VideoCard> VideoCards { get; set; }

        [Table("Оперативная память")]
        public virtual DbSet<RAM> RAMs { get; set; }

        [Table("Блок питания")]
        public virtual DbSet<PowerModule> PowerModules { get; set; }

        [Table("Охлаждение процессора")]
        public virtual DbSet<ProcessorCooling> ProcessorCoolings { get; set; }

        [Table("Корпус")]
        public virtual DbSet<Case> Cases { get; set; }

        [Table("Память (HDD/SSD)")]
        public virtual DbSet<Storage> Storages { get; set; }

        [Table("M2")]
        public virtual DbSet<M2> M2Collection { get; set; }

        [Table("Охлаждение корпуса")]
        public virtual DbSet<CaseCooling> CaseCoolings { get; set; }
    }
}
