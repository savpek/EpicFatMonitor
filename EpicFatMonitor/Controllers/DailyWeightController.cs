using System.Web.Http;

namespace EpicFatMonitor.Controllers
{
    public class DailyWeightController : ApiController
    {
        public double Get()
        {
            return 120.2;
        }

        public double Put(double weight)
        {
            return weight;
        }
    }
}
