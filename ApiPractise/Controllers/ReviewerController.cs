﻿using ApiPractise.DTOs;
using ApiPractise.Interfaces;
using ApiPractise.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiPractise.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReviewerController : ControllerBase
{
    private readonly IReviewerRepository _reviewerRepository;
    private readonly IMapper _mapper;

    public ReviewerController(IReviewerRepository reviewerRepository, IMapper mapper)
    {
        _reviewerRepository = reviewerRepository;
        _mapper = mapper;
    }
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Reviewer>))]
    public IActionResult GetReviewers()
    {
        var reviewers = _mapper.Map<List<ReviewerDTO>>(_reviewerRepository.GetReviewers());
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        return Ok(reviewers);
    }
    [HttpGet("{reviewerId}")]
    [ProducesResponseType(200, Type = typeof(Reviewer))]
    [ProducesResponseType(400)]
    public IActionResult GetPokemon(int reviewerId)
    {
        if (!_reviewerRepository.ReviewerExists(reviewerId))
            return NotFound();
        var reviewer = _mapper.Map<PokemonDTO>(_reviewerRepository.GetReviewer(reviewerId));
        if (!ModelState.IsValid)
            return BadRequest();
        return Ok(reviewer);
    }
    [HttpGet("{reviewerId}/reviews")]
    [ProducesResponseType(200, Type = typeof(Reviewer))]
    [ProducesResponseType(400)]
    public IActionResult GetReviewsByAReviewer(int reviewerId)
    {
        if (!_reviewerRepository.ReviewerExists(reviewerId))
            return NotFound();
        var reviews = _mapper.Map<ReviewDTO>(_reviewerRepository.GetReviewsByReviewer(reviewerId));
        if (!ModelState.IsValid)
            return BadRequest();
        return Ok(reviews);



    }
}