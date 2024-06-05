using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Responses;
using InnovationAdmin.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.AccountManager.Commands.CreateAccountManager
{
    public class CreateAccountManagerCommandHandler : IRequestHandler<CreateAccountManagerCommand, Response<CreateAccountManagerDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAccountManagerRepository _accountManagerRepository;
        private readonly IMessageRepository _messageRepository;

        public CreateAccountManagerCommandHandler(IMapper mapper, IAccountManagerRepository accountManagerRepository, IMessageRepository messageRepository)
        {
            _mapper = mapper;
            _accountManagerRepository = accountManagerRepository;
            _messageRepository = messageRepository;
        }

        public async Task<Response<CreateAccountManagerDto>> Handle(CreateAccountManagerCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateAccountManagerCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

            var accountManager = new Domain.Entities.AccountManager
            {
                Name = request.Name
            };

            accountManager = await _accountManagerRepository.AddAsync(accountManager);

            var accountManagerDto = _mapper.Map<CreateAccountManagerDto>(accountManager);

            return new Response<CreateAccountManagerDto>(accountManagerDto, "Account manager created successfully");
        }
    }
}
