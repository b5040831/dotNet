using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Data.IDAO;
using NAA.Data.BEANS;

namespace NAA.Data.DAO
{
    public class NAADAO : INAADAO
    {
        private NAAEntities _context;
        public NAADAO()
        {
            _context = new NAAEntities();
        }
        /*public NAA_User_Profile GetUserProfile(int ApplicantID)
        {
            IQueryable<NAA_User_Profile> _userProfile;
            _userProfile = from profile
                           in _context.NAA_User_Profile
                           where profile.ApplicantID == ApplicantID
                       select profile;
            return _userProfile.ToList<NAA_User_Profile>().First();
        } backup */

        public NAA_User_Profile GetUserProfile(string UserID)
        {
            IQueryable<NAA_User_Profile> _userProfile;
            _userProfile = from profile
                           in _context.NAA_User_Profile
                           where profile.UserID == UserID
                           select profile;
            return _userProfile.ToList<NAA_User_Profile>().FirstOrDefault();
        }
        public NAA_User_Profile ShowUserProfileOnApplicantID(int ApplicantID)
        {
            IQueryable<NAA_User_Profile> _userProfile;
            _userProfile = from profile
                           in _context.NAA_User_Profile
                           where profile.ApplicantID == ApplicantID
                           select profile;
            return _userProfile.ToList<NAA_User_Profile>().FirstOrDefault();
        }

        public void CreateUserProfile(NAA_User_Profile newProfile)
        {
            _context.NAA_User_Profile.Add(newProfile);
            _context.SaveChanges();
        }

        public void EditUserProfile(NAA_User_Profile editProfile)
        {
            NAA_User_Profile currentProfile = GetUserProfile(editProfile.UserID);

            currentProfile.ApplicantName = editProfile.ApplicantName;
            currentProfile.ApplicantAddress = editProfile.ApplicantAddress;
            currentProfile.Phone = editProfile.Phone;
            currentProfile.Email = editProfile.Email;

            _context.SaveChanges();
    
        }

        public void EditUserFirmDecision(int ApplicationID, bool Firm)
        {
            NAA_Application currentApplication = GetStudentApplication(ApplicationID);

            //currentApplication.Firm = editApplication.Firm;
            currentApplication.Firm = Firm;
            _context.SaveChanges();
        }

        public IList<NAA_University> GetUniversityList()
        {
            IQueryable<NAA_University> _universities;
            _universities = from university
                            in _context.NAA_University
                            select university;
            return _universities.ToList<NAA_University>();
        }
        public void CreateCourseApplication(NAA_Application newApplication, int ApplicantID, int UniversityID, string CourseName)
        {
            _context.NAA_Application.Add(newApplication);
            _context.SaveChanges();
        }

        public IList<NAA_Application> GetAppsForUniversity(int UniversityID)
        {
            IQueryable<NAA_Application> _applications;
            _applications = from application
                            in _context.NAA_Application
                            where application.UniversityID == UniversityID
                            select application;
            return _applications.ToList<NAA_Application>();
        }

        public NAA_Application GetStudentApplication(int ApplicationID)
        {
            IQueryable<NAA_Application> _application;
            _application = from application
                           in _context.NAA_Application
                           where application.ApplicationID == ApplicationID
                           select application;
            return _application.ToList<NAA_Application>().First();
        }

        public void UniDecision(string UniversityOffer, int ApplicationID)
        {
            NAA_Application currentApplication = GetStudentApplication(ApplicationID);
            currentApplication.UniversityOffer = UniversityOffer;
            _context.SaveChanges();

        }

        public IList<ApplicationBEAN> GetStudentApplications(int ApplicantID)
        {
            IQueryable<ApplicationBEAN> _appBEANs = from universities in _context.NAA_University
                                                     from applications in _context.NAA_Application
                                                     where universities.UniversityID == applications.UniversityID
                                                     where applications.ApplicantID == ApplicantID
                                                     select new ApplicationBEAN
                                                     {
                                                         ApplicantID = applications.ApplicantID,
                                                         ApplicationID = applications.ApplicationID,
                                                         UniversityName = universities.UniversityName,
                                                         CourseName = applications.CourseName,
                                                         UniversityOffer = applications.UniversityOffer,
                                                         Firm = applications.Firm
                                                     };

            return _appBEANs.ToList<ApplicationBEAN>();
        }

        public void CreateUniversity(NAA_University newUniversity)
        {
            _context.NAA_University.Add(newUniversity);
            _context.SaveChanges();
        }

        public NAA_University GetUniversity(int UniversityID)
        {
            IQueryable<NAA_University> _university;
            _university = from university
                          in _context.NAA_University
                          where university.UniversityID == UniversityID
                          select university;
           return _university.ToList<NAA_University>().First();
        }
        public void EditUniversity(NAA_University editUniversity, int UniversityID)
        {

            NAA_University currentUniversity = GetUniversity(UniversityID);

            currentUniversity.UniversityID = editUniversity.UniversityID;
            currentUniversity.UniversityName = editUniversity.UniversityName;
            _context.SaveChanges();
        }

        public void DeleteUniversity(NAA_University deleteUniversity)
        {
            _context.NAA_University.Remove(deleteUniversity);
            _context.SaveChanges();
        }

        public void DeleteApplication(NAA_Application deleteApplication)
        {
            _context.NAA_Application.Remove(deleteApplication);
            _context.SaveChanges();
        }

        public void EditApplication(NAA_Application editApplication)
        {
            NAA_Application currentApplication = GetStudentApplication(editApplication.ApplicationID);

            currentApplication.PersonalStatement = editApplication.PersonalStatement;
            currentApplication.TeacherContactDetails = editApplication.TeacherContactDetails;
            currentApplication.TeacherReference = editApplication.TeacherReference;

            _context.SaveChanges();
        }
    }
}
