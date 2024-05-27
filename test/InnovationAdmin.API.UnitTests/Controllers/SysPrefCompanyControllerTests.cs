using InnovationAdmin.Api.Controllers;
using InnovationAdmin.Application.Features.SysPrefCompanies.Commands.CreateSysPrefCompany;
using InnovationAdmin.Application.Features.SysPrefCompanies.Commands.DeleteSysPrefCommand;
using InnovationAdmin.Application.Features.SysPrefCompanies.Commands.UpdateSysPrefCompany;
using InnovationAdmin.Application.Features.SysPrefCompanies.Queries.GetAllListSysPrefCompnayQuery;
using InnovationAdmin.Application.Features.SysPrefCompanies.Queries.GetSysPrefCompanyQuery;
using InnovationAdmin.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace InnovationAdmin.API.UnitTests.Controllers
{
    public class SysPrefCompanyControllerTests
    {
        [Fact]
        public async Task Create_Returns_OkResult_With_Valid_Input()
        {
            
            var createSysPrefCompanyCommand = new CreateSysPrefCompanyCommand
            {
                CompanyName = "Neosoft ",
                TermForPharmacy = "Test Term"
            };

            var expectedResult = new Response<CreateSysPrefCompanyDto>
            {
                Succeeded = true,
                Data = new CreateSysPrefCompanyDto
                {
                    CompanyID = Guid.NewGuid(),
                    CompanyName = createSysPrefCompanyCommand.CompanyName,
                    TermForPharmacy = createSysPrefCompanyCommand.TermForPharmacy
                }
            };

            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(x => x.Send(It.IsAny<CreateSysPrefCompanyCommand>(), default))
                        .ReturnsAsync(expectedResult);

            var loggerMock = new Mock<ILogger<SysPrefCompanyController>>();

            var controller = new SysPrefCompanyController(mediatorMock.Object, loggerMock.Object);

           
            var result = await controller.Create(createSysPrefCompanyCommand) as OkObjectResult;

           
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);

            var actualResult = result.Value as Response<CreateSysPrefCompanyDto>;
            Assert.NotNull(actualResult);
            Assert.True(actualResult.Succeeded);
            Assert.NotNull(actualResult.Data);
            Assert.Equal(expectedResult.Data.CompanyID, actualResult.Data.CompanyID);
            Assert.Equal(expectedResult.Data.CompanyName, actualResult.Data.CompanyName);
            Assert.Equal(expectedResult.Data.TermForPharmacy, actualResult.Data.TermForPharmacy);
        }

        [Fact]
        public async Task Update_Returns_OkResult_With_Valid_Input()
        {          
            var id = Guid.NewGuid();
            var updateSysPrefCompanyCommand = new UpdateSysPrefCompanyCommand
            {
                CompanyID = id,
                CompanyName = "Updated Company Name",
                TermForPharmacy = "Updated Term for Pharmacy"
            };
            var expectedResult = new Response<UpdateSysPrefCompanyDto>
            {
                Succeeded = true,
                Data = new UpdateSysPrefCompanyDto
                {
                    CompanyID = Guid.NewGuid(),  
                    CompanyName = "Updated Company Name",
                    TermForPharmacy = "Updated Term for Pharmacy"
                }
            };
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(x => x.Send(updateSysPrefCompanyCommand, default))
                .ReturnsAsync(expectedResult);
            var loggerMock = new Mock<ILogger<SysPrefCompanyController>>();
            var controller = new SysPrefCompanyController(mediatorMock.Object, loggerMock.Object);
            var result = await controller.Update(id, updateSysPrefCompanyCommand) as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(expectedResult, result.Value);
        }

        [Fact]
        public async Task Update_Returns_BadRequest_When_ID_Mismatch()
        {
            var id = Guid.NewGuid();
            var updateSysPrefCompanyCommand = new UpdateSysPrefCompanyCommand
            {
                CompanyID = Guid.NewGuid(),  
                CompanyName = "Updated Company Name",
                TermForPharmacy = "Updated Term for Pharmacy"
            };
            var mediatorMock = new Mock<IMediator>();
            var loggerMock = new Mock<ILogger<SysPrefCompanyController>>();
            var controller = new SysPrefCompanyController(mediatorMock.Object, loggerMock.Object);
            var result = await controller.Update(id, updateSysPrefCompanyCommand) as BadRequestObjectResult;
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
                Data = true             };
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(x => x.Send(It.IsAny<DeleteSysPrefCompanyCommand>(), default))
                .ReturnsAsync(expectedResult);
            var loggerMock = new Mock<ILogger<SysPrefCompanyController>>();
            var controller = new SysPrefCompanyController(mediatorMock.Object, loggerMock.Object);
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
            mediatorMock.Setup(x => x.Send(It.IsAny<DeleteSysPrefCompanyCommand>(), default))
                .ReturnsAsync(expectedResult);
            var loggerMock = new Mock<ILogger<SysPrefCompanyController>>();
            var controller = new SysPrefCompanyController(mediatorMock.Object, loggerMock.Object);
            var result = await controller.Delete(id) as NotFoundObjectResult;
            Assert.NotNull(result);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal(expectedResult, result.Value);
        }

        [Fact]
        public async Task GetSysPrefCompanyById_Returns_OkResult_With_Valid_Company()
        { 
            var companyId = Guid.NewGuid();
            var expectedCompany = new SysPrefCompanyDto
            {
                CompanyID = companyId,
                CompanyName = "Test Company",
                TermForPharmacy = "Test Term"
            };
            var expectedResult = new Response<SysPrefCompanyDto>
            {
                Succeeded = true,
                Data = expectedCompany
            };
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(x => x.Send(It.IsAny<GetSysPrefCompanyByIdQuery>(), default))
                .ReturnsAsync(expectedResult);

            var loggerMock = new Mock<ILogger<SysPrefCompanyController>>();

            var controller = new SysPrefCompanyController(mediatorMock.Object, loggerMock.Object); 
            var result = await controller.GetSysPrefCompanyById(companyId) as OkObjectResult; 
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);

            var responseData = result.Value as Response<SysPrefCompanyDto>;
            Assert.NotNull(responseData);
            Assert.True(responseData.Succeeded);
            Assert.NotNull(responseData.Data);
            Assert.Equal(expectedCompany, responseData.Data);
        }

        [Fact]
        public async Task GetAll_Returns_OkResult_With_Valid_Companies()
        { 
            var expectedCompanies = new List<SysPrefCompanyDto>
            {
                new SysPrefCompanyDto { CompanyID = Guid.NewGuid(), CompanyName = "Company 1", TermForPharmacy = "Term 1" },
                new SysPrefCompanyDto { CompanyID = Guid.NewGuid(), CompanyName = "Company 2", TermForPharmacy = "Term 2" }
              };
            var expectedResult = new Response<IEnumerable<SysPrefCompanyDto>>
            {
                Succeeded = true,
                Data = expectedCompanies
            };
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(x => x.Send(It.IsAny<GetAllSysPrefCompaniesQuery>(), default))
                .ReturnsAsync(expectedResult);
            var loggerMock = new Mock<ILogger<SysPrefCompanyController>>();
            var controller = new SysPrefCompanyController(mediatorMock.Object, loggerMock.Object);
            var result = await controller.GetAll() as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            var responseData = result.Value as Response<IEnumerable<SysPrefCompanyDto>>;
            Assert.NotNull(responseData);
            Assert.True(responseData.Succeeded);
            Assert.NotNull(responseData.Data);
            Assert.Equal(expectedCompanies, responseData.Data);
        }

        
    }

}

