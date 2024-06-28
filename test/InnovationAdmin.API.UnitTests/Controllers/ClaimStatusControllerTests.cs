
using InnovationAdmin.Api.Controllers;
using InnovationAdmin.Application.Features.ClaimStatus.Commands.CreateClaimStatus;
using InnovationAdmin.Application.Features.ClaimStatus.Commands.DeleteClaimStatus;
using InnovationAdmin.Application.Features.ClaimStatus.Commands.UpdateClaimStatus;
using InnovationAdmin.Application.Responses;
using Moq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

using Xunit;

namespace InnovationAdmin.API.UnitTests.Controllers
{
    public class ClaimStatusControllerTests
    { 
     [Fact]
    public async Task Create_OkResult_With_Valid_Input()
    {

        var createClaimStatusCommand = new CreateClaimStatusCommand
        {
            Name = "demo ",
            Color = "#fff"
        };

        var expectedResult = new Response<CreateClaimStatusDto>
        {
            Succeeded = true,
            Data = new CreateClaimStatusDto
            {
                ID = Guid.NewGuid(),
                Name = createClaimStatusCommand.Name,
                Color = createClaimStatusCommand.Color
            }
        };
        var mediatorMock = new Mock<IMediator>();
        mediatorMock.Setup(x => x.Send(It.IsAny<CreateClaimStatusCommand>(), default))
                    .ReturnsAsync(expectedResult);

        var loggerMock = new Mock<ILogger<ClaimStatusController>>();

        var controller = new ClaimStatusController(mediatorMock.Object, loggerMock.Object);


        var result = await controller.Create(createClaimStatusCommand) as OkObjectResult;


        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);

        var actualResult = result.Value as Response<CreateClaimStatusDto>;
        Assert.NotNull(actualResult);
        Assert.True(actualResult.Succeeded);
        Assert.NotNull(actualResult.Data);
        Assert.Equal(expectedResult.Data.ID, actualResult.Data.ID);
        Assert.Equal(expectedResult.Data.Name, actualResult.Data.Name);
        Assert.Equal(expectedResult.Data.Color, actualResult.Data.Color);
    }

    [Fact]
    public async Task Update__OkResult_With_Valid_Input()
    {
        var id = Guid.NewGuid();
        var updateClaimStatusCommand = new UpdateClaimStatusCommand
        {
            Id = id,
            Name = "Updated Claim Status",
            Color = "Updated Color of Claim Status"
        };
        var expectedResult = new Response<UpdateClaimStatusDto>
        {
            Succeeded = true,
            Data = new UpdateClaimStatusDto
            {
                Id = Guid.NewGuid(),
                Name = "Updated Claim Status Name",
                Color = "Updated Color of Claim Status"
            }
        };
        var mediatorMock = new Mock<IMediator>();
        mediatorMock.Setup(x => x.Send(updateClaimStatusCommand, default))
            .ReturnsAsync(expectedResult);
        var loggerMock = new Mock<ILogger<ClaimStatusController>>();
        var controller = new ClaimStatusController(mediatorMock.Object, loggerMock.Object);
        var result = await controller.Update(id, updateClaimStatusCommand) as OkObjectResult;
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal(expectedResult, result.Value);
    }

    [Fact]
    public async Task Update_Returns_BadRequest_When_ID_Mismatch()
    {
        var id = Guid.NewGuid();
        var updateClaimStatusCommand = new UpdateClaimStatusCommand
        {
            Id = Guid.NewGuid(),
            Name = "Updated Claim Status Name",
            Color = "Updated Color Of Claim Status"
        };
        var mediatorMock = new Mock<IMediator>();
        var loggerMock = new Mock<ILogger<ClaimStatusController>>();
        var controller = new ClaimStatusController(mediatorMock.Object, loggerMock.Object);
        var result = await controller.Update(id, updateClaimStatusCommand) as BadRequestObjectResult;
        Assert.NotNull(result);
        Assert.Equal(400, result.StatusCode);
        Assert.Equal("ID mismatch", result.Value);
    }

    [Fact]
    public async Task Delete_Returns_OkResult_When_Deletion_Successful()
    {
        var id = Guid.NewGuid();
        var expectedResult = new Response<bool>
        {
            Succeeded = true,
            Data = true
        };
        var mediatorMock = new Mock<IMediator>();
        mediatorMock.Setup(x => x.Send(It.IsAny<DeleteClaimStatusCommand>(), default))
            .ReturnsAsync(expectedResult);
        var loggerMock = new Mock<ILogger<ClaimStatusController>>();
        var controller = new ClaimStatusController(mediatorMock.Object, loggerMock.Object);
        var result = await controller.Delete(id) as OkObjectResult;
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal(expectedResult, result.Value);
    }
        
    [Fact]
    public async Task Delete_Returns_NotFound_When_Deletion_Unsuccessful()
    {
        var id = Guid.NewGuid();
        var expectedResult = new Response<bool>
        {
            Succeeded = true,
            Data = false
        };
        var mediatorMock = new Mock<IMediator>();
        mediatorMock.Setup(x => x.Send(It.IsAny<DeleteClaimStatusCommand>(), default))
            .ReturnsAsync(expectedResult);
        var loggerMock = new Mock<ILogger<ClaimStatusController>>();
        var controller = new ClaimStatusController(mediatorMock.Object, loggerMock.Object);
        var result = await controller.Delete(id) as NotFoundObjectResult;
        Assert.NotNull(result);
        Assert.Equal(404, result.StatusCode);
        Assert.Equal(expectedResult, result.Value);
    }
}
}
