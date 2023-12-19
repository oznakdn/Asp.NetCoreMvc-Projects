using FaturaYonetimSistemi.Data.Abstract.BaseRepository;
using FaturaYonetimSistemi.Data.Concrete.BaseRepository;
using FaturaYonetimSistemi.Data.Context;
using FaturaYonetimSistemi.Services.Abstract;
using FaturaYonetimSistemi.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Services.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddMyServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<AppDbContext>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<IAidatService, AidatManager>();
            serviceCollection.AddScoped<IFaturaService, FaturaManager>();
            serviceCollection.AddScoped<IKullaniciService, KullaniciManager>();
            serviceCollection.AddScoped<IDaireService, DaireManager>();
            serviceCollection.AddScoped<IBlokService, BlokManager>();
            serviceCollection.AddScoped<IKullaniciAidatService, KullaniciAidatManager>();
            serviceCollection.AddScoped<IKullaniciFaturaService, KullaniciFaturaManager>();

            return serviceCollection;
        }
    }
}
