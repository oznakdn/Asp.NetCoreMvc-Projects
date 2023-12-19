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
    public class BlokMapping : IEntityTypeConfiguration<Blok>
    {
        public void Configure(EntityTypeBuilder<Blok> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.BlokAdi).IsRequired().HasMaxLength(30);
            builder.Property(x => x.ToplamDaire).IsRequired();

            builder.ToTable("Bloklar");

            builder.HasData(
                new Blok
                {
                    ID = 1,
                    BlokAdi = "A Blok",
                    ToplamDaire = 20,
                    AktifMi = true,
                    OlusturmaTarihi = new DateTime(2020, 01, 01),
                    GuncellemeTarihi=DateTime.Now
                }
            );
        }
    }
}
