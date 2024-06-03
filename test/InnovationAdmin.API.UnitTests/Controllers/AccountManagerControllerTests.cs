using InnovationAdmin.Api.Controllers;
using InnovationAdmin.Application.Features.AccountManager.Commands.CreateAccountManager;
using InnovationAdmin.Application.Features.AccountManager.Commands.DeleteAccountManager;
using InnovationAdmin.Application.Features.AccountManager.Commands.UpdateAccountManager;
using InnovationAdmin.Application.Features.AccountManager.Queries.GetAccountManagerById;
using InnovationAdmin.Application.Features.AccountManager.Queries.GetAllAccountManager;
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
    public   class AccountManagerControllerTests

    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<ILogger<AccountManagerController>> _loggerMock;

        private readonly AccountManagerController _accountManagerController;
        public AccountManagerControllerTests() {

            _mediatorMock = new Mock<IMediator>();
            _loggerMock = new Mock<ILogger<AccountManagerController>>();
            _accountManagerController = new AccountManagerController(_mediatorMock.Object, _loggerMock.Object);
        }

       
        [Fact]
        public async Task CreateAccount()
        {
            var createCommand = new CreateAccountManagerCommand
            {
                Name = "sanjyot",
              
            };

            var expectedResult = new Response<CreateAccountManagerDto>
            {
                Succeeded = true,
                Data = new CreateAccountManagerDto
                {
                    Id = Guid.NewGuid(),
                    Name = createCommand.Name,
                   
                }
            };

            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(x => x.Send(It.IsAny<CreateAccountManagerCommand>(), default))
                        .ReturnsAsync(expectedResult);

            var loggerMock = new Mock<ILogger<AccountManagerController>>();

            var controller = new AccountManagerController(mediatorMock.Object, loggerMock.Object);

            var result = await controller.Create(createCommand);

            var actionResult = Assert.IsType<ActionResult<Response<CreateAccountManagerDto>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            Assert.Equal(200, okResult.StatusCode);

            var actualResult = Assert.IsType<Response<CreateAccountManagerDto>>(okResult.Value);
            Assert.True(actualResult.Succeeded);
            Assert.NotNull(actualResult.Data);
            Assert.Equal(expectedResult.Data.Id, actualResult.Data.Id);
            Assert.Equal(expectedResult.Data.Name, actualResult.Data.Name);
        }

        [Fact]
        public async Task Delete_Returns()
        {
            var id = Guid.NewGuid();
            var response = new Response<Guid> { Succeeded = true, Data = id };
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteAccountManagerCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(response);
            var result = await _accountManagerController.Delete(id) as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);

            var actualResult = result.Value as Response<Guid>;
            Assert.NotNull(actualResult);
            Assert.True(actualResult.Succeeded);
            Assert.Equal(id, actualResult.Data);
        }

        [Fact]
        public async Task GetAllAccountManager()
        {
            var AccountList = new List<AccountManagerDto>
    {
        new AccountManagerDto { Id = Guid.NewGuid(),Name = "Sanjyot" },
        new AccountManagerDto { Id = Guid.NewGuid(), Name = "Sham " }
    };

            var response = new Response<IEnumerable<AccountManagerDto>>
            {
                Succeeded = true,
                Data = AccountList
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllAccountManagersQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(response);

            var result = await _accountManagerController.GetAll() as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);

            var actualResult = result.Value as Response<IEnumerable<AccountManagerDto>>;
            Assert.NotNull(actualResult);
            Assert.True(actualResult.Succeeded);
            Assert.Equal(2, actualResult.Data.Count());
        }

        [Fact]
        public async Task GetAllAccountManager_Is_Null()
        {
      
            var response = new Response<IEnumerable<AccountManagerDto>>
            {
                Succeeded = true,
                Data = null 
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllAccountManagersQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(response);

 
            var result = await _accountManagerController.GetAll() as NotFoundResult;

            
            Assert.NotNull(result);
            Assert.Equal(404, result.StatusCode);
        }
        [Fact]
        public async Task GetAcountManagerByIdValidId()
        {
            var accountManagerId = Guid.NewGuid();
            var response = new Response<AccountManagerDto>
            {
                Succeeded = true,
                Data = new AccountManagerDto
                {
                    Id = accountManagerId,
                    Name = "Raj"
                }
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetAccountManagerByIdQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(response);

            var result = await _accountManagerController.GetAccountManagerById(accountManagerId) as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);

            var actualResult = result.Value as Response<AccountManagerDto>;
            Assert.NotNull(actualResult);
            Assert.True(actualResult.Succeeded);
            Assert.Equal(accountManagerId, actualResult.Data.Id);
            Assert.Equal("Raj", actualResult.Data.Name);
        }




    }
}
