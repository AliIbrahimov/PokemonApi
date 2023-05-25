using ApiPractise.DataAccess;
using ApiPractise.Interfaces;
using ApiPractise.Models;

namespace ApiPractise.Repository;

public class PokemonRepository : IPokemonRepository
{
    private readonly AppDbContext _context;

    public PokemonRepository(AppDbContext context)
    {
        _context = context;
    }

    public ICollection<Pokemon> GetPokemons()
    {
        return _context.Pokemons.OrderBy(p => p.Id).ToList();
    }

    public Pokemon GetPokemonByID(int id)
    {
        return _context.Pokemons.Where(p => p.Id == id).FirstOrDefault();
    }

    public Pokemon GetPokemonByName(string name)
    {
        return _context.Pokemons.Where(p => p.Name == name).FirstOrDefault();
    }

    public decimal GetPokemonRating(int pokemonId)
    {
        var review = _context.Reviews.Where(p => p.Pokemon.Id == pokemonId);
        if (review.Count() <= 0)
            return 0;
        return ((decimal)review.Sum(r => r.Rating) / review.Count());

    }

    public bool PokemonExists(int pokemonId)
    {
        return _context.Pokemons.Any(p => p.Id == pokemonId);
    }
}