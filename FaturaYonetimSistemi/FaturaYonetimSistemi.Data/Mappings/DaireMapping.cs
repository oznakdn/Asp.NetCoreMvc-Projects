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
    public class DaireMapping : IEntityTypeConfiguration<Daire>
    {
        public void Configure(EntityTypeBuilder<Daire> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.DaireNo).IsRequired();
            builder.Property(x => x.Blokid).IsRequired();
            builder.Property(x => x.BosMu).IsRequired();


            //builder.HasOne<Blok>()
            //       .WithMany(x => x.Daireler)
            //       .HasForeignKey(x => x.Blokid);


            builder.ToTable("Daireler");


            builder.HasData(
                new Daire
                {
                    ID = 1,
                    DaireNo = 1,
                    Kat = 1,
                    BosMu = false,
                    Tipi = "3+1",
                    SahibiMi = true,
                    Blokid = 1,
                    AktifMi = true,
                    OlusturmaTarihi = new DateTime(2020, 01, 01),
                    GuncellemeTarihi = DateTime.Now
                },
                 new Daire
                 {
                     ID = 2,
                     DaireNo = 2,
                     Kat = 1,
                     BosMu = true,
                     Tipi = "2+1",
                     SahibiMi = false,
                     Blokid = 1,
                     AktifMi = true,
                     OlusturmaTarihi = new DateTime(2020, 01, 01),
                     GuncellemeTarihi = DateTime.Now
                 },
                 new Daire
                 {
                     ID = 3,
                     DaireNo = 3,
                     Kat = 2,
                     BosMu = false,
                     Tipi = "3+1",
                     SahibiMi = false,
                     Blokid = 1,
                     AktifMi = true,
                     OlusturmaTarihi = new DateTime(2020, 01, 01),
                     GuncellemeTarihi = DateTime.Now
                 },
                 new Daire
                 {
                     ID = 4,
                     DaireNo = 4,
                     Kat = 2,
                     BosMu = true,
                     Tipi = "2+1",
                     SahibiMi = false,
                     Blokid = 1,
                     AktifMi = true,
                     OlusturmaTarihi = new DateTime(2020, 01, 01),
                     GuncellemeTarihi = DateTime.Now
                 }

                 );



        }
    }
}
