namespace DSS_Clothes.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        public string FileName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Index { get; set; }

        public int ClotheID { get; set; }
        public Clothe Clothe { get; set; }
    }
}
