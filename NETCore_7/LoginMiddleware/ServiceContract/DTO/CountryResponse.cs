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
