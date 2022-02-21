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
        public async Task<IActionResult> Create([FromForm] CustomerDto customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse.Failed("Could not send feedback. Try again"));   
            }
            var customerToReturn = new Customer
            {
                Name = customer.customerName,
                Email = customer.customerEmail,
                Message = customer.customerMessage
            };
            await _repository.CreateAsync(customerToReturn);
            return Ok(ApiResponse.Success("Feedback submitted successfully"));
        }
    }
}
