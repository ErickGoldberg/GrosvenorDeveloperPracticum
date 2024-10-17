using System;
using System.Threading.Tasks;
using GrosvenorDeveloperPracticum.Application.Abstractions;
using GrosvenorDeveloperPracticum.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GrosvenorDeveloperPracticum.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IServer _server;

        public OrdersController(IServer server)
        {
            _server = server;
        }

        /// <summary>
        /// Takes an order as a string and returns a formatted list of dishes.
        /// </summary>
        /// <param name="order">The order string in the format: <timeOfDay>,<dishType1>,<dishType2>,...</param>
        /// <returns>A Result containing a formatted string of dishes or an error message.</returns>
        [HttpPost]
        public async Task<ActionResult<Result<string>>> TakeOrder([FromBody] string order)
        {
            if (string.IsNullOrWhiteSpace(order))
                return BadRequest(Result<string>.Failure("Enter a valid order."));

            try
            {
                var output = await Task.Run(() => _server.TakeOrder(order));
                return Ok(Result<string>.Success(output));
            }
            catch (ApplicationException ex)
            {
                return BadRequest(Result<string>.Failure(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, Result<string>.Failure("An unexpected error occurred: " + ex.Message));
            }
        }
    }
}