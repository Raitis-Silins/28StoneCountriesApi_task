# EUCountriesApiApp

Java Spring Boot app

IntelliJ IDEA 2021.2.2 was used for development.

---
![Alt Text](https://github.com/Raitis-Silins/28StoneCountriesApi_task/blob/main/assets/UnZip.gif)


### What it does
Application displays different Tops of countries depending on selected criteria.

### How to run
Clone repository to Your local drive and open cloned folder or "countriesApi.iml" with Java IDE in e.g. IntelliJ IDEA 2021.2.2.<br />
In IDE locate src folder and in src folder find Java file "CountriesApiAplication".<br />
With mouse right click on "CountriesApiAplication" file and select "Run 'CountriesApiAplication.main()'".<br />
<img src = "images/runCountriesApiLong.PNG">

Open web browser. enter following web address: `http://localhost:8080/countries` which will display all European Union countries.<br />
<img src = "images/browserSetupCountries.PNG">

Output could differ from example depending on EU country information in that moment.<br />
<img src = "images/countriesOutput.PNG">

To apply Top 10 filters, in browser change "countries" to "topbyarea" to get top 10 countries comparison by area.<br />
<img src = "images/browserSetupByArea.PNG">

And output should be similar to this:<br />
<img src = "images/byAreaOutput.PNG">
"topbypopulation" will display top 10 countries by population and "topbydensity" will display top 10 countries by population density.<br />

### Tests
Unit test tests if ten countries are added to Top 10 filters as by requirement.<br />
To run Unit Tests, under test folder locate file "CountriesApiApplicationTests" and select "Run 'CountriesApiApplicationTests'"<br />
<img src = "images/runTests.PNG">

### Could be improved
Integration tests could be applied.
