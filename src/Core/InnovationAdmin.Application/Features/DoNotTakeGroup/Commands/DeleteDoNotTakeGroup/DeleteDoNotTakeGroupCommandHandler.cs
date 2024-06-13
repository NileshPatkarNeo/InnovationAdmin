using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Features.DoNotTakeGroup.Commands.DeleteDoNotGroup;
using InnovationAdmin.Application.Responses;
using MediatR;


namespace InnovationAdmin.Application.Features.DoNotTakeGroup.Commands.DeleteDoNotTakeGroup
{
    public class DeleteDoNotTakeGroupCommandHandler : IRequestHandler<DeleteDoNotTakeGroupCommand, Response<bool>>
    {
        private readonly IDoNotTakeGroup _doNotTakeGroup;

        public DeleteDoNotTakeGroupCommandHandler(IDoNotTakeGroup doNotTakeGroup)
        {
          _doNotTakeGroup = doNotTakeGroup;
        }
       
        public async Task<Response<bool>> Handle(DeleteDoNotTakeGroupCommand request, CancellationToken cancellationToken)
        {
            var groupToDelete = await _doNotTakeGroup.GetByIdAsync(request.Id);

            if (groupToDelete == null)
            {
                return new Response<bool>($"Group with id {request.Id} not found.");
            }

            await _doNotTakeGroup.DeleteAsync(groupToDelete);

            return new Response<bool>(true, "Group deleted successfully.");
        }
    }

}
