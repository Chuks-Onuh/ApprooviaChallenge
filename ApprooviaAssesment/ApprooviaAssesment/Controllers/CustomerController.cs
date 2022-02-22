using ApprooviaAssesment.Dto;
using ApprooviaAssesment.Model;
using ApprooviaAssesment.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApprooviaAssesment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _repository;

        public CustomerController(CustomerService repository)
        {
            _repository = repository;
        }

        [HttpPost("SparkPlugFeedback")]
        public async Task<IActionResult> Create([FromForm] CustomerDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse.Failed("Could not send feedback. Please try again."));   
            }

            var customer = new Customer
            {
                Name = model.customerName,
                Email = model.customerEmail,
                Message = model.customerMessage
            };

            await _repository.CreateAsync(customer);

            return Ok(ApiResponse.Success("Feedback submitted successfully."));
        }
    }
}
