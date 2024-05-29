using Innovation_Admin.UI.Models.AdminUser;
using Innovation_Admin.UI.Models.ResponsesModel.AdminUser;
using Innovation_Admin.UI.Models.AdminRole;
using Innovation_Admin.UI.Models.ResponsesModel.AdminRole;


using Innovation_Admin.UI.Models.ResponsesModel.SysPrefCompany;
using Innovation_Admin.UI.Models.ResponsesModel.SysPrefGeneralBehaviour;
using Innovation_Admin.UI.Models.SysPrefCompany;
using Innovation_Admin.UI.Models.SysPrefGeneralBehaviour;
using Innovation_Admin.UI.Services.IRepositories;
using Microsoft.Extensions.Options;
using System.Drawing;
using static Innovation_Admin.UI.Helper.APIBaseUrl;
using Innovation_Admin.UI.Models.Account_Manager;
using Innovation_Admin.UI.Models.ResponsesModel.AccountManager;
using Innovation_Admin.UI.Services.Repositories;
using Innovation_Admin.UI.Models.PharmacyGroup;
using Innovation_Admin.UI.Models.ResponsesModel.PharmacyGroup;

namespace Innovation_Admin.UI.Common
{
    public class Common
    {
        private readonly ISysPrefCompanies sysPrefCompanies;
        private readonly IAdminUser adminUser;
        private readonly IAdminRoles adminRoles;
        private readonly IAccountManager accountManager;
        private readonly ISysPrefGeneralBehaviouries sysPrefBehaviouries;
        private readonly IPharmacyGroup pharmacyGroups;
        private readonly IConfiguration _configuration;
        private readonly IOptions<ApiBaseUrl> _apiBaseUrl;

        public Common(ISysPrefCompanies _sysPrefCompanies, IAdminUser _adminUser, IConfiguration configuration, IOptions<ApiBaseUrl> apiBaseUrl, IAdminRoles _adminRoles, ISysPrefGeneralBehaviouries _sysPrefBehaviouries, IAccountManager _accountManager)



        public Common(ISysPrefCompanies _sysPrefCompanies, IAdminUser _adminUser, IConfiguration configuration, IOptions<ApiBaseUrl> apiBaseUrl, IAdminRoles _adminRoles, ISysPrefGeneralBehaviouries _sysPrefBehaviouries, IPharmacyGroup _pharmacyGroups)

        {
            adminUser = _adminUser;
            sysPrefCompanies = _sysPrefCompanies;
            _configuration = configuration;
            _apiBaseUrl = apiBaseUrl;
            adminRoles = _adminRoles;
            sysPrefBehaviouries = _sysPrefBehaviouries;
            accountManager = _accountManager;
            pharmacyGroups = _pharmacyGroups;
        }

        #region System_Preference



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



        public async Task<CreateSysPrefCompanyResponseModel> CreateSysPrefCompany(SysPrefCompanyDto company)
        {
            return await sysPrefCompanies.CreateSysPrefCompany(company);
        }


        public async Task<UpdateSysPrefCompanyResponseModel> UpdateSysPrefCompany(SysPrefCompanyDto updatedCompany)
        {
            return await sysPrefCompanies.UpdateSysPrefCompany(updatedCompany);
        }
        public async Task<GetSysPrefCompanyByIdResponseModel> GetSysPrefCompanyById(Guid companyId)
        {
            return await sysPrefCompanies.GetSysPrefCompanyById(companyId);
        }

        public async Task<bool> DeleteSysPrefCompany(Guid companyId)
        {
            return await sysPrefCompanies.DeleteSysPrefCompany(companyId);
        }
        #endregion


        #region Admin_User


        public async Task<IEnumerable<AdminUserDto>> GetAllAdminUser()
        {
            GetAllAdminUserResponseModel getAllAdminUserResponseModel = new GetAllAdminUserResponseModel();

            getAllAdminUserResponseModel = await adminUser.GetAllAdminUser();

            if (getAllAdminUserResponseModel.IsSuccess)
            {
                if (getAllAdminUserResponseModel != null && getAllAdminUserResponseModel.Data.Count() > 0)
                {
                    return getAllAdminUserResponseModel.Data;
                }
            }

            return new List<AdminUserDto>();
        }

        public async Task<CreateAdminUserResponseModel> CreateAdminUser(CreateAdminUserDto company)
        {
            return await adminUser.CreateAdminUser(company);
        }

        public async Task<UpdateAdminUserResponseModel> UpdateAdminUser(AdminUserDto updatedCompany)
        {
            return await adminUser.UpdateAdminUser(updatedCompany);
        }
        public async Task<GetAdminUserByIdResponseModel> GetAdminUserById(Guid companyId)
        {
            return await adminUser.GetAdminUserById(companyId);
        }

