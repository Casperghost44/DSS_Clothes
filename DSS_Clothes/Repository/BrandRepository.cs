using DSS_Clothes.Models;
using DSS_Clothes.Services;
using Microsoft.EntityFrameworkCore;

namespace DSS_Clothes.Repository
{
    public class BrandRepository : IBrand
    {
        private readonly DBContext db;
        public BrandRepository(DBContext _db)
        {
            db = _db;
        }

        public IEnumerable<Brand> GetBrands => db.Brands;

        public void Add(Brand _brand)
        {
            db.Brands.Add(_brand);
            db.SaveChanges();
        }

        public Brand GetBrand(int? ID)
        {
            Brand dbEntity = db.Brands.
                Include(x => x.Clothes).
                SingleOrDefault(a => a.BrandID == ID);
            return dbEntity;
        }

        public void Remove(int? ID)
        {
            Brand dbEntity = db.Brands.Find(ID);
            db.Brands.Remove(dbEntity);
            db.SaveChanges();
        }
    }
}
