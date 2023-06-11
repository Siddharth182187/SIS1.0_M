using System;
using System.Web.Http;

namespace AuthApi.Controllers
{
    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("api/login")]
        public IHttpActionResult Login([FromBody] LoginRequest request)
        {
            // Check if the provided ID and password match the defined values
            if (request.lid != "JYA" || request.pwd != "JYA@123")
            {
                return Unauthorized(); // Return 401 Unauthorized if the ID or password is incorrect
            }

            // Perform authentication using JICDS (replace with your authentication logic)
            bool isAuthenticated = Authenticate(request.lid, request.pwd);

            if (!isAuthenticated)
            {
                return Unauthorized(); // Return 401 Unauthorized if authentication fails
            }

            // Generate token and token expiry time (replace with your token generation logic)
            string token = GenerateToken();
            int expiryTimeInSeconds = 120; // 1 hour

            // Create the response object
            var response = new
            {
                Token = token,
                TokenType = "Bearer",
                ExpiresIn = expiryTimeInSeconds,
                tid = "12389"
            };

            return Ok(response); // Return 200 OK with token and expiry time
        }

        // Helper method to perform authentication (replace with your own authentication logic)
        private bool Authenticate(string username, string password)
        {
            // Perform authentication against JICDS and return true or false based on the result
            // Implement your authentication logic here
            // ...
            return true;
        }

        // Helper method to generate a token (replace with your own token generation logic)
        private string GenerateToken()
        {
            // Generate a unique token using Guid
            string token = Guid.NewGuid().ToString();

            return token;
        }
    }

    public class LoginRequest
    {
        public string evt { get; set; }
        public string gtp { get; set; }
        public string lid { get; set; }
        public string pwd { get; set; }
        public string scp { get; set; }
        public string tid { get; set; }
    }
}


