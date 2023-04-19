using Entities;
using ServiceContract;
using ServiceContract.DTO;

namespace Services
{
    public class CountryService : ICountryService
    {
        //private field
        private readonly List<Country> _countries;
        public CountryService()
        {
            _countries= new List<Country>();
        }
        public CountryResponse addCountry(CountryAddRequest? countryAddRequest)
        {
            //countryAddRequest cant be null
            if (countryAddRequest==null)
            {
                throw new ArgumentNullException(nameof(countryAddRequest));
            }
            //CountryName cant be null
            if (countryAddRequest.CountryName == null)
            {
                throw new ArgumentException(nameof(countryAddRequest.CountryName));
            }

            //countryName cant be duplicate
            if(_countries.Where(temp => temp.CountryName ==countryAddRequest.CountryName).Count() > 0) 
            {
                throw new ArgumentException("Country name already exist!");
            }

            // convert obj from countryaddrequest to country
            Country country =  countryAddRequest.ToCountry();

            //generate counrtyID
            country.CountryId = Guid.NewGuid();

            // add country obj in country list
           _countries.Add(country);

            return country.ToCountryResponse();
        }

        public List<CountryResponse> GetAllCountries()
        {
           return _countries.Select(country => country.ToCountryResponse()).ToList();

        }

        public CountryResponse? GetCountryByCountryID(Guid? countryID)
        {
            if(countryID==null) { return null; }
            Country? countryResponseFromList = _countries.FirstOrDefault(temp =>temp.CountryId == countryID);

            if(countryResponseFromList==null) { return null; }
            return countryResponseFromList.ToCountryResponse();
        }
    }
}