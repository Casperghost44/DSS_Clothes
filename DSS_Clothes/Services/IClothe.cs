using DSS_Clothes.Models;

namespace DSS_Clothes.Services
{
    public interface IClothe
    {
        IEnumerable<Clothe> GetClothes { get; }

        Clothe GetClothe(int? ID);
        void Add(Clothe _clothe);
        void Remove(int? ID);
    }
}
