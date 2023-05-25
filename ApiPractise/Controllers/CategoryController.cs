using System.Collections;
using ApiPractise.DTOs;
using ApiPractise.Interfaces;
using ApiPractise.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiPractise.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository;
    private  readonly IMapper _mapper;

    public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }


    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
    public IActionResult GetCategories()
    {
        var categories = _mapper.Map<List<CategoryDTO>>(_categoryRepository.GetCategories());
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        return Ok(categories);
    }
    [HttpGet("{categoryId}")]
    [ProducesResponseType(200, Type = typeof(Category))]
    [ProducesResponseType(400)]
    public IActionResult GetCategory(int categoryId)
    {
        if (!_categoryRepository.CategoryExists(categoryId))
            return NotFound();
        var category = _mapper.Map<CategoryDTO>(_categoryRepository.GetCategoryById(categoryId));
        if (!ModelState.IsValid)
            return BadRequest();
        return Ok(category);
    }

    [HttpGet("pokemon/{categoryId}")]
    [ProducesResponseType(200, Type = typeof(Category))]
    [ProducesResponseType(400)]
    public IActionResult GetPokemonByCategoryId(int categoryId)
    {
        var pokemon =  _mapper.Map<List<PokemonDTO>>(_categoryRepository.GetPokemonByCategory(categoryId));
        if (!ModelState.IsValid)
            return BadRequest();
        return Ok(pokemon);
        
    }

    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public IActionResult CreateCategory([FromBody] CategoryDTO categoryCreate)
    {
        if (categoryCreate is null)
            return BadRequest(ModelState);
        var category = _categoryRepository.GetCategories().Where(c => c.Name.Trim().ToUpper() == categoryCreate
            .Name.Trim().ToUpper()).FirstOrDefault();
        if (category is not null)
        {
            ModelState.AddModelError("","Category alredy exists!");
            return StatusCode(409, ModelState);
        }

        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var categoryMap = _mapper.Map<Category>(categoryCreate);
        if (!_categoryRepository.CreateCategory(categoryMap))
        {
            ModelState.AddModelError("","Something went wrong while saving!");
            return StatusCode(500, ModelState);
        }
        return Ok("Successful!");
    }

}