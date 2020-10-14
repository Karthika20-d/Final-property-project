using System.Web.Mvc;

namespace OnlineRealEstate.Controllers
{
    public class ErrorController : Controller
    {

        public ActionResult NotFound()
        {
            return View();
        }
    }
}