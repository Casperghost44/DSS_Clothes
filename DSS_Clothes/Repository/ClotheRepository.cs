using DSS_Clothes.Models;
using DSS_Clothes.Services;
using Microsoft.EntityFrameworkCore;

namespace DSS_Clothes.Repository
{
    public class ClotheRepository : IClothe
    {
        private readonly DBContext db;
        public ClotheRepository(DBContext _db)
        {
            db = _db;
        }
        public IEnumerable<Clothe> GetClothes => db.Clothes.Include(x => x.Brand);

        public void Add(Clothe _clothe)
        {
            db.Clothes.Add(_clothe);
            db.SaveChanges();
        }

        public Clothe GetClothe(int? ID)
        {
            Clothe Entity = db.Clothes
                .Include(b => b.Designers)
                .ThenInclude(c => c.Stores)
                .Include(a => a.Brand)
                .FirstOrDefault(x => x.ClotheID == ID);
            return Entity;
        }

        public void Remove(int? ID)
        {
            Clothe Entity = db.Clothes.Find(ID);
            db.Clothes.Remove(Entity);
            db.SaveChanges();
        }
    }
}
