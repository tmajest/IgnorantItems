using System.Web.Mvc;

namespace CoffeeCat.RiotFrontend.Controllers
{
    public class ChampionsController : Controller
    {
        // GET: Champion
#if (!DEBUG)
        [OutputCache(Duration=86000)]
#endif
        public ActionResult Index()
        {
            return View();
        }
    }
}