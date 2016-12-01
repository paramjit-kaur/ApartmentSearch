using System.Collections.Generic;
using System.Linq;

namespace ApartmentSearch.Models
{
    public interface IApartmentService
    {
        /// <summary>
        /// Retrieve list of all the apartments in the database.
        /// </summary>
        /// <returns></returns>
        List<Apartment> GetAllApartments();

        /// <summary>
        /// Search for apartments based on different input parameters.
        /// </summary>
        /// <param name="city"></param>
        /// <param name="address"></param>
        /// <param name="suburb"></param>
        /// <param name="rooms"></param>
        /// <param name="bathrooms"></param>
        /// <param name="carports"></param>
        /// <returns>List of apartments.</returns>
        List<Apartment> GetApartmentsByParameters(Apartment searchApartment);

        ///<summary>
        /// Fetches a groupped list of apartments according to suburb
        /// </summary>
        /// <returns></returns>
        IEnumerable<IGrouping<string, Apartment>> GroupApartments();
    }
}