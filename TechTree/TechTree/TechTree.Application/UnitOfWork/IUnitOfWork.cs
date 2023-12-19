using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTree.Application.Repositories;

namespace TechTree.Application.UnitOfWork
{
    public interface IUnitOfWork:IAsyncDisposable
    {


        ICategoryRepository Category { get; }
        ICategoryItemRepository CategoryItem { get; }
        IContentRepository Content { get; }
        IMediaTypeRepository MediaType { get; }
        IUserCategoryRepository UserCategory { get; }


        Task SaveAsync();






    }
}
