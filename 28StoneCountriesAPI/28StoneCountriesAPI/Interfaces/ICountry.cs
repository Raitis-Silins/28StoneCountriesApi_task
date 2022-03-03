using _28StoneCountriesAPI.Models;
using Refit;

namespace _28StoneCountriesAPI.Interfaces
{
    public interface ICountry
    {
        [Get("/v2/name/{name}")]
        Task<List<Country>> GetCountryByItsName(string name);

        [Get("/v2/regionalbloc/eu")]
        Task<List<Country>> GetAllCountries();
    }
}
