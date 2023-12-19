

namespace E_Commerce.Application.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        IProductRepository Product { get; }
        ICategoryRepository Category { get; }



        void Save();
    }
}
