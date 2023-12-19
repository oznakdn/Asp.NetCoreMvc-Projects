using FaturaYonetimSistemi.Shared.Dtos.KullaniciFaturaDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Services.Abstract
{
    public interface IKullaniciFaturaService
    {
        List<ListKullaniciFaturaDto> GetAllKullaniciFatura(int kullaniciId);
    }
}
