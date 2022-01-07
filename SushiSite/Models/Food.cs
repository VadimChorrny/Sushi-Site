namespace SushiSite.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public double Weight { get; set; }
        public int Amount { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
