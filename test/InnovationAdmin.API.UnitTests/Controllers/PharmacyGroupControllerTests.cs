using InnovationAdmin.Api.Controllers;
using InnovationAdmin.Application.Features.PharmacyGroup.Commands.CreatePharmacyGroup;
using InnovationAdmin.Application.Features.PharmacyGroup.Commands.DeletePharmacyGroup;
using InnovationAdmin.Application.Features.PharmacyGroup.Commands.UpdatePharmacyGroup;
using InnovationAdmin.Application.Features.PharmacyGroup.Queries.GetAllListPharmacyGroupQuery;
using InnovationAdmin.Application.Features.PharmacyGroup.Queries.GetPharmacyGroupQuery;
using InnovationAdmin.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace InnovationAdmin.API.UnitTests.Controllers
{
    public class PharmacyGroupControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<ILogger<CategoryController>> _loggerMock;
        private readonly CategoryController _controller;

        public PharmacyGroupControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _loggerMock = new Mock<ILogger<CategoryController>>();
            _controller = new CategoryController(_mediatorMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task CreatePharmacyGroup()
        {
            var createPharmacyGroupCommand = new CreatePharmacyGroupCommand
            {
                PharmacyName = "Pharma"
            };

            var expectedResult = new Response<CreatePharmacyGroupDto>
            {
                Succeeded = true,
                Data = new CreatePharmacyGroupDto
                {
                    Id = Guid.NewGuid(),
                    PharmacyName = createPharmacyGroupCommand.PharmacyName
                }
            };

            _mediatorMock.Setup(x => x.Send(It.IsAny<CreatePharmacyGroupCommand>(), default))
                         .ReturnsAsync(expectedResult);

            var result = await _controller.Create(createPharmacyGroupCommand) as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);

            var actualResult = result.Value as Response<CreatePharmacyGroupDto>;
            Assert.NotNull(actualResult);
            Assert.True(actualResult.Succeeded);
            Assert.NotNull(actualResult.Data);
            Assert.Equal(expectedResult.Data.PharmacyName, actualResult.Data.PharmacyName);
        }

        [Fact]
        public async Task CreateWhenPharmacyNameIsNull()
        {
            var createPharmacyGroupCommand = new CreatePharmacyGroupCommand
            {
                PharmacyName = null
            };

            var result = await _controller.Create(createPharmacyGroupCommand) as BadRequestObjectResult;

            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Pharmacy Name cannot be null or empty", result.Value);
        }

        [Fact]
        public async Task CreateWhenPharmacyNameIsEmpty()
        {
            var createPharmacyGroupCommand = new CreatePharmacyGroupCommand
            {
                PharmacyName = string.Empty
            };

            var result = await _controller.Create(createPharmacyGroupCommand) as BadRequestObjectResult;

            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Pharmacy Name cannot be null or empty", result.Value);
        }

        [Fact]
        public async Task Delete()
        {
            var pharmacyGroupId = Guid.NewGuid();
            var response = new Response<bool> { Succeeded = true, Data = false };

            _mediatorMock.Setup(m => m.Send(It.IsAny<DeletePharmacyGroupCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(response);

            var result = await _controller.Delete(pharmacyGroupId) as NotFoundObjectResult;

            Assert.NotNull(result);
            Assert.Equal(404, result.StatusCode);

            var actualResult = result.Value as Response<bool>;
            Assert.NotNull(actualResult);
            Assert.False(actualResult.Data);
        }

        [Fact]
        public async Task UpdateSuccessful()
        {
            var updatePharmacyGroupCommand = new UpdatePharmacyGroupCommand
            {
                Id = Guid.NewGuid(),
                PharmacyName = "Updated Pharmacy Name"
            };

            var response = new Response<UpdatePharmacyGroupDto>
            {
                Succeeded = true,
                Data = new UpdatePharmacyGroupDto
                {
                    Id = updatePharmacyGroupCommand.Id,
                    PharmacyName = updatePharmacyGroupCommand.PharmacyName
                }
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdatePharmacyGroupCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(response);

            var result = await _controller.Update(updatePharmacyGroupCommand.Id, updatePharmacyGroupCommand) as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);

            var actualResult = result.Value as Response<UpdatePharmacyGroupDto>;
            Assert.NotNull(actualResult);
            Assert.True(actualResult.Succeeded);
            Assert.Equal(updatePharmacyGroupCommand.PharmacyName, actualResult.Data.PharmacyName);
        }

        [Fact]
        public async Task UpdateWhenIdMismatch()
        {
            var updatePharmacyGroupCommand = new UpdatePharmacyGroupCommand
            {
                Id = Guid.NewGuid(),
                PharmacyName = "Updated Pharmacy Name"
            };

            var differentId = Guid.NewGuid();

            var result = await _controller.Update(differentId, updatePharmacyGroupCommand) as BadRequestObjectResult;

            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("ID mismatch", result.Value);
        }

        [Fact]
        public async Task UpdateWhenUpdateFails()
        {
             var updatePharmacyGroupCommand = new UpdatePharmacyGroupCommand
            {
                Id = Guid.NewGuid(),
                PharmacyName = "Updated Pharmacy Name"
            };

            var response = new Response<UpdatePharmacyGroupDto>
            {
                Succeeded = false,
                Message = "Update failed"
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdatePharmacyGroupCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(response);

            var result = await _controller.Update(updatePharmacyGroupCommand.Id, updatePharmacyGroupCommand) as BadRequestObjectResult;

            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);

            var actualResult = result.Value as Response<UpdatePharmacyGroupDto>;
            Assert.NotNull(actualResult);
            Assert.False(actualResult.Succeeded);
            Assert.Equal("Update failed", actualResult.Message);
        }

        [Fact]
        public async Task GetPharmacyGrouprByIdValidId()
        {
            var pharmacyGroupId = Guid.NewGuid();
            var response = new Response<PharmacyGroupDto>
            {
                Succeeded = true,
                Data = new PharmacyGroupDto
                {
                    Id = pharmacyGroupId,
                    PharmacyName = "Pharmacy Group 1"
                }
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetPharmacyGroupByIdQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(response);

           var result = await _controller.GetPharmacyGrouprById(pharmacyGroupId.ToString()) as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);

            var actualResult = result.Value as Response<PharmacyGroupDto>;
            Assert.NotNull(actualResult);
            Assert.True(actualResult.Succeeded);
            Assert.Equal(pharmacyGroupId, actualResult.Data.Id);
            Assert.Equal("Pharmacy Group 1", actualResult.Data.PharmacyName);
        }

        [Fact]
        public async Task GetPharmacyGrouprByIdWithInvalidIdFormat()
        {
            var invalidId = "invalid-guid";

            var result = await _controller.GetPharmacyGrouprById(invalidId) as BadRequestObjectResult;

            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Invalid ID format.", result.Value);
        }

        [Fact]
        public async Task GetPharmacyGroupWithPharmacyGroups()
        {
            var pharmacyGroups = new List<PharmacyGroupDto>
            {
                new PharmacyGroupDto { Id = Guid.NewGuid(), PharmacyName = "Pharmacy Group 1" },
                new PharmacyGroupDto { Id = Guid.NewGuid(), PharmacyName = "Pharmacy Group 2" }
            };

            var response = new Response<IEnumerable<PharmacyGroupDto>>
            {
                Succeeded = true,
                Data = pharmacyGroups
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllPharmacyGroupQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(response);

            var result = await _controller.GetPharmacyGroup() as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);

            var actualResult = result.Value as Response<IEnumerable<PharmacyGroupDto>>;
            Assert.NotNull(actualResult);
            Assert.True(actualResult.Succeeded);
            Assert.Equal(2, actualResult.Data.Count());
        }

        [Fact]
        public async Task GetPharmacyGroupWithEmptyList()
        {
            var response = new Response<IEnumerable<PharmacyGroupDto>>
            {
                Succeeded = true,
                Data = new List<PharmacyGroupDto>()
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllPharmacyGroupQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(response);

            var result = await _controller.GetPharmacyGroup() as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);

            var actualResult = result.Value as Response<IEnumerable<PharmacyGroupDto>>;
            Assert.NotNull(actualResult);
            Assert.True(actualResult.Succeeded);
            Assert.Empty(actualResult.Data);
        }
    }
}
