using ServiceContract.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContract
{

    public interface IPersonService
    {
        /// <summary>
        /// Add a new person in the existing list of person
        /// </summary>
        /// <param name="personAddRequest"></param>
        /// <returns>Return the same person records with newly generated personId Details</returns>
        PersonResponse AddPerson(PersonAddRequest? personAddRequest);

        /// <summary>
        /// returns all persons
        /// </summary>
        /// <returns> Return a list of object of type PersonResponse type</returns>
        List<PersonResponse> GetAllPersonList();

        /// <summary>
        /// Return Person object based Person ID
        /// </summary>
        /// <param name="PersonId">Person Id to Search</param>
        /// <returns>Matching person object</returns>
        PersonResponse? GetPersonByPersonId(Guid? PersonId);
    }
}
