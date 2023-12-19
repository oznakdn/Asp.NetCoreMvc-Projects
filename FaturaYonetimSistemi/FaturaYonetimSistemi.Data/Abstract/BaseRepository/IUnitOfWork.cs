using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Data.Abstract.BaseRepository
{
    public interface IUnitOfWork
    {
        IDaireRepository Daire { get; }
        IBlokRepository Blok { get; }
        IAidatRepository Aidat { get; }
        IFaturaRepository Fatura { get; }
        IKullaniciRepository Kullanici { get; }
        IMesajRepository Mesaj { get; }
        IKullaniciAidatRepository KullaniciAidat { get; }
        IKullaniciFaturaRepository KullaniciFatura { get; }
        IAppUserRepository AppUser { get; }

    }
}
