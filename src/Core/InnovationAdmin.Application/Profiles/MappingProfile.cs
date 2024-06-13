using AutoMapper;
using InnovationAdmin.Application.Features.AdminRoles.Commands.CreateAdminRole;
using InnovationAdmin.Application.Features.AdminRoles.Commands.DeleteAdminRole;
using InnovationAdmin.Application.Features.AdminRoles.Commands.UpdateAdminRole;
using InnovationAdmin.Application.Features.AdminRoles.Queries.GetAdminRole;
using InnovationAdmin.Application.Features.AdminRoles.Queries.GetAdminRoleList;
using InnovationAdmin.Application.Features.SysPref_GeneralBehaviour.Commands.Create_SysPref_GeneralBehaviour;
using InnovationAdmin.Application.Features.SysPref_GeneralBehaviour.Commands.Update_SysPref_GeneralBehaviour;
using InnovationAdmin.Application.Features.SysPref_GeneralBehaviour.Queries.Get_SysPref_GeneralBehaviour_List;
using InnovationAdmin.Application.Features.SysPref_GeneralBehaviour.Queries.GetById_SysPref_GeneralBehaviour;
using InnovationAdmin.Application.Features.Admin_Users.Commands.CreateAdmin_User;
using InnovationAdmin.Application.Features.Admin_Users.Commands.CreateAdminUser;
using InnovationAdmin.Application.Features.Admin_Users.Commands.DeleteAdminUser;
using InnovationAdmin.Application.Features.Admin_Users.Commands.UpdateAdminUser;
using InnovationAdmin.Application.Features.Admin_Users.Queries.GetAdminUserById;
using InnovationAdmin.Application.Features.Admin_Users.Queries.GetAdminUserList;
using InnovationAdmin.Application.Features.SysPrefCompanies.Commands.CreateSysPrefCompany;
using InnovationAdmin.Application.Features.SysPrefCompanies.Commands.UpdateSysPrefCompany;
using InnovationAdmin.Application.Features.SysPrefCompanies.Queries.GetSysPrefCompanyQuery;
using InnovationAdmin.Domain.Entities;
using Microsoft.Extensions.Logging;
using InnovationAdmin.Application.Features.PharmacyGroup.Commands.CreatePharmacyGroup;
using InnovationAdmin.Application.Features.PharmacyGroup.Commands.UpdatePharmacyGroup;
using InnovationAdmin.Application.Features.PharmacyGroup.Queries.GetPharmacyGroupQuery;
using InnovationAdmin.Application.Features.AccountManager.Commands.CreateAccountManager;
using InnovationAdmin.Application.Features.AccountManager.Queries.GetAccountManagerById;
using InnovationAdmin.Application.Features.SysPrefSecurityEmails.Commands.CreateSysPrefSecurityEmail;
using InnovationAdmin.Application.Features.SysPrefSecurityEmails.Queries.GetSysPrefSecurityEmailById;
using InnovationAdmin.Application.Features.SysPrefSecurityEmails.Queries.GetSysPrefSecurityEmailList;
using InnovationAdmin.Application.Features.SysPrefSecurityEmails.Commands.UpdateSysPrefSecurityEmail;

using InnovationAdmin.Application.Features.SysPrefFinancials.Commands.CreateSysPrefFinancial;
using InnovationAdmin.Application.Features.SysPrefFinancials.Commands.UpdateSysPrefFinancial;
using InnovationAdmin.Application.Features.SysPrefFinancials.Commands.DeleteSysPrefFinancial;
using InnovationAdmin.Application.Features.SysPrefFinancials.Queries.GetSysPrefFinancialList;
using InnovationAdmin.Application.Features.SysPrefFinancials.Queries.GetSysPrefFinancial;
using InnovationAdmin.Application.Features.Quote.Commands.CreateQuote;
using InnovationAdmin.Application.Features.Quote.Commands.UpdateQuote;
using InnovationAdmin.Application.Features.Quote.Commands.DeleteQuote;
using InnovationAdmin.Application.Features.Quote.Queries.GetQuote;
using InnovationAdmin.Application.Features.Quote.Queries.GetQuotesList;
using InnovationAdmin.Application.Features.ReceiptBatchSource.Commands.CraeateReceiptBatchSource;
using InnovationAdmin.Application.Features.ReceiptBatchSource.Queries.GetReceiptBatchSourceQuery;
using InnovationAdmin.Application.Features.ReceiptBatchSource.Commands.UpdateReceiptBatchSource;
using InnovationAdmin.Application.Features.RemittanceType.Commands.CreateRemittanceType;
using InnovationAdmin.Application.Features.RemittanceType.Commands.UpdateRemittanceType;
using InnovationAdmin.Application.Features.RemittanceType.Queries.GetRemittanceTypeQuery;
using InnovationAdmin.Application.Features.DataSources.Commands.CreateDataSource;
using InnovationAdmin.Application.Features.DataSources.Queries.GetDataSourceById;
using InnovationAdmin.Application.Features.DataSources.Queries.GetDataSourceList;
using InnovationAdmin.Application.Features.DataSources.Commands.UpdateDataSource;
using InnovationAdmin.Application.Features.DoNotTakeGroup.Commands.CreateDoNotTakeGroup;
using InnovationAdmin.Application.Features.DoNotTakeGroup.Queries.GetDoNotTakeGroupQuery;
using InnovationAdmin.Application.Features.DoNotTakeGroup.Commands.UpdateDoNotTakeGroup;

