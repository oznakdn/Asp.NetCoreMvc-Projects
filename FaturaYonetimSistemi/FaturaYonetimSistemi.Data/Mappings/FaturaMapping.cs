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
    public class FaturaMapping : IEntityTypeConfiguration<Fatura>
    {
        public void Configure(EntityTypeBuilder<Fatura> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.SonOdemeTarihi).IsRequired();
            builder.Property(x => x.FaturaAdi).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Tutar).IsRequired();
            builder.Property(x => x.Aciklama).HasMaxLength(250);

            builder.ToTable("Faturalar");

            builder.HasData(
                new Fatura
                {
                    ID = 1,
                    FaturaAdi = "Elektrik",
                    SonOdemeTarihi = new DateTime(2022, 02, 25),
                    Tutar=100,
                    Aciklama="Şubat 2022 elektrik faturası",
                    AktifMi=true,
                    OlusturmaTarihi=new DateTime(2022,02,01),
                    GuncellemeTarihi=DateTime.Now
                },
                new Fatura
                {
                    ID = 2,
                    FaturaAdi = "Su",
                    SonOdemeTarihi = new DateTime(2022, 02, 20),
                    Tutar = 50,
                    Aciklama = "Şubat 2022 su faturası",
                    AktifMi = true,
                    OlusturmaTarihi = new DateTime(2022, 02, 01),
                    GuncellemeTarihi = DateTime.Now
                }

                );
        }
    }
}
