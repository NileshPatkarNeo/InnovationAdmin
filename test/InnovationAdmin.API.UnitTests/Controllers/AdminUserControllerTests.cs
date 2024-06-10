//using Xunit;
//using Moq;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using InnovationAdmin.Application.Responses;
//using System.Threading.Tasks;
//using InnovationAdmin.Api.Controllers;
//using Microsoft.Extensions.Logging;
//using System;
//using InnovationAdmin.Application.Features.Admin_Users.Commands.UpdateAdminUser;
//using InnovationAdmin.Application.Features.Admin_Users.Commands.DeleteAdminUser;
//using InnovationAdmin.Application.Features.Admin_Users.Queries.GetAdminUserById;
//using InnovationAdmin.Application.Features.Admin_Users.Commands.CreateAdmin_User;
//using System.Collections.Generic; 


//namespace InnovationAdmin.API.UnitTests.Controller;
//public class AdminUserControllerTests
//{
    
//    private readonly Mock<IMediator> _mediatorMock;
//    private readonly Mock<ILogger<AdminUserController>> _loggerMock;
//    private readonly AdminUserController _controller;

//    public AdminUserControllerTests()
//    {
//        _mediatorMock = new Mock<IMediator>();
//        _loggerMock = new Mock<ILogger<AdminUserController>>();
//        _controller = new AdminUserController(_mediatorMock.Object, _loggerMock.Object);
//    }

//    [Fact]
//    public async Task GetEventById_ReturnsOk_WhenResponseIsSuccessful()
//    {
//        // Arrange
//        var id = "123";
//        var response = new Response<AdminUserByIdVm>
//        {
//            Succeeded = true,
//            Data = new AdminUserByIdVm
//            {
//                User_ID = Guid.NewGuid(),
//                User_Name = "TestUser",
//                Password = "TestPassword",
//                Email = "test@example.com",
//                Role = 1,
//                Status = true
//            }
//        };

//        _mediatorMock.Setup(m => m.Send(It.IsAny<AdminUserByIdQuery>(), default)).ReturnsAsync(response);

//        // Act
//        var result = await _controller.GetEventById(id);

//        // Assert
//        var okResult = Assert.IsType<OkObjectResult>(result);
//        var returnValue = Assert.IsType<AdminUserByIdVm>(okResult.Value);
//        Assert.Equal(response.Data.User_ID, returnValue.User_ID);
//    }



//    [Fact]
//    public async Task GetEventById_ReturnsBadRequest_WhenResponseIsNotSuccessful()
//    {
//        // Arrange
//        var id = "123";
//        var response = new Response<AdminUserByIdVm>
//        {
//            Succeeded = false,
//            Message = "Error occurred"
//        };

//        _mediatorMock.Setup(m => m.Send(It.IsAny<AdminUserByIdQuery>(), default)).ReturnsAsync(response);

//        // Act
//        var result = await _controller.GetEventById(id);

//        // Assert
//        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
//        Assert.Equal(response.Message, badRequestResult.Value);
//    }

//    [Fact]
//    public async Task Create_ReturnsOk_WhenResponseIsSuccessful()
//    {
//        // Arrange
//        var command = new CreateAdminUserCommand
//        {
//            User_Name = "TestUser",
//            Password = "TestPassword",
//            Role = 1,
//            Email = "test@example.com",
//            Status = true
//        };

//        var response = new Response<Application.Features.Admin_Users.Commands.CreateAdminUser.CreateAdminUserDto>
//        {
//            Succeeded = true,
//            Data = new Application.Features.Admin_Users.Commands.CreateAdminUser.CreateAdminUserDto
//            {
//                User_ID = Guid.NewGuid(),
//                User_Name = command.User_Name,
//                Password = command.Password,
//                Email = command.Email,
//                Role = command.Role,
//                Status = command.Status
//            }
//        };

//        _mediatorMock.Setup(m => m.Send(It.IsAny<CreateAdminUserCommand>(), default)).ReturnsAsync(response);

//        // Act
//        var result = await _controller.Create(command);

//        // Assert
//        var okResult = Assert.IsType<OkObjectResult>(result);
//        var returnValue = Assert.IsType<Response<Application.Features.Admin_Users.Commands.CreateAdminUser.CreateAdminUserDto>>(okResult.Value);
//        Assert.True(returnValue.Succeeded);
//        Assert.Equal(response.Data.User_ID, returnValue.Data.User_ID);
//    }

//    [Fact]
//    public async Task Create_ReturnsBadRequest_WhenResponseIsNotSuccessful()
//    {
//        // Arrange
//        var command = new CreateAdminUserCommand
//        {
//            User_Name = "TestUser",
//            Password = "TestPassword",
//            Role = 1,
//            Email = "test@example.com",
//            Status = true
//        };

