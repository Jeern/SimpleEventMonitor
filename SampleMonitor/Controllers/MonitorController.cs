using System.Web.Mvc;
using SimpleEventMonitor.Store.Redis;

namespace SampleMonitor.Controllers
{
    public class MonitorController : Controller
    {
        // GET: Monitor
        public ActionResult Index()
        {
            var eventDataStore = new RedisEventDataStore();
            return View(eventDataStore.GetEvents());
        }
    }
}