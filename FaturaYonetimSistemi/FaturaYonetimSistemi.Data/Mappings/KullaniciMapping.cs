using FaturaYonetimSistemi.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Data.EntityConfigurations
{
    public class KullaniciMapping : IEntityTypeConfiguration<Kullanici>
    {
        public void Configure(EntityTypeBuilder<Kullanici> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.Ad).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Soyad).IsRequired().HasMaxLength(30);
            builder.Property(x => x.TCNo).IsRequired();
            builder.HasIndex(x => x.TCNo).IsUnique();
            builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Telefon).IsRequired().HasMaxLength(11);
            builder.Property(x => x.Arac).IsRequired();
            builder.Property(x => x.Plaka).HasMaxLength(10);
            builder.Property(x => x.DaireId).IsRequired();

            builder.ToTable("Kullanicilar");

            builder.HasData(
                new Kullanici
                {
                    ID=1,
                    Ad="Ali",
                    Soyad="Güzel",
                    TCNo=12345678910,
                    Fotograf= "https://statics.altinyildizclassics.com/mnresize/380/521/productimages/4A3022100062_LAM_1.jpg",
                    Email ="aliguzel@mail.com",
                    Telefon="05001002030",
                    Arac=false,
                    Plaka=String.Empty,
                    DaireId=1,
                    AktifMi=true,
                    OlusturmaTarihi=new DateTime(2021,01,01),
                    GuncellemeTarihi=DateTime.Now
                },
                 new Kullanici
                 {
                     ID = 2,
                     Ad = "Veli",
                     Soyad = "Sever",
                     TCNo = 10987654321,
                     Fotograf = "https://cdn.sorsware.com/ramsey/ContentImages/Product/2019-1/10112785/duz-dokuma-ceket_lacivert-lacivert_1_buyuk.JPG",
                     Email = "velisever@mail.com",
                     Telefon = "05002003040",
                     Arac = true,
                     Plaka = "34 ABC 100",
                     DaireId = 3,
                     AktifMi = true,
                     OlusturmaTarihi = new DateTime(2021, 01, 01),
                     GuncellemeTarihi = DateTime.Now
                 }
            );





        }
    }
}