//        var response = new Response<Application.Features.Admin_Users.Commands.CreateAdminUser.CreateAdminUserDto>
//        {
//            Succeeded = false,
//            Message = "Error occurred"
//        };

//        _mediatorMock.Setup(m => m.Send(It.IsAny<CreateAdminUserCommand>(), default)).ReturnsAsync(response);

//        // Act
//        var result = await _controller.Create(command);

//        // Assert
//        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
//        Assert.Equal(response.Message, badRequestResult.Value);
//    }

//    [Fact]
//    public async Task Update_ReturnsOk_WhenResponseIsSuccessful()
//    {
//        // Arrange
//        var command = new UpdateAdminUserCommand
//        {
//            User_ID = Guid.NewGuid(),
//            User_Name = "TestUser",
//            Password = "TestPassword",
//            Role = 1,
//            Email = "test@example.com",
//            Status = true
//        };

//        var response = new Response<UpdateAdminUserCommandDto>
//        {
//            Succeeded = true,
//            Data = new UpdateAdminUserCommandDto
//            {
//                User_ID = command.User_ID,
//                User_Name = command.User_Name,
//                Password = command.Password,
//                Email = command.Email,
//                Role = command.Role,
//                Status = command.Status
//            }
//        };

//        _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateAdminUserCommand>(), default)).ReturnsAsync(response);

//        // Act
//        var result = await _controller.Update(command.User_ID, command);

//        // Assert
//        var okResult = Assert.IsType<OkObjectResult>(result);
//        var returnValue = Assert.IsType<Response<UpdateAdminUserCommandDto>>(okResult.Value);
//        Assert.True(returnValue.Succeeded);
//        Assert.Equal(response.Data.User_ID, returnValue.Data.User_ID);
//    }

//    [Fact]
//    public async Task Update_ReturnsBadRequest_WhenIdMismatch()
//    {
//        // Arrange
//        var id = Guid.NewGuid();
//        var command = new UpdateAdminUserCommand
//        {
//            User_ID = Guid.NewGuid(),
//            User_Name = "TestUser",
//            Password = "TestPassword",
//            Role = 1,
//            Email = "test@example.com",
//            Status = true
//        };

//        // Act
//        var result = await _controller.Update(id, command);

//        // Assert
//        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
//        Assert.Equal("ID mismatch", badRequestResult.Value);
//    }

//    [Fact]
//    public async Task Update_ReturnsOk_WhenResponseIsNotSuccessful()
//    {
//        // Arrange
//        var command = new UpdateAdminUserCommand
//        {
//            User_ID = Guid.NewGuid(),
//            User_Name = "TestUser",
//            Password = "TestPassword",
//            Role = 1,
//            Email = "test@example.com",
//            Status = true
//        };

//        var response = new Response<UpdateAdminUserCommandDto>
//        {
//            Succeeded = false,
//            Message = "Error occurred"
//        };

//        _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateAdminUserCommand>(), default)).ReturnsAsync(response);

//        // Act
//        var result = await _controller.Update(command.User_ID, command);

//        // Assert
//        var okResult = Assert.IsType<OkObjectResult>(result);
//        var returnValue = Assert.IsType<Response<UpdateAdminUserCommandDto>>(okResult.Value);
//        Assert.False(returnValue.Succeeded);
//        Assert.Equal("Error occurred", returnValue.Message);
//    }

//    [Fact]
//    public async Task Delete_ReturnsNoContent_WhenDeletionIsSuccessful()
//    {
//        // Arrange
//        var id = Guid.NewGuid().ToString();
//        _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteAdminUserCommand>(), default)).ReturnsAsync(Unit.Value);

//        // Act
//        var result = await _controller.Delete(id);

//        // Assert
//        Assert.IsType<NoContentResult>(result);
//    }

//    [Fact]
//    public async Task Delete_ReturnsBadRequest_WhenIdIsInvalid()
//    {
//        // Arrange
//        var invalidId = "invalid-id";

//        // Act
//        var result = await _controller.Delete(invalidId);

//        // Assert
//        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
//        Assert.Equal("Invalid GUID format", badRequestResult.Value);
//    }

//    [Fact]
//    public async Task Delete_ReturnsNotFound_WhenDeletionFails()
//    {
//        // Arrange
//        var id = Guid.NewGuid().ToString();
//        _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteAdminUserCommand>(), default)).ThrowsAsync(new KeyNotFoundException("Resource not found"));

//        // Act
//        var result = await _controller.Delete(id);

//        // Assert
//        var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
//        Assert.Equal("Resource not found", notFoundResult.Value);
//    }

















//}
