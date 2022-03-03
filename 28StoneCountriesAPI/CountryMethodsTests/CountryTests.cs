using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _28StoneCountriesAPI.Interfaces;
using _28StoneCountriesAPI.Methods;
using _28StoneCountriesAPI.Models;
using Moq;
using Moq.AutoMock;
using Newtonsoft.Json;
using Xunit;

namespace CountryMethodsTests;

public class CountryTests
{
    public List<Country> SampleCountry = new()
    {
        new Country
        {
            Name = "Germany",
            TopLevelDomain = new List<string> {".de"},
            Population = 83240525,
            Area = 357114,
            NativeName = "Deutschland",
            Independent = true
        },

        new Country
        {
            Name = "Latvia",
            TopLevelDomain = new List<string> {".lv"},
            Population = 1901548,
            Area = 64559,
            NativeName = "Latvija",
            Independent = true
        }
    };

    public CountrySpecifyModel SampleCountryWithoutName = new()
    {
        TopLevelDomain = new List<string> {".de"},
        Population = 83240525,
        Area = 357114,
        NativeName = "Deutschland"
    };


    [Fact]
    public async void GetCountryByDensity_InputData_ShouldReturnCountriesByDensity()
    {
        //Arrange
        var mock = new AutoMocker();

        mock.GetMock<ICountry>().Setup(x => x.GetAllCountries()).ReturnsAsync(SampleCountry);

        var expected = SampleCountry.OrderByDescending(x => x.Population / x.Area).ToList();

        ICountryUtility countrySelect = new CountryMethods (mock.GetMock<ICountry>().Object);

        //Act
        var result = await countrySelect.GetCountryByDensity();

        //Assert
        result.Equals(expected);
    }


    [Fact]
    public async void GetCountryByPopulation_InputData_ShouldReturnCountriesByPopulation()
    {
        //Arrange
        var mock = new AutoMocker();

        mock.GetMock<ICountry>().Setup(x => x.GetAllCountries()).ReturnsAsync(SampleCountry);

        var expected = SampleCountry.OrderByDescending(x => x.Independent).ToList();

        ICountryUtility countrySelect = new CountryMethods (mock.GetMock<ICountry>().Object);

        //Act
        var result = await countrySelect.GetCountryByPopulation();

        //Assert
        result.Equals(expected);
    }

    [Fact]
    public async void GetCountryByItsName_InputData_ShouldReturnCountryWithoutName()
    {
        //Arrange
        var mock = new AutoMocker();

        mock.GetMock<ICountry>().Setup(x => x.GetCountryByItsName("Germany")).ReturnsAsync(SampleCountry);

        ICountryUtility countrySelect = new CountryMethods (mock.GetMock<ICountry>().Object);

        //Act
        var result = await countrySelect.GetCountryByItsName("Germany");
        var expected = JsonConvert.SerializeObject(result);
        var outcome = JsonConvert.SerializeObject(SampleCountryWithoutName);

        //Assert
        Assert.Equal(expected, outcome);
    }

    [Fact]
    public async void GetAllCountries_InputData_ShouldReturnCountries()
    {
        //Arrange
        var mock = new AutoMocker();

        mock.GetMock<ICountry>().Setup(x => x.GetAllCountries()).ReturnsAsync(SampleCountry);

        var expected = SampleCountry.Where(x => x.Independent).ToList();

        ICountryUtility countrySelect = new CountryMethods (mock.GetMock<ICountry>().Object);

        //Act
        var result = await countrySelect.GetAllCountries();

        //Assert
        result.Equals(expected);
    }
}