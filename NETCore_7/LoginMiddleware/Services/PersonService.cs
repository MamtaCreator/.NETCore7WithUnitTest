using Entities;
using ServiceContract;
using ServiceContract.DTO;
using Services.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PersonService : IPersonService
    {
        private readonly List<Person> _person;
        private readonly ICountryService _countryService;

        private PersonResponse ConvertPersonToPersonResponse(Person person)
        {
            // convert person to personresponse 
            PersonResponse personResponse = person.ToPersonResponse();
            personResponse.Country = _countryService.GetCountryByCountryID(person.CountryID)?.CountryName;
            return personResponse;
        }
        public PersonService()
        {
            _person = new List<Person>();
            _countryService = new CountryService();
        }

        public PersonResponse AddPerson(PersonAddRequest? personAddRequest)
        {
            if(personAddRequest==null)
            {
                throw new ArgumentNullException(nameof(personAddRequest));
            }
            //Model Validation
            ValidationHelpers.ModelValidation(personAddRequest);


            // convert PersonAddrequest to Person Type
            Person person =  personAddRequest.ToPerson();

            // generate new Person guid
            person.PersonId = new Guid();

            // add object to person list
            _person.Add(person);

            return ConvertPersonToPersonResponse(person);
                       
        }

        public List<PersonResponse> GetAllPersonList()
        {
            throw new NotImplementedException();
        }

        public PersonResponse? GetPersonByPersonId(Guid? PersonId)
        {
            if(PersonId ==null) { return null; }

            Person? person = _person.FirstOrDefault(temp =>temp.PersonId == PersonId);

            if(person ==null) { return null; }

            return person.ToPersonResponse();
        }
    }
}
