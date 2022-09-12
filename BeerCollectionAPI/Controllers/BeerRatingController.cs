using BeerCollection.Data.Repositories.Interfaces;
using BeerCollection.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeerCollectionAPI.Controllers
{
    [ApiController]
    [Route("api/beer-rating")]
    public class BeerRatingController : ControllerBase
    {
        private readonly IBeerRatingRepository _beerRatingRepository;
        private readonly ILogger<BeerRatingController> _logger;

        public BeerRatingController(IBeerRatingRepository beerRatingRepository, ILogger<BeerRatingController> logger)
        {
            _beerRatingRepository = beerRatingRepository;
            _logger = logger;
        }

        // insert a new rating 
        // if we want to immediately refresh the average beer rating after a new rating comes,
        // we can do the calculation here and call a method that saves both Beer and BeerRating table (in a transaction)
        [HttpPost]

        public async Task<IActionResult> AddBeerRating(BeerRating beer_rating)
        {
            try
            {
                //ratings can be from 1 to 5
                if ((beer_rating.BeerId == 0) || (beer_rating.Score < 1 || beer_rating.Score > 5))
                    return BadRequest();

                await _beerRatingRepository.Add(beer_rating);
                _logger.LogInformation("Added new Beer Rating");
                return Ok(beer_rating);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while adding beer rating: ", ex);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
