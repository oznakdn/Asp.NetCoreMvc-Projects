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
    public class MesajMapping : IEntityTypeConfiguration<Mesaj>
    {
        public void Configure(EntityTypeBuilder<Mesaj> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.Konu).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Icerik).IsRequired().HasMaxLength(500);

            builder.ToTable("Mesajlar");

            builder.HasData(
                new Mesaj
                {
                    ID=1,
                    Konu="Çevre düzenleme",
                    Icerik="Ağaç ve çiçeklerin bakımı",
                    OlusturmaTarihi=DateTime.Now,
                    AktifMi=true,
                    GuncellemeTarihi=DateTime.Now,
                    KullaniciId=1
                }
            );



        }
    }
}
