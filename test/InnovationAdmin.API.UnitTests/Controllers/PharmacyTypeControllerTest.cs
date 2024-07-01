using InnovationAdmin.Api.Controllers;
using InnovationAdmin.Application.Features.PharmacyType.Commands.CreatePharmacyType;
using InnovationAdmin.Application.Features.PharmacyType.Commands.DeletePharmacyType;
using InnovationAdmin.Application.Features.PharmacyType.Commands.UpdatePharmacyType;
using InnovationAdmin.Application.Features.PharmacyType.Queries.GetPharmacyTypeQuery;
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
    public class PharmacyTypeControllerTest
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<ILogger<PharmacyTypeController>> _loggerMock;
        private readonly PharmacyTypeController _controller;

        public PharmacyTypeControllerTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _loggerMock = new Mock<ILogger<PharmacyTypeController>>();
            _controller = new PharmacyTypeController(_mediatorMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task Create_IsNull()
        {
            // Arrange
            CreatePharmacyTypeCommand command = null;

            // Act
            var result = await _controller.Create(command);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);

            var response = badRequestResult.Value as InnovationAdmin.Application.Responses.Response<CreatePharmacyTypeDto>;
            Assert.NotNull(response);
            Assert.False(response.Succeeded);
            Assert.Equal("Invalid input", response.Message);
        }

        [Fact]
        public async Task Create_Valid()
        {
            // Arrange
            var command = new CreatePharmacyTypeCommand { Description = "Pharmacy A", Code = 123 };
            var response = new InnovationAdmin.Application.Responses.Response<CreatePharmacyTypeDto>
            {
                Succeeded = true,
                Data = new CreatePharmacyTypeDto { Id = Guid.NewGuid(), Description = "Pharmacy A", Code = 123 }
            };
            _mediatorMock.Setup(m => m.Send(command, default)).ReturnsAsync(response);

            // Act
            var result = await _controller.Create(command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(response, okResult.Value);
        }

        [Fact]
        public async Task GetById_IsValid()
        {
            // Arrange
            var validId = Guid.NewGuid();
            var query = new GetPharmacyTypeByIdQuery { Id = validId };
            var response = new InnovationAdmin.Application.Responses.Response<PharmacyTypeDto>
            {
                Succeeded = true,
                Data = new PharmacyTypeDto { Id = validId, Description = "Pharmacy A", Code = 123 }
            };
            _mediatorMock.Setup(m => m.Send(It.Is<GetPharmacyTypeByIdQuery>(q => q.Id == validId), default)).ReturnsAsync(response);

            // Act
            var result = await _controller.GetPharmacyTypeById(validId.ToString());

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(response, okResult.Value);
        }


        [Fact]
        public async Task GetById_IsNull()
        {
            // Arrange
            var validId = Guid.NewGuid();
            var query = new GetPharmacyTypeByIdQuery { Id = validId };
            _mediatorMock.Setup(m => m.Send(query, default)).ReturnsAsync((InnovationAdmin.Application.Responses.Response<PharmacyTypeDto>)null);

            // Act
            var result = await _controller.GetPharmacyTypeById(validId.ToString());

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(404, notFoundResult.StatusCode);
            Assert.Equal("System preference not found.", notFoundResult.Value);
        }

        [Fact]
        public async Task Update_IdMismatch()
        {
            // Arrange
            var id = Guid.NewGuid();
            var updateCommand = new UpdatePharmacyTypeCommand
            {
                Id = Guid.NewGuid(), // Different ID
                Description = "Updated Pharmacy",
                Code = 456
            };

            // Act
            var result = await _controller.Update(id, updateCommand);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);
            Assert.Equal("ID mismatch", badRequestResult.Value);
        }

        
        [Fact]
        public async Task Update_Successful()
        {
            // Arrange
            var id = Guid.NewGuid();
            var updateCommand = new UpdatePharmacyTypeCommand
            {
                Id = id,
                Description = "Updated Pharmacy",
                Code = 456
            };
            var response = new InnovationAdmin.Application.Responses.Response<UpdatePharmacyTypeDto>
            {
                Succeeded = true,
                Data = new UpdatePharmacyTypeDto { Id = id, Description = "Updated Pharmacy", Code = 456 }
            };
            _mediatorMock.Setup(m => m.Send(updateCommand, default)).ReturnsAsync(response);

            // Act
            var result = await _controller.Update(id, updateCommand);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(response, okResult.Value);
        }

       
        [Fact]
        public async Task Delete()
        {
            var pharmacyGroupId = Guid.NewGuid();
            var response = new InnovationAdmin.Application.Responses.Response<bool> { Succeeded = true, Data = false };

            _mediatorMock.Setup(m => m.Send(It.IsAny<DeletePharmacyTypeCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(response);

            var result = await _controller.Delete(pharmacyGroupId) as NotFoundObjectResult;

            Assert.NotNull(result);
            Assert.Equal(404, result.StatusCode);

            var actualResult = result.Value as InnovationAdmin.Application.Responses.Response<bool>;
            Assert.NotNull(actualResult);
            Assert.False(actualResult.Data);
        }

    }
}
