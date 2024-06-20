using Innovation_Admin.UI.Models.CorrespondenceNote;
using Innovation_Admin.UI.Models.RemittanceType;
using Innovation_Admin.UI.Models.ResponsesModel.CorrespondenceNote;
using Innovation_Admin.UI.Models.ResponsesModel.RemittanceType;
using Innovation_Admin.UI.Services.Repositories;

namespace Innovation_Admin.UI.Services.IRepositories
{
    public interface ICorrespondenceNote
    {
        Task<GetAllCorrespondenceNoteResponseModel> GetAllCorrespondenceNotes();

        Task<CreateCorrespondenceNoteResponseModel> CreateCorrespondenceNote(CreateCorrespondenceNoteDto note);

        Task<UpdateCorrespondenceNoteResponseModel> UpdateCorrespondenceNote(CorrespondenceNoteDto updatedNote);
        Task<GetAllCorrespondenceNoteByIdResponseModel> GetCorrespondenceNoteById(Guid Id);

        Task<bool> DeleteCorrespondenceNote(Guid correspondnoteId);
    }
}
