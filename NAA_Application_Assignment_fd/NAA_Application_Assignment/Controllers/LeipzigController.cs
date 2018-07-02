using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAA_Application_Assignment.Controllers
{
    public class LeipzigController : Controller
    {
        private Leipzig.Services.IService.ILeipzigService _proxy;
            
        public LeipzigController()
        {
            _proxy = new Leipzig.Services.Service.LeipzigService();
        }


        public ActionResult GetSHUCourses(int UniversityID, int ApplicantID)
        {
            ViewBag.UniversityID = UniversityID;
            ViewBag.ApplicantID = ApplicantID;
            return View(_proxy.GetSHUCourses());
        }

        public ActionResult GetShefUniCourses(int UniversityID, int ApplicantID)
        {
            ViewBag.UniversityID = UniversityID;
            ViewBag.ApplicantID = ApplicantID;
            return View(_proxy.GetShefUniCourses());
        }
        // GET: Leipzig
        public ActionResult Index()
        {
            return View();
        }
    }
}