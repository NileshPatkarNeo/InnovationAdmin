using InnovationAdmin.Application.Responses;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace InnovationAdmin.API.UnitTests.Mocks
{
    public class MediatorMocks
    {
        public static Mock<IMediator> GetMediator()
        {
            var mockMediator = new Mock<IMediator>();

            //mockMediator.Setup(m => m.Send(It.IsAny<GetCategoriesListQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Response<IEnumerable<CategoryListVm>>());
            //mockMediator.Setup(m => m.Send(It.IsAny<GetCategoriesListWithEventsQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Response<IEnumerable<CategoryEventListVm>>());
          
            //mockMediator.Setup(m => m.Send(It.IsAny<CreateEventCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Response<Guid>());
           
            
            return mockMediator;
        }
    }
}
