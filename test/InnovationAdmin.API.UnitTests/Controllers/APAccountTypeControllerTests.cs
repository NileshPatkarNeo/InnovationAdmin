using InnovationAdmin.Api.Controllers;
using InnovationAdmin.Application.Features.APAccountTypes.Commands.CreateAPAccountType;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Threading.Tasks;
using System;
using Xunit;
using InnovationAdmin.Application.Responses;
using InnovationAdmin.Application.Features.APAccountTypes.Queries.GetAPAccountTypebyId;
using InnovationAdmin.Application.Features.APAccountTypes.Commands.UpdateAPAccountType;
using InnovationAdmin.Application.Features.APAccountTypes.Commands.DeleteAPAccountType;
using System.Collections.Generic;


namespace InnovationAdmin.API.UnitTests.Controllers
{
    public class APAccountTypeControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<ILogger<APAccountTypeController>> _loggerMock;
        private readonly APAccountTypeController _controller;

        public APAccountTypeControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _loggerMock = new Mock<ILogger<APAccountTypeController>>();
            _controller = new APAccountTypeController(_mediatorMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task Create_ReturnsOk_WhenRequestIsValid()
        {
            // Arrange
            var command = new CreateAPAccountTypeCommand { Name = "ValidName" };
            var response = new Response<CreateAPAccountTypeDto>
            {
                Succeeded = true,
                Data = new CreateAPAccountTypeDto { ID = Guid.NewGuid(), Name = "ValidName" }
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateAPAccountTypeCommand>(), default))
                         .ReturnsAsync(response);

            // Act
            var result = await _controller.Create(command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Response<CreateAPAccountTypeDto>>(okResult.Value);
            Assert.True(returnValue.Succeeded);
        }

        [Fact]
        public async Task Create_ReturnsBadRequest_WhenCreationFails()
        {
            // Arrange
            var command = new CreateAPAccountTypeCommand { Name = "InvalidName" };
            var response = new Response<CreateAPAccountTypeDto>
            {
                Succeeded = false,
                Message = "Creation failed."
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateAPAccountTypeCommand>(), default))
                         .ReturnsAsync(response);

            // Act
            var result = await _controller.Create(command);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Creation failed.", badRequestResult.Value);
        }

        [Fact]
        public async Task GetAPAccountTypeById_ReturnsOk_WhenResponseIsSuccessful()
        {
            // Arrange
            var id = "validId";
            var getAPAccountTypeByIdQuery = new GetAPAccountTypebyIdQuery { ID = id };
            var expectedResponse = new Response<GetAPAccountTypebyIdVm>
            {
                Succeeded = true,
                Data = new GetAPAccountTypebyIdVm { ID = Guid.NewGuid(), Name = "ValidName" }
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetAPAccountTypebyIdQuery>(), default)).ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.GetAPAccountTypeById(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<Response<GetAPAccountTypebyIdVm>>(okResult.Value);
            Assert.True(response.Succeeded);
            Assert.Equal(expectedResponse.Data, response.Data);
        }

        [Fact]
        public async Task GetAPAccountTypeById_ReturnsBadRequest_WhenResponseIsNotSuccessful()
        {
            // Arrange
            var id = "invalidId";
            var getAPAccountTypeByIdQuery = new GetAPAccountTypebyIdQuery { ID = id };
            var expectedResponse = new Response<GetAPAccountTypebyIdVm>
            {
                Succeeded = false,
                Message = "Error occurred"
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetAPAccountTypebyIdQuery>(), default)).ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.GetAPAccountTypeById(id);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(expectedResponse.Message, badRequestResult.Value);
        }

        [Fact]
        public async Task Update_ReturnsOk_WhenResponseIsSuccessful()
        {
            // Arrange
            var updateCommand = new UpdateAPAccountTypeCommand
            {
                ID = Guid.NewGuid(),
                Name = "UpdatedName"
            };

            var response = new Response<UpdateAPAccountTypeCommandDto>
            {
                Succeeded = true,
                Data = new UpdateAPAccountTypeCommandDto
                {
                    ID = updateCommand.ID,
                    Name = updateCommand.Name
                }
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateAPAccountTypeCommand>(), default)).ReturnsAsync(response);

            // Act
            var result = await _controller.Update(updateCommand);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(response, okResult.Value);
        }

        [Fact]
        public async Task Update_ReturnsNotFound_WhenResponseIsNotSuccessful()
        {
            // Arrange
            var updateCommand = new UpdateAPAccountTypeCommand
            {
                ID = Guid.NewGuid(),
                Name = "UpdatedName"
            };

            var response = new Response<UpdateAPAccountTypeCommandDto>
            {
                Succeeded = false,
                Message = "Resource not found"
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateAPAccountTypeCommand>(), default)).ReturnsAsync(response);

            // Act
            var result = await _controller.Update(updateCommand);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(response.Message, notFoundResult.Value);
        }

        [Fact]
        public async Task Delete_ReturnsNoContent_WhenResourceIsDeleted()
        {
            // Arrange
            var id = Guid.NewGuid().ToString();
            var command = new DeleteAPAccountTypeCommand { ID = Guid.Parse(id) };

            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteAPAccountTypeCommand>(), default)).ReturnsAsync(Unit.Value);

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
            var command = new DeleteAPAccountTypeCommand { ID = Guid.Parse(id) };

            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteAPAccountTypeCommand>(), default)).Throws<KeyNotFoundException>();

            // Act
            var result = await _controller.Delete(id);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("Resource not found", notFoundResult.Value);
        }

    }
}
