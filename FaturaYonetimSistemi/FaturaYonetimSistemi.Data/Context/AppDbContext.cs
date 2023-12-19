using FaturaYonetimSistemi.Data.EntityConfigurations;
using FaturaYonetimSistemi.Data.Mappings;
using FaturaYonetimSistemi.Shared.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Data.Context
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        //public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        //{

        //}


        public DbSet<Daire> Daireler { get; set; }
        public DbSet<Blok> Bloklar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Aidat> Aidatlar { get; set; }
        public DbSet<Fatura> Faturalar { get; set; }
        public DbSet<KullaniciAidat> KullaniciAidatlar { get; set; }
        public DbSet<KullaniciFatura> KullaniciFaturalar { get; set; }
        public DbSet<Mesaj> Mesajlar { get; set; }



        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = (localdb)\\MSSQLLocalDb; Database = FaturaYonetimSistemiDb; Trusted_Connection = true");
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {


            builder.Entity<Kullanici>()
                   .HasMany(x => x.KullaniciAidatlar)
                   .WithOne(x => x.Kullanici)
                   .HasForeignKey(x => x.KullaniciId);
            builder.Entity<Aidat>()
                   .HasMany(x => x.KullaniciAidatlar)
                   .WithOne(x => x.Aidat)
                   .HasForeignKey(x => x.AidatId);

            builder.Entity<Kullanici>()
                   .HasMany(x => x.KullaniciFaturalar)
                   .WithOne(x => x.Kullanici)
                   .HasForeignKey(x => x.KullaniciId);
            builder.Entity<Fatura>()
                   .HasMany(x => x.KullaniciFaturalar)
                   .WithOne(x => x.Fatura)
                   .HasForeignKey(x => x.FaturaId);


            builder.Entity<KullaniciAidat>()
                   .HasIndex(x => new
                   {
                       x.KullaniciId,
                       x.AidatId
                   }).IsUnique();

            builder.Entity<KullaniciFatura>()
                   .HasIndex(x => new
                   {
                       x.KullaniciId,
                       x.FaturaId
                   }).IsUnique();


            builder.ApplyConfiguration(new DaireMapping());
            builder.ApplyConfiguration(new BlokMapping());
            builder.ApplyConfiguration(new KullaniciMapping());
            builder.ApplyConfiguration(new AidatMapping());
            builder.ApplyConfiguration(new FaturaMapping());
            builder.ApplyConfiguration(new KullaniciAidatMapping());
            builder.ApplyConfiguration(new KullaniciFaturaMapping());
            builder.ApplyConfiguration(new MesajMapping());



            base.OnModelCreating(builder);
        }
    }
}
