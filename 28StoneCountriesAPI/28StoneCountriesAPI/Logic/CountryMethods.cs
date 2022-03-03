using _28StoneCountriesAPI.Interfaces;
using _28StoneCountriesAPI.Models;

namespace _28StoneCountriesAPI.Methods
{
    public class CountryMethods : ICountryUtility
    {

        private readonly ICountry _countryBase;


        public CountryMethods(ICountry countryBase)
        {
            _countryBase = countryBase;
        }

        public async Task<List<Country>> GetAllCountries()
        {
            var allCountries = await  _countryBase.GetAllCountries();
            var independentCountry = allCountries.Where(x => x.Independent).ToList();

            return independentCountry;
        }

        public async Task<List<Country>> GetCountryByDensity()
        {
            var countryByPopulationDensity = await _countryBase.GetAllCountries();
            var independentCountry = countryByPopulationDensity.Where(x => x.Independent);
            var countryByDensity = independentCountry.OrderByDescending(x => x.Population / x.Area).Take(10).ToList();

            return countryByDensity;
        }

        public async Task<CountrySpecifyModel> GetCountryByItsName(string name)
        {
            var countryByName = await _countryBase.GetCountryByItsName(name);
            var countryWithoutName = countryByName.Select(x => new CountrySpecifyModel
            {
                TopLevelDomain = x.TopLevelDomain,
                Population = x.Population,
                Area = x.Area,
                NativeName = x.NativeName
            });

            return countryWithoutName.FirstOrDefault();
        }

        public async Task<List<Country>> GetCountryByPopulation()
        {
            var countryByPopulation = await _countryBase.GetAllCountries();
            var independentCountry = countryByPopulation.Where(x => x.Independent).Take(10);
            var countryTopTen =
                independentCountry.OrderByDescending(x => x.Population).ToList();

            return countryTopTen;
        }
    }
}