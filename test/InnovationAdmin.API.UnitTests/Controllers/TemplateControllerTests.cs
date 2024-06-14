using InnovationAdmin.Api.Controllers;
using InnovationAdmin.Application.Features.Template.Commands.CreateTemplate;
using InnovationAdmin.Application.Features.Template.Commands.DeleteTemplate;
using InnovationAdmin.Application.Features.Template.Commands.UpdateTemplate;
using InnovationAdmin.Application.Features.Template.Queries.GetTemplate;
using InnovationAdmin.Application.Features.Template.Queries.GetTemplateList;
using InnovationAdmin.Application.Features.Template.Queries.GetTemplatesList;
using InnovationAdmin.Application.Responses;
using InnovationAdmin.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace InnovationAdmin.API.UnitTests.Controllers
{
    public class TemplateControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<ILogger<TemplateController>> _loggerMock;
        private readonly TemplateController _controller;

        public TemplateControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _loggerMock = new Mock<ILogger<TemplateController>>();
            _controller = new TemplateController(_mediatorMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task Create_ReturnsOkResult_WithCreatedTemplate()
        {
            // Arrange
            var command = new CreateTemplateCommand
            {
                Name = "Test Template",
                PdfTemplateFile = "test.pdf",
                Domain = "test.com",
                Size = "A4"
            };

            var responseDto = new CreateTemplateDto
            {
                ID = Guid.NewGuid(),
                Name = command.Name,
                PdfTemplateFile = command.PdfTemplateFile,
                Domain = command.Domain,
                Size = command.Size
            };

            var response = new Response<CreateTemplateDto>
            {
                Data = responseDto,
                Message = "Success"
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<CreateTemplateCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.Create(command);

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);
            var returnedTemplate = okResult.Value as Templates;
            Assert.NotNull(returnedTemplate);
            Assert.Equal(responseDto.ID, returnedTemplate.ID);
            Assert.Equal(responseDto.Name, returnedTemplate.Name);
            Assert.Equal(responseDto.PdfTemplateFile, returnedTemplate.PdfTemplateFile);
            Assert.Equal(responseDto.Domain, returnedTemplate.Domain);
            Assert.Equal(responseDto.Size, returnedTemplate.Size);
        }

       

        [Fact]
        public async Task Update_ReturnsOkResult_WithUpdatedTemplate()
        {
            // Arrange
            var command = new UpdateTemplateCommand
            {
                ID = Guid.NewGuid(),
                Name = "Updated Template",
                PdfTemplateFile = "updated.pdf",
                Domain = "updated.com",
                Size = "A3"
            };

            var responseDto = new UpdateTemplateDto
            {
                ID = command.ID,
                Name = command.Name,
                PdfTemplateFile = command.PdfTemplateFile,
                Domain = command.Domain,
                Size = command.Size
            };

            var response = new Response<UpdateTemplateDto>
            {
                Data = responseDto,
                Succeeded = true
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<UpdateTemplateCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.Update(command);

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);
            var returnedTemplate = okResult.Value as Templates;
            Assert.NotNull(returnedTemplate);
            Assert.Equal(responseDto.ID, returnedTemplate.ID);
            Assert.Equal(responseDto.Name, returnedTemplate.Name);
            Assert.Equal(responseDto.PdfTemplateFile, returnedTemplate.PdfTemplateFile);
            Assert.Equal(responseDto.Domain, returnedTemplate.Domain);
            Assert.Equal(responseDto.Size, returnedTemplate.Size);
        }

        [Fact]
        public async Task Update_ReturnsNotFoundResult_WhenResponseIsNull()
        {
            // Arrange
            var command = new UpdateTemplateCommand
            {
                ID = Guid.NewGuid(),
                Name = "Updated Template",
                PdfTemplateFile = "updated.pdf",
                Domain = "updated.com",
                Size = "A3"
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<UpdateTemplateCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((Response<UpdateTemplateDto>)null);

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
                .Setup(m => m.Send(It.IsAny<DeleteTemplateCommand>(), It.IsAny<CancellationToken>()))
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

        [Fact]
        public async Task GetById_ReturnsOkResult_WhenResponseIsSuccessful()
        {
            // Arrange
            var id = Guid.NewGuid();
            var query = new GetTemplateDetailQuery { ID = id };
            var expectedResponse = new Response<TemplateVM>
            {
                Succeeded = true,
                Data = new TemplateVM
                {
                    ID = id,
                    Name = "Valid Template",
                    PdfTemplateFile = "template.pdf",
                    Domain = "example.com",
                    Size = "A4"
                }
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetTemplateDetailQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.GetById(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var response = Assert.IsType<Response<TemplateVM>>(okResult.Value);
            Assert.True(response.Succeeded);

            var template = Assert.IsType<TemplateVM>(response.Data);
            Assert.Equal(expectedResponse.Data.ID, template.ID);
            Assert.Equal(expectedResponse.Data.Name, template.Name);
            Assert.Equal(expectedResponse.Data.PdfTemplateFile, template.PdfTemplateFile);
            Assert.Equal(expectedResponse.Data.Domain, template.Domain);
            Assert.Equal(expectedResponse.Data.Size, template.Size);
        }

      
    }
}
