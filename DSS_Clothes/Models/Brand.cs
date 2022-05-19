using System.ComponentModel.DataAnnotations;

namespace DSS_Clothes.Models
{
    public class Brand
    {
        [Key]
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public int BrandYear { get; set; }
        public ICollection<Clothe>? Clothes { get; set; }
    }
}
