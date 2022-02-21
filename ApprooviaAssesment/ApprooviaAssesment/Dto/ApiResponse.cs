using Newtonsoft.Json;
using System.Collections.Generic;

namespace ApprooviaAssesment.Dto
{
    public class ApiResponse
    {
        public bool success { get; set; }
        public string message { get; set; }

        public override string ToString() => JsonConvert.SerializeObject(this);

        public ApiResponse(string message = null)
        {
            success = true;
            message = message;
        }
        public static ApiResponse Success(object data)
        {
            return new ApiResponse {message = "Success" };
        }

        public static ApiResponse Failed(string message = "Failure", List<string> errors = null)
        {
            return new ApiResponse { success = false,  message = message };
        }
    }
    
}
