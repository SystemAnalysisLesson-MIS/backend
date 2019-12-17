
using Microsoft.EntityFrameworkCore;
using IkematgahDegisim.Entity.Concerete;
using IkematgahDegisim.Core.Entities.Concerete;

namespace IkematgahDegisim.DataAccess.Concerete.EntityFramework.Context
{
    public class IkematgahDegisimContext:DbContext
    {
        public IkematgahDegisimContext()
        {

        }

        public IkematgahDegisimContext(DbContextOptions<IkematgahDegisimContext> options):base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            optionbuilder.UseSqlServer(connectionString: @"Data Source=DESKTOP-BFT7NEM\SQLEXPRESS;Database=IkematgahDegisimDB;Trusted_Connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Vatandas>().HasOne(v => v.vatandasTalep)
                 .WithOne(v => v.vatandas)
                 .HasForeignKey<VatandasTalep>(v => v.Id);

            modelBuilder.Entity<Vatandas>().HasOne(v => v.vatandasKisisel)
                 .WithOne(v => v.vatandas)
                 .HasForeignKey<VatandasKisisel>(v => v.Id);

            modelBuilder.Entity<Vatandas>().HasOne(v => v.vatandasTeslimat)
               .WithOne(v => v.vatandas)
               .HasForeignKey<VatandasTeslimat>(v => v.Id);

            modelBuilder.Entity<Talep>().Property(t => t.sozlesmeFotograf)
                .HasColumnType("image");

            

        }

        public DbSet<Ikematgah> İkematgahlar { get; set; }
        public DbSet<Vatandas> Vatandaslar { get; set; }

        public DbSet<VatandasKisisel> KisiselBilgiler { get; set; }
        public DbSet<Talep> Talepler { get; set; }
        public DbSet<VatandasTalep> VatandasTalepler { get; set; }

        public DbSet<VatandasTeslimat> VatandasTeslimatlar { get; set; }
        public DbSet<Teslimat> Teslimatlar { get; set; }

        public DbSet<Kullanici> Kullanicilar { get; set; }
       
        public DbSet<KullaniciOperasyonelTalep> KullaniciOperasyonelTalepler { get; set; }

        public DbSet<OperasyonelTalep> OperasyonelTalepler { get; set; }
    }

}
