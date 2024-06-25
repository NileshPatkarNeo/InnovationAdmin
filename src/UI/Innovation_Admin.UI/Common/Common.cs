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
using Innovation_Admin.UI.Models.SysPrefSecurityEmail;
using Innovation_Admin.UI.Models.ResponsesModel.SysPrefSecurityEmail;
using Innovation_Admin.UI.Models.ResponsesModel.SysPrefFinancial;
using Innovation_Admin.UI.Models.SysPrefFinancial;
using Innovation_Admin.UI.Models.PharmacyGroup;
using Innovation_Admin.UI.Models.ResponsesModel.PharmacyGroup;
using Innovation_Admin.UI.Models.Quote;
using Innovation_Admin.UI.Models.ResponsesModel.Quote;
using Innovation_Admin.UI.Models.RemittanceType;
using Innovation_Admin.UI.Models.ResponsesModel.RemittanceType;
using Innovation_Admin.UI.Models.ReceiptBatchSource;
using Innovation_Admin.UI.Models.ResponsesModel.ReceiptBatchSource;
using Innovation_Admin.UI.Models.DataSource;
using Innovation_Admin.UI.Models.ResponsesModel.DataSource;
using Innovation_Admin.UI.Services.Repositories;
using Innovation_Admin.UI.Models.ResponsesModel.Template;
using Innovation_Admin.UI.Models.Template;
using Innovation_Admin.UI.Models.ResponsesModel.BillingMethodType;
using Innovation_Admin.UI.Models.BillingMethodType;
using Innovation_Admin.UI.Models.APAccountType;
using Innovation_Admin.UI.Models.ResponsesModel.APAccountType;
using Innovation_Admin.UI.Models.CorrespondenceNote;
using Innovation_Admin.UI.Models.ResponsesModel.CorrespondenceNote;
using Innovation_Admin.UI.Models.DoNotTakeGroup;
using Innovation_Admin.UI.Models.ResponsesModel.DoNotTakeGroup;
using Innovation_Admin.UI.Models.CategoryType;
using Innovation_Admin.UI.Models.ResponsesModel.CategoryType;
using Innovation_Admin.UI.Models.PharmacyType;
using Innovation_Admin.UI.Models.ResponsesModel.PharmacyType;

namespace Innovation_Admin.UI.Common
{
    public class Common
    {
        private readonly ISysPrefCompanies sysPrefCompanies;
        private readonly IAdminUser adminUser;
        private readonly IAdminRoles adminRoles;
        private readonly ISysPrefSecurityEmails sysPrefSecurityEmails;
        private readonly IAccountManager accountManager;
        private readonly ISysPrefGeneralBehaviouries sysPrefBehaviouries;
        private readonly ISysPrefFinancials sysPrefFinancial;
        private readonly IPharmacyGroup pharmacyGroups;
        private readonly IQuotes quotes;
        private readonly IRemittanceType remittanceTypes;
        private readonly IConfiguration _configuration;
        private readonly IOptions<ApiBaseUrl> _apiBaseUrl;
        private readonly IReceiptBatchSource receiptBatchSource;
        private readonly IDataSources dataSources;
        private readonly ITemplates templates;
        private readonly IBillingMethodTypes billingMethodTypes;
        private readonly IAPAccountTypes aPAccountTypes;
        private readonly IDoNotTakeGroup doNotTakeGroup;
        private readonly ICategoryTypes categoryTypes;
       
        private readonly ICorrespondenceNote correspondenceNote;
        private readonly IPharmacyType pharmacyTypes;


        
      
        public Common(ISysPrefCompanies _sysPrefCompanies, ISysPrefFinancials _sysPrefFinancial, IAdminUser _adminUser, IConfiguration configuration, IOptions<ApiBaseUrl> apiBaseUrl, IAdminRoles _adminRoles, ISysPrefGeneralBehaviouries _sysPrefBehaviouries, IPharmacyGroup _pharmacyGroups, IAccountManager _accountManager, ISysPrefSecurityEmails _sysPrefSecurityEmails, IDataSources _dataSources, IRemittanceType _remittanceTypes, IQuotes _quotes, IReceiptBatchSource _receiptBatchSource,IBillingMethodTypes _billingMethodTypes,IAPAccountTypes _aPAccountTypes, ITemplates _templates, ICorrespondenceNote _correspondenceNote,IDoNotTakeGroup _doNotTakeGroup, ICategoryTypes _categoryTypes, IPharmacyType _pharmacyTypes)


        {
            adminUser = _adminUser;
            sysPrefCompanies = _sysPrefCompanies;
            _configuration = configuration;
            _apiBaseUrl = apiBaseUrl;
            adminRoles = _adminRoles;
            sysPrefBehaviouries = _sysPrefBehaviouries;
            accountManager = _accountManager;
            sysPrefSecurityEmails = _sysPrefSecurityEmails;
            sysPrefFinancial = _sysPrefFinancial;
            pharmacyGroups = _pharmacyGroups;
            quotes = _quotes;
            remittanceTypes = _remittanceTypes;
            receiptBatchSource = _receiptBatchSource;
            dataSources = _dataSources;
            templates = _templates;
            billingMethodTypes = _billingMethodTypes;
            aPAccountTypes = _aPAccountTypes; ;
            correspondenceNote = _correspondenceNote;
            doNotTakeGroup = _doNotTakeGroup;
            categoryTypes = _categoryTypes;
            pharmacyTypes = _pharmacyTypes;
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

        #region SysPrefFinancials
        public async Task<IEnumerable<SysPrefFinancialDto>> GetAllSysPrefFinancials()
        {
            GetAllSysPrefFinancialResponseModel getAllSysPrefFinancialResponseModel = new GetAllSysPrefFinancialResponseModel();

            getAllSysPrefFinancialResponseModel = await sysPrefFinancial.GetAllSysPrefFinancials();

            if (getAllSysPrefFinancialResponseModel.IsSuccess)
            {
                if (getAllSysPrefFinancialResponseModel != null && getAllSysPrefFinancialResponseModel.Data.Count() > 0)
                {
                    return getAllSysPrefFinancialResponseModel.Data;
                }
            }

            return new List<SysPrefFinancialDto>();
        }
        public async Task<CreateSysPrefFinancialResponseModel> CreateSysPrefFinancial(SysPrefFinancialDto sysPrefFinancialDto)
        {
            return await sysPrefFinancial.CreateSysPrefFinancial(sysPrefFinancialDto);
        }

        public async Task<UpdateSysPrefFinancialResponseModel> UpdateSysPrefFinancial(SysPrefFinancialDto updatedSysPrefFinancial)
        {
            return await sysPrefFinancial.UpdateSysPrefFinancial(updatedSysPrefFinancial);
        }

        public async Task<GetSysPrefFinancialByIdResponseModel> GetSysPrefFinancialById(Guid financialId)
        {
            return await sysPrefFinancial.GetSysPrefFinancialById(financialId);
        }

        public async Task<bool> DeleteSysPrefFinancial(Guid financialId)
        {
            return await sysPrefFinancial.DeleteSysPrefFinancial(financialId);
        }
        #endregion

        #region Pharmacy Group

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
        #endregion

        #region SysPrefSecurityEmail

        public async Task<IEnumerable<SysPrefSecurityEmailDto>> GetAllSysPrefSecurityEmail()
        {
            GetAllSysPrefSecurityEmailResponseModel getAllSysPrefSecurityEmailResponseModel = new GetAllSysPrefSecurityEmailResponseModel();

            getAllSysPrefSecurityEmailResponseModel = await sysPrefSecurityEmails.GetAllSysPrefSecurityEmail();

            if (getAllSysPrefSecurityEmailResponseModel.IsSuccess)
            {
                if (getAllSysPrefSecurityEmailResponseModel != null && getAllSysPrefSecurityEmailResponseModel.Data.Count() > 0)
                {
                    return getAllSysPrefSecurityEmailResponseModel.Data;
                }
            }

            return new List<SysPrefSecurityEmailDto>();
        }


        public async Task<CreateSysPrefSecurityEmailResponseModel> CreateSysPrefSecurityEmail(CreateSysPrefSecurityEmailDto email)
        {
            return await sysPrefSecurityEmails.CreateSysPrefSecurityEmail(email);
        }

        public async Task<UpdateSysPrefSecurityEmailResponseModel> UpdateSysPrefSecurityEmail(SysPrefSecurityEmailDto updatedemail)
        {
            return await sysPrefSecurityEmails.UpdateSysPrefSecurityEmail(updatedemail);
        }

        public async Task<GetSysPrefSecurityEmailByIdResponseModel> GetSysPrefSecurityEmailById(Guid companyId)
        {
            return await sysPrefSecurityEmails.GetSysPrefSecurityEmailById(companyId);
        }

        public async Task<bool> DeleteSysPrefSecurityEmail(Guid emailId)
        {
            return await sysPrefSecurityEmails.DeleteSysPrefSecurityEmail(emailId);
        }


        #endregion

        #region DataSource

        public async Task<IEnumerable<DataSourceDto>> GetAllDataSource()
        {
            GetAllDataSourceResponseModel getAllDataSourceResponseModel = new GetAllDataSourceResponseModel();

            getAllDataSourceResponseModel = await dataSources.GetAllDataSource();

            if (getAllDataSourceResponseModel.IsSuccess)
            {
                if (getAllDataSourceResponseModel != null && getAllDataSourceResponseModel.Data.Count() > 0)
                {
                    return getAllDataSourceResponseModel.Data;
                }
            }

            return new List<DataSourceDto>();
        }


        public async Task<CreateDataSourceResponseModel> CreateDataSource(CreateDataSourceDto data)
        {
            return await dataSources.CreateDataSource(data);
        }

        public async Task<UpdateDataSourceResponseModel> UpdateDataSource(DataSourceDto updateddata)
        {
            return await dataSources.UpdateDataSource(updateddata);
        }
        public async Task<GetDataSourceByIdResponseModel> GetDataSourceById(Guid dataId)
        {
            return await dataSources.GetDataSourceById(dataId);
        }

        public async Task<bool> DeleteDataSource(Guid dataId)
        {
            return await dataSources.DeleteDataSource(dataId);
        }

        #endregion

        #region Quote

        public async Task<IEnumerable<QuoteDto>> GetAllQuotes()
        {
            GetAllQuotesResponseModel getAllQuotesResponseModel = new GetAllQuotesResponseModel();

            getAllQuotesResponseModel = await quotes.GetAllQuotes();

            if (getAllQuotesResponseModel.IsSuccess)
            {
                if (getAllQuotesResponseModel != null && getAllQuotesResponseModel.Data.Count() > 0)
                {
                    return getAllQuotesResponseModel.Data;
                }
            }

            return new List<QuoteDto>();
        }

        public async Task<CreateQuoteResponseModel> CreateQuote(CreateQuoteDto newQuote)
        {
            return await quotes.CreateQuote(newQuote);
        }

        public async Task<UpdateQuoteResponseModel> UpdateQuote(QuoteDto updatedQuote)
        {
            return await quotes.UpdateQuote(updatedQuote);
        }

        public async Task<GetQuoteByIdResponseModel> GetQuoteById(Guid quoteId)
        {
            return await quotes.GetQuoteById(quoteId);
        }
        public async Task<bool> DeleteQuote(Guid quoteId)
        {
            return await quotes.DeleteQuote(quoteId);
        }
        #endregion

        #region RemittanceType

        public async Task<IEnumerable<RemittanceTypeDto>> GetAllRemittanceType()
        {
            GetAllRemittanceTypeResponseModel getAllRemittanceTypeResponseModel = new GetAllRemittanceTypeResponseModel();

            getAllRemittanceTypeResponseModel = await remittanceTypes.GetAllRemittanceTypes();

            if (getAllRemittanceTypeResponseModel.IsSuccess)
            {
                if (getAllRemittanceTypeResponseModel != null && getAllRemittanceTypeResponseModel.Data.Count() > 0)
                {
                    return getAllRemittanceTypeResponseModel.Data;
                }
            }

            return new List<RemittanceTypeDto>();
        }

        public async Task<CreateRemittanceTypeResponseModel> CreateRemittanceType(RemittanceTypeDto type)
        {
            return await remittanceTypes.CreateRemittanceType(type);
        }

        public async Task<UpdateRemittanceTypeResponseModel> UpdateRemittanceType(RemittanceTypeDto updatedType)
        {
            return await remittanceTypes.UpdateRemittanceType(updatedType);
        }

        public async Task<GetRemittanceTypeByIdResponseModel> GetRemittanceTypeById(Guid Id)
        {
            return await remittanceTypes.GetRemittanceTypeById(Id);
        }

        public async Task<bool> DeleteRemittanceType(Guid Id)
        {
            return await remittanceTypes.DeleteRemittanceType(Id);
        }

        #endregion

        #region ReceiptBatchSource

        public async Task<IEnumerable<ReceiptBatchSourceDto>> GetAllReceiptBatchSource()
        {
            GetAllReceiptBatchSourceResponseModel getAllReceiptBatchSourceResponseModel = new GetAllReceiptBatchSourceResponseModel();

            getAllReceiptBatchSourceResponseModel = await receiptBatchSource.GetAllReceiptBatchSource();

            if (getAllReceiptBatchSourceResponseModel.IsSuccess)
            {
                if (getAllReceiptBatchSourceResponseModel != null && getAllReceiptBatchSourceResponseModel.Data.Count() > 0)
                {
                    return getAllReceiptBatchSourceResponseModel.Data;
                }
            }

            return new List<ReceiptBatchSourceDto>();
        }



        public async Task<CreateReceiptBatchSourceResponseModel> CreateReceiptBatchSource(ReceiptBatchSourceDto batch)
        {
            return await receiptBatchSource.CreateReceiptBatchSource(batch);
        }


        public async Task<UpdateReceiptBatchSourceResponseModel> UpdateReceiptBatchSource(ReceiptBatchSourceDto updatedBatch)
        {
            return await receiptBatchSource.UpdateReceiptBatchSource(updatedBatch);
        }
        public async Task<GetReceiptBatchSourceByIdResponseModel> GetReceiptBatchSourceById(Guid Id)
        {
            return await receiptBatchSource.GetReceiptBatchSourceById(Id);
        }

        public async Task<bool> DeleteReceiptBatchSource(Guid Id)
        {
            return await receiptBatchSource.DeleteReceiptBatchSource(Id);
        }
        #endregion

        #region DoNotTakeGroup

        public async Task<IEnumerable<DoNotTakeGroupDto>> GetAllDoNotTakeGroups()
        {
            GetAllDoNotTakeGroupResponseModel getAllDoNotTakeGroupResponseModel = new GetAllDoNotTakeGroupResponseModel();

            getAllDoNotTakeGroupResponseModel = await doNotTakeGroup.GetAllDoNotTakeGroup();

            if (getAllDoNotTakeGroupResponseModel.IsSuccess)
            {
                if (getAllDoNotTakeGroupResponseModel != null && getAllDoNotTakeGroupResponseModel.Data.Count() > 0)
                {
                    return getAllDoNotTakeGroupResponseModel.Data;
                }
            }

            return new List<DoNotTakeGroupDto>();
        }



        public async Task<CreateDoNotTakeGroupResponseModel> CreateDoNotTakeGroup(DoNotTakeGroupDto group)
        {
            return await doNotTakeGroup.CreateDoNotTakeGroup(group);
        }


        public async Task<UpdateDoNotTakeGroupResponseModel> UpdateDoNotTakeGroup(DoNotTakeGroupDto updatedGroup)
        {
            return await doNotTakeGroup.UpdateDoNotTakeGroup(updatedGroup);
        }
        public async Task<GetDoNotTakeGroupByIdResponseModel> GetDoNoTakeGroupById(Guid Id)
        {
            return await doNotTakeGroup.GetDoNotTakeGroupById(Id);
        }

        public async Task<bool> DeleteDoNotTakeGroup(Guid Id)
        {
            return await doNotTakeGroup.DeleteDoNotTakeGroup(Id);
        }

        #endregion

        #region BillingMethodType


        public async Task<IEnumerable<BillingMethodTypeDto>> GetAllBillingMethodType()
        {
            GetAllBillingMethodTypeResponseModel getAllBillingMethodTypeResponseModel = new GetAllBillingMethodTypeResponseModel();

            getAllBillingMethodTypeResponseModel = await billingMethodTypes.GetAllBillingMethodType();

            if (getAllBillingMethodTypeResponseModel.IsSuccess)
            {
                if (getAllBillingMethodTypeResponseModel != null && getAllBillingMethodTypeResponseModel.Data.Count() > 0)
                {
                    return getAllBillingMethodTypeResponseModel.Data;
                }
            }

            return new List<BillingMethodTypeDto>();
        }


        public async Task<CreateBillingMethodTypeResponseModel> CreateBillingMethodType(CreateBillingMethodTypeDto billing)
        {
            return await billingMethodTypes.CreateBillingMethodType(billing);
        }

        public async Task<UpdateBillingMethodTypeResponseModel> UpdateBillingMethodType(BillingMethodTypeDto updatedbilling)
        {
            return await billingMethodTypes.UpdateBillingMethodType(updatedbilling);
        }

        public async Task<GetBillingMethodTypeByIdResponseModel> GetBillingMethodTypeById(Guid billingId)
        {
            return await billingMethodTypes.GetBillingMethodTypeById(billingId);
        }

        public async Task<bool> DeleteBillingMethodType(Guid billingId)
        {
            return await billingMethodTypes.DeleteBillingMethodType(billingId);
        }



        #endregion

        #region APAccountType

        public async Task<IEnumerable<APAccountTypeDto>> GetAllAPAccountType()
        {
            GetAllAPAccountTypeResponseModel getAllAPAccountTypeResponseModel = new GetAllAPAccountTypeResponseModel();

            getAllAPAccountTypeResponseModel = await aPAccountTypes.GetAllAPAccountType();

            if (getAllAPAccountTypeResponseModel.IsSuccess)
            {
                if (getAllAPAccountTypeResponseModel != null && getAllAPAccountTypeResponseModel.Data.Count() > 0)
                {
                    return getAllAPAccountTypeResponseModel.Data;
                }
            }

            return new List<APAccountTypeDto>();
        }


        public async Task<CreateAPAccountTypeResponseModel> CreateAPAccountType(CreateAPAccountTypeDto billing)
        {
            return await aPAccountTypes.CreateAPAccountType(billing);
        }

        public async Task<UpdateAPAccountTypeResponseModel> UpdateAPAccountType(APAccountTypeDto updatedbilling)
        {
            return await aPAccountTypes.UpdateAPAccountType(updatedbilling);
        }

        public async Task<GetAPAccountTypeByIdResponseModel> GetAPAccountTypeById(Guid billingId)
        {
            return await aPAccountTypes.GetAPAccountTypeById(billingId);
        }

        public async Task<bool> DeleteAPAccountType(Guid billingId)
        {
            return await aPAccountTypes.DeleteAPAccountType(billingId);
        }

        #endregion


        #region Template

        public async Task<IEnumerable<TemplateDto>> GetAllTemplates()
        {
            GetAllTemplatesResponseModel getAllTemplatesResponseModel = new GetAllTemplatesResponseModel();

            getAllTemplatesResponseModel = await templates.GetAllTemplates();

            if (getAllTemplatesResponseModel.IsSuccess)
            {
                if (getAllTemplatesResponseModel != null && getAllTemplatesResponseModel.Data.Count() > 0)
                {
                    return getAllTemplatesResponseModel.Data;
                }
            }

            return new List<TemplateDto>();
        }

        public async Task<CreateTemplateResponseModel> CreateTemplate(CreateTemplateDto newTemplate )
        {
            return await templates.CreateTemplate(newTemplate);
        }
        public async Task<UpdateTemplateResponseModel> UpdateTemplate(TemplateDto updatedTemplate)
        {
            return await templates.UpdateTemplate(updatedTemplate);
        }
        public async Task<GetTemplateByIdResponseModel> GetTemplateById(Guid templateId)
        {
            return await templates.GetTemplateById(templateId);
        }
        public async Task<bool> DeleteTemplate(Guid templateId)
        {
            return await templates.DeleteTemplate(templateId);
        }

       
        #endregion

        #region CorrespondenceNote
        public async Task<IEnumerable<CorrespondenceNoteDto>> GetAllCorrespondenceNotes()
        {
            GetAllCorrespondenceNoteResponseModel getAllCorrespondenceNoteResponseModel = new GetAllCorrespondenceNoteResponseModel();

            getAllCorrespondenceNoteResponseModel = await correspondenceNote.GetAllCorrespondenceNotes();

            if (getAllCorrespondenceNoteResponseModel.IsSuccess)
            {
                if (getAllCorrespondenceNoteResponseModel != null && getAllCorrespondenceNoteResponseModel.Data.Count() > 0)
                {
                    return getAllCorrespondenceNoteResponseModel.Data;
                }
            }

            return new List<CorrespondenceNoteDto>();
        }

        public async Task<CreateCorrespondenceNoteResponseModel> CreateCorrespondenceNote(CreateCorrespondenceNoteDto note)
        {
            return await correspondenceNote.CreateCorrespondenceNote(note);
        }

        public async Task<UpdateCorrespondenceNoteResponseModel> UpdateCorrespondenceNote(CorrespondenceNoteDto updatedNote)
        {
            return await correspondenceNote.UpdateCorrespondenceNote(updatedNote);
        }
        public async Task<GetAllCorrespondenceNoteByIdResponseModel> GetCorrespondenceNoteById(Guid Id)
        {
            return await correspondenceNote.GetCorrespondenceNoteById(Id);
        }

        public async Task<bool> DeleteCorrespondenceNote(Guid noteId)
        {
            return await correspondenceNote.DeleteCorrespondenceNote(noteId);
        }

        #endregion

        #region CategoryType
        public async Task<IEnumerable<CategoryTypeDto>> GetAllCategoryType()
        {
            GetAllCategoryTypeResponseModel getAllCategoryTypeResponseModel = new GetAllCategoryTypeResponseModel();

            getAllCategoryTypeResponseModel = await categoryTypes.GetAllCategoryType();

            if (getAllCategoryTypeResponseModel.IsSuccess)
            {
                if (getAllCategoryTypeResponseModel != null && getAllCategoryTypeResponseModel.Data.Count() > 0)
                {
                    return getAllCategoryTypeResponseModel.Data;
                }
            }

            return new List<CategoryTypeDto>();
        }

        public async Task<CreateCategoryTypeResponseModel> CreateCategoryType(CreateCategoryTypeDto category)
        {
            return await categoryTypes.CreateCategoryType(category);
        }

        public async Task<UpdateCategoryTypeResponseModel> UpdateCategoryType(CategoryTypeDto updatedcategory)
        {
            return await categoryTypes.UpdateCategoryType(updatedcategory);
        }
        public async Task<GetCategoryTypeByIdResponseModel> GetCategoryTypeById(Guid dataId)
        {
            return await categoryTypes.GetCategoryTypeById(dataId);
        }

        public async Task<bool> DeleteCategoryType(Guid dataId)
        {
            return await categoryTypes.DeleteCategoryType(dataId);
        }

        #endregion

        #region PharmacyType

        public async Task<IEnumerable<PharmacyTypeDto>> GetAllPharmcayType()
        {
            GetAllPharmacyTypeResponseModel getAllPharmacyTypeResponseModel = new GetAllPharmacyTypeResponseModel();

            getAllPharmacyTypeResponseModel = await pharmacyTypes.GetAllPharmacyTypes();

            if (getAllPharmacyTypeResponseModel.IsSuccess)
            {
                if (getAllPharmacyTypeResponseModel != null && getAllPharmacyTypeResponseModel.Data.Count() > 0)
                {
                    return getAllPharmacyTypeResponseModel.Data;
                }
            }

            return new List<PharmacyTypeDto>();
        }
        #endregion
    }
}
