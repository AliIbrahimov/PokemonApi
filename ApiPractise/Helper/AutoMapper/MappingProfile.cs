using ApiPractise.DTOs;
using ApiPractise.Models;
using AutoMapper;

namespace ApiPractise.Helper.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Pokemon, PokemonDTO>();
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<Country, CountryDTO>();
        CreateMap<Owner, OwnerDTO>();
        CreateMap<Review, ReviewDTO>();
        CreateMap<Reviewer, ReviewerDTO>();
    }
}