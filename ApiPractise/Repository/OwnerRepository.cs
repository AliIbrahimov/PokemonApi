using ApiPractise.DataAccess;
using ApiPractise.Interfaces;
using ApiPractise.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPractise.Repository;

public class OwnerRepository:IOwnerRepository
{
    private readonly AppDbContext _context;

    public OwnerRepository(AppDbContext context)
    {
        _context = context;
    }

    public ICollection<Owner> GetOwners()
    {
        return _context.Owners.ToList();
    }

    public Owner GetOwner(int id)
    {
        return _context.Owners.Where(o => o.Id == id).FirstOrDefault();
    }

    public ICollection<Owner> GetOwnerOfAPokemon(int pokeId)
    {
        return _context.Owners.Where(o=>o.Pokemons.FirstOrDefault().Id==pokeId).Include(o=>o.Pokemons).ToList();
    }

    public ICollection<Pokemon> GetPokemonByOwner(int ownerId)
    {
        return _context.Pokemons.Where(o => o.Owners.FirstOrDefault().Id == ownerId).Include(o => o.Owners).ToList();
    }

    public bool OwnerExists(int ownerId)
    {
        return  _context.Owners.Any(o => o.Id == ownerId);
    }
}