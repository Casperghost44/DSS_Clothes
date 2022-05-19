using DSS_Clothes.Models;

namespace DSS_Clothes.Services
{
    public interface IStore
    {
        IEnumerable<Store> GetStores { get; }

        Store GetStore(int? ID);
        void Add(Store _store);
        void Remove(int? ID);
    }
}
