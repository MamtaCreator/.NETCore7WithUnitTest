using ServiceContract;
using ServiceContract.DTO;
using Services;
using System;
using System.Collections.Generic;


namespace XunitPracProject
{
    public class CountriesServiceTest
    {
        private readonly ICountryService _countriesService;


        //Constructor
        public CountriesServiceTest()
        {
            _countriesService = new CountryService();
        }

        #region AddCountry
        //Requirements :
        // 1 : when CountryAddRequest is null , it should throw argumentnullexception.

        [Fact]
        public void AddCountry_NullCountry()
        {
            //Arrange
            CountryAddRequest? request = null;

            //assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                //act
                _countriesService.addCountry(request);
            });
            
        }
        // 2 : when CountryName is null , it should throw argument exception.[Fact]
        [Fact]    
        public void AddCountry_CountryNameIsNull()
            {
                //Arrange
                CountryAddRequest? request = new CountryAddRequest
                { CountryName = null};

                //assert
                Assert.Throws<ArgumentException>(() =>
                {
                    //act
                    _countriesService.addCountry(request);
                });

            }

        // 3 : when CountryName is duplicate , it should throw argument exception.

        [Fact]
        public void AddCountry_DuplicateCountryName()
        {
            //Arrange
            CountryAddRequest? request1 = new CountryAddRequest { CountryName = "USA"};
            CountryAddRequest? request2 = new CountryAddRequest { CountryName = "USA"};

            //assert
            Assert.Throws<ArgumentException>(() =>
            {
                //act
                _countriesService.addCountry(request1);
                _countriesService.addCountry(request2);
            });

        }
        // 4 : when  you supply correctc country name , it should insert in the country to the existing list of countries.

        [Fact]
        public void AddCountr_ProperCountryDetails()
        {
            //Arrange
            CountryAddRequest? request = new CountryAddRequest { CountryName ="India"};
            //act
           CountryResponse countryResponse = _countriesService.addCountry(request);
            List<CountryResponse> countryResponsesFromGetAllCountries = _countriesService.GetAllCountries();

            //assert
            Assert.True(countryResponse.CountryId!=Guid.Empty);
            Assert.Contains(countryResponse, countryResponsesFromGetAllCountries);
        }

        #endregion


        #region GetAllCountries
        [Fact]
        //The list of countries should be empty by default(Before adding any country)
        public void GetAllCountries_EmptyList()
        {
            //arrange *No arrange required for this
            
            //act
            List<CountryResponse> actual_country_response_list = _countriesService.GetAllCountries();

            //Assert
            Assert.Empty(actual_country_response_list);                   
        }

        [Fact]

        public void GetAllCountries_AddFewCountries()
        {
            //arrange
            List<CountryAddRequest> countryRequestsList = 
                new List<CountryAddRequest>() 
                { 
                  new CountryAddRequest{CountryName = "INDIA"},
                  new CountryAddRequest{CountryName = "USA"},
                  new CountryAddRequest{CountryName = "JAPAN"}
                };
            //act
            List<CountryResponse> countryResponsesfromAddCountry = new List<CountryResponse>();
            foreach (CountryAddRequest countryRequest in countryRequestsList) 
            {
                countryResponsesfromAddCountry.Add(_countriesService.addCountry(countryRequest));
            }
             List<CountryResponse> actualCountryResponseList = _countriesService.GetAllCountries();
             foreach(CountryResponse expectedCountry in countryResponsesfromAddCountry)
             {

                Assert.Contains(expectedCountry, actualCountryResponseList);
             }

        }

        #endregion

        #region GetCountryByCountryId

        // if we supply null countryId it should null countryresponse.
        [Fact]
        public void GetCountryByCountryId_NullCountryId()
        {
            //arrange
            Guid? countryId = null;

            //act
          CountryResponse? countryResponseFromGetMethod =  _countriesService.GetCountryByCountryID(countryId);

             //assert
          Assert.Null(countryResponseFromGetMethod);
            


        }
        [Fact]
        // if we supply a valid countryId , it should return the matching country details as CountryResponse object
        public void GetCountryByCountryId_ValidCountryId()
        {
            //arrange
            CountryAddRequest? countryAddRequest = new CountryAddRequest()
            { CountryName = "China" };
            CountryResponse countryResponseFromAdd = _countriesService.addCountry(countryAddRequest);



            //act
           CountryResponse? countryResponseFromGet = _countriesService.GetCountryByCountryID(countryResponseFromAdd.CountryId);
            //assert
            Assert.Equal(countryResponseFromAdd, countryResponseFromGet);
        }
        
        #endregion

    }
}