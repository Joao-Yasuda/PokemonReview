using Microsoft.AspNetCore.Mvc;
using Pokemon_Review_App.Models;
using Review_Review_App.Interfaces;

namespace Review_Review_App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReviewController : ControllerBase
{
    private readonly IReviewRepository _pokemonRepository;
    
    public ReviewController(IReviewRepository pokemonRepository)
    {
        _pokemonRepository = pokemonRepository;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Review>))]
    public IActionResult GetReviews()
    {
        var pokemons = _pokemonRepository.GetReviews();
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(pokemons);
    }

    [HttpGet("{pokemonId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Review))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetReview(int pokemonId)
    {
        var pokemon =  _pokemonRepository.GetReview(pokemonId);
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(pokemon);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Review))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult CreateReview([FromBody] Review pokemon)
    {
        var pokemonCreated = _pokemonRepository.CreateReview(pokemon);
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(pokemonCreated);
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Review))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult UpdateReview([FromBody] Review pokemon)
    {
        var pokemonUpdated = _pokemonRepository.UpdateReview(pokemon);
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(pokemonUpdated);
    }
    
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Review))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult DeleteReview(int pokemonId)
    {
        _pokemonRepository.DeleteReviewById(pokemonId);
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok();
    }
    
}