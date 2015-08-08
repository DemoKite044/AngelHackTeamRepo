using Hackathon2015.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAO;
using CPS;

namespace Hackathon2015.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(string name, string message)
        {
            return View();
        }

        public ActionResult Search(string keyword)
        {
            var locations = new List<Location>();
            Business businessManager = new Business();

            var searchResults = businessManager.Search(keyword);
            foreach (KeyValuePair<string, CPS_SimpleXML> pair in searchResults)
            {
                //var test = pair.Value["Location"]["Address"].GetChild("Floor");
                locations.Add(new Location
                {
                    Name = pair.Value.GetChild("Name"),
                    Floor = pair.Value.GetChild("Floor"),
                    Building = pair.Value.GetChild("Building"),
                    City = pair.Value.GetChild("Town"),
                    Province = pair.Value.GetChild("Province")
                });                
            }

            return Json(locations, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Add(Location location)
        {
            Business businessMgr = new Business();
            businessMgr.InsertXML(location.Name, location.Floor, location.Building, location.Street, location.Barangay, location.City, location.Province);

            return View();
        }

        
    }
}
