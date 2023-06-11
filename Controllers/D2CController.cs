using System.Web.Http;

namespace AuthApi.Controllers
{
    [Route("api/d2c")]
    public class DataController : ApiController
    {
        [HttpPost]
        public IHttpActionResult PushData([FromBody] SISData data)
        {
            // Here you can handle the received employee data and perform necessary operations

            // Example: Saving the employee data to a database or processing it in some way
            SaveSISDataToDatabase(data);

            // Return a successful response
            var response = new
            {
                msg = "Success"
            };

            return Ok(response); // Return 200 OK 
        }

        private void SaveSISDataToDatabase(SISData data)
        {
            // Perform data saving logic here (e.g., saving to a database)
            // You can replace this with your own data handling logic
        }
    }

    public class SISData
    {
        public bool Motor { get; set; }
        public decimal FlowRate { get; set; }
        public decimal TotalWater { get; set; }
    }
}
