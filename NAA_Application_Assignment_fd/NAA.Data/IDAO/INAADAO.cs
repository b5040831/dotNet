using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Data.BEANS;

namespace NAA.Data.IDAO
{
    public interface INAADAO
    {
        //NAA.Data.NAA_User_Profile GetUserProfile(int ApplicantID); backup
        NAA.Data.NAA_User_Profile GetUserProfile(string UserID);
        NAA.Data.NAA_User_Profile ShowUserProfileOnApplicantID(int ApplicantID);

        void CreateUserProfile(NAA_User_Profile newProfile);
        void EditUserProfile(NAA_User_Profile editProfile);
        void EditUserFirmDecision(int ApplicationID, bool Firm);

        IList<NAA_University> GetUniversityList();
        IList<ApplicationBEAN> GetStudentApplications(int ApplicantID);

        void CreateCourseApplication(NAA_Application newApplication, int ApplicantID, int UniversityID, string CourseName);

        IList<NAA_Application> GetAppsForUniversity(int UniversityID);
        NAA.Data.NAA_Application GetStudentApplication(int ApplicationID);

        void UniDecision(string UniversityOffer, int ApplicationID);
        NAA_University GetUniversity(int UniversityID);
        void CreateUniversity(NAA_University newUniversity);
        void EditUniversity(NAA_University editUniversity, int UniversityID);

        void DeleteUniversity(NAA_University deleteUniversity);

        void DeleteApplication(NAA_Application deleteApplication);

        void EditApplication(NAA_Application editApplication);
    }
}
