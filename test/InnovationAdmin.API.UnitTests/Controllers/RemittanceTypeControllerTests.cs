using InnovationAdmin.Api.Controllers;
using InnovationAdmin.Application.Features.RemittanceType.Commands.CreateRemittanceType;
using InnovationAdmin.Application.Features.RemittanceType.Commands.DeleteRemittanceType;
using InnovationAdmin.Application.Features.RemittanceType.Commands.UpdateRemittanceType;
using InnovationAdmin.Application.Features.RemittanceType.Queries.GetRemittanceTypeQuery;
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

        [Fact]
        public async Task DeleteRemittanceTypeReturnsOk()
        {
            
            var id = Guid.NewGuid();
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteRemittanceTypeCommand>(), default))
                         .ReturnsAsync(new Response<bool> { Data = true, Succeeded = true });

            var result = await _controller.Delete(id);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<Response<bool>>(okResult.Value);
            Assert.True(response.Data);
        }

        [Fact]
        public async Task DeleteRemittanceTypeReturnsInternalServerError()
        {
            var id = Guid.NewGuid();
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteRemittanceTypeCommand>(), default))
                         .ReturnsAsync(new Response<bool> { Data = false, Succeeded = false });

            var result = await _controller.Delete(id);

            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task Delete_RemittanceType_NotFound_ReturnsNotFound()
        {

            var id = Guid.NewGuid();
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteRemittanceTypeCommand>(), default))
                         .ReturnsAsync(new Response<bool> { Data = false, Succeeded = true });

            var result = await _controller.Delete(id);

            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            var response = Assert.IsType<Response<bool>>(notFoundResult.Value);
            Assert.False(response.Data);
        }

        [Fact]
        public async Task Update_RemittanceType_IdMismatch_ReturnsBadRequest()
        {
            // Arrange
            var id = Guid.NewGuid();
            var command = new UpdateRemittanceTypeCommand { Id = Guid.NewGuid(), Name = "New Name" };

            // Act
            var result = await _controller.Update(id, command);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("ID mismatch", badRequestResult.Value);
        }

        [Fact]
        public async Task Update_RemittanceType_Success_ReturnsOk()
        {
            // Arrange
            var id = Guid.NewGuid();
            var command = new UpdateRemittanceTypeCommand { Id = id, Name = "Updated Name" };
            var response = new Response<UpdateRemittanceTypeDto> { Succeeded = true, Data = new UpdateRemittanceTypeDto { Id = id, Name = "Updated Name" } };
            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateRemittanceTypeCommand>(), default))
                         .ReturnsAsync(response);

            // Act
            var result = await _controller.Update(id, command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var responseObject = Assert.IsType<Response<UpdateRemittanceTypeDto>>(okResult.Value);
            Assert.True(responseObject.Succeeded);
            Assert.Equal("Updated Name", responseObject.Data.Name);
        }

        [Fact]
        public async Task UpdateRemittanceTypeReturnsBadRequest()
        {
            var id = Guid.NewGuid();
            var command = new UpdateRemittanceTypeCommand { Id = id, Name = "Updated Name" };
            var response = new Response<UpdateRemittanceTypeDto> { Succeeded = false, Message = "Update failed" };
            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateRemittanceTypeCommand>(), default))
                         .ReturnsAsync(response);

            var result = await _controller.Update(id, command);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var responseObject = Assert.IsType<Response<UpdateRemittanceTypeDto>>(badRequestResult.Value);
            Assert.False(responseObject.Succeeded);
            Assert.Equal("Update failed", responseObject.Message);
        }

        [Fact]
        public async Task GetRemittanceTypeByIdInvalidIdFormatReturnsBadRequest()
        {
            var invalidId = "invalid-guid";

            var result = await _controller.GetRemittanceTypeById(invalidId);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Invalid ID format.", badRequestResult.Value);
        }

        [Fact]
        public async Task GetRemittanceTypeByIdReturnsNotFound()
        {

            var id = Guid.NewGuid().ToString();
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetRemittanceTypeByIdQuery>(), default))
                         .ReturnsAsync((Response<RemittanceTypeDto>)null);

            var result = await _controller.GetRemittanceTypeById(id);

            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("Remittance Type not found.", notFoundResult.Value);
        }

        [Fact]
        public async Task GetRemittanceTypeByIdReturnsOk()
        {
            var id = Guid.NewGuid();
            var remittanceTypeDto = new RemittanceTypeDto { Id = id, Name = "Sample Name" };
            var response = new Response<RemittanceTypeDto> { Succeeded = true, Data = remittanceTypeDto };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetRemittanceTypeByIdQuery>(), default))
                         .ReturnsAsync(response);

            var result = await _controller.GetRemittanceTypeById(id.ToString());

            var okResult = Assert.IsType<OkObjectResult>(result);
            var responseObject = Assert.IsType<Response<RemittanceTypeDto>>(okResult.Value);
            Assert.True(responseObject.Succeeded);
            Assert.Equal("Sample Name", responseObject.Data.Name);
        }

    }
}