        public async Task<bool> DeleteAdminUser(Guid companyId)
        {
            return await adminUser.DeleteAdminUser(companyId);
        }
        #endregion

        #region - AdminRole
        public async Task<IEnumerable<AdminRoleDto>> GetAllAdminRoles()
        {
            GetAllAdminRoleResponseModel getAllAdminRoleResponseModel = new GetAllAdminRoleResponseModel();

            getAllAdminRoleResponseModel = await adminRoles.GetAllAdminRoles();

            if (getAllAdminRoleResponseModel.IsSuccess)
            {
                if (getAllAdminRoleResponseModel != null && getAllAdminRoleResponseModel.Data.Count() > 0)
                {
                    return getAllAdminRoleResponseModel.Data;
                }
            }

            return new List<AdminRoleDto>();
        }
        public async Task<CreateAdminRoleResponseModel> CreateAdminRole(CreateAdminRoleDto newAdminRole)
        {
            return await adminRoles.CreateAdminRole(newAdminRole);
        }

        public async Task<UpdateAdminRoleResponseModel> UpdateAdminRole(AdminRoleDto updatedAdminRole)
        {
            return await adminRoles.UpdateAdminRole(updatedAdminRole);
        }
        public async Task<GetAdminRoleByIdResponseModel> GetAdminRoleById(Guid adminRoleId)
        {
            return await adminRoles.GetAdminRoleById(adminRoleId);
        }

        public async Task<bool> DeleteAdminRole(Guid adminRoleId)
        {
            return await adminRoles.DeleteAdminRole(adminRoleId);
        }
        #endregion


        #region GeneralBehaviour

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
        #endregion

        #region Account_Manager

        public async Task<IEnumerable<AccountManagerDto>> GetAllAccountManagers()
        {
            GetAllAccountManagerResponseModel getAllAccountManagersResponseModel = new GetAllAccountManagerResponseModel();

            getAllAccountManagersResponseModel = await accountManager.GetAllAccountManagers();

            if (getAllAccountManagersResponseModel.IsSuccess)
            {
                if (getAllAccountManagersResponseModel != null && getAllAccountManagersResponseModel.Data != null && getAllAccountManagersResponseModel.Data.Count() > 0)
                {
                    return getAllAccountManagersResponseModel.Data;
                }
            }

            return new List<AccountManagerDto>();
        }


        #endregion




        public async Task<IEnumerable<PharmacyGroupDto>> GetAllPharmcayGroup()
        {
            GetAllPharmacyGroupResponseModel getAllPharmacyProupyResponseModel = new GetAllPharmacyGroupResponseModel();

            getAllPharmacyProupyResponseModel = await pharmacyGroups.GetAllPharmacyGroups();

            if (getAllPharmacyProupyResponseModel.IsSuccess)
            {
                if (getAllPharmacyProupyResponseModel != null && getAllPharmacyProupyResponseModel.Data.Count() > 0)
                {
                    return getAllPharmacyProupyResponseModel.Data;
                }
            }

            return new List<PharmacyGroupDto>();
        }


        public async Task<CreatePharmacyGroupResponseModel> CreatePharmacyGroup(PharmacyGroupDto group)
        {
            return await pharmacyGroups.CreatePharmacyGroup(group);
        }

        public async Task<UpdatePharmacyGroupResponseModel> UpdatePharmacyGroup(PharmacyGroupDto updatedGroup)
        {
            return await pharmacyGroups.UpdatePharmacyGroup(updatedGroup);
        }

        public async Task<GetPharmacyGroupByIdResponseModel> GetPharmacyGroupById(Guid Id)
        {
            return await pharmacyGroups.GetPharmacyGroupById(Id);
        }

        public async Task<bool> DeletePharmacyGroup(Guid Id)
        {
            return await pharmacyGroups.DeletePharmacyGroup(Id);
        }

        public async Task<CreateAccountManagerResponseModel> CreateAccountManager(AccountManagerDto manager)
        {
            return await accountManager.CreateAccountManager(manager);
        }

        public async Task<UpdateAccountManagerResponseModel> UpdateAccountManager(AccountManagerDto manager)
        {
            return await accountManager.UpdateAccountManager(manager);
        }
        public async Task<GetAccountManagerByIdResponseModel> GetAccountManagerById(Guid Id)
        {
            return await accountManager.GetAccountManagerById(Id);
        }


        public async Task<bool> DeleteAccountManager(Guid Id)
        {
            return await accountManager.DeleteAccountManager(Id);
        }

        #endregion


    }
    }
