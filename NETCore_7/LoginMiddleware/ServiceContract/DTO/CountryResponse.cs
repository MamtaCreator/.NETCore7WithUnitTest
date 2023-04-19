using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContract.DTO
{

    /// <summary>
    /// DTO method that is used as a return type for most of the countryservices methods 
    /// </summary>
    public class CountryResponse
    {
        public Guid CountryId { get; set; }
        public string? CountryName { get; set; }

        // it compares the current object to another obj of
        // countryresponse type and return true , if both values are same;
        // otherwise returns false
        public override bool Equals(object? obj)
        {
            if(obj == null)
            {
                return false;
            }
            if(obj.GetType()!=typeof(CountryResponse))
            {
                return false;
            }

            CountryResponse countryToCompare = (CountryResponse)obj;

            return CountryId == countryToCompare.CountryId && 
                CountryName == countryToCompare.CountryName;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    public static class CountryExtension
    {
        public static CountryResponse ToCountryResponse(this Country country)
        {
            return new CountryResponse 
            {
              CountryId= country.CountryId,
              CountryName= country.CountryName,
            };
        }
    }
}
