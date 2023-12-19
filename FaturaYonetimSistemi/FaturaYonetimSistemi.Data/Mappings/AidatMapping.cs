using FaturaYonetimSistemi.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Data.Mappings
{
    public class AidatMapping : IEntityTypeConfiguration<Aidat>
    {
        public void Configure(EntityTypeBuilder<Aidat> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.Donem).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Tutar).IsRequired();
            builder.Property(x => x.SonOdemeTarihi).IsRequired();
            builder.Property(x => x.Aciklama).HasMaxLength(250);

            builder.ToTable("Aidatlar");

            builder.HasData(
                new Aidat
                {
                    ID=1,
                    Donem="Ocak 2022",
                    Tutar=200,
                    SonOdemeTarihi=new DateTime(2022,01,31),
                    Aciklama="Ocak ayı bina tadilat masrafı eklenmiştir.",
                    AktifMi=true,
                    OlusturmaTarihi=new DateTime(2022,01,01),
                    GuncellemeTarihi=DateTime.Now
                },
                new Aidat
                {
                    ID = 2,
                    Donem = "Şubat 2022",
                    Tutar = 200,
                    SonOdemeTarihi = new DateTime(2022, 02, 28),
                    Aciklama = "Ocak ayı bina tadilat masrafı eklenmiştir.",
                    AktifMi = true,
                    OlusturmaTarihi = new DateTime(2022, 02, 01),
                    GuncellemeTarihi = DateTime.Now
                }
            );




        }
    }
}
