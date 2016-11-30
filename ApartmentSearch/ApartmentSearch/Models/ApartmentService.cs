using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApartmentSearch.Models
{
    public class ApartmentService : IApartmentService
    {
        #region Fields

        private ApartmentsEntities apartmentDB = new ApartmentsEntities();  //Declaring ApartmentEntities

        #endregion Fields

        #region Public Methods
        /// <summary>
        /// Retrieve list of all the apartments in the database.
        /// </summary>
        /// <returns>List of Apartments.</returns>
        public List<Apartment> GetAllApartments()
        {
            try
            {
                List<Apartment> apartments = apartmentDB.Apartments.ToList();
                return apartments;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Fetches a groupped list of apartments according to suburb
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IGrouping<string, Apartment>> GroupApartments()
        {
            List<Apartment> apartments = GetAllApartments();
            IEnumerable<IGrouping<string, Apartment>> groups = apartments.GroupBy(x => x.Suburb);   //create grouppings according to Suburb as the key.
            return groups;
        }

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
        public List<Apartment> GetApartmentsByParameters(string city, string address, string suburb, int rooms, decimal bathrooms, int carports)
        {
            try
            {
                var apartments = (from apartment in apartmentDB.Apartments
                                  where apartment.City == city || apartment.Address == address ||
                                  apartment.Suburb == suburb || apartment.Rooms == rooms ||
                                   apartment.Bathrooms == bathrooms || apartment.Carports == carports
                                  select apartment).ToList();
                return apartments;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Public Methods
    }
}