using FaturaYonetimSistemi.Shared.Dtos.DaireDtos;
using FaturaYonetimSistemi.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Services.Abstract
{
    public interface IDaireService
    {
        Daire Get(Expression<Func<Daire, bool>> Predicate, params Expression<Func<Daire, object>>[] includeProperty);
        List<ListDaireDto> GetAllDaireler();
        void AddDaire(InsertDaireDto model);
        void UpdateDaire(UpdateDaireDto model);
        Daire SoftDelete(int id);


    }
}
