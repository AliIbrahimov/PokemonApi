using ApiPractise.Models;

namespace ApiPractise.Interfaces;

public interface ICountryRepository
{
    ICollection<Country> GetCountries();
    Country GetCountry(int id);
    Country GetCountryByOwner(int ownerId);
    ICollection<Owner> GetOwnersFormCountry(int countryId);
    bool CountryExists(int countryId);
}