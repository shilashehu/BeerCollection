using BeerCollection.Data;
using BeerCollection.Data.Repositories.Interfaces;
using BeerCollection.Domain.Models;

namespace BeerCollection.Data.Repositories.Common
{
    public class BeerRepository : BaseRepository<Beer>, IBeerRepository
    {
        private BeerCollectionContext _context;
        public BeerRepository(BeerCollectionContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
