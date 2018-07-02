using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leipzig.Services.IService
{
    public interface ILeipzigService
    {
        IList<SHUServiceReference.SHUCourse> GetSHUCourses();
        IList<ShefUniServiceReference.Course> GetShefUniCourses();
    }
}
