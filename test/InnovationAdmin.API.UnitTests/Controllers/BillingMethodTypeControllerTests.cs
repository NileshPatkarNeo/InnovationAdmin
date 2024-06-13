using InnovationAdmin.Api.Controllers;
using InnovationAdmin.Application.Features.BillingMethodTypes.Commands.CreateBillingMethodType;
using InnovationAdmin.Application.Features.BillingMethodTypes.Commands.DeleteBillingMethodType;
using InnovationAdmin.Application.Features.BillingMethodTypes.Commands.UpdateBillingMethodType;
using InnovationAdmin.Application.Features.BillingMethodTypes.Queries.GetBillingMethodTypeById;
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
    public class BillingMethodTypeControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<ILogger<BillingMethodTypeController>> _loggerMock;
        private readonly BillingMethodTypeController _controller;

        public BillingMethodTypeControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _loggerMock = new Mock<ILogger<BillingMethodTypeController>>();
            _controller = new BillingMethodTypeController(_mediatorMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task Create_ReturnsOk_WhenResponseIsSuccessful()
        {
            // Arrange
            var createBillingMethodTypeCommand = new CreateBillingMethodTypeCommand { Name = "ValidName" };
            var expectedId = Guid.NewGuid();
            var expectedResponse = new Response<CreateBillingMethodTypeDto>
            {
                Data = new CreateBillingMethodTypeDto { ID = expectedId, Name = createBillingMethodTypeCommand.Name },
                Succeeded = true
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateBillingMethodTypeCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.Create(createBillingMethodTypeCommand);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expectedResponse, okResult.Value);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("A")] // Less than minimum length
        [InlineData("This is a very long name that exceeds the maximum length allowed.")] // More than maximum length
        [InlineData("Invalid@Name")] // Contains invalid characters
        public async Task Create_ReturnsBadRequest_WhenResponseIsNotSuccessful(string name)
        {
            // Arrange
            var createBillingMethodTypeCommand = new CreateBillingMethodTypeCommand { Name = name };
            var expectedResponse = new Response<CreateBillingMethodTypeDto> { Succeeded = false, Message = "Validation error message" };

            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateBillingMethodTypeCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.Create(createBillingMethodTypeCommand);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(expectedResponse.Message, badRequestResult.Value);
        }


        [Fact]
        public async Task GetBillingMethodById_ReturnsOk_WhenResponseIsSuccessful()
        {
            // Arrange
            var billingMethodId = Guid.NewGuid().ToString();
            var expectedResponse = new Response<GetBillingMethodTypeByIdVm>
            {
                Data = new GetBillingMethodTypeByIdVm
                {
                    ID = Guid.Parse(billingMethodId),
                    Name = "ValidName"
                },
                Succeeded = true
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetBillingMethodTypeByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.GetBillingMethodById(billingMethodId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expectedResponse, okResult.Value);
        }

        [Fact]
        public async Task GetBillingMethodById_ReturnsBadRequest_WhenResponseIsNotSuccessful()
        {
            // Arrange
            var billingMethodId = Guid.NewGuid().ToString();
            var expectedResponse = new Response<GetBillingMethodTypeByIdVm>
            {
                Succeeded = false,
                Message = "Billing method not found"
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetBillingMethodTypeByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.GetBillingMethodById(billingMethodId);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(expectedResponse.Message, badRequestResult.Value);
        }

        [Fact]
        public async Task Update_ReturnsOk_WhenResponseIsSuccessful()
        {
            // Arrange
            var updateCommand = new UpdateBillingMethodTypeCommand
            {
                ID = Guid.NewGuid(),
                Name = "ValidName"
            };
            var expectedResponse = new Response<UpdateBillingMethodTypeCommandDto>
            {
                Data = new UpdateBillingMethodTypeCommandDto
                {
                    ID = updateCommand.ID,
                    Name = updateCommand.Name
                },
                Succeeded = true
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateBillingMethodTypeCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.Update(updateCommand);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expectedResponse, okResult.Value);
        }

        [Fact]
        public async Task Update_ReturnsNotFound_WhenResponseIsNotSuccessful()
        {
            // Arrange
            var updateCommand = new UpdateBillingMethodTypeCommand
            {
                ID = Guid.NewGuid(),
                Name = "InvalidName"
            };
            var expectedResponse = new Response<UpdateBillingMethodTypeCommandDto>
            {
                Succeeded = false,
                Message = "Billing method not found"
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateBillingMethodTypeCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.Update(updateCommand);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(expectedResponse.Message, notFoundResult.Value);
        }

        [Fact]
        public async Task Delete_ReturnsNoContent_WhenResourceIsDeleted()
        {
            // Arrange
            var id = Guid.NewGuid().ToString();
            var command = new DeleteBillingMethodTypeCommand { ID = Guid.Parse(id) };

            _mediatorMock.Setup(m => m.Send(command, default)).ReturnsAsync(Unit.Value);

            // Act
            var result = await _controller.Delete(id);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Delete_ReturnsBadRequest_WhenIdIsInvalid()
        {
            // Arrange
            var id = "invalid_id";

            // Act
            var result = await _controller.Delete(id);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Invalid GUID format", badRequestResult.Value);
        }

        [Fact]
        public async Task Delete_ReturnsNotFound_WhenResourceIsNotFound()
        {
            // Arrange
            var id = Guid.NewGuid().ToString();
            var command = new DeleteBillingMethodTypeCommand { ID = Guid.Parse(id) };

            _mediatorMock.Setup(m => m.Send(command, default)).Throws<KeyNotFoundException>();

            // Act
            var result = await _controller.Delete(id);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }



    }
}