namespace InnovationAdmin.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            //ACCOunt Manager
            CreateMap<AccountManager, CreateAccountManagerDto>().ReverseMap();
            CreateMap<AccountManager,AccountManagerDto>().ReverseMap();

            CreateMap<Admin_User, CreateAdminUserDto>();
            CreateMap<Admin_User, CreateAdminUserDto>().ReverseMap();
            CreateMap<Admin_User, AdminUserListVm>().ReverseMap();

            CreateMap<Admin_User, CreateAdminUserCommand>().ReverseMap();
            CreateMap<Admin_User, UpdateAdminUserCommand>().ReverseMap();
            CreateMap<Admin_User, DeleteAdminUserCommand>();
         

            CreateMap<SysPrefCompany, CreateSysPrefCompanyDto>().ReverseMap();
            CreateMap<SysPrefCompany, SysPrefCompanyDto>().ReverseMap();
            CreateMap<SysPrefCompany, UpdateSysPrefCompanyDto>().ReverseMap();
    
            CreateMap<SysPref_GeneralBehaviours, Create_SysPref_GeneralBehaviour_Command>().ReverseMap();

            CreateMap<SysPref_GeneralBehaviours, Update_SysPref_GeneralBehaviour_Command>().ReverseMap();
            CreateMap<SysPref_GeneralBehaviours, SysPref_GeneralBehaviour_ListVM>().ReverseMap();
            CreateMap<Admin_User, AdminUserByIdVm>().ReverseMap();

     

            CreateMap<PharmacyGroup, CreatePharmacyGroupCommand>().ReverseMap();
            CreateMap<PharmacyGroup, CreatePharmacyGroupDto>().ReverseMap();
            CreateMap<PharmacyGroup, UpdateSysPrefCompanyCommand>().ReverseMap();
            CreateMap<PharmacyGroup, UpdatePharmacyGroupDto>().ReverseMap();
            CreateMap<PharmacyGroup, PharmacyGroupDto>().ReverseMap();
            CreateMap<PharmacyGroup, GetPharmacyGroupByIdQuery>().ReverseMap();
            CreateMap<PharmacyGroup, GetPharmacyGroupByIdQuery>().ReverseMap();

            CreateMap<RemittanceType, CreateRemittanceTypeCommand>().ReverseMap();
            CreateMap<RemittanceType, CreateRemittanceTypeDto>().ReverseMap();
            CreateMap<RemittanceType, UpdateRemittanceTypeCommand>().ReverseMap();
            CreateMap<RemittanceType, UpdateRemittanceTypeDto>().ReverseMap();
            CreateMap<RemittanceType, RemittanceTypeDto>().ReverseMap();
            CreateMap<RemittanceType, GetRemittanceTypeByIdQuery>().ReverseMap();
            CreateMap<RemittanceType, GetRemittanceTypeByIdQuery>().ReverseMap();


            CreateMap<SysPref_GeneralBehaviours, Create_SysPref_GeneralBehaviour_Dto>();
            CreateMap<SysPref_GeneralBehaviours, SysPref_GeneralBehaviour_ListVM>();
            CreateMap<SysPref_GeneralBehaviours, Create_SysPref_GeneralBehaviour_Command>();

            CreateMap<SysPref_GeneralBehaviours, Update_SysPref_GeneralBehaviour_Command>().ReverseMap();
            CreateMap<SysPref_GeneralBehaviours, Get_SysPref_GeneralBehaviour_List_Query>().ReverseMap();
            CreateMap<SysPref_GeneralBehaviours, GetById_SysPref_GeneralBehaviours_VM>();
        
    

       
           // CreateMap<Category, UpdateCategoryCommand>().ReverseMap();
       
            CreateMap<SysPrefCompany, CreateSysPrefCompanyDto>().ReverseMap();
            CreateMap<SysPrefCompany, SysPrefCompanyDto>().ReverseMap();
            CreateMap<SysPrefCompany, UpdateSysPrefCompanyDto>().ReverseMap();
            
         

            CreateMap<Admin_Role, AdminRoleVM>();
            CreateMap<Admin_Role, CreateAdminRoleCommand>();
            CreateMap<Admin_Role, CreateAdminRoleCommand>();
            CreateMap<Admin_Role, DeleteAdminRoleCommand>();
            CreateMap<Admin_Role, UpdateAdminRoleCommand>();
            CreateMap<Admin_Role, AdminRoleListVm>();



            // CreateMap<Category, UpdateCategoryCommand>().ReverseMap();

            CreateMap<Admin_Role, AdminRoleVM>().ReverseMap();
            CreateMap<Admin_Role, CreateAdminRoleCommand>().ReverseMap();
            CreateMap<Admin_Role, CreateAdminRoleCommand>().ReverseMap();
            CreateMap<Admin_Role, DeleteAdminRoleCommand>().ReverseMap();
            CreateMap<Admin_Role, UpdateAdminRoleCommand>().ReverseMap();
            CreateMap<Admin_Role, AdminRoleListVm>().ReverseMap();

            CreateMap<Admin_Role, CreateAdminRoleDto>();


        
            CreateMap<SysPrefSecurityEmail, CreateSysPrefSecurityEmailDto>().ReverseMap();
            CreateMap<SysPrefSecurityEmail, GetSysPrefSecurityEmailByIdVm>().ReverseMap();
            CreateMap<SysPrefSecurityEmail, GetSysPrefSecurityEmailListVm>().ReverseMap();
            CreateMap<SysPrefSecurityEmail, UpdateSysPrefSecurityEmailCommand>().ReverseMap();
            CreateMap<SysPrefSecurityEmail, GetSysPrefSecurityEmailByIdVm>().ReverseMap();
            CreateMap<SysPrefSecurityEmail, CreateSysPrefSecurityEmailCommand>().ReverseMap();
            CreateMap<SysPrefSecurityEmail, UpdateSysPrefSecurityEmailCommandDto>().ReverseMap();
           


            CreateMap<SysPrefFinancial, CreateSysPrefFinancialDto>().ReverseMap();
            CreateMap<SysPrefFinancial, UpdateSysPrefFinancialDto>().ReverseMap();
            CreateMap<SysPrefFinancial, DeleteSysPrefFinancialCommand>();
            CreateMap<SysPrefFinancial, SysPrefFinancialListVM>();
            CreateMap<SysPrefFinancial, SysPrefFinancialVM>();


            CreateMap<Quotes, CreateQuoteDto>().ReverseMap();
            CreateMap<Quotes, UpdateQuoteDto>().ReverseMap();
            CreateMap<Quotes, DeleteQuoteCommand>().ReverseMap();
            CreateMap<Quotes, QuoteListVM>();
            CreateMap<Quotes, QuoteVM>();
            CreateMap<Quotes, UpdateQuoteCommand>().ReverseMap();


            CreateMap<ReceiptBatchSource, CreateReceiptBatchDto>().ReverseMap();
            CreateMap<ReceiptBatchSource, ReceiptBatchSourceDto>().ReverseMap();
            CreateMap<ReceiptBatchSource, UpdateReceiptBAtchSourceDto>().ReverseMap();
            CreateMap<ReceiptBatchSource, UpdateReceiptBAtchSourceCommand>().ReverseMap();

            CreateMap<DoNotTakeGroup, CreateDoNoTakeGroupDto>().ReverseMap();
            CreateMap<DoNotTakeGroup, DoNotTakeGroupDto>().ReverseMap();
            CreateMap<DoNotTakeGroup, UpdateDoNotTakeGroupDto>().ReverseMap();  
            CreateMap<DoNotTakeGroup, UpdateDoNotTakeGroupCommand>().ReverseMap();    




            CreateMap<DataSource, CreateDataSourceDto>().ReverseMap();
            CreateMap<DataSource, GetDataSourceByIdVm>().ReverseMap();
            CreateMap<DataSource, GetDataSourceListVm>().ReverseMap();
            CreateMap<DataSource, UpdateDataSourceCommand>().ReverseMap();
            CreateMap<DataSource, CreateDataSourceCommand>().ReverseMap();
            CreateMap<DataSource, UpdateDataSourceCommandDto>().ReverseMap();







        }
    }
}
