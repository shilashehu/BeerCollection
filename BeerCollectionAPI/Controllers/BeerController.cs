using BeerCollection.Data.Repositories.Interfaces;
using BeerCollection.Domain.Models;
using Microsoft.AspNetCore.Mvc;


namespace BeerCollectionAPI.Controllers
{
    [ApiController]
    [Route("api/beers")]
    public class BeerController : ControllerBase
    {
        private readonly IBeerRepository _beerRepository;
        private readonly IBeerRatingRepository _beerRatingRepository;
        private readonly ILogger<BeerController> _logger;

        public BeerController
            (IBeerRepository beerRepository,
            IBeerRatingRepository beerRatingRepository,
            ILogger<BeerController> logger)
        {
            _beerRepository = beerRepository;
            _beerRatingRepository = beerRatingRepository;
            _logger = logger;
        }

        // get all beers from the database
        [HttpGet]
        public async Task<IActionResult> GetBeers()
        {
            try
            {
                var beers = await _beerRepository.GetAll();

                if (beers.Count() == 0)
                    return NoContent();

                _logger.LogInformation("Getting all beers from the database");
                return Ok(beers);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while getting beers: ", ex);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // get beer by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBeerById(int id)
        {
            try
            {
                if (id == 0)
                    return BadRequest();

                var beer = await _beerRepository.GetById(id);

                if (beer == null)
                    return NotFound();

                _logger.LogInformation("Getting beer with ID: " + id + " from the database");
                return Ok(beer);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while getting beer by id " + id + ": ", ex);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // get beers by name
        [HttpGet("name")]
        public IActionResult GetBeersByName(string name)
        {
            try
            {
                if (String.IsNullOrEmpty(name))
                    return BadRequest();

                var beers = _beerRepository.Get(x => x.Name.Contains(name));

                if (beers.Count() == 0)
                    return NotFound();

                _logger.LogInformation("Getting all beers with name: " + name + " from the database");
                return Ok(beers);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while getting beers by name: " + name + ": ", ex);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // insert a new beer in the database
        [HttpPost]
        public async Task<IActionResult> AddBeer(Beer beer)
        {
            try
            {
                if (beer == null)
                    return BadRequest();

                await _beerRepository.Add(beer);
                _logger.LogInformation("Added new beer in the database");
                return CreatedAtAction(nameof(GetBeerById), new { id = beer.Id }, beer);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while adding a new beer: ", ex);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // update beer with new average rating (rating saved in table BeerRating)
        // for example a refresh button is hit in the UI 
        [HttpPut]
        [Route("beer-rating")]
        public async Task<IActionResult> UpdateBeerRating(Beer beer)
        {
            try
            {
                if (beer == null)
                    return BadRequest();

                beer.AvgRating = CalculateAvgRating(beer);

                await _beerRepository.Update(beer);
                _logger.LogInformation("Updated beer with ID: " + beer.Id + ". New Average: " + beer.AvgRating);
                return CreatedAtAction(nameof(GetBeerById), new { id = beer.Id }, beer);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while updating beer rating with beerId:  " + beer.Id + ": ", ex);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        private double CalculateAvgRating(Beer beer)
        {
            var beer_ratings = _beerRatingRepository.GetBeerRatingsScoreByBeerId(beer.Id);
            return Enumerable.Average(beer_ratings);
        }
    }
}
