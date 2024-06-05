
using InnovationAdmin.Api.Controllers;
using InnovationAdmin.Application.Features.SysPrefSecurityEmails.Commands.CreateSysPrefSecurityEmail;
using InnovationAdmin.Application.Features.SysPrefSecurityEmails.Commands.DeleteSysPrefSecurityEmail;
using InnovationAdmin.Application.Features.SysPrefSecurityEmails.Commands.UpdateSysPrefSecurityEmail;
using InnovationAdmin.Application.Features.SysPrefSecurityEmails.Queries.GetSysPrefSecurityEmailById;
using InnovationAdmin.Application.Features.SysPrefSecurityEmails.Queries.GetSysPrefSecurityEmailList;
using InnovationAdmin.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace InnovationAdmin.API.UnitTests.Controllers
{
    public class SysPrefSecurityEmailControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<ILogger<SysPrefSecurityEmailController>> _loggerMock;
        private readonly SysPrefSecurityEmailController _controller;

        public SysPrefSecurityEmailControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _loggerMock = new Mock<ILogger<SysPrefSecurityEmailController>>();
            _controller = new SysPrefSecurityEmailController(_mediatorMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task Create_ReturnsOk_WhenResponseIsSuccessful()
        {
            
            var createCommand = new CreateSysPrefSecurityEmailCommand
            {
                DefaultFromName = "Admin",
                DefaultFromAddress = "admin@example.com",
                DefaultReplyToAddress = "reply@example.com",
                DefaultReplyToName = "Reply",
                Status = 1
            };

            var response = new Response<CreateSysPrefSecurityEmailDto>
            {
                Succeeded = true,
                Data = new CreateSysPrefSecurityEmailDto
                {
                    SysPrefSecurityEmailId = Guid.NewGuid(),
                    DefaultFromName = createCommand.DefaultFromName,
                    DefaultFromAddress = createCommand.DefaultFromAddress,
                    DefaultReplyToAddress = createCommand.DefaultReplyToAddress,
                    DefaultReplyToName = createCommand.DefaultReplyToName,
                    Status = createCommand.Status
                }
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateSysPrefSecurityEmailCommand>(), default)).ReturnsAsync(response);

            
            var result = await _controller.Create(createCommand);

            
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(response, okResult.Value);
        }

        [Fact]
        public async Task Create_ReturnsBadRequest_WhenResponseIsNotSuccessful()
        {
            
            var createCommand = new CreateSysPrefSecurityEmailCommand
            {
                DefaultFromName = "Admin",
                DefaultFromAddress = "admin@example.com",
                DefaultReplyToAddress = "reply@example.com",
                DefaultReplyToName = "Reply",
                Status = 1
            };

            var response = new Response<CreateSysPrefSecurityEmailDto>
            {
                Succeeded = false,
                Message = "Error occurred"
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateSysPrefSecurityEmailCommand>(), default)).ReturnsAsync(response);

            
            var result = await _controller.Create(createCommand);

            
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(response.Message, badRequestResult.Value);
        }

        [Fact]
        public async Task GetSysPrefSecurityEmailById_ReturnsOk_WhenResponseIsSuccessful()
        {
            
            var query = new GetSysPrefSecurityEmailByIdQuery { SysPrefSecurityEmailId = "123" };
            var response = new Response<GetSysPrefSecurityEmailByIdVm>
            {
                Succeeded = true,
                Data = new GetSysPrefSecurityEmailByIdVm
                {
                    SysPrefSecurityEmailId = Guid.NewGuid(),
                    DefaultFromName = "Admin",
                    DefaultFromAddress = "admin@example.com",
                    DefaultReplyToAddress = "reply@example.com",
                    DefaultReplyToName = "Reply",
                    Status = 1
                }
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetSysPrefSecurityEmailByIdQuery>(), default)).ReturnsAsync(response);

            
            var result = await _controller.GetSysPrefSecurityEmailById(query.SysPrefSecurityEmailId);

            
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Response<GetSysPrefSecurityEmailByIdVm>>(okResult.Value);
            Assert.True(returnValue.Succeeded);
            Assert.Equal(response.Data, returnValue.Data);
        }

        [Fact]
        public async Task GetSysPrefSecurityEmailById_ReturnsBadRequest_WhenResponseIsNotSuccessful()
        {
            // Arrange
            var query = new GetSysPrefSecurityEmailByIdQuery { SysPrefSecurityEmailId = "123" };
            var response = new Response<GetSysPrefSecurityEmailByIdVm>
            {
                Succeeded = false,
                Message = "Error occurred"
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetSysPrefSecurityEmailByIdQuery>(), default)).ReturnsAsync(response);

            // Act
            var result = await _controller.GetSysPrefSecurityEmailById(query.SysPrefSecurityEmailId);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(response.Message, badRequestResult.Value);
        }

        [Fact]
        public async Task GetAllSysPrefSecurityEmail_ReturnsOk_WhenResponseIsSuccessful()
        {
            // Arrange
            var response = new Response<IEnumerable<GetSysPrefSecurityEmailListVm>>
            {
                Succeeded = true,
                Data = new List<GetSysPrefSecurityEmailListVm>
                {
                    new GetSysPrefSecurityEmailListVm
                    {
                        SysPrefSecurityEmailId = Guid.NewGuid(),
                        DefaultFromName = "Admin",
                        DefaultFromAddress = "admin@example.com",
                        DefaultReplyToAddress = "reply@example.com",
                        DefaultReplyToName = "Reply",
                        Status = 1
                    }
                }
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetSysPrefSecurityEmailListQuery>(), default)).ReturnsAsync(response);

            // Act
            var result = await _controller.GetAllSysPrefSecurityEmail();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Response<IEnumerable<GetSysPrefSecurityEmailListVm>>>(okResult.Value);
            Assert.True(returnValue.Succeeded);
            Assert.Equal(response.Data, returnValue.Data);
        }

        [Fact]
        public async Task GetAllSysPrefSecurityEmail_ReturnsBadRequest_WhenResponseIsNotSuccessful()
        {
            // Arrange
            var response = new Response<IEnumerable<GetSysPrefSecurityEmailListVm>>
            {
                Succeeded = false,
                Message = "Error occurred"
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetSysPrefSecurityEmailListQuery>(), default)).ReturnsAsync(response);

            // Act
            var result = await _controller.GetAllSysPrefSecurityEmail();

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(response.Message, badRequestResult.Value);
        }

        [Fact]
        public async Task Update_ReturnsOk_WhenResponseIsSuccessful()
        {
            // Arrange
            var updateCommand = new UpdateSysPrefSecurityEmailCommand
            {
                SysPrefSecurityEmailId = Guid.NewGuid(),
                DefaultFromName = "Admin",
                DefaultFromAddress = "admin@example.com",
                DefaultReplyToAddress = "reply@example.com",
                DefaultReplyToName = "Reply",
                Status = 1
            };

            var response = new Response<UpdateSysPrefSecurityEmailCommandDto>
            {
                Succeeded = true,
                Data = new UpdateSysPrefSecurityEmailCommandDto
                {
                    SysPrefSecurityEmailId = updateCommand.SysPrefSecurityEmailId,
                    DefaultFromName = updateCommand.DefaultFromName,
                    DefaultFromAddress = updateCommand.DefaultFromAddress,
                    DefaultReplyToAddress = updateCommand.DefaultReplyToAddress,
                    DefaultReplyToName = updateCommand.DefaultReplyToName,
                    Status = updateCommand.Status
                }
            };

            _mediatorMock.Setup(m => m.Send(updateCommand, default)).ReturnsAsync(response);

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
            var updateCommand = new UpdateSysPrefSecurityEmailCommand
            {
                SysPrefSecurityEmailId = Guid.NewGuid(),
                DefaultFromName = "Admin",
                DefaultFromAddress = "admin@example.com",
                DefaultReplyToAddress = "reply@example.com",
                DefaultReplyToName = "Reply",
                Status = 1
            };

            var response = new Response<UpdateSysPrefSecurityEmailCommandDto>
            {
                Succeeded = false,
                Message = "Error occurred"
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateSysPrefSecurityEmailCommand>(), default)).ReturnsAsync(response);

            // Act
            var result = await _controller.Update(updateCommand);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(response.Message, notFoundResult.Value);
        }

             [Fact]
        public async Task Delete_ReturnsNoContent_WhenDeletionIsSuccessful()
        {
            // Arrange
            var id = Guid.NewGuid().ToString();
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteSysPrefSecurityEmailCommand>(), default)).ReturnsAsync(Unit.Value);

            // Act
            var result = await _controller.Delete(id);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Delete_ReturnsBadRequest_WhenGuidIsInvalid()
        {
            // Arrange
            var invalidId = "invalid-guid";

            // Act
            var result = await _controller.Delete(invalidId);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Invalid GUID format", badRequestResult.Value);
        }

        [Fact]
        public async Task Delete_ReturnsNotFound_WhenDeletionFails()
        {
            // Arrange
            var id = Guid.NewGuid().ToString();
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteSysPrefSecurityEmailCommand>(), default)).ThrowsAsync(new KeyNotFoundException("Resource not found"));

            // Act
            var result = await _controller.Delete(id);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("Resource not found", notFoundResult.Value);
        }

    }
}
