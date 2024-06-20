using InnovationAdmin.Api.Controllers;
using InnovationAdmin.Application.Features.CorrespondenceNotes.Commands.CreateCorrespondenceNote;
using InnovationAdmin.Application.Features.CorrespondenceNotes.Commands.DeleteCorrespondenceNote;
using InnovationAdmin.Application.Features.CorrespondenceNotes.Commands.UpdateCorrespondenceNote;
using InnovationAdmin.Application.Features.CorrespondenceNotes.Queries.GetCorrespondenceNoteQuery;
using InnovationAdmin.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace InnovationAdmin.API.UnitTests.Controllers
{
    public class CorrespondenceNoteControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<ILogger<CorrespondenceNotesController>> _loggerMock;
        private readonly CorrespondenceNotesController _controller;

        public CorrespondenceNoteControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _loggerMock = new Mock<ILogger<CorrespondenceNotesController>>();
            _controller = new CorrespondenceNotesController(_mediatorMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task CreateNoteIsNullOrEmptyReturnsBadRequest()
        {
            var command = new CreateCorrespondenceNoteCommand { Note = "" };

            var result = await _controller.Create(command);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Correspondence Note cannot be null or empty", badRequestResult.Value);
        }

        [Fact]
        public async Task CreateSucceededReturnsOk()
        {
            var command = new CreateCorrespondenceNoteCommand { Note = "Test Note" };
            var response = new Response<CreateCorrespondenceNoteDto> { Succeeded = true };
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateCorrespondenceNoteCommand>(), default)).ReturnsAsync(response);

            var result = await _controller.Create(command);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(response, okResult.Value);
        }

        [Fact]
        public async Task DeleteSuccessfulReturnsOk()
        {
            var id = Guid.NewGuid();
            var response = new Response<bool> { Succeeded = true, Data = true };
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteCorrespondenceNoteCommand>(), default)).ReturnsAsync(response);

            var result = await _controller.Delete(id);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(response, okResult.Value);
        }

        [Fact]
        public async Task DeleteNotFoundReturnsNotFound()
        {
            var id = Guid.NewGuid();
            var response = new Response<bool> { Succeeded = true, Data = false };
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteCorrespondenceNoteCommand>(), default)).ReturnsAsync(response);

            var result = await _controller.Delete(id);

            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(response, notFoundResult.Value);
        }

        [Fact]
        public async Task UpdateIdMismatchReturnsBadRequest()
        {
            var id = Guid.NewGuid();
            var command = new UpdateCorrespondenceNoteCommand { Id = Guid.NewGuid(), Note = "Updated Note" };

            var result = await _controller.Update(id, command);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("ID mismatch", badRequestResult.Value);
        }

        [Fact]
        public async Task UpdateSucceededReturnsOk()
        {
            var id = Guid.NewGuid();
            var command = new UpdateCorrespondenceNoteCommand { Id = id, Note = "Updated Note" };
            var response = new Response<UpdateCorrespondenceNoteDto> { Succeeded = true, Data = new UpdateCorrespondenceNoteDto { Id = id, Note = "Updated Note" } };
            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateCorrespondenceNoteCommand>(), default)).ReturnsAsync(response);

            var result = await _controller.Update(id, command);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(response, okResult.Value);
        }

        [Fact]
        public async Task GetCorrespondenceNoteByIdNotFoundReturnsNotFound()
        {
            var id = Guid.NewGuid().ToString();
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetCorrespondenceNoteByIdQuery>(), default)).ReturnsAsync((Response<CorrespondenceNoteDto>)null);

            var result = await _controller.GetCorrespondenceNoteById(id);

            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("Correspondence Note not found.", notFoundResult.Value);
        }

        [Fact]
        public async Task GetCorrespondenceNoteByIdSuccessReturnsOk()
        {
            var id = Guid.NewGuid();
            var response = new Response<CorrespondenceNoteDto>
            {
                Succeeded = true,
                Data = new CorrespondenceNoteDto { Id = id, Note = "Test Note" }
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetCorrespondenceNoteByIdQuery>(), default)).ReturnsAsync(response);

            var result = await _controller.GetCorrespondenceNoteById(id.ToString());

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(response, okResult.Value);
        }


    }
}
