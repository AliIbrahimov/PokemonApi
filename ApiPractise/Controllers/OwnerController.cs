using ApiPractise.DTOs;
using ApiPractise.Interfaces;
using ApiPractise.Models;
using ApiPractise.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiPractise.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OwnerController : ControllerBase
{
    private readonly IOwnerRepository _ownerRepository;
    private readonly IMapper _mapper;

    public OwnerController(IOwnerRepository ownerRepository, IMapper mapper)
    {
        _ownerRepository = ownerRepository;
        _mapper = mapper;
    }
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
    public IActionResult GetOwners()
    {
        var owners = _mapper.Map<List<OwnerDTO>>(_ownerRepository.GetOwners());
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        return Ok(owners);
    }
    [HttpGet("{ownerId}")]
    [ProducesResponseType(200, Type = typeof(Owner))]
    [ProducesResponseType(400)]
    public IActionResult GetOwner(int ownerId)
    {
        if (!_ownerRepository.OwnerExists(ownerId))
            return NotFound();
        var owner = _mapper.Map<OwnerDTO>(_ownerRepository.GetOwner(ownerId));
        if (!ModelState.IsValid)
            return BadRequest();
        return Ok(owner);
    }

    [HttpGet("{ownerId}/pokemon")]
    [ProducesResponseType(200, Type = typeof(Owner))]
    [ProducesResponseType(400)]
    public IActionResult GetPokemonByOwner(int ownerId)
    {
        if (!_ownerRepository.OwnerExists(ownerId))
            return NotFound();
        var pokemon = _mapper.Map<List<PokemonDTO>>(_ownerRepository.GetPokemonByOwner(ownerId));
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        return Ok(pokemon);
    }
}