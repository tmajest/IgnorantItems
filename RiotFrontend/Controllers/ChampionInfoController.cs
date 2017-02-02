using System.Web.Mvc;

namespace CoffeeCat.RiotFrontend.Controllers
{
    public class ChampionInfoController : Controller
    {
        // GET: Champion
#if (!DEBUG)
        [OutputCache(Duration=86000, VaryByParam="id")]
#endif
        public ActionResult Index(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return RedirectToAction("Home", "Index");
            }

            this.ViewBag.ChampionId = id;
            return View();
        }
    }
}