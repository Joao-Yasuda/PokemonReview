using Microsoft.AspNetCore.Mvc;
using Pokemon_Review_App.Interfaces;
using Pokemon_Review_App.Models;

namespace Pokemon_Review_App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PokemonController : ControllerBase
{
    private readonly IPokemonRepository _pokemonRepository;
    
    public PokemonController(IPokemonRepository pokemonRepository)
    {
        _pokemonRepository = pokemonRepository;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
    public IActionResult GetPokemons()
    {
        var pokemons = _pokemonRepository.GetPokemons();
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(pokemons);
    }

    [HttpGet("{pokemonId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Pokemon))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetPokemon(int pokemonId)
    {
        var pokemon =  _pokemonRepository.GetPokemon(pokemonId);
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(pokemon);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Pokemon))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult CreatePokemon([FromBody] Pokemon pokemon)
    {
        var pokemonCreated = _pokemonRepository.CreatePokemon(pokemon);
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(pokemonCreated);
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Pokemon))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult UpdatePokemon([FromBody] Pokemon pokemon)
    {
        var pokemonUpdated = _pokemonRepository.UpdatePokemon(pokemon);
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(pokemonUpdated);
    }
    
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Pokemon))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult DeletePokemon(int pokemonId)
    {
        _pokemonRepository.DeletePokemonById(pokemonId);
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok();
    }
    
}