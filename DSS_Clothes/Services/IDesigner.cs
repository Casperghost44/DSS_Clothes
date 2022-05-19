using DSS_Clothes.Models;

namespace DSS_Clothes.Services
{
    public interface IDesigner
    {
        IEnumerable<Designer> GetDesigners { get; }

        Designer GetDesigner(int? ID);
        void Add(Designer _designer);
        void Remove(int? ID);
    }
}
