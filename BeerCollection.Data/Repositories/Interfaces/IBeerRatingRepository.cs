using BeerCollection.Domain.Models;

namespace BeerCollection.Data.Repositories.Interfaces
{
    public interface IBeerRatingRepository : IBaseRepository<BeerRating>
    {
        IEnumerable<int> GetBeerRatingsScoreByBeerId(int beer_id);
    }
}
