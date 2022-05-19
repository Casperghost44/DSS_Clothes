using DSS_Clothes.Models;
using DSS_Clothes.Services;
using Microsoft.EntityFrameworkCore;

namespace DSS_Clothes.Repository
{
    public class StoreRepository : IStore
    {
        private readonly DBContext db;
        public StoreRepository(DBContext _db)
        {
            db = _db;
        }
        public IEnumerable<Store> GetStores => db.Stores;

        public void Add(Store _store)
        {
            db.Stores.Add(_store);
            db.SaveChanges();
        }

        public Store GetStore(int? ID)
        {
            Store Entity = db.Stores.
                Include(a => a.Designers).
                ThenInclude(b => b.Clothes).
                SingleOrDefault(x => x.StoreID == ID);
            return Entity;
        }

        public void Remove(int? ID)
        {
            Store Entity = db.Stores.Find(ID);
            db.Stores.Remove(Entity);
            db.SaveChanges();
        }
    }
}
