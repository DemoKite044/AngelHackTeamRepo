using Hackathon2015.Models;
using PeepPlace.Common.Entities;
using PeepPlace.Core;
using PeepPlace.Core.Businesses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PeepPlace.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
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
            Business businessManager = new Business();

            return Json(businessManager.Search(keyword), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Add(Location location)
        {
            Business businessMgr = new Business();
            businessMgr.InsertXML(location.Name, location.Floor, location.Building, location.Street, location.Barangay, location.City, location.Province);

            return View();
        }

        
    }
}
