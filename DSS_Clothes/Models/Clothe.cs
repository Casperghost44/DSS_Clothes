using System.ComponentModel.DataAnnotations;

namespace DSS_Clothes.Models
{
    public class Clothe
    {
        [Key]
        public int ClotheID { get; set; }
        public string? ClotheName { get; set; }
        public int BrandID { get; set; }
        public Brand? Brand { get; set; }
        public ICollection<Designer>? Designers { get; set; }
        public ICollection<Image>? Images { get; set; }
    }
}
