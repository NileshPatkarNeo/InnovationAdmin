using InnovationAdmin.Api.Controllers;
using InnovationAdmin.Application.Features.DoNotTakeGroup.Commands.CreateDoNotTakeGroup;
using InnovationAdmin.Application.Features.DoNotTakeGroup.Commands.DeleteDoNotGroup;
using InnovationAdmin.Application.Features.DoNotTakeGroup.Commands.UpdateDoNotTakeGroup;
using InnovationAdmin.Application.Features.DoNotTakeGroup.Queries.GetDoNotTakeGroupQuery;
using InnovationAdmin.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace InnovationAdmin.API.UnitTests.Controllers
{
    public class DoNotTakeGroupsControllerTest
    {
        [Fact]
        public async Task Create_OkResult_With_Valid_Input()
        {

            var createDoNotTakeGroupCommand = new CreateDoNotTakeGroupCommand
            {
                GroupName = "demo",
                GroupCode = 2333222
            };

            var expectedResult = new Response<CreateDoNoTakeGroupDto>
            {
                Succeeded = true,
                Data = new CreateDoNoTakeGroupDto
                {
                    Id = Guid.NewGuid(),
                    GroupName = createDoNotTakeGroupCommand.GroupName,
                    GroupCode = createDoNotTakeGroupCommand.GroupCode
                }
            };
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(x => x.Send(It.IsAny<CreateDoNotTakeGroupCommand>(), default))
                        .ReturnsAsync(expectedResult);

            var loggerMock = new Mock<ILogger<DoNotTakeGroupController>>();

            var controller = new DoNotTakeGroupController(mediatorMock.Object, loggerMock.Object);


            var result = await controller.Create(createDoNotTakeGroupCommand) as OkObjectResult;


            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);

            var actualResult = result.Value as Response<CreateDoNoTakeGroupDto>;
            Assert.NotNull(actualResult);
            Assert.True(actualResult.Succeeded);
            Assert.NotNull(actualResult.Data);
            Assert.Equal(expectedResult.Data.Id, actualResult.Data.Id);
            Assert.Equal(expectedResult.Data.GroupName, actualResult.Data.GroupName);
            Assert.Equal(expectedResult.Data.GroupCode, actualResult.Data.GroupCode);
        }

        [Fact]
        public async Task Update__OkResult_With_Valid_Input()
        {
            var id = Guid.NewGuid();
            var updateDoNotTakeGroupCommand = new UpdateDoNotTakeGroupCommand
            {
                Id = id,
                GroupName = "Updated  Group Name",
                GroupCode = 36757
            };
            var expectedResult = new Response<UpdateDoNotTakeGroupDto>
            {
                Succeeded = true,
                Data = new UpdateDoNotTakeGroupDto
                {
                    Id = Guid.NewGuid(),
                    GroupName = "Updated Group Name",
                     GroupCode = 36757
                }
            };
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(x => x.Send(updateDoNotTakeGroupCommand, default))
                .ReturnsAsync(expectedResult);
            var loggerMock = new Mock<ILogger<DoNotTakeGroupController>>();
            var controller = new DoNotTakeGroupController(mediatorMock.Object, loggerMock.Object);
            var result = await controller.Update(id,  updateDoNotTakeGroupCommand  ) as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(expectedResult, result.Value);
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
            mediatorMock.Setup(x => x.Send(It.IsAny<DeleteDoNotTakeGroupCommand>(), default))
                .ReturnsAsync(expectedResult);
            var loggerMock = new Mock<ILogger<DoNotTakeGroupController>>();
            var controller = new DoNotTakeGroupController(mediatorMock.Object, loggerMock.Object);
            var result = await controller.Delete(id) as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(expectedResult, result.Value);
        }

        [Fact]
        public async Task GetSysPrefCompanyById_Returns_OkResult_With_Valid_Company()
        {
            var batchId = Guid.NewGuid();
            var expectedBatch = new DoNotTakeGroupDto
            {
                Id = batchId,
                GroupName = "Test Batch",
                 GroupCode = 54635
            };
            var expectedResult = new Response<DoNotTakeGroupDto>
            {
                Succeeded = true,
                Data = expectedBatch
            };
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(x => x.Send(It.IsAny<GetDoNotTakeGroupByIdQuery>(), default))
                .ReturnsAsync(expectedResult);

            var loggerMock = new Mock<ILogger<DoNotTakeGroupController>>();

            var controller = new DoNotTakeGroupController(mediatorMock.Object, loggerMock.Object);
            var result = await controller.GetDoNotTakeGroupById(batchId) as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);

            var responseData = result.Value as Response<DoNotTakeGroupDto>;
            Assert.NotNull(responseData);
            Assert.True(responseData.Succeeded);
            Assert.NotNull(responseData.Data);
            Assert.Equal(expectedBatch, responseData.Data);
        }
    }
}
