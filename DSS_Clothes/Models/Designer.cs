using System.ComponentModel.DataAnnotations;

namespace DSS_Clothes.Models
{
    public class Designer
    {
        [Key]
        public int DesignerID { get; set; }
        public int ClotheID { get; set; }
        public int StoreID { get; set; }
        public Clothe? Clothes { get; set; }
        public Store? Stores { get; set; }
    }
}
