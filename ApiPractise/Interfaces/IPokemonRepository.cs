using ApiPractise.Models;

namespace ApiPractise.Interfaces;

public interface IPokemonRepository
{
    ICollection<Pokemon> GetPokemons();
    Pokemon GetPokemonByID(int id);
    Pokemon GetPokemonByName(string name);
    decimal GetPokemonRating(int pokemonId);
    bool PokemonExists(int pokemonId);
}