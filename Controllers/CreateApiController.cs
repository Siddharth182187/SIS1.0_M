using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AuthApi.Controllers
{
    public class CreateApiController : ApiController
    {
        [HttpPost]
        [Route("CreateApi/data/v2/ntfy")]
        public IHttpActionResult PostData([FromBody] DataModel data)
        {
            // You can access the properties of the received JSON body here
            string partnerId = data.partnerId;
            string vid = data.vid;
            string svc = data.svc;
            string bpid = data.bpid;
            string rmn = data.rmn;
            string email = data.email;
            string msisdn = data.msisdn;
            string firstName = data.userDetails?.firstName;
            string lastName = data.userDetails?.lastName;
            string planCode = data.plan?.code;
            string planName = data.plan?.name;
            string planDescription = data.plan?.description;
            DateTime? planStartDate = data.plan?.startDate;
            DateTime? planEndDate = data.plan?.endDate;
            string serviceStatus = data.serviceStatus;

            // Perform any required processing or validation with the received data

            var response = new
            {
                msg = "Success"
            };

            return Ok(response); // Return 200 OK 
        }
    }

    public class DataModel
    {
        public string partnerId { get; set; }
        public string vid { get; set; }
        public string svc { get; set; }
        public string bpid { get; set; }
        public string rmn { get; set; }
        public string email { get; set; }
        public string msisdn { get; set; }
        public UserDetails userDetails { get; set; }
        public PlanDetails plan { get; set; }
        public string serviceStatus { get; set; }
    }

    public class UserDetails
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
    }

    public class PlanDetails
    {
        public string code { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}

