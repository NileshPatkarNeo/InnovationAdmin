using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Features.SysPrefCompanies.Commands.CreateSysPrefCompany;
using InnovationAdmin.Application.Responses;
using InnovationAdmin.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.DoNotTakeGroup.Commands.CreateDoNotTakeGroup
{
    public class CreateDoNotTakeGroupCommandHandler : IRequestHandler<CreateDoNotTakeGroupCommand, Response<CreateDoNoTakeGroupDto>>
    {
        private readonly IMapper _mapper;
        private readonly IDoNotTakeGroup _doNotTakeGroup;
        private readonly IMessageRepository _messageRepository;

        public CreateDoNotTakeGroupCommandHandler(IMapper mapper, IMessageRepository messageRepository, IDoNotTakeGroup doNotTakeGroup)
        {
            _mapper = mapper;
            _doNotTakeGroup = doNotTakeGroup;
            _messageRepository = messageRepository;
        }

        public async Task<Response<CreateDoNoTakeGroupDto>> Handle(CreateDoNotTakeGroupCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateDoNotTakeGroupCommandValidator(_messageRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

            var group = new Domain.Entities.DoNotTakeGroup
            {
                GroupCode = request.GroupCode,
                GroupName = request.GroupName
              
            };
            group = await _doNotTakeGroup.AddAsync(group);


            var groupDto = _mapper.Map<CreateDoNoTakeGroupDto>(group);

            return new Response<CreateDoNoTakeGroupDto>(groupDto, "success");
        }
    }
}
