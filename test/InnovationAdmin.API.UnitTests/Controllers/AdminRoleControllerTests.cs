using InnovationAdmin.Api.Controllers;
using InnovationAdmin.Application.Features.AdminRoles.Commands.CreateAdminRole;
using InnovationAdmin.Application.Features.AdminRoles.Commands.DeleteAdminRole;
using InnovationAdmin.Application.Features.AdminRoles.Commands.UpdateAdminRole;
using InnovationAdmin.Application.Responses;
using InnovationAdmin.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace InnovationAdmin.API.UnitTests.Controllers
{
    public class AdminRoleControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<ILogger<AdminRoleController>> _loggerMock;
        private readonly AdminRoleController _controller;

        public AdminRoleControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _loggerMock = new Mock<ILogger<AdminRoleController>>();
            _controller = new AdminRoleController(_mediatorMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task Create_ReturnsOkResult_WithCreatedAdminRole()
        {
            // Arrange
            var command = new CreateAdminRoleCommand
            {
                Name = "Teacher",
                Description = "Description"
            };

            var responseDto = new CreateAdminRoleDto
            {
                Role_ID = Guid.NewGuid(),
                Role_Name = command.Name,
                Description = command.Description
            };

            var response = new Response<CreateAdminRoleDto>
            {
                Data = responseDto,
                Message = "Success"
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<CreateAdminRoleCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.Create(command);

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);
            var returnedAdminRole = okResult.Value as Admin_Role;
            Assert.NotNull(returnedAdminRole);
            Assert.Equal(responseDto.Role_ID, returnedAdminRole.Role_ID);
            Assert.Equal(responseDto.Role_Name, returnedAdminRole.Role_Name);
            Assert.Equal(responseDto.Description, returnedAdminRole.Description);
        }

        [Fact]
        public async Task Update_ReturnsOkResult_WithUpdatedAdminRole()
        {
            // Arrange
            var command = new UpdateAdminRoleCommand
            {
                Role_ID = Guid.NewGuid(),
                Role_Name = "ROle Name",
                Description = "Updated Description"
            };

            var responseDto = new UpdateAdminRoleDto
            {
                Role_ID = command.Role_ID,
                Role_Name = command.Role_Name,
                Description = command.Description
            };

            var response = new Response<UpdateAdminRoleDto>
            {
                Data = responseDto,
                Succeeded = true
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<UpdateAdminRoleCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.Update(command);

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);
            var returnedAdminRole = okResult.Value as Admin_Role;
            Assert.NotNull(returnedAdminRole);
            Assert.Equal(responseDto.Role_ID, returnedAdminRole.Role_ID);
            Assert.Equal(responseDto.Role_Name, returnedAdminRole.Role_Name);
            Assert.Equal(responseDto.Description, returnedAdminRole.Description);
        }

        [Fact]
        public async Task Update_ReturnsNotFoundResult_WhenResponseIsNull()
        {
            // Arrange
            var command = new UpdateAdminRoleCommand
            {
                Role_ID = Guid.NewGuid(),
                Role_Name = "role",
                Description = "Updated Description"
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<UpdateAdminRoleCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((Response<UpdateAdminRoleDto>)null);

            // Act
            var result = await _controller.Update(command);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

      

        [Fact]
        public async Task Delete_ShouldReturnNoContent_WhenCommandIsValid()
        {
            // Arrange
            var id = Guid.NewGuid().ToString();

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<DeleteAdminRoleCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Unit.Value);

            // Act
            var result = await _controller.Delete(id);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
        [Fact]
        public async Task Delete_ShouldReturnBadRequest_WhenCommandIsNotValid()
        {
            // Arrange
            var invalidId = "invalid-guid";

            // Act
            var result = await _controller.Delete(invalidId);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Invalid GUID format", badRequestResult.Value);
        }


    }
}
