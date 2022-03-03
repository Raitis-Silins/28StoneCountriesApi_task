using _28StoneCountriesAPI.Models;

namespace _28StoneCountriesAPI.Interfaces
{
    public interface ICountryUtility
    {
        Task<List<Country>> GetCountryByPopulation();
        Task<List<Country>> GetCountryByDensity();
        Task<List<Country>> GetAllCountries();
        Task<CountrySpecifyModel> GetCountryByItsName(string name);
    }
}
