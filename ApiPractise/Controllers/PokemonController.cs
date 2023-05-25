using ApiPractise.DTOs;
using ApiPractise.Interfaces;
using ApiPractise.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPractise.Controllers;

[Route("api/[controller]")]
[ApiController]

public class PokemonController : ControllerBase
{
    private readonly IPokemonRepository _pokemon;
    private readonly IMapper _mapper;

    public PokemonController(IPokemonRepository pokemon, IMapper mapper)
    {
        _pokemon = pokemon;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
    public IActionResult GetPokemons()
    {
        var pokemons = _mapper.Map<List<PokemonDTO>>(_pokemon.GetPokemons());
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        return Ok(pokemons);
    }

    [HttpGet("{pokeId}")]
    [ProducesResponseType(200, Type = typeof(Pokemon))]
    [ProducesResponseType(400)]
    public IActionResult GetPokemon(int pokeId)
    {
        if (!_pokemon.PokemonExists(pokeId))
            return NotFound();
        var pokemon = _mapper.Map<PokemonDTO>(_pokemon.GetPokemonByID(pokeId));
        if (!ModelState.IsValid)
            return BadRequest();
        return Ok(pokemon);
    }

    [HttpGet("{pokeId}/rating")]
    [ProducesResponseType(200, Type = typeof(decimal))]
    [ProducesResponseType(400)]
    public IActionResult GetPokemonRating(int pokeId)
    {
        if (!_pokemon.PokemonExists(pokeId))
            return NotFound();
        var rating = _pokemon.GetPokemonRating(pokeId);
        if (!ModelState.IsValid)
            return BadRequest();
        return Ok(rating);



    }
}