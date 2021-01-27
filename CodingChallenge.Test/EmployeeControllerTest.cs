using CodingChallenge.Business;
using CodingChallenge.Web.Controllers;
using Moq;
using System;
using CodingChallenge.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Xunit;

namespace CodingChallenge.Test
{
    public class EmployeeControllerTest
    {
        [Fact]
        public void Should_Return_View()
        {
            // Arrange
            var mockRepoEmployeeService = new Mock<IEmployeeService>();
            var mockRepoLogger = new Mock<ILogger<EmployeeController>>();
            var controller = new EmployeeController(mockRepoEmployeeService.Object, mockRepoLogger.Object);

            // Act
            var result = controller.Create();

            // Assert
            Assert.NotNull(result);
        }
    }
}
