using Xunit;
using Moq;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using InnovationAdmin.Application.Features.Admin_Users.Commands.CreateAdmin_User;
using InnovationAdmin.Application.Responses;
using System.Threading.Tasks;
using Innovation_Admin.UI.Models.AdminUser;
using InnovationAdmin.Api.Controllers;
using Microsoft.Extensions.Logging;
using System.Threading;
using InnovationAdmin.Domain.Entities;
using System;
using InnovationAdmin.Application.Features.Admin_Users.Commands.UpdateAdminUser;
using InnovationAdmin.Application.Features.Admin_Users.Commands.DeleteAdminUser;
using InnovationAdmin.Application.Features.Admin_Users.Queries.GetAdminUserById; // Adjust the namespace as necessary


namespace InnovationAdmin.API.UnitTests.Controller;
public class AdminUserControllerTests
{
    
    private readonly Mock<IMediator> _mediatorMock;
    private readonly Mock<ILogger<AdminUserController>> _loggerMock;
    private readonly AdminUserController _controller;

    public AdminUserControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _loggerMock = new Mock<ILogger<AdminUserController>>();
        _controller = new AdminUserController(_mediatorMock.Object, _loggerMock.Object);
    }



 


    [Fact]
    public async Task Update_ReturnsOkResult_WithUpdatedAdminUser()
    {
        // Arrange
        var id = Guid.NewGuid();
        var updateAdminUserCommand = new UpdateAdminUserCommand
        {
            User_ID = id,
            User_Name = "testuser",
            Password = "password123",
            Role = 1,
            Email = "testuser@example.com",
            Status = true
        };

        var responseDto = new UpdateAdminUserCommandDto
        {
            User_ID = updateAdminUserCommand.User_ID,
            User_Name = updateAdminUserCommand.User_Name,
            Password = updateAdminUserCommand.Password,
            Role = updateAdminUserCommand.Role,
            Email = updateAdminUserCommand.Email,
            Status = updateAdminUserCommand.Status
        };

        var response = new Response<UpdateAdminUserCommandDto>
        {
            Data = responseDto,
            Message = "Success",
            Succeeded = true
        };

        _mediatorMock
            .Setup(m => m.Send(It.IsAny<UpdateAdminUserCommand>(), default))
            .ReturnsAsync(response);

        // Act
        var result = await _controller.Update(id, updateAdminUserCommand);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var responseResult = Assert.IsType<Response<UpdateAdminUserCommandDto>>(okResult.Value);
        Assert.Equal(response.Data, responseResult.Data);
        Assert.Equal(response.Message, responseResult.Message);
        Assert.Equal(response.Succeeded, responseResult.Succeeded);
    }

    [Fact]
    public async Task Delete_ReturnsNoContentResult()
    {
        // Arrange
        var id = "test-id";
        var deleteAdminUserCommand = new DeleteAdminUserCommand { User_ID = id };

        _mediatorMock
            .Setup(m => m.Send(It.IsAny<DeleteAdminUserCommand>(), default))
            .Returns(Task.FromResult(Unit.Value)); // Corrected the return type to Task<Unit>

        // Act
        var result = await _controller.Delete(id);

        // Assert
        var noContentResult = Assert.IsType<NoContentResult>(result);
        Assert.Equal(204, noContentResult.StatusCode);
    }



}
