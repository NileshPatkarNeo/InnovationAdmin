

using Innovation_Admin.UI.Models.ResponsesModel.SysPrefCompany;
using Innovation_Admin.UI.Models.ResponsesModel.SysPrefGeneralBehaviour;
using Innovation_Admin.UI.Models.SysPrefCompany;
using Innovation_Admin.UI.Models.SysPrefGeneralBehaviour;
using Innovation_Admin.UI.Services.IRepositories;
using Microsoft.Extensions.Options;
using static Innovation_Admin.UI.Helper.APIBaseUrl;

namespace Innovation_Admin.UI.Common
{
    public class Common
    {
        private readonly ISysPrefCompanies sysPrefCompanies;
        private readonly ISysPrefGeneralBehaviouries sysPrefBehaviouries;
        private readonly IConfiguration _configuration;
        private readonly IOptions<ApiBaseUrl> _apiBaseUrl;
        public Common(ISysPrefCompanies _sysPrefCompanies, IConfiguration configuration, ISysPrefGeneralBehaviouries _sysPrefBehaviouries, IOptions<ApiBaseUrl> apiBaseUrl)
        {
            sysPrefCompanies = _sysPrefCompanies;
            _configuration = configuration;
            _apiBaseUrl = apiBaseUrl;
            sysPrefBehaviouries = _sysPrefBehaviouries;
        }

        public async Task<IEnumerable<SysPrefCompanyDto>> GetAllSysPrefCompanies()
        {
            GetAllSysPrefCompanyResponseModel getAllSysPrefCompanyResponseModel = new GetAllSysPrefCompanyResponseModel();

            getAllSysPrefCompanyResponseModel = await sysPrefCompanies.GetAllSysPrefCompanies();

            if (getAllSysPrefCompanyResponseModel.IsSuccess)
            {
                if (getAllSysPrefCompanyResponseModel != null && getAllSysPrefCompanyResponseModel.Data.Count() > 0)
                {
                    return getAllSysPrefCompanyResponseModel.Data;
                }
            }

            return new List<SysPrefCompanyDto>();
        }

        
        public async Task<IEnumerable<SysPrefGeneralBehaviourDto>> GetAllSysPrefBehaviouries()
        {
            GetAllSysPrefGeneralBehaviourResponseModel getAllSysPrefCompanyResponseModel = new GetAllSysPrefGeneralBehaviourResponseModel();

            getAllSysPrefCompanyResponseModel = await sysPrefBehaviouries.GetAllSysPrefBehaviouries();

            if (getAllSysPrefCompanyResponseModel.IsSuccess)
            {
                if (getAllSysPrefCompanyResponseModel != null && getAllSysPrefCompanyResponseModel.Data.Count() > 0)
                {
                    return getAllSysPrefCompanyResponseModel.Data;
                }
            }

            return new List<SysPrefGeneralBehaviourDto>();
        }


       
        public async Task<CreateSysPrefGeneralBehaviourResponseModel> CreateSysPrefGeneralBehaviour(CreateSysPrefGeneralBehaviourDto company)
        {
            return await sysPrefBehaviouries.CreateSysPrefGeneralBehaviour(company);
        }


        public async Task<UpdateSysPrefGeneralBehaviourResponseModel> UpdateSysSysPrefGeneralBehaviour(SysPrefGeneralBehaviourDto updatedCompany)
        {
            return await sysPrefBehaviouries.UpdateSysPrefGeneralBehaviour(updatedCompany);
        }
        public async Task<GetSysPrefGeneralBehaviourByIdResponseModel> GetSysPrefGeneralBehaviourById(Guid Preference_ID)
        {
            return await sysPrefBehaviouries.GetPrefGeneralBehaviourById(Preference_ID);
        }


        public async Task<bool> DeleteSysPrefGeneralBehaviour(Guid Preference_ID)
        {
            return await sysPrefBehaviouries.DeleteSysPrefGeneralBehaviour(Preference_ID);
        }

    }
}
