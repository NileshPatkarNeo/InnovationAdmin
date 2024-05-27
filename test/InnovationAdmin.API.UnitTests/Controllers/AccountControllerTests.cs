﻿using InnovationAdmin.Api.Controllers;
using InnovationAdmin.API.UnitTests.Mocks;
using InnovationAdmin.Application.Contracts.Identity;
using InnovationAdmin.Application.Features.SysPrefCompanies.Queries.GetSysPrefCompanyQuery;
using InnovationAdmin.Application.Models.Authentication;
using InnovationAdmin.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace InnovationAdmin.API.UnitTests.Controllers
{
    public class AccountControllerTests
    {
        private readonly Mock<IAuthenticationService> _mockAuthenticationService;
        public AccountControllerTests()
        {
            _mockAuthenticationService = AuthenticationServiceMocks.GetAuthenticationService();
        }

        [Fact]
        public async Task Authenticate()
        {
            var controller = new AccountController(_mockAuthenticationService.Object);

            var response = await controller.AuthenticateAsync(new AuthenticationRequest()
            {
                Email = "john@test.com",
                Password = "User123!@#"
            });

            response.ShouldBeOfType<ActionResult<AuthenticationResponse>>();
            var okObjectResult = response.Result as OkObjectResult;
            okObjectResult.StatusCode.ShouldBe(200);
            okObjectResult.Value.ShouldNotBeNull();
            okObjectResult.Value.ShouldBeOfType<AuthenticationResponse>();
        }

        [Fact]
        public async Task Register()
        {
            var controller = new AccountController(_mockAuthenticationService.Object);

            var response = await controller.RegisterAsync(new RegistrationRequest()
            {
                FirstName = "Fname",
                LastName = "Lname",
                Email = "fname@test.com",
                UserName = "fname.lname",
                Password = "User123!@#"
            });

            response.ShouldBeOfType<ActionResult<RegistrationResponse>>();
            var okObjectResult = response.Result as OkObjectResult;
            okObjectResult.StatusCode.ShouldBe(200);
            okObjectResult.Value.ShouldNotBeNull();
            okObjectResult.Value.ShouldBeOfType<RegistrationResponse>();
        }


        [Fact]
        public async Task Refresh_Token()
        {
            var controller = new AccountController(_mockAuthenticationService.Object);
            var result = await controller.RefreshTokenAsync(new RefreshTokenRequest()
            {
                Token = "string"
            });

         
            result.ShouldBeOfType<OkObjectResult>();
            var okObjectResult = result as OkObjectResult;
            okObjectResult.StatusCode.ShouldBe(200);
            okObjectResult.Value.ShouldNotBeNull();
            okObjectResult.Value.ShouldBeOfType<RefreshTokenResponse>();
        }

        [Fact]
        public async Task Revoke_Token()
        {
            _mockAuthenticationService.Setup(auth => auth.RevokeToken(It.IsAny<RevokeTokenRequest>())).ReturnsAsync(
                new RevokeTokenResponse() { IsRevoked = true, Message = "Token revoked" });

            var controller = new AccountController(_mockAuthenticationService.Object);

            var result = await controller.RevokeTokenAsync(new RevokeTokenRequest()
            {
                Token = "string"
            });

            result.ShouldBeOfType<OkObjectResult>();
            var okObjectResult = result as OkObjectResult;
            okObjectResult.StatusCode.ShouldBe(200);
            okObjectResult.Value.ShouldNotBeNull();
            okObjectResult.Value.ShouldBeOfType<RevokeTokenResponse>();
        }

        [Fact]
        public async Task Revoke_EmptyToken()
        {
            _mockAuthenticationService.Setup(auth => auth.RevokeToken(It.IsAny<RevokeTokenRequest>())).ReturnsAsync(
                new RevokeTokenResponse() { IsRevoked = false, Message = "Token is required" });

            var controller = new AccountController(_mockAuthenticationService.Object);

            var result = await controller.RevokeTokenAsync(new RevokeTokenRequest());

            result.ShouldBeOfType<BadRequestObjectResult>();
            var okObjectResult = result as BadRequestObjectResult;
            okObjectResult.StatusCode.ShouldBe(400);
            okObjectResult.Value.ShouldNotBeNull();
            okObjectResult.Value.ShouldBeOfType<RevokeTokenResponse>();
        }
        
    }
}
