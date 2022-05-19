

using DSS_Clothes.Models;
using DSS_Clothes.Services;
using Microsoft.EntityFrameworkCore;

namespace DSS_Clothes.Repository
{
    public class DesignerRepository : IDesigner
    {
        private readonly DBContext db;
        public DesignerRepository(DBContext _db)
        {
            db = _db;
        }
        public IEnumerable<Designer> GetDesigners => db.Designers.Include(x => x.Clothes).Include(a => a.Stores);

        public void Add(Designer _designer)
        {
            db.Designers.Add(_designer);
            db.SaveChanges();
        }

        public Designer GetDesigner(int? ID)
        {
            Designer Entity = db.Designers.Include(x => x.Clothes).Include(a => a.Stores).SingleOrDefault(b => b.DesignerID == ID);
            return Entity;
        }

        public void Remove(int? ID)
        {
            Designer Entity = db.Designers.Find(ID);
            db.Designers.Remove(Entity);
            db.SaveChanges();
        }
    }
}
