using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Data.BEANS
{
    public class ApplicationBEAN
    {

        public int ApplicantID { get; set; }
        public int ApplicationID { get; set; }
        public string UniversityName { get; set; }
        public string CourseName { get; set; }
        public string UniversityOffer { get; set; }
        public Nullable<Boolean> Firm { get; set; }
        public ApplicationBEAN() { }


        //public int ApplicantID

        //public string CourseName
        
        //public int UniversityID

        //public string PersonalStatement
        //public string TeacherReference
        //public string TeacherContactDetails
        //public string UniversityOffer
        //public Nullable<bool> Firm
    }
}
