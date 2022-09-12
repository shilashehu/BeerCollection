using BeerCollection.Data;
using BeerCollection.Data.Repositories.Interfaces;
using BeerCollection.Domain.Models;

namespace BeerCollection.Data.Repositories.Common
{
    public class BeerRatingRepository : BaseRepository<BeerRating>, IBeerRatingRepository
    {
        private BeerCollectionContext _context;
        public BeerRatingRepository(BeerCollectionContext context)
            : base(context)
        {
            _context = context;
        }

        public IEnumerable<int> GetBeerRatingsScoreByBeerId(int beer_id)
        {
            var beers = from m in _context.BeerRating.Where(x => x.BeerId == beer_id)
                        select m.Score;
            return beers;
        }
    }
}
