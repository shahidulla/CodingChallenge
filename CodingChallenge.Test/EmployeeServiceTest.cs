using System;
using System.Collections.Generic;
using System.Text;
using CodingChallenge.Business;
using CodingChallenge.Business.Interfaces;
using CodingChallenge.Data.Interfaces;
using CodingChallenge.Entity;
using CodingChallenge.Web.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace CodingChallenge.Test
{
   public class EmployeeServiceTest
    {
        [Fact]
        public void Should_Return_False()
        {
            // Arrange
            var mockRepo = new Mock<IEmployeeRepository>();
            var employeeService = new EmployeeService(mockRepo.Object);
            mockRepo.Setup(repo => repo.SaveEmployee(new Employee())).Returns(false);
            // Act
            var result = employeeService.SaveEmployeeInfo(new Employee());

            // Assert
            Assert.False(result);
        }
    }
}
