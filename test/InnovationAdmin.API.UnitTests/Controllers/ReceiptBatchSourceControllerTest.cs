using InnovationAdmin.Api.Controllers;
using InnovationAdmin.Application.Features.ReceiptBatchSource.Commands.CraeateReceiptBatchSource;
using InnovationAdmin.Application.Features.ReceiptBatchSource.Commands.DeleteReceiptBatchSource;
using InnovationAdmin.Application.Features.ReceiptBatchSource.Commands.UpdateReceiptBatchSource;
using InnovationAdmin.Application.Features.ReceiptBatchSource.Queries.GetReceiptBatchSourceQuery;
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
    public class ReceiptBatchSourceControllerTest
    {
        [Fact]
        public async Task Create_OkResult_With_Valid_Input()
        {

            var createReceiptBatchSourceCommand = new CreateReceiptBatchSourceCommand
            {
                Name = "demo ",
                Type = "EDI"
            };

            var expectedResult = new Response<CreateReceiptBatchDto>
            {
                Succeeded = true,
                Data = new CreateReceiptBatchDto
                {
                    Id = Guid.NewGuid(),
                    Name = createReceiptBatchSourceCommand.Name,
                    Type = createReceiptBatchSourceCommand.Type
                }
            };
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(x => x.Send(It.IsAny<CreateReceiptBatchSourceCommand>(), default))
                        .ReturnsAsync(expectedResult);

            var loggerMock = new Mock<ILogger<ReceiptBatchSourceController>>();

            var controller = new ReceiptBatchSourceController(mediatorMock.Object, loggerMock.Object);


            var result = await controller.Create(createReceiptBatchSourceCommand) as OkObjectResult;


            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);

            var actualResult = result.Value as Response<CreateReceiptBatchDto>;
            Assert.NotNull(actualResult);
            Assert.True(actualResult.Succeeded);
            Assert.NotNull(actualResult.Data);
            Assert.Equal(expectedResult.Data.Id, actualResult.Data.Id);
            Assert.Equal(expectedResult.Data.Name, actualResult.Data.Name);
            Assert.Equal(expectedResult.Data.Type, actualResult.Data.Type);
        }

        [Fact]
        public async Task Update__OkResult_With_Valid_Input()
        {
            var id = Guid.NewGuid();
            var updateReceiptBAtchSourceCommand = new UpdateReceiptBAtchSourceCommand
            {
                Id = id,
                Name = "Updated Receipt Batch",
                Type = "Updated type of receipt batch"
            };
            var expectedResult = new Response<UpdateReceiptBAtchSourceDto>
            {
                Succeeded = true,
                Data = new UpdateReceiptBAtchSourceDto
                {
                    Id = Guid.NewGuid(),
                    Name = "Updated Receipt Batch Name",
                    Type = "Updated Type of Receipt Batch"
                }
            };
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(x => x.Send(updateReceiptBAtchSourceCommand, default))
                .ReturnsAsync(expectedResult);
            var loggerMock = new Mock<ILogger<ReceiptBatchSourceController>>();
            var controller = new ReceiptBatchSourceController(mediatorMock.Object, loggerMock.Object);
            var result = await controller.Update(id, updateReceiptBAtchSourceCommand) as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(expectedResult, result.Value);
        }

        [Fact]
        public async Task Update_Returns_BadRequest_When_ID_Mismatch()
        {
            var id = Guid.NewGuid();
            var updateReceiptBAtchSourceCommand = new UpdateReceiptBAtchSourceCommand
            {
                Id = Guid.NewGuid(),
                Name = "Updated Receipt Batch Name",
                Type = "Updated Type of Receipt Batch"
            };
            var mediatorMock = new Mock<IMediator>();
            var loggerMock = new Mock<ILogger<ReceiptBatchSourceController>>();
            var controller = new ReceiptBatchSourceController(mediatorMock.Object, loggerMock.Object);
            var result = await controller.Update(id, updateReceiptBAtchSourceCommand) as BadRequestObjectResult;
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
            mediatorMock.Setup(x => x.Send(It.IsAny<DeleteReceiptBatchSourceCommand>(), default))
                .ReturnsAsync(expectedResult);
            var loggerMock = new Mock<ILogger<ReceiptBatchSourceController>>();
            var controller = new ReceiptBatchSourceController(mediatorMock.Object, loggerMock.Object);
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
            mediatorMock.Setup(x => x.Send(It.IsAny<DeleteReceiptBatchSourceCommand>(), default))
                .ReturnsAsync(expectedResult);
            var loggerMock = new Mock<ILogger<ReceiptBatchSourceController>>();
            var controller = new ReceiptBatchSourceController(mediatorMock.Object, loggerMock.Object);
            var result = await controller.Delete(id) as NotFoundObjectResult;
            Assert.NotNull(result);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal(expectedResult, result.Value);
        }

        [Fact]
        public async Task GetSysPrefCompanyById_Returns_OkResult_With_Valid_Company()
        {
            var batchId = Guid.NewGuid();
            var expectedBatch = new ReceiptBatchSourceDto
            {
                Id = batchId,
                Name = "Test Batch",
                Type = "Test Type"
            };
            var expectedResult = new Response<ReceiptBatchSourceDto>
            {
                Succeeded = true,
                Data = expectedBatch
            };
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(x => x.Send(It.IsAny<GetReceiptBatchSourceByIdQuery>(), default))
                .ReturnsAsync(expectedResult);

            var loggerMock = new Mock<ILogger<ReceiptBatchSourceController>>();

            var controller = new ReceiptBatchSourceController(mediatorMock.Object, loggerMock.Object);
            var result = await controller.GetReceiptBatchSourceyById(batchId) as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);

            var responseData = result.Value as Response<ReceiptBatchSourceDto>;
            Assert.NotNull(responseData);
            Assert.True(responseData.Succeeded);
            Assert.NotNull(responseData.Data);
            Assert.Equal(expectedBatch, responseData.Data);
        }




    }
}

