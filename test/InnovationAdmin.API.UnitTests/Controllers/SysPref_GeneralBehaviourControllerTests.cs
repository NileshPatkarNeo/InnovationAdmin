using InnovationAdmin.Api.Controllers;
using InnovationAdmin.Application.Features.SysPref_GeneralBehaviour.Commands.Create_SysPref_GeneralBehaviour;
using InnovationAdmin.Application.Features.SysPref_GeneralBehaviour.Commands.Delete_SysPref_GeneralBehaviour;
using InnovationAdmin.Application.Features.SysPref_GeneralBehaviour.Commands.Update_SysPref_GeneralBehaviour;
using InnovationAdmin.Application.Features.SysPref_GeneralBehaviour.Queries.Get_SysPref_GeneralBehaviour_List;
using InnovationAdmin.Application.Features.SysPref_GeneralBehaviour.Queries.GetById_SysPref_GeneralBehaviour;
using InnovationAdmin.Application.Responses;
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
    public class SysPref_GeneralBehaviourControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<ILogger<SysPref_GeneralBehaviourController>> _loggerMock;

        private readonly SysPref_GeneralBehaviourController _controller;

        public SysPref_GeneralBehaviourControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _loggerMock = new Mock<ILogger<SysPref_GeneralBehaviourController>>();
            _controller = new SysPref_GeneralBehaviourController(_mediatorMock.Object, _loggerMock.Object);
        }



        [Fact]
        public async Task Create_ShouldReturnBadRequest_WhenCommandIsNotValid()
        {
            var command = new Create_SysPref_GeneralBehaviour_Command
            {
                Auto_Change_Claim_Status = true,
                Claim_Status_Receipting = false,
                Claim_Status_Payment = true,
                Claim_Status_Zero_Paid = false,
                Claim_Status_Procare_Claim_Load = true,
                Logout_Redirect = false,
                Records_Locked_Seconds = -9, 
                User_Timeout = 0 
            };

            _controller.ModelState.AddModelError("Records_Locked_Seconds", "Records_Locked_Seconds must be greater than 0");
            _controller.ModelState.AddModelError("User_Timeout", "User_Timeout must be greater than 0");

            var result = await _controller.Create(command);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var modelState = Assert.IsType<SerializableError>(badRequestResult.Value);
            Assert.True(modelState.ContainsKey("Records_Locked_Seconds"));
            Assert.True(modelState.ContainsKey("User_Timeout"));
        }

        

        [Fact]
        public async Task Update_ShouldReturnOkResult_WhenCommandIsValid()
        {
            var command = new Update_SysPref_GeneralBehaviour_Command
            {
                Preference_ID = Guid.NewGuid(),
                Auto_Change_Claim_Status = true,
                Claim_Status_Receipting = false,
                Claim_Status_Payment = true,
                Claim_Status_Zero_Paid = false,
                Claim_Status_Procare_Claim_Load = true,
                Logout_Redirect = false,
                Records_Locked_Seconds = 300,
                User_Timeout = 120
            };

            var responseDto = new Update_SysPref_GeneralBehaviour_Dto
            {
                Preference_ID = command.Preference_ID,
                Auto_Change_Claim_Status = command.Auto_Change_Claim_Status,
                Claim_Status_Receipting = command.Claim_Status_Receipting,
                Claim_Status_Payment = command.Claim_Status_Payment,
                Claim_Status_Zero_Paid = command.Claim_Status_Zero_Paid,
                Claim_Status_Procare_Claim_Load = command.Claim_Status_Procare_Claim_Load,
                Logout_Redirect = command.Logout_Redirect,
                Records_Locked_Seconds = command.Records_Locked_Seconds,
                User_Timeout = command.User_Timeout
            };

            var response = new Response<Update_SysPref_GeneralBehaviour_Dto>
            {
                Data = responseDto,
                Message = "Success"
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<Update_SysPref_GeneralBehaviour_Command>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            var result = await _controller.Update(command);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedResponse = Assert.IsType<Response<Update_SysPref_GeneralBehaviour_Dto>>(okResult.Value);
            Assert.Equal(responseDto, returnedResponse.Data);
        }

        [Fact]
        public async Task Update_ShouldReturnBadRequest_WhenCommandIsNotValid()
        {

            var command = new Update_SysPref_GeneralBehaviour_Command
            {
                Preference_ID = Guid.Empty, 
                Auto_Change_Claim_Status = true,
                Claim_Status_Receipting = false,
                Claim_Status_Payment = true,
                Claim_Status_Zero_Paid = false,
                Claim_Status_Procare_Claim_Load = true,
                Logout_Redirect = false,
                Records_Locked_Seconds = -1, 
                User_Timeout = 0 
            };

            _controller.ModelState.AddModelError("Preference_ID", "Invalid GUID format");
            _controller.ModelState.AddModelError("Records_Locked_Seconds", "Records_Locked_Seconds must be greater than 0");
            _controller.ModelState.AddModelError("User_Timeout", "User_Timeout must be greater than 0");

            var result = await _controller.Update(command);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var modelState = Assert.IsType<SerializableError>(badRequestResult.Value);
            Assert.True(modelState.ContainsKey("Preference_ID"));
            Assert.True(modelState.ContainsKey("Records_Locked_Seconds"));
            Assert.True(modelState.ContainsKey("User_Timeout"));
        }


        [Fact]
        public async Task Delete_ShouldReturnNoContent_WhenCommandIsValid()
        {
            var id = Guid.NewGuid().ToString();

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<Delete_SysPref_GeneralBehaviour_Command>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Unit.Value);

            var result = await _controller.Delete(id);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Delete_ShouldReturnBadRequest_WhenCommandIsNotValid()
        {
            var invalidId = "invalid-guid";

            var result = await _controller.Delete(invalidId);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Invalid GUID format", badRequestResult.Value);
        }


        [Fact]
        public async Task GetAllSysPref_ShouldReturnOkResult_WithListOfSysPref()
        {
            var sysPrefList = new List<SysPref_GeneralBehaviour_ListVM>
            {
                new SysPref_GeneralBehaviour_ListVM
                {
                    Preference_ID = Guid.NewGuid(),
                    Auto_Change_Claim_Status = true,
                    Claim_Status_Receipting = false,
                    Claim_Status_Payment = true,
                    Claim_Status_Zero_Paid = false,
                    Claim_Status_Procare_Claim_Load = true,
                    Logout_Redirect = false,
                    Records_Locked_Seconds = 300,
                    User_Timeout = 120
                },
                new SysPref_GeneralBehaviour_ListVM
                {
                    Preference_ID = Guid.NewGuid(),
                    Auto_Change_Claim_Status = false,
                    Claim_Status_Receipting = true,
                    Claim_Status_Payment = false,
                    Claim_Status_Zero_Paid = true,
                    Claim_Status_Procare_Claim_Load = false,
                    Logout_Redirect = true,
                    Records_Locked_Seconds = 600,
                    User_Timeout = 240
                }
            };

            var response = new Response<IEnumerable<SysPref_GeneralBehaviour_ListVM>>
            {
                Data = sysPrefList,
                Message = "Success"
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<Get_SysPref_GeneralBehaviour_List_Query>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            var result = await _controller.GetAllSysPref();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedResponse = Assert.IsType<Response<IEnumerable<SysPref_GeneralBehaviour_ListVM>>>(okResult.Value);
            Assert.Equal(sysPrefList, returnedResponse.Data);
        }


        [Fact]
        public async Task GetSysPref_GeneralBehaviourId_ShouldReturnOkResult_WithSysPref()
        {
            var preferenceId = Guid.NewGuid();
            var sysPref = new GetById_SysPref_GeneralBehaviours_VM
            {
                Preference_ID = preferenceId,
                Auto_Change_Claim_Status = true,
                Claim_Status_Receipting = false,
                Claim_Status_Payment = true,
                Claim_Status_Zero_Paid = false,
                Claim_Status_Procare_Claim_Load = true,
                Logout_Redirect = false,
                Records_Locked_Seconds = 300,
                User_Timeout = 120
            };

            var response = new Response<GetById_SysPref_GeneralBehaviours_VM>
            {
                Data = sysPref,
                Message = "Success"
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetById_SysPref_GeneralBehaviours_Query>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            var result = await _controller.GetSysPref_GeneralBehaviourId(preferenceId.ToString());

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedResponse = Assert.IsType<Response<GetById_SysPref_GeneralBehaviours_VM>>(okResult.Value);
            Assert.Equal(sysPref, returnedResponse.Data);
        }

        [Fact]
        public async Task GetSysPref_GeneralBehaviourId_ShouldReturnBadRequest_WhenIdIsInvalid()
        {
            string invalidId = "invalid-guid";

            var result = await _controller.GetSysPref_GeneralBehaviourId(invalidId);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Invalid ID format.", badRequestResult.Value);
        }

        [Fact]
        public async Task GetSysPref_GeneralBehaviourId_ShouldReturnNotFound_WhenSysPrefDoesNotExist()
        {

            var nonExistingId = Guid.NewGuid();

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetById_SysPref_GeneralBehaviours_Query>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((Response<GetById_SysPref_GeneralBehaviours_VM>)null);

            var result = await _controller.GetSysPref_GeneralBehaviourId(nonExistingId.ToString());

            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("System preference not found.", notFoundResult.Value);
        }
    }
}
