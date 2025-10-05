using Pokemon_Review_App.Data;
using Pokemon_Review_App.Interfaces;
using Pokemon_Review_App.Models;

namespace Pokemon_Review_App.Repository;

public class PokemonRepository : IPokemonRepository
{
    private readonly DataContext _context;

    public PokemonRepository(DataContext context)
    {
        _context = context;
    }

    public ICollection<Pokemon> GetPokemons()
    {
        return _context.Pokemon.ToList();
    }

    public Pokemon GetPokemon(int pokemonId)
    {
        return _context.Pokemon.Find(pokemonId) ?? throw new InvalidOperationException();
    }

    public Pokemon CreatePokemon(Pokemon pokemon)
    {
        _context.Pokemon.Add(pokemon);
        _context.SaveChanges();       
        return pokemon;
    }

    public Pokemon UpdatePokemon(Pokemon pokemon)
    {
        _context.Pokemon.Update(pokemon);
        _context.SaveChanges();       
        return pokemon;
    }

    public void DeletePokemonById(int pokemonId)
    {
        _context.Pokemon.Remove(GetPokemon(pokemonId));
        _context.SaveChanges();
    }
}