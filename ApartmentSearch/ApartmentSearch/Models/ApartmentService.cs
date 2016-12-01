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
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ApartmentService));  //Declaring Log4Net 

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
                logger.Info("Fetching list of all apartments from database.");
                List<Apartment> apartments = apartmentDB.Apartments.ToList();
                return apartments;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());    //Logging the exception into logger file.
                throw ex;
            }
        }

        /// <summary>
        /// Fetches a groupped list of apartments according to suburb
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IGrouping<string, Apartment>> GroupApartments()
        {
            try
            {
                List<Apartment> apartments = GetAllApartments();
                logger.Info("Grouping apartments according to Suburbs.");
                IEnumerable<IGrouping<string, Apartment>> groups = apartments.GroupBy(x => x.Suburb);   //create grouppings according to Suburb as the key.
                return groups;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());    //Logging the exception into logger file.
                throw ex;
            }
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
                logger.Info("Seraching apartments according to parameters entered by the user.");

                var apartments = (from apartment in apartmentDB.Apartments
                                  where apartment.City == city || apartment.Address == address ||
                                  apartment.Suburb == suburb || apartment.Rooms == rooms ||
                                   apartment.Bathrooms == bathrooms || apartment.Carports == carports
                                  select apartment).ToList();
                return apartments;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());    //Logging the exception into logger file.
                throw ex;
            }
        }
        #endregion Public Methods
    }
}