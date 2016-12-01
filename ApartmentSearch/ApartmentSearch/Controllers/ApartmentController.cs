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
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ApartmentController));  //Declaring Log4Net  


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
            logger.Info("url visited by user:/apartment/Index");  //Adding url details into logger.

            IEnumerable<IGrouping<string, Apartment>> apartments = service.GroupApartments();    //Retrieving list of all the apartments calling service method.
            return View(apartments);
        }


        public ActionResult Search()
        {
            logger.Info("url visited by user:/apartment/search");  //Adding url details into logger.
            return View("Search");
        }

        [HttpPost]
        public ActionResult Search(Apartment apartment)
        {
            logger.Info("url visited by user:/apartment/search");  //Adding url details into logger.

            ViewData["Address"] = apartment.Address;
            ViewData["Suburb"] = apartment.Suburb;

            List<Apartment> apartments = service.GetApartmentsByParameters(apartment);    //Retrieving list of apartments by parameters passed.

            return View(apartments);
        }

        public ActionResult ResetFields()
        {
            return RedirectToAction("Search");
        }
    }


}
