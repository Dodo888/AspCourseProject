using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AspCourseProject.Domain.Entities;
using AspCourseProject.WebUI.Binders;
using AspCourseProject.WebUI.Interface;

namespace AspCourseProject.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
            ModelBinders.Binders.Add(typeof(VoteResults), new VoteResultsModelBinder());
        }
    }
}
