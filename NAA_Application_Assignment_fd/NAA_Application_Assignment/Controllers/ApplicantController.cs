using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAA_Application_Assignment.Controllers
{
    public class ApplicantController : Controller
    {
        private NAA.Services.IService.INAAService _NAAService;
        public ApplicantController()
        {
            _NAAService = new NAA.Services.Service.NAAService();
        }

        // GET: Applicant
        public ActionResult ShowUserProfile(string UserID)
        {
            if (_NAAService.GetUserProfile(UserID) != null)
            {
                return View(_NAAService.GetUserProfile(UserID));
            } else
            {
                return RedirectToAction("CreateUserProfile", new { UserID = UserID, Controller = "Admin" });
            }

        }

        public ActionResult ShowUserProfileOnApplicantID(int ApplicantID)
        {
            return View(_NAAService.ShowUserProfileOnApplicantID(ApplicantID));

        }

        // GET: Applicant/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Applicant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Applicant/Create
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

        // GET: Applicant/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Applicant/Edit/5
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

        // GET: Applicant/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Applicant/Delete/5
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
