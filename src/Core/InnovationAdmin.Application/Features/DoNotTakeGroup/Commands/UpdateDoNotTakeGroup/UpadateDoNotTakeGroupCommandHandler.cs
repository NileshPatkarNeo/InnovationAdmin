

using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Responses;
using MediatR;

namespace InnovationAdmin.Application.Features.DoNotTakeGroup.Commands.UpdateDoNotTakeGroup
{
    public class UpadateDoNotTakeGroupCommandHandler : IRequestHandler<UpdateDoNotTakeGroupCommand, Response<UpdateDoNotTakeGroupDto>>
    {
        private readonly IMapper _mapper;
        private readonly IDoNotTakeGroup _doNotTakeGroup;

        public UpadateDoNotTakeGroupCommandHandler(IMapper mapper,IDoNotTakeGroup doNotTakeGroup)
        {
            _mapper = mapper;
           _doNotTakeGroup = doNotTakeGroup;
        }

        public async Task<Response<UpdateDoNotTakeGroupDto>> Handle(UpdateDoNotTakeGroupCommand request, CancellationToken cancellationToken)
        {
            var groupToUpdate = await _doNotTakeGroup.GetByIdAsync(request.Id);

            if (groupToUpdate == null)
            {
                throw new NotFoundException(nameof(DoNotTakeGroup), request.Id);
            }

            groupToUpdate.GroupName = request.GroupName;
            groupToUpdate.GroupCode = request.GroupCode;
            //groupToUpdate.LastModifiedDate = DateTime.Now;

            await _doNotTakeGroup.UpdateAsync(groupToUpdate);

            var groupDto = _mapper.Map<UpdateDoNotTakeGroupDto>(groupToUpdate);

            return new Response<UpdateDoNotTakeGroupDto>(groupDto, "Group updated successfully");
        }
    }

}
