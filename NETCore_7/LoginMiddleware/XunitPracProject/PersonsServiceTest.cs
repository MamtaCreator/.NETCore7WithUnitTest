using ServiceContract;
using ServiceContract.DTO;
using ServiceContract.Enums;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XunitPracProject
{
    public class PersonsServiceTest
    {
        private readonly IPersonService _personService;
        private readonly ICountryService _countryService;

        public PersonsServiceTest()
        {
            _personService = new PersonService();
            _countryService = new CountryService();
        }

        #region AddPerson
        // when we supply null value as PersonAddRequest
        // it should throw ArgumentNullException

        [Fact]
        public void AddPerson_NullPerson()
        {
            //Arrange
            PersonAddRequest? personAddRequest = null;

            //Act
            Assert.Throws<ArgumentNullException>(() =>
            {
                _personService.AddPerson(personAddRequest);

            });
        }
        // when we supply null value as PersonName
        // it should throw ArgumentException

        [Fact]
        public void AddPerson_PersonNameIsNull()
        {
            //Arrange
            PersonAddRequest? personAddRequest = new PersonAddRequest() { PersonName = null };

            //Act
            Assert.Throws<ArgumentException>(() =>
            {
                _personService.AddPerson(personAddRequest);

            });
        }

        // when we supply Correct value as PersonAddRequest
        // it should insert  person into person list and It should return PersonResponse which includes newly generated personId

        [Fact]
        public void AddPerson_CorrectPersonDetails()
        {
            //Arrange
            PersonAddRequest? personAddRequest = new PersonAddRequest()
            { PersonName = "Mamta",
              Address = "Bhayander",
              Email = "mamta@gmail.com",
              CountryID = new Guid(),
              Gender = ServiceContract.Enums.GenderOptions.Female,
              DateOfBirth = DateTime.Parse("2000-01-09"),
              ReceiveNewsLetters = true,

            };
            //Act
            PersonResponse personResponseFromAdd =
            _personService.AddPerson(personAddRequest);

            List<PersonResponse> personResponsesFromGetAllperson =
            _personService.GetAllPersonList();

            //Assert
            Assert.True(personResponseFromAdd.PersonId !=Guid.Empty);
            
            Assert.Contains(personResponseFromAdd, personResponsesFromGetAllperson);

        }




        #endregion
        #region GetPersonByPersonId

        //if we supply null as personId it should return null values as personResponse.
        [Fact]
        public void GetPersonByPesonId_NullPersonId()
        {
            //arrange
            Guid? personId = null;

            //act
           PersonResponse? personResponseFromGet =  _personService.GetPersonByPersonId(personId);

            //assert
            Assert.Null(personId);



        }

        [Fact]
        public void GetPersonByPersonId_WithValidPersonId()
        {
            //arrange
            CountryAddRequest countryAddRequest = new CountryAddRequest()
            {
                CountryName = "India"
            };
            CountryResponse countryResponse = _countryService.addCountry(countryAddRequest);
            PersonAddRequest personAddRequest = new PersonAddRequest()
            {
                PersonName = "Mamta",
                Address = "Bhayander",
                Email = "mamta@gmail.com",
                CountryID = countryResponse.CountryId,
                Gender = (GenderOptions.Female),
                DateOfBirth = DateTime.Parse("2000-01-09"),
                ReceiveNewsLetters = false,

            };
            PersonResponse personResponseFromAdd = _personService.AddPerson(personAddRequest);
            PersonResponse? personResponseFromGet = _personService.GetPersonByPersonId(personResponseFromAdd.PersonId);

            //Assert
            Assert.Equal(personResponseFromAdd, personResponseFromGet);
        }

        #endregion


            #region ListAllPerson


            #endregion

    }
}
