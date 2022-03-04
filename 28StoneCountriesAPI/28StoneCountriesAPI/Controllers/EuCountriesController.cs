using _28StoneCountriesAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace _28StoneCountriesAPI.Controllers
{
    [ApiController]
    public class EuCountriesController : ControllerBase
    {
        private readonly ICountryUtility _countryBase;

        public EuCountriesController(ICountryUtility countryBase)
        {
            _countryBase = countryBase;
        }

        [HttpGet]
        [Route("/Country/{name}")]
        public async Task<IActionResult> GetCountry(string name)
        {
            return Ok(await _countryBase.GetCountryByItsName(name));
        }

        [HttpGet]
        [Route("/Country/Population")]
        public async Task<IActionResult> GetCountryPopulationTopTen()
        {
            return Ok(await _countryBase.GetCountryByPopulation());
        }

        [HttpGet]
        [Route("/Country/PopulationByDensity")]
        public async Task<IActionResult> GetCountryPopulationByDensity()
        {
            return Ok(await _countryBase.GetCountryByDensity());
        }

        [HttpGet]
        [Route("/Countries")]
        public async Task<IActionResult> GetAllCountries()
        {
            return Ok(await _countryBase.GetAllCountries());
        }
    }
}
