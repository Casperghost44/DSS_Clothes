using DSS_Clothes.Models;

namespace DSS_Clothes.Services
{
    public interface IBrand
    {
        IEnumerable<Brand> GetBrands { get; }

        Brand GetBrand(int? ID);
        void Add(Brand _brand);
        void Remove(int? ID);
    }
}
