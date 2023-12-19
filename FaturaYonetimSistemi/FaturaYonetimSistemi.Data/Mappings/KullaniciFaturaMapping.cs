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
    public class KullaniciFaturaMapping : IEntityTypeConfiguration<KullaniciFatura>
    {
        public void Configure(EntityTypeBuilder<KullaniciFatura> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.KullaniciId).IsRequired();
            builder.Property(x => x.FaturaId).IsRequired();
            builder.Property(x => x.OdendiMi).IsRequired();

            builder.ToTable("KullaniciFaturalar");

            builder.HasData(
                new KullaniciFatura
                {
                    ID=1,
                    KullaniciId=1,
                    FaturaId=1,
                    AktifMi=true,
                    OdendiMi=false,
                    OdemeTarihi=null,
                    OlusturmaTarihi=new DateTime(2022,01,01),
                    GuncellemeTarihi=DateTime.Now

                },
                new KullaniciFatura
                {
                    ID = 2,
                    KullaniciId = 1,
                    FaturaId = 2,
                    AktifMi = true,
                    OdendiMi=false,
                    OdemeTarihi=null,
                    OlusturmaTarihi = new DateTime(2022, 02, 01),
                    GuncellemeTarihi = DateTime.Now

                },
                new KullaniciFatura
                {
                    ID = 3,
                    KullaniciId = 2,
                    FaturaId = 1,
                    AktifMi = true,
                    OdendiMi=false,
                    OdemeTarihi=null,
                    OlusturmaTarihi = new DateTime(2022, 01, 01),
                    GuncellemeTarihi = DateTime.Now

                },
                new KullaniciFatura
                {
                    ID = 4,
                    KullaniciId = 2,
                    FaturaId = 2,
                    AktifMi = true,
                    OdendiMi=false,
                    OdemeTarihi=null,
                    OlusturmaTarihi = new DateTime(2022, 02, 01),
                    GuncellemeTarihi = DateTime.Now

                }
            );



        }
    }
}
