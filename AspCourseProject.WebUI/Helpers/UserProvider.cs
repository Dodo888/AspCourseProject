using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspCourseProject.WebUI.Helpers
{
    public class UserProvider: IUserProvider
    {
        public string GetUserName(Controller controller)
        {
            return controller.User.Identity.Name;
        }
    }
}