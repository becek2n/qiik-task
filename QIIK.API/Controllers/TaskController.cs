using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QIIK.DTO;
using QIIK.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QIIK.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<TaskController> _logger;
        private readonly IQiikTask _task;

        public TaskController(ILogger<TaskController> logger, IQiikTask task)
        {
            _logger = logger;
            _task = task;
        }

        [HttpPost("Triangle")]
        public async Task<IActionResult> Triangle([FromBody] TriangleRequestDTO request)
        {
            if (request is null)
            {
                _logger.LogError("Triangle object sent from client is null.");
                return BadRequest("Triangle object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid Triangle object sent from client.");
                return BadRequest("Invalid Triangle model object");
            }

            var response = await _task.GetTriangle(request);

            return Ok(response);
        }

        [HttpPost("Fibonacci")]
        public async Task<IActionResult> Fibonacci([FromBody] FibonacciRequestDTO request)
        {
            if (request is null)
            {
                _logger.LogError("Fibonacci object sent from client is null.");
                return BadRequest("Fibonacci object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid Fibonacci object sent from client.");
                return BadRequest("Invalid Fibonacci model object");
            }

            var response = await _task.GetFibonacci(request);

            return Ok(response);
        }

        [HttpPost("Reverse")]
        public async Task<IActionResult> Reverse([FromBody] ReverseRequestDTO request)
        {
            if (request is null)
            {
                _logger.LogError("Reverse object sent from client is null.");
                return BadRequest("Reverse object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid Reverse object sent from client.");
                return BadRequest("Invalid Reverse model object");
            }

            var response = await _task.GetReverse(request);

            return Ok(response);
        }

        [HttpPost("Hashing")]
        public async Task<IActionResult> Hashing([FromBody] HashingRequestDTO request)
        {
            if (request is null)
            {
                _logger.LogError("Hashing object sent from client is null.");
                return BadRequest("Hashing object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid Hashing object sent from client.");
                return BadRequest("Invalid Hashing model object");
            }

            var response = await _task.GetHashing(request);

            return Ok(response);
        }
    }
}
