using Pokemon_Review_App.Models;

namespace Pokemon_Review_App.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();
        Pokemon GetPokemon(int pokemonId);
        Pokemon CreatePokemon(Pokemon pokemon);
        Pokemon UpdatePokemon(Pokemon pokemon);
        void DeletePokemonById(int pokemonId);
    }
}
