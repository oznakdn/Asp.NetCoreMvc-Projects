using FaturaYonetimSistemi.Data.Abstract;
using FaturaYonetimSistemi.Data.Concrete.BaseRepository;
using FaturaYonetimSistemi.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Data.Concrete
{
    public class MesajRepository:EfRepositoryBase<Mesaj>,IMesajRepository
    {
    }
}
