using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using InnovationAdmin.Api.Controllers;
using InnovationAdmin.Application.Features.DataSources.Commands.CreateDataSource;
using InnovationAdmin.Application.Features.DataSources.Commands.DeleteDataSource;
using InnovationAdmin.Application.Features.DataSources.Commands.UpdateDataSource;
using InnovationAdmin.Application.Features.DataSources.Queries.GetDataSourceById;
using InnovationAdmin.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;


namespace InnovationAdmin.API.UnitTests.Controllers
{
    public class DataSourceControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<ILogger<DataSourceController>> _loggerMock;
        private readonly DataSourceController _controller;

        public DataSourceControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _loggerMock = new Mock<ILogger<DataSourceController>>();
            _controller = new DataSourceController(_mediatorMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task Create_ReturnsOk_WhenResponseIsSuccessful()
        {
            // Arrange
            var createDataSourceCommand = new CreateDataSourceCommand { Name = "ValidName" };
            var expectedId = Guid.NewGuid();
            var expectedResponse = new Response<CreateDataSourceDto> { Data = new CreateDataSourceDto { ID = expectedId, Name = createDataSourceCommand.Name }, Succeeded = true };

            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateDataSourceCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.Create(createDataSourceCommand);

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
            var createDataSourceCommand = new CreateDataSourceCommand { Name = name };
            var expectedResponse = new Response<CreateDataSourceDto> { Succeeded = false, Message = "Validation error message" };

            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateDataSourceCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.Create(createDataSourceCommand);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(expectedResponse.Message, badRequestResult.Value);
        }


        [Fact]
        public async Task GetDataSourceById_ReturnsOk_WhenResponseIsSuccessful()
        {
            // Arrange
            var id = "validId";
            var getDataSourceQuery = new GetDataSourceByIdQuery { ID = id };
            var expectedResponse = new Response<GetDataSourceByIdVm>
            {
                Succeeded = true,
                Data = new GetDataSourceByIdVm { ID = Guid.NewGuid(), Name = "ValidName" }
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetDataSourceByIdQuery>(), default)).ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.GetDataSourceById(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<Response<GetDataSourceByIdVm>>(okResult.Value);
            Assert.True(response.Succeeded);
            Assert.Equal(expectedResponse.Data, response.Data);
        }

        [Fact]
        public async Task GetDataSourceById_ReturnsBadRequest_WhenResponseIsNotSuccessful()
        {
            // Arrange
            var id = "invalidId";
            var getDataSourceQuery = new GetDataSourceByIdQuery { ID = id };
            var expectedResponse = new Response<GetDataSourceByIdVm>
            {
                Succeeded = false,
                Message = "Error occurred"
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetDataSourceByIdQuery>(), default)).ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.GetDataSourceById(id);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(expectedResponse.Message, badRequestResult.Value);
        }

        [Fact]
        public async Task Update_ReturnsOk_WhenResponseIsSuccessful()
        {
            // Arrange
            var updateCommand = new UpdateDataSourceCommand
            {
                ID = Guid.NewGuid(),
                Name = "UpdatedName"
            };

            var response = new Response<UpdateDataSourceCommandDto>
            {
                Succeeded = true,
                Data = new UpdateDataSourceCommandDto
                {
                    ID = updateCommand.ID,
                    Name = updateCommand.Name
                }
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateDataSourceCommand>(), default)).ReturnsAsync(response);

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
            var updateCommand = new UpdateDataSourceCommand
            {
                ID = Guid.NewGuid(),
                Name = "UpdatedName"
            };

            var response = new Response<UpdateDataSourceCommandDto>
            {
                Succeeded = false,
                Message = "Resource not found"
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateDataSourceCommand>(), default)).ReturnsAsync(response);

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
            var command = new DeleteDataSourceCommand { ID = Guid.Parse(id) };

            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteDataSourceCommand>(), default)).ReturnsAsync(Unit.Value);

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
            var command = new DeleteDataSourceCommand { ID = Guid.Parse(id) };

            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteDataSourceCommand>(), default)).Throws<KeyNotFoundException>();

            // Act
            var result = await _controller.Delete(id);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("Resource not found", notFoundResult.Value);
        }



    }
}
