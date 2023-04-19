using ServiceContract.DTO;

namespace ServiceContract
{
    /// <summary>
    /// represent business logic for manipulating country entity
    /// </summary>
    public interface ICountryService
    {
        /// <summary>
        /// add country object to list of countries
        /// </summary>
        /// <param name="countryAddRequest">country object to add</param>
        /// <returns>return the country object after addin (including newly generated country id)</returns>
        CountryResponse addCountry(CountryAddRequest? countryAddRequest);

        /// <summary>
        /// Returns all countries
        /// </summary>
        /// <returns></returns>

        List<CountryResponse> GetAllCountries();

        /// <summary>
        /// returns the county obj based on the given countryId
        /// </summary>
        /// <param name="countryID"></param>
        /// <returns>Return the matching country object</returns>
        CountryResponse? GetCountryByCountryID(Guid? countryID);
       

    }
}