using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leipzig.Services.Service
{
    public class LeipzigService : Leipzig.Services.IService.ILeipzigService
    {
        private SHUServiceReference.SHUWebService _shuproxy;
        private ShefUniServiceReference.SheffieldWebService _shefuniproxy;
        public LeipzigService()
        {
            _shuproxy = new SHUServiceReference.SHUWebService();
            _shefuniproxy = new ShefUniServiceReference.SheffieldWebService();
        }

        public IList<SHUServiceReference.SHUCourse> GetSHUCourses()
        {
            return _shuproxy.SHUCourses();
        }

        public IList<ShefUniServiceReference.Course> GetShefUniCourses()
        {
            return _shefuniproxy.SheffCourses();
        }

    }
}
