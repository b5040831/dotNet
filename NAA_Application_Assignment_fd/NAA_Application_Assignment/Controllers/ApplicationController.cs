using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NAA.Data;
using NAA.Data.BEANS;

namespace NAA_Application_Assignment.Controllers
{
    public class ApplicationController : Controller
    {
        private NAA.Services.IService.INAAService _NAAService;
        // GET: Application
        public ApplicationController()
        {
            _NAAService = new NAA.Services.Service.NAAService();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetUniversityList(int ApplicantID)
        {
            ViewBag.ApplicantID = ApplicantID;
            return View(_NAAService.GetUniversityList());
        }
        public ActionResult GetStudentApplications(int ApplicantID)
        {
            ViewBag.ApplicantID = ApplicantID;
            return View(_NAAService.GetStudentApplications(ApplicantID));
        }

        public ActionResult GetStudentApplication(int ApplicationID)
        {
            return View(_NAAService.GetStudentApplication(ApplicationID));
        }

        public ActionResult UniversityLogic(int UniversityID, int ApplicantID)
        {
            //ViewBag.ApplicantID = ApplicantID;
            //ViewBag.UniversityID = UniversityID;
            if (UniversityID == 1)
            {
                 return RedirectToAction("GetSHUCourses", new { UniversityID = UniversityID, ApplicantID = ApplicantID,  Controller = "Leipzig" });
            }
            else 
            {
                return RedirectToAction("GetShefUniCourses", new { UniversityID = UniversityID, ApplicantID = ApplicantID, Controller = "Leipzig" });
            }
        }

        public ActionResult CreateCourseApplication(string CourseName, int UniversityID, int ApplicantID)
        {

            return View();
        }
        [HttpPost]
        public ActionResult CreateCourseApplication(NAA_Application newApplication, string CourseName, int UniversityID, int ApplicantID)
        {
            int maxApplications = 5;
            int currentApplications = _NAAService.GetStudentApplications(ApplicantID).Count;
            if (currentApplications <= maxApplications)
            {
                _NAAService.CreateCourseApplication(newApplication, UniversityID, ApplicantID, CourseName);
                return RedirectToAction("ShowUserProfile", new { ApplicantID = newApplication.ApplicantID, Controller = "Applicant" });
            }
            else
            {
                return RedirectToAction("CreateApplicationErrorMessage");
            }

        }

        public ActionResult CreateApplicationErrorMessage()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EditUserFirmDecision(int ApplicationID, int ApplicantID)
        {
            ViewBag.ApplicantID = ApplicantID;
            return View(_NAAService.GetStudentApplication(ApplicationID));
        }

        [HttpPost]
        public ActionResult EditUserFirmDecision(int ApplicantID, int ApplicationID, bool Firm)
        {
            bool canGoFirm = true;
            NAA_Application Application = _NAAService.GetStudentApplication(ApplicationID);
            IList<ApplicationBEAN> Applications = _NAAService.GetStudentApplications(ApplicantID); 

            foreach (var wentFirm in Applications)
            {
                do
                {
                    if (wentFirm.Firm == true)
                    {
                        canGoFirm = false;
                    }
                }
                while (wentFirm.Firm == false);
            }
            if (canGoFirm)
            {
                if (Application.UniversityOffer == null)
                {
                    return RedirectToAction("GoFirmErrorMessage");
                }
                else
                {
                    if (Application.UniversityOffer == "U" || Application.UniversityOffer == "C")
                    {
                        _NAAService.EditUserFirmDecision(ApplicationID, Firm);
                        return RedirectToAction("GetStudentApplications", new { ApplicantID = ApplicantID });
                    }
                    else
                    {
                        return RedirectToAction("GoFirmErrorMessage");
                    }
                }

            } else
            {
                return RedirectToAction("GoFirmErrorMessage");
            }

        }
            

        public ActionResult GoFirmErrorMessage()
        {
            return View();
        }

        public ActionResult DeleteErrorMessage()
        {
            return View();
        }

        public ActionResult DeleteApplication(int ApplicationID, int ApplicantID)
        {
            ViewBag.ApplicantID = ApplicantID;
            NAA_Application application = new NAA_Application();
            application = _NAAService.GetStudentApplication(ApplicationID);
            return View(application);
        }
        [HttpPost]
        public ActionResult DeleteApplication(NAA_Application deleteApplication, int ApplicationID, int ApplicantID)
        {

            NAA_Application application;
            application = _NAAService.GetStudentApplication(deleteApplication.ApplicationID);

            if (application.UniversityOffer == "R" || application.UniversityOffer == "U" || application.UniversityOffer == "C")
            {
                return RedirectToAction("DeleteErrorMessage", new { ApplicantID = ApplicantID });
            }
            else
            {
                if (application.Firm == true)
                {
                    return RedirectToAction("DeleteErrorMessage", new { ApplicantID = ApplicantID });
                }
                else
                {
                    _NAAService.DeleteApplication(application);
                    return RedirectToAction("GetStudentApplications", new { ApplicantID = ApplicantID });
                }
           
            }
        }

        [HttpGet]
        public ActionResult EditApplication(int ApplicationID)
        {
            return View(_NAAService.GetStudentApplication(ApplicationID));
        }
        [HttpPost]
        public ActionResult EditApplication(NAA_Application editApplication)
        {
            ViewBag.ApplicantID = editApplication.ApplicantID; 
            _NAAService.EditApplication(editApplication);
            return RedirectToAction("GetStudentApplications", new { ApplicantID = ViewBag.ApplicantID });
        }

        // GET: Application/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Application/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Application/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Application/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Application/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Application/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Application/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
