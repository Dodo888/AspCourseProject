using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AspCourseProject.WebUI.Helpers
{
    public interface IUserProvider
    {
        string GetUserName(Controller controller);
    }
}
