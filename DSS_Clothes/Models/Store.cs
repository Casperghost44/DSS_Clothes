using System.ComponentModel.DataAnnotations;

namespace DSS_Clothes.Models
{
    public class Store
    {
        [Key]
        public int StoreID { get; set; }
        public string StoreName { get; set; }
        public string? StoreYear { get; set; }
        public ICollection<Designer>? Designers { get; set; }
    }
}
