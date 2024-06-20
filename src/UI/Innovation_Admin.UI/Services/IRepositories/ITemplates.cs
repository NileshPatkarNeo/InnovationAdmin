using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Innovation_Admin.UI.Models.Template;
using Innovation_Admin.UI.Models.ResponsesModel.Template;

namespace Innovation_Admin.UI.Services.IRepositories
{
    public interface ITemplates
    {
        Task<GetAllTemplatesResponseModel> GetAllTemplates();
        Task<CreateTemplateResponseModel> CreateTemplate(CreateTemplateDto newTemplate);
        Task<UpdateTemplateResponseModel> UpdateTemplate(TemplateDto updatedTemplate);
        Task<GetTemplateByIdResponseModel> GetTemplateById(Guid templateId);
        Task<bool> DeleteTemplate(Guid templateId);
    }
}
