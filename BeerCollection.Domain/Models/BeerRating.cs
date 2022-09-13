namespace BeerCollection.Domain.Models
{
    public class BeerRating
    {
        public int Id { get; set; }
        public int BeerId { get; set; }
        public int Score { get; set; }
    }
}
