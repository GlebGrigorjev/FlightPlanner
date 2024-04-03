using System.Net;

namespace FlightPlannerUseCases.Models
{
    public class ServiceResult
    {
        public object ResultObject { get; set; }
        public HttpStatusCode Status { get; set; }
    }
}
