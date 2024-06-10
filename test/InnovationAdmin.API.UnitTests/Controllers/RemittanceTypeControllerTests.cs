using InnovationAdmin.Api.Controllers;
using InnovationAdmin.Application.Features.RemittanceType.Commands.CreateRemittanceType;
using InnovationAdmin.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace InnovationAdmin.API.UnitTests.Controllers
{
    public class RemittanceTypeControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<ILogger<RemittanceTypeController>> _loggerMock;
        private readonly RemittanceTypeController _controller;

        public RemittanceTypeControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _loggerMock = new Mock<ILogger<RemittanceTypeController>>();
            _controller = new RemittanceTypeController(_mediatorMock.Object,_loggerMock.Object);
        }
        [Fact]
        public async Task CreateWhenNameIsNull()
        {
            // Arrange
            var command = new CreateRemittanceTypeCommand { Name = null };

            // Act
            var result = await _controller.Create(command);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Remittance Type cannot be null or empty", badRequestResult.Value);
        }

        [Fact]
        public async Task CreateWhenNameIsEmpty()
        {

            var command = new CreateRemittanceTypeCommand { Name = string.Empty };

            var result = await _controller.Create(command);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Remittance Type cannot be null or empty", badRequestResult.Value);
        }
        [Fact]
        public async Task CreateWhenRequestIsSuccessful()
        {
            var command = new CreateRemittanceTypeCommand { Name = "TestName" };
            var response = new Response<CreateRemittanceTypeDto>
            {
                Succeeded = true,
                Data = new CreateRemittanceTypeDto { Name = "TestName" }
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateRemittanceTypeCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            var result = await _controller.Create(command);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(response, okResult.Value);
        }
    }
}
