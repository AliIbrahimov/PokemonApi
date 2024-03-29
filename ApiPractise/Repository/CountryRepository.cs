﻿using ApiPractise.DataAccess;
using ApiPractise.Interfaces;
using ApiPractise.Models;
using AutoMapper;

namespace ApiPractise.Repository;

public class CountryRepository:ICountryRepository
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public CountryRepository(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ICollection<Country> GetCountries()
    {
        return _context.Countries.ToList();
    }

    public Country GetCountry(int id)
    {
        return _context.Countries.Where(c => c.Id == id).FirstOrDefault();
    }

    public Country GetCountryByOwner(int ownerId)
    {
        return _context.Owners.Where(c => c.Id == ownerId).Select(c => c.Country).FirstOrDefault();
    }

    public ICollection<Owner> GetOwnersFormCountry(int countryId)
    {
        return _context.Owners.Where(c => c.Country.Id == countryId).ToList();
    }

    public bool CountryExists(int countryId)
    {
        return _context.Countries.Any(c => c.Id == countryId);
    }
}