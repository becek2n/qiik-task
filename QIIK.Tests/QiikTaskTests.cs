using Xunit;
using QIIK.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using QIIK.API.Controllers;
using Moq;
using QIIK.Interface;
using QIIK.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QIIK.Tests
{
    public class TaskControllerTests
    {
        private readonly Mock<ILogger<TaskController>> _logger;
        private readonly Mock<IQiikTask> _task;
        private readonly TaskController _controller;

        public TaskControllerTests()
        {
            _logger = new Mock<ILogger<TaskController>>();
            _task = new Mock<IQiikTask>();
            _controller = new TaskController(_logger.Object, _task.Object);
        }
        [Fact()]
        public async Task TriangleTest_ResultOk()
        {
            //arrange 
            string classification = "The Triangle is Equilateral";

            var request = new TriangleRequestDTO() { Side1 = 2, Side2 = 2, Side3 = 2 };
            _task.Setup(r => r.GetTriangle(request))
                .ReturnsAsync(new TriangleResponseDTO() { Category = classification });

            var result = await _controller.Triangle(request);

            //assert
            var okActionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<TriangleResponseDTO>(okActionResult.Value);
            Assert.Equal(200, okActionResult?.StatusCode);
            Assert.Equal(classification, returnValue?.Category);
        }
        [Fact]
        public async Task TriangleTest_ResultBadRequest()
        {
            //arrange 
            _controller.ModelState.AddModelError("Side1", "Side1 Error");

            //act
            var request = new TriangleRequestDTO();
            var result = await _controller.Triangle(request);

            //assert
            var badActionResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, badActionResult?.StatusCode);
            Assert.Equal("Invalid Triangle model object", badActionResult?.Value);
        }

        [Fact()]
        public async Task FibonacciTest_ResultOk()
        {
            //arrange 
            int[] fibonaccies = { 0, 1, 1, 2, 3, 5, 8, 12, 21, 34 };

            var request = new FibonacciRequestDTO() { LengthSeries = 10 };
            _task.Setup(r => r.GetFibonacci(request))
                .ReturnsAsync(new FibonacciResponseDTO() { Values = fibonaccies });

            var result = await _controller.Fibonacci(request);

            //assert
            var okActionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<FibonacciResponseDTO>(okActionResult.Value);
            Assert.Equal(fibonaccies, returnValue.Values);
        }
        [Fact]
        public async Task FibonacciTest_ResultBadRequest()
        {
            //arrange 
            _controller.ModelState.AddModelError("LengthSeries", "LengthSeries Error");

            //act
            var request = new FibonacciRequestDTO();
            var result = await _controller.Fibonacci(request);

            //assert
            var badActionResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, badActionResult?.StatusCode);
            Assert.Equal("Invalid Fibonacci model object", badActionResult?.Value);
        }

        [Fact()]
        public async Task ReverseTest_ResultOk()
        {
            //arrange 
            string reverse = "igoY";
            var request = new ReverseRequestDTO() { Value = "Yogi" };
            _task.Setup(r => r.GetReverse(request))
                .ReturnsAsync(new ReverseResponseDTO() { Value = reverse });

            //act
            var result = await _controller.Reverse(request);

            //assert
            var okActionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<ReverseResponseDTO>(okActionResult.Value);
            Assert.Equal(reverse, returnValue.Value);
        }
        [Fact]
        public async Task ReverseTest_ResultBadRequest()
        {
            //arrange 
            _controller.ModelState.AddModelError("Value", "Value Error");

            //act
            var request = new ReverseRequestDTO();
            var result = await _controller.Reverse(request);

            //assert
            var badActionResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, badActionResult?.StatusCode);
            Assert.Equal("Invalid Reverse model object", badActionResult?.Value);
        }
        [Fact]
        public async Task HashingTest_ResultOk()
        {
            //arrange 
            string hash = "53522ad67a425c5c0f4ac9fc089fbbb4";
            var request = new HashingRequestDTO() { Value = "Yogi" };
            _task.Setup(r => r.GetHashing(request))
                .ReturnsAsync(new HashingResponseDTO() { Algorithm = "MD5", Value = hash });

            //act
            var result = await _controller.Hashing(request);

            //assert
            var okActionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<HashingResponseDTO>(okActionResult.Value);
            Assert.Equal(hash, returnValue.Value);
        }
        [Fact]
        public async Task HashingTest_ResultBadRequest()
        {
            //arrange 
            _controller.ModelState.AddModelError("Value", "Value Error");

            //act
            var request = new HashingRequestDTO();
            var result = await _controller.Hashing(request);

            //assert
            var badActionResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, badActionResult?.StatusCode);
            Assert.Equal("Invalid Hashing model object", badActionResult?.Value);
        }
    }
}