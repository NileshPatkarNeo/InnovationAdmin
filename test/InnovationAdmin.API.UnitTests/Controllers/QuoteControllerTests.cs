using InnovationAdmin.Api.Controllers;
using InnovationAdmin.Application.Features.Quote.Commands.CreateQuote;
using InnovationAdmin.Application.Features.Quote.Commands.DeleteQuote;
using InnovationAdmin.Application.Features.Quote.Commands.UpdateQuote;
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
    public class QuoteControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<ILogger<QuoteController>> _loggerMock;
        private readonly QuoteController _controller;

        public QuoteControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _loggerMock = new Mock<ILogger<QuoteController>>();
            _controller = new QuoteController(_mediatorMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task Create_ReturnsOkResult_WithCreatedQuote()
        {
            // Arrange
            var command = new CreateQuoteCommand
            {
                Name = "Test Quote",
                QuoteBy = "Test Author"
            };

            var responseDto = new CreateQuoteDto
            {
                ID = Guid.NewGuid(),
                Name = command.Name,
                QuoteBy = command.QuoteBy
            };

            var response = new Response<CreateQuoteDto>
            {
                Data = responseDto,
                Message = "Success"
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<CreateQuoteCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.Create(command);

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);
            var returnedQuote = okResult.Value as Quotes;
            Assert.NotNull(returnedQuote);
            Assert.Equal(responseDto.ID, returnedQuote.ID);
            Assert.Equal(responseDto.Name, returnedQuote.Name);
            Assert.Equal(responseDto.QuoteBy, returnedQuote.QuoteBy);
        }

        [Fact]
        public async Task Update_ReturnsOkResult_WithUpdatedQuote()
        {
            // Arrange
            var command = new UpdateQuoteCommand
            {
                ID = Guid.NewGuid(),
                Name = "Updated Quote",
                QuoteBy = "Updated Author"
            };

            var responseDto = new UpdateQuoteDto
            {
                ID = command.ID,
                Name = command.Name,
                QuoteBy = command.QuoteBy
            };

            var response = new Response<UpdateQuoteDto>
            {
                Data = responseDto,
                Succeeded = true
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<UpdateQuoteCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.Update(command);

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);
            var returnedQuote = okResult.Value as Quotes;
            Assert.NotNull(returnedQuote);
            Assert.Equal(responseDto.ID, returnedQuote.ID);
            Assert.Equal(responseDto.Name, returnedQuote.Name);
            Assert.Equal(responseDto.QuoteBy, returnedQuote.QuoteBy);
        }

        [Fact]
        public async Task Update_ReturnsNotFoundResult_WhenResponseIsNull()
        {
            // Arrange
            var command = new UpdateQuoteCommand
            {
                ID = Guid.NewGuid(),
                Name = "Updated Quote",
                QuoteBy = "Updated Author"
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<UpdateQuoteCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((Response<UpdateQuoteDto>)null);

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
                .Setup(m => m.Send(It.IsAny<DeleteQuoteCommand>(), It.IsAny<CancellationToken>()))
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
