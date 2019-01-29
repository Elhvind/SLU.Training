using System.Linq;
using System.Web.Mvc;

namespace SLU.Training.Extensions.HtmlHelperExtensions
{
    public static partial class HtmlHelperExtension
    {
        public static string IsMenuActive(this HtmlHelper html, string controllers = "", string actions = "", string cssClass = "active")
        {
            var viewContext = html.ViewContext.Controller.ControllerContext.IsChildAction
                ? html.ViewContext.ParentActionViewContext
                : html.ViewContext;

            var routeValues = viewContext.RouteData.Values;
            string currentAction = routeValues["action"].ToString();
            string currentController = routeValues["controller"].ToString();

            if (string.IsNullOrEmpty(actions))
                actions = currentAction;

            if (string.IsNullOrEmpty(controllers))
                controllers = currentController;

            string[] acceptedActions = actions.Trim().Split(',').Distinct().ToArray();
            string[] acceptedControllers = controllers.Trim().Split(',').Distinct().ToArray();

            return acceptedActions.Contains(currentAction) && acceptedControllers.Contains(currentController)
               ? cssClass
               : string.Empty;
        }
    }
}