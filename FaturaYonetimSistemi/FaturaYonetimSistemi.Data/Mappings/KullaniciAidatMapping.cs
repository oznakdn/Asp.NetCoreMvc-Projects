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
    public class KullaniciAidatMapping : IEntityTypeConfiguration<KullaniciAidat>
    {
        public void Configure(EntityTypeBuilder<KullaniciAidat> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.AidatId).IsRequired();
            builder.Property(x => x.KullaniciId).IsRequired();
            builder.Property(x => x.OdendiMi).IsRequired();

            builder.ToTable("KullaniciAidatlar");

            builder.HasData(
                new KullaniciAidat
                {
                    ID=1,
                    KullaniciId=1,
                    AidatId=1,
                    AktifMi=true,
                    OdendiMi=false,
                    OdenmeTarihi=null,
                    OlusturmaTarihi=new DateTime(2022,01,01),
                    GuncellemeTarihi=DateTime.Now
                },
                new KullaniciAidat
                {
                    ID = 2,
                    KullaniciId = 1,
                    AidatId = 2,
                    AktifMi = true,
                    OdendiMi=false,
                    OdenmeTarihi=null,
                    OlusturmaTarihi = new DateTime(2022, 02, 01),
                    GuncellemeTarihi = DateTime.Now


                },
                new KullaniciAidat
                {
                    ID = 3,
                    KullaniciId = 2,
                    AidatId = 1,
                    AktifMi = true,
                    OdendiMi=false,
                    OdenmeTarihi=null,
                    OlusturmaTarihi = new DateTime(2022, 01, 01),
                    GuncellemeTarihi = DateTime.Now


                },
                new KullaniciAidat
                {
                    ID = 4,
                    KullaniciId = 2,
                    AidatId = 2,
                    AktifMi = true,
                    OdendiMi=false,
                    OdenmeTarihi=null,
                    OlusturmaTarihi = new DateTime(2022, 02, 01),
                    GuncellemeTarihi = DateTime.Now


                }

            );



        }
    }
}
