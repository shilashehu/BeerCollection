namespace BeerCollection.Domain.Models
{
    public class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? AvgRating { get; set; }
        public int BeerTypeId { get; set; }
    }
}
