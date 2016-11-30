using ApartmentSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApartmentSearch.Controllers
{
    public class ApartmentController : Controller
    {

        private IApartmentService service;

        public ApartmentController()
        {
        }

        public ApartmentController(IApartmentService apartmentService)
        {
            this.service = apartmentService;

            if (service == null)
                throw new ArgumentNullException("ApartmentService");
        }

        public ActionResult Index()
        {
            IEnumerable<IGrouping<string, Apartment>> apartments = service.GroupApartments();    //Retrieving list of all the apartments calling service method.
            return View(apartments);
        }

        public ActionResult Search(string city, string address, string suburb, int rooms, decimal bathrooms, int carports)
        {
            List<Apartment> apartments = service.GetApartmentsByParameters(city, address, suburb, rooms, bathrooms, carports);    //Retrieving list of all the apartments calling service method.
            return View(apartments);
        }
    }


}
