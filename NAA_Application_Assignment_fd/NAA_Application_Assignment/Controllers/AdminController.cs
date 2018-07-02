using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NAA.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NAA_Application_Assignment.Models;

namespace NAA_Application_Assignment.Controllers
{
    public class AdminController : Controller
    {

        private NAA.Services.IService.INAAService _profileService;
        private NAA_Application_Assignment.Models.ApplicationDbContext _context;
        public AdminController()
        {
            _profileService = new NAA.Services.Service.NAAService();
            _context = new NAA_Application_Assignment.Models.ApplicationDbContext();

        }

        [HttpGet]
        public ActionResult CreateUserProfile(string UserID)
        {
            ViewBag.UserID = UserID;
            return View();
        }
        [HttpPost]
        public ActionResult CreateUserProfile(NAA_User_Profile newProfile)
        {
            _profileService.CreateUserProfile(newProfile);
            return RedirectToAction("ShowUserProfile", new { UserID = newProfile.UserID, Controller = "Applicant" });
        }

        [HttpGet]
        [Authorize(Roles = "Applicant")]
        public ActionResult EditUserProfile(int ApplicantID)
        {
            return View(_profileService.ShowUserProfileOnApplicantID(ApplicantID));
        }
        [HttpPost]
        public ActionResult EditUserProfile(int ApplicantID, NAA_User_Profile editProfile)
        {
            _profileService.EditUserProfile(editProfile);
            return RedirectToAction("ShowUserProfile", new { ApplicantID = editProfile.ApplicantID, Controller = "Applicant" });
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateRole(FormCollection collection)
        {
            try
            {
                _context.Roles.Add(
                    new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
                    { Name = collection["RoleName"] });
                _context.SaveChanges();
                return RedirectToAction("GetRoles");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult GetRoles()
        {
            return View(_context.Roles.ToList());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ManageUserRoles()
        {
            var roleList = _context.Roles.OrderBy(r => r.Name).ToList().Select(rr =>
                new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = roleList;
            var userList = _context.Users.OrderBy(u => u.UserName).ToList().Select(uu =>
                new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();
            ViewBag.Users = userList;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult ManageUserRoles(string UserName, string RoleName)
        {
            ApplicationUser user =
                _context.Users.Where
                (u => u.UserName.Equals(UserName,
                    StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var um = new Microsoft.AspNet.Identity.UserManager<ApplicationUser>
                (new
                Microsoft.AspNet.Identity.EntityFramework.UserStore<ApplicationUser>(_context));
            var idResult = um.AddToRole(user.Id, RoleName);
            var roleList = _context.Roles.OrderBy
                (r => r.Name).ToList().Select
                (rr => new SelectListItem
                {
                    Value = rr.Name.ToString(),
                    Text =
                rr.Name
                }).ToList();
            ViewBag.Roles = roleList;
            var userList = _context.Users.OrderBy
                (u => u.UserName).ToList().Select
                (uu => new SelectListItem
                {
                    Value = uu.UserName.ToString(),
                    Text =
                uu.UserName
                }).ToList();
            ViewBag.Users = userList;
            return View("ManageUserRoles");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult GetRolesforUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult GetRolesforUser(string UserName)
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                ApplicationUser user =
                    _context.Users.Where(u => u.UserName.Equals
                    (UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                var um = new Microsoft.AspNet.Identity.UserManager<ApplicationUser>
                    (new Microsoft.AspNet.Identity.EntityFramework.UserStore<ApplicationUser>(_context));
                ViewBag.RolesForThisUser = um.GetRoles(user.Id);
            }
            return View("GetRolesforUserConfirmed");
        }

        [Authorize(Roles = "Admin,Staff")]
        public ActionResult ManageUniversities()
        {
            return View(_profileService.GetUniversityList());
        }
        [Authorize(Roles = "Admin,Staff")]
        public ActionResult CreateUniversity()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin,Staff")]
        public ActionResult CreateUniversity(NAA_University newUniversity)
        {
            _profileService.CreateUniversity(newUniversity);
            return RedirectToAction("ManageUniversities");
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Staff")]
        public ActionResult EditUniversity(int UniversityID)
        {
            return View(_profileService.GetUniversity(UniversityID));
        }
        [HttpPost]
        [Authorize(Roles = "Admin,Staff")]
        public ActionResult EditUniversity(NAA_University editUniversity, int UniversityID)
        {
            _profileService.EditUniversity(editUniversity, UniversityID);
            return RedirectToAction("ManageUniversities");
        }

        [Authorize(Roles = "Admin,Staff")]
        public ActionResult DeleteUniversity(int UniversityID)
        {
            NAA_University university = new NAA_University();
            university = _profileService.GetUniversity(UniversityID);
            return View(university);
        }
        [HttpPost]
        [Authorize(Roles = "Admin,Staff")]
        public ActionResult DeleteUniversity(NAA_University deleteUniversity)
        {
            NAA_University university;
            university = _profileService.GetUniversity(deleteUniversity.UniversityID);
            _profileService.DeleteUniversity(university);
            return RedirectToAction("ManageUniversities");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AdminHomePage()
        {
            return View();
        }


    // GET: Admin
    public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
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

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
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

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
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
