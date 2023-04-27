using Entities;
using ServiceContract.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContract.DTO
{

    /// <summary>
    /// Person domain for inserting Person Details 
    /// </summary>
    public class PersonAddRequest
    {
        [Required(ErrorMessage = "PersonName  can not be blank")]
        public string? PersonName { get; set; }
        [Required(ErrorMessage = "Email  can not be blank")]
        [EmailAddress(ErrorMessage ="Email value should be a valid email")]
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public GenderOptions? Gender { get; set; }
        public Guid? CountryID { get; set; }
        public String? Address { get; set; }
        public bool ReceiveNewsLetters { get; set; }

        /// <summary>
        /// Converts the current objects of PersonAddRequest into a new object of Person Type
        /// </summary>
        /// <returns></returns>
        public Person ToPerson()
        {
            return new Person()
            {
                PersonName = PersonName,
                Email = Email,
                DateOfBirth = DateOfBirth,
                Gender = Gender.ToString(),
                CountryID = CountryID,
                Address = Address,
                ReceiveNewsLetters = ReceiveNewsLetters
            };
        }
    }
}
