using FaturaYonetimSistemi.Data.Abstract;
using FaturaYonetimSistemi.Data.Abstract.BaseRepository;
using FaturaYonetimSistemi.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Data.Concrete.BaseRepository
{
    public class UnitOfWork : IUnitOfWork
    {

      

        private readonly AidatRepository aidatRepository;
        private readonly BlokRepository blokRepository;
        private readonly DaireRepository daireRepository;
        private readonly FaturaRepository faturaRepository;
        private readonly KullaniciRepository kullaniciRepository;
        private readonly MesajRepository mesajRepository;
        private readonly KullaniciFaturaRepository kullaniciFaturaRepository;
        private readonly KullaniciAidatRepository kullaniciAidatRepository;
        private readonly AppUserRepository appUserRepository;





        public IDaireRepository Daire => daireRepository ?? new DaireRepository();

        public IBlokRepository Blok => blokRepository ?? new BlokRepository();

        public IAidatRepository Aidat => aidatRepository ?? new AidatRepository();

        public IFaturaRepository Fatura => faturaRepository ?? new FaturaRepository();

        public IKullaniciRepository Kullanici => kullaniciRepository ?? new KullaniciRepository();

        public IMesajRepository Mesaj => mesajRepository ?? new MesajRepository();

        public IKullaniciAidatRepository KullaniciAidat => kullaniciAidatRepository ?? new KullaniciAidatRepository();

        public IKullaniciFaturaRepository KullaniciFatura => kullaniciFaturaRepository ?? new KullaniciFaturaRepository();

        public IAppUserRepository AppUser => appUserRepository ?? new AppUserRepository();

        
    }
}
