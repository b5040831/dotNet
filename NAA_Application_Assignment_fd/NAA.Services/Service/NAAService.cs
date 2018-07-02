using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Data;
using NAA.Data.DAO;
using NAA.Data.IDAO;


namespace NAA.Services.Service
{
    public class NAAService :
        NAA.Services.IService.INAAService
    {
        private INAADAO _NAADAO;
        public NAAService()
        {
            _NAADAO = new NAADAO();
        }

        /*public NAA_User_Profile GetUserProfile(int ApplicantID)
        {
            return _NAADAO.GetUserProfile(ApplicantID);
        } backup */

        public NAA_User_Profile GetUserProfile(string UserID)
        {
            return _NAADAO.GetUserProfile(UserID);
        }
        public NAA_User_Profile ShowUserProfileOnApplicantID(int ApplicantID)
        {
            return _NAADAO.ShowUserProfileOnApplicantID(ApplicantID);
        }

        public void CreateUserProfile(NAA_User_Profile newProfile)
        {
            _NAADAO.CreateUserProfile(newProfile);
        }

        public void EditUserProfile(NAA_User_Profile editProfile)
        {
            _NAADAO.EditUserProfile(editProfile);
        }
        public void EditUserFirmDecision(int ApplicationID, bool Firm)
        {
            _NAADAO.EditUserFirmDecision(ApplicationID, Firm);
        }

        public void CreateCourseApplication(NAA_Application newApplication, int ApplicantID, int UniversityID, string CourseName)
        {
            _NAADAO.CreateCourseApplication(newApplication, ApplicantID, UniversityID, CourseName);
        }

        public IList<NAA.Data.NAA_University> GetUniversityList()
        {
            return _NAADAO.GetUniversityList();
        }

        public IList<NAA.Data.BEANS.ApplicationBEAN> GetStudentApplications(int ApplicantID)
        {
            return _NAADAO.GetStudentApplications(ApplicantID);
        }

        public IList<NAA.Data.NAA_Application> GetAppsForUniversity(int UniversityID)
        {
            return _NAADAO.GetAppsForUniversity(UniversityID);
        }

        public NAA.Data.NAA_Application GetStudentApplication(int ApplicationID)
        {
            return _NAADAO.GetStudentApplication(ApplicationID);
        }

        public void UniDecision(string UniversityOffer, int ApplicationID)
        {
            _NAADAO.UniDecision(UniversityOffer, ApplicationID);
        }

        public void CreateUniversity(NAA_University newUniversity)
        {
            _NAADAO.CreateUniversity(newUniversity);
        }
        public void EditUniversity(NAA_University editUniversity, int UniversityID)
        {
            _NAADAO.EditUniversity(editUniversity, UniversityID);
        }

        public NAA_University GetUniversity(int UniversityID)
        {
            return _NAADAO.GetUniversity(UniversityID);
        }

        public void DeleteUniversity(NAA_University deleteUniversity)
        {
            _NAADAO.DeleteUniversity(deleteUniversity);
        }

        public void DeleteApplication(NAA_Application deleteApplication)
        {
            _NAADAO.DeleteApplication(deleteApplication);
        }

        public void EditApplication(NAA_Application editApplication)
        {
            _NAADAO.EditApplication(editApplication);
        }
    }
}
