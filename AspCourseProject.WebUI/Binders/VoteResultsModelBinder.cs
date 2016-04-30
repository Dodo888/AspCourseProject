using System.Web.Mvc;
using AspCourseProject.Domain.Entities;

namespace AspCourseProject.WebUI.Binders
{
    public class VoteResultsModelBinder : IModelBinder
    {
        private const string sessionKey = "Cart";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext
            bindingContext)
        {
            // get the Cart from the session
            VoteResults votes = (VoteResults) controllerContext.HttpContext.Session[sessionKey];
            // create the Cart if there wasn't one in the session data
            if (votes == null)
            {
                votes = new VoteResults();
                controllerContext.HttpContext.Session[sessionKey] = votes;
            }
            // return the cart
            return votes;
        }
    }
}