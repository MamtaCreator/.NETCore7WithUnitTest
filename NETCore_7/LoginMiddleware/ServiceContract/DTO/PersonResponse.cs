using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContract.DTO
{
    /// <summary>
    /// Person domain for fetching person's records
    /// </summary>
    public class PersonResponse
    {
        public Guid? PersonId { get; set; }
        public string? PersonName { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public String? Gender { get; set; }
        public Guid? CountryID { get; set; }
        public String? Country { get; set; }
        public String? Address { get; set; }
        public Double? Age { get; set; }
        public bool ReceiveNewsLetters { get; set; }

        /// <summary>
        /// compares the current object data with parameter object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>true or fals indication if all data of person is matched with parameter specified object</returns>
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != typeof(PersonResponse)) return false;
            PersonResponse person = (PersonResponse)obj;
            return PersonId == person.PersonId
                && PersonName == person.PersonName
                && Email == person.Email
                && DateOfBirth == person.DateOfBirth
                && Gender == person.Gender
                && CountryID == person.CountryID
                && Address == person.Address
                && ReceiveNewsLetters == person.ReceiveNewsLetters;

        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

        public static class PersonExtension
        {
            /// <summary>
            /// an extension method that converts an object of person class into  PersonResponse obj
            /// </summary>
            /// <param name="person">  </param>
            /// <returns>Converts the converted PersonResponse Object</returns>
            public static PersonResponse ToPersonResponse(this Person person)
            {
                return new PersonResponse() {PersonId = person.PersonId
                    , PersonName = person.PersonName
                    , Email = person.Email
                    , DateOfBirth= person.DateOfBirth
                    , Gender = person.Gender
                    , ReceiveNewsLetters= person.ReceiveNewsLetters
                    ,CountryID= person.CountryID
                    ,Address= person.Address
                    ,Age = (person.DateOfBirth != null)? ((DateTime.Now - person.DateOfBirth.Value).TotalDays/365.25): null
                
                };
            }
        }
        
    
}
