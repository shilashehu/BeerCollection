namespace BeerCollection.Domain.Models
{
    public class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BeerTypeId { get; set; }
        public ICollection<BeerRating> BeerRatings { get; set; }
        public double? AvgRating { get; set; }
    }
}
