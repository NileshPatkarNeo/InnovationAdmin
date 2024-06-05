using InnovationAdmin.Api.Controllers;
using InnovationAdmin.Application.Features.SysPrefFinancials.Commands.CreateSysPrefFinancial;
using InnovationAdmin.Application.Features.SysPrefFinancials.Commands.DeleteSysPrefFinancial;
using InnovationAdmin.Application.Features.SysPrefFinancials.Commands.UpdateSysPrefFinancial;
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
    public class SysPrefFinancialControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<ILogger<SysPrefFinancialController>> _loggerMock;
        private readonly SysPrefFinancialController _controller;

        public SysPrefFinancialControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _loggerMock = new Mock<ILogger<SysPrefFinancialController>>();
            _controller = new SysPrefFinancialController(_mediatorMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task Create_ReturnsOkResult_WithCreatedSysPrefFinancial()
        {
            // Arrange
            var command = new CreateSysPrefFinancialCommand
            {
                CompanyID = Guid.NewGuid(),
                DefaultPaymentMethod = "Credit Card",
                LastCheckNo = 100,
                ClaimAgeCollectionStart = DateTime.UtcNow,
                ClaimAgeCollectionEnd = DateTime.UtcNow.AddDays(30),
                DefaultReceiptBatchDescription = "Monthly Receipts",
                ClaimPaidThreshold = 1000,
                ClaimStatusWriteOff = "WriteOff",
                DaysToBlock = 30
            };

            var responseDto = new CreateSysPrefFinancialDto
            {
                FinancialID = Guid.NewGuid(),
                CompanyID = command.CompanyID,
                DefaultPaymentMethod = command.DefaultPaymentMethod,
                LastCheckNo = command.LastCheckNo,
                ClaimAgeCollectionStart = command.ClaimAgeCollectionStart,
                ClaimAgeCollectionEnd = command.ClaimAgeCollectionEnd,
                DefaultReceiptBatchDescription = command.DefaultReceiptBatchDescription,
                ClaimPaidThreshold = command.ClaimPaidThreshold,
                ClaimStatusWriteOff = command.ClaimStatusWriteOff,
                DaysToBlock = command.DaysToBlock
            };

            var response = new Response<CreateSysPrefFinancialDto>
            {
                Data = responseDto,
                Message = "Created successfully"
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<CreateSysPrefFinancialCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.Create(command);

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);
            var returnedSysPrefFinancial = okResult.Value as SysPrefFinancial;
            Assert.NotNull(returnedSysPrefFinancial);
            Assert.Equal(responseDto.FinancialID, returnedSysPrefFinancial.FinancialID);
            Assert.Equal(responseDto.CompanyID, returnedSysPrefFinancial.CompanyID);
            Assert.Equal(responseDto.DefaultPaymentMethod, returnedSysPrefFinancial.DefaultPaymentMethod);
            Assert.Equal(responseDto.LastCheckNo, returnedSysPrefFinancial.LastCheckNo);
            Assert.Equal(responseDto.ClaimAgeCollectionStart, returnedSysPrefFinancial.ClaimAgeCollectionStart);
            Assert.Equal(responseDto.ClaimAgeCollectionEnd, returnedSysPrefFinancial.ClaimAgeCollectionEnd);
            Assert.Equal(responseDto.DefaultReceiptBatchDescription, returnedSysPrefFinancial.DefaultReceiptBatchDescription);
            Assert.Equal(responseDto.ClaimPaidThreshold, returnedSysPrefFinancial.ClaimPaidThreshold);
            Assert.Equal(responseDto.ClaimStatusWriteOff, returnedSysPrefFinancial.ClaimStatusWriteOff);
            Assert.Equal(responseDto.DaysToBlock, returnedSysPrefFinancial.DaysToBlock);
        }

        [Fact]
        public async Task Update_ReturnsOkResult_WithUpdatedSysPrefFinancial()
        {
            // Arrange
            var command = new UpdateSysPrefFinancialCommand
            {
                FinancialID = Guid.NewGuid(),
                CompanyID = Guid.NewGuid(),
                DefaultPaymentMethod = "Credit Card",
                LastCheckNo = 100,
                ClaimAgeCollectionStart = DateTime.UtcNow,
                ClaimAgeCollectionEnd = DateTime.UtcNow.AddDays(30),
                DefaultReceiptBatchDescription = "Monthly Receipts",
                ClaimPaidThreshold = 1000,
                ClaimStatusWriteOff = "WriteOff",
                DaysToBlock = 30
            };

            var responseDto = new UpdateSysPrefFinancialDto
            {
                FinancialID = command.FinancialID,
                CompanyID = command.CompanyID,
                DefaultPaymentMethod = command.DefaultPaymentMethod,
                LastCheckNo = command.LastCheckNo,
                ClaimAgeCollectionStart = command.ClaimAgeCollectionStart,
                ClaimAgeCollectionEnd = command.ClaimAgeCollectionEnd,
                DefaultReceiptBatchDescription = command.DefaultReceiptBatchDescription,
                ClaimPaidThreshold = command.ClaimPaidThreshold,
                ClaimStatusWriteOff = command.ClaimStatusWriteOff,
                DaysToBlock = command.DaysToBlock
            };

            var response = new Response<UpdateSysPrefFinancialDto>
            {
                Data = responseDto,
                Succeeded = true
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<UpdateSysPrefFinancialCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.Update(command);

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);
            var returnedSysPrefFinancial = okResult.Value as SysPrefFinancial;
            Assert.NotNull(returnedSysPrefFinancial);
            Assert.Equal(responseDto.FinancialID, returnedSysPrefFinancial.FinancialID);
            Assert.Equal(responseDto.CompanyID, returnedSysPrefFinancial.CompanyID);
            Assert.Equal(responseDto.DefaultPaymentMethod, returnedSysPrefFinancial.DefaultPaymentMethod);
            Assert.Equal(responseDto.LastCheckNo, returnedSysPrefFinancial.LastCheckNo);
            Assert.Equal(responseDto.ClaimAgeCollectionStart, returnedSysPrefFinancial.ClaimAgeCollectionStart);
            Assert.Equal(responseDto.ClaimAgeCollectionEnd, returnedSysPrefFinancial.ClaimAgeCollectionEnd);
            Assert.Equal(responseDto.DefaultReceiptBatchDescription, returnedSysPrefFinancial.DefaultReceiptBatchDescription);
            Assert.Equal(responseDto.ClaimPaidThreshold, returnedSysPrefFinancial.ClaimPaidThreshold);
            Assert.Equal(responseDto.ClaimStatusWriteOff, returnedSysPrefFinancial.ClaimStatusWriteOff);
            Assert.Equal(responseDto.DaysToBlock, returnedSysPrefFinancial.DaysToBlock);
        }

        [Fact]
        public async Task Update_ReturnsNotFoundResult_WhenResponseIsNull()
        {
            // Arrange
            var command = new UpdateSysPrefFinancialCommand
            {
                FinancialID = Guid.NewGuid(),
                CompanyID = Guid.NewGuid(),
                DefaultPaymentMethod = "Credit Card",
                LastCheckNo = 100,
                ClaimAgeCollectionStart = DateTime.UtcNow,
                ClaimAgeCollectionEnd = DateTime.UtcNow.AddDays(30),
                DefaultReceiptBatchDescription = "Monthly Receipts",
                ClaimPaidThreshold = 1000,
                ClaimStatusWriteOff = "WriteOff",
                DaysToBlock = 30
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<UpdateSysPrefFinancialCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((Response<UpdateSysPrefFinancialDto>)null);

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
                .Setup(m => m.Send(It.IsAny<DeleteSysPrefFinancialCommand>(), It.IsAny<CancellationToken>()))
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
