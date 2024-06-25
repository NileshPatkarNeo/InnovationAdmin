using System;

namespace Innovation_Admin.UI.Helper
{
    public static class URLHelper
    {
        #region - SysPrefCompany
        public const string GetAllSysPrefCompany= "/api/SysPrefCompany?api-version=1";

        public const string GetSysPrefCompaynyById = "/api/SysPrefCompany/{id}?api-version=1";

        public const string CreateSysPrefCompany = "/api/SysPrefCompany?api-version=1";

        public const string UpdateSysPrefCompany = "/api/SysPrefCompany/{id}?api-version=1";
        
        public const string DeleteSysPrefCompany = "/api/SysPrefCompany/{id}?api-version=1";
        #endregion


        #region Authenticate
        public const string Authenticate = "/api/v1/Account/authenticate";
        #endregion


        #region - AdminUser

        public const string GetAllAdminUser = "/api/AdminUser/all?api-version=1";

        public const string CreateAdminUser = "/api/AdminUser?api-version=1";

        public const string GetAdminUserById = "/api/AdminUser/{id}?api-version=1";

        public const string UpdateAdminUser = "/api/AdminUser?id={id}&api-version=1";

        public const string DeleteAdminUser = "/api/AdminUser/{id}?api-version=1";
        #endregion

        #region - AdminROle
        public const string GetAllAdminRole = "/api/AdminRole?api-version=1";

        public const string CreateAdminRole = "/api/AdminRole/create?api-version=1";

        public const string GetAdminRoleById = "/api/AdminRole/{id}?api-version=1"; 

        public const string UpdateAdminRole = "/api/AdminRole?api-version=1";

        public const string DeleteAdminRole = "/api/AdminRole/{id}?api-version=1";
        #endregion


        #region SysPrefGeneralBehaviour

        public const string GetAllSysPrefGeneralBehaviour = "/api/SysPref_GeneralBehaviour/all?api-version=1";

        public const string CreatelSysPrefGeneralBehaviour = "/api/SysPref_GeneralBehaviour?api-version=1";

        public const string UpdateSysPrefGeneralBehaviour = "/api/SysPref_GeneralBehaviour?api-version=1";

        public const string DeleteSysPrefGeneralBehaviour = "/api/SysPref_GeneralBehaviour/{id}?api-version=1";

        public const string GetSysPrefGeneralBehaviourById = "/api/SysPref_GeneralBehaviour/{id}?api-version=1";

        #endregion

        #region SysPrefSecurityEmail
        public const string GetAllSysPrefSecurityEmail = "/api/SysPrefSecurityEmail/all?api-version=1";

        public const string CreateSysPrefSecurityEmail = "/api/SysPrefSecurityEmail?api-version=1";

        public const string GetSysPrefSecurityEmailById = "/api/SysPrefSecurityEmail/{id}?api-version=1";
        public const string UpdateSysPrefSecurityEmail = "/api/SysPrefSecurityEmail?api-version=1";

        public const string DeleteSysPrefSecurityEmail = "/api/SysPrefSecurityEmail/{id}?api-version=1";

        #endregion


        #region Accoun_Manager

        public const string GetAllAccountManagers = "/api/AccountManager?api-version=1";
        public const string CreateAccountManager = "/api/AccountManager?api-version=1";
        public const string UpdateAccountManager = "/api/AccountManager?api-version=1";
        public const string GetAccountManagerById = "/api/AccountManager/{id}?api-version=1";
        public const string DeleteAccountManager = "/api/AccountManager/{id}?api-version=1";


        #endregion


        #region SysPrefFinancial
        public const string GetAllSysPrefFinancial = "/api/SysPrefFinancial/list?api-version=1";
        public const string CreateSysPrefFinancial = "/api/SysPrefFinancial/create?api-version=1";
        public const string UpdateSysPrefFinancial = "/api/SysPrefFinancial/update?api-version=1";
        public const string GetSysPrefFinancialById = "/api/SysPrefFinancial/{id}?api-version=1";
        public const string DeleteSysPrefFinancial = "/api/SysPrefFinancial/{id}?api-version=1";

        #endregion


        #region Category

        public const string GetAllPharmacyGroup = "/api/Category/all? api-version=1";

        public const string CreatePharmacyGroup = "/api/Category?api-version=1";

        public const string UpdatePharmacyGroup = "/api/Category/{id}?api-version=1";

        public const string GetPharmacyGroupById = "/api/Category/{id}?api-version=1";

        public const string DeletePharmacyGroup = "/api/Category/{id}?api-version=1";

        #endregion

        #region ReceiptBatchSource
        public const string GetAllReceiptBatchSource = "/api/ReceiptBatchSource?api-version=1";

        public const string GetReceiptBatchSourceById = "/api/ReceiptBatchSource/{id}?api-version=1";

        public const string CreateReceiptBatchSource = "/api/ReceiptBatchSource?api-version=1";

        public const string UpdateReceiptBatchSource = "/api/ReceiptBatchSource/{id}?api-version=1";

        public const string DeleteReceiptBatchSource = "/api/ReceiptBatchSource/{id}?api-version=1";


        #endregion

        #region Quote

        public const string GetAllQuotes = "/api/Quote?api-version=1";

        public const string CreateQuote = "/api/Quote/create?api-version=1";

        public const string GetQuoteById = "/api/Quote/{id}?api-version=1";

        public const string UpdateQuote = "/api/Quote?api-version=1";

        public const string DeleteQuote = "/api/Quote/{id}?api-version=1";

        #endregion


        #region RemittanceType
        public const string GetAllRemittanceType = "/api/RemittanceType/all?api-version=1";

        public const string CreateRemittanceType = "/api/RemittanceType?api-version=1";

        public const string UpdateRemittanceType = "/api/RemittanceType/{id}?api-version=1";

        public const string GetRemittanceTypeById = "/api/RemittanceType/{id}?api-version=1";

        public const string DeleteRemittanceType = "/api/RemittanceType/{id}?api-version=1";

        #endregion

        #region DataSource
        public const string GetAllDataSource = "/api/DataSource/all?api-version=1";

        public const string CreateDataSource = "/api/DataSource?api-version=1";

        public const string GetDataSourceById = "/api/DataSource/{id}?api-version=1";
        public const string UpdateDataSource = "/api/DataSource?api-version=1   ";

        public const string DeleteDataSource = "/api/DataSource/{id}?api-version=1";


        #endregion

        #region DoNotTakeGroup

        public const string GetAllDoNotTakeGroup = "/api/DoNotTakeGroup?api-version=1";

        public const string GetDoNotTakeGroupByID = "/api/DoNotTakeGroup/{id}?api-version=1";

        public const string CreateDoNotTakeGroup = "/api/DoNotTakeGroup?api-version=1";

        public const string UpdateDoNotTakeGroup = "/api/DoNotTakeGroup/?api-version=1";
        
        public const string DeleteDoNotTakeGroup = "/api/DoNotTakeGroup/{id}?api-version=1";

        #endregion

        #region BillingMethodType
        public const string GetAllBillingMethodType = "/api/BillingMethodType/all?api-version=1";

        public const string CreateBillingMethodType = "/api/BillingMethodType?api-version=1";

        public const string GetBillingMethodTypeById = "/api/BillingMethodType/{id}?api-version=1";
        public const string UpdateBillingMethodType = "/api/BillingMethodType?api-version=1";

        public const string DeleteBillingMethodType = "/api/BillingMethodType/{id}?api-version=1";
        #endregion

        #region APAccountType

        public const string GetAllAPAccountType = "/api/APAccountType/all?api-version=1";

        public const string CreateAPAccountType = "/api/APAccountType?api-version=1";

        public const string GetAPAccountTypeById = "/api/APAccountType/{id}?api-version=1";
        public const string UpdateAPAccountType = "/api/APAccountType?api-version=1";

        public const string DeleteAPAccountType = "/api/APAccountType/{id}?api-version=1";

        #endregion
        #region Template 

            public static string GetAllTemplates = "/api/Template?api-version=1";
            public static string CreateTemplate = "/api/Template/create?api-version=1";
            public static string UpdateTemplate = "/api/Template?api-version=1";
            public static string GetTemplateById = "/api/Template/{id}?api-version=1";
            public static string DeleteTemplate = "/api/Template/{id}?api-version=1";
       

        #region CorrespondenceNotes

        public const string GetAllCorrespondenceNote = "/api/CorrespondenceNotes/all?api-version=1";

        public const string CreateCorrespondenceNote = "/api/CorrespondenceNotes?api-version=1";

        public const string UpdateCorrespondenceNote = "/api/CorrespondenceNotes/{id}?api-version=1";

        public const string GetCorrespondenceNoteById = "/api/CorrespondenceNotes/{id}?api-version=1";

        public const string DeleteCorrespondenceNote = "/api/CorrespondenceNotes/{id}?api-version=1";

        #endregion


        #endregion

        #region PharmacyType

        public const string GetAllPharmacyType = "/api/PharmacyType?api-version=1";

        public const string CreatePharmacyType = "/api/Category?api-version=1";

        public const string UpdatePharmacyType = "/api/Category/{id}?api-version=1";

        public const string GetPharmacyTypeById = "/api/Category/{id}?api-version=1";

        public const string DeletePharmacyType = "/api/Category/{id}?api-version=1";

        #endregion


        #region CategoryType
        public const string GetAllCategoryType = "/api/CategoryType/all?api-version=1";

        #endregion


        #region ClaimStatus
        public const string GetAllClaimStatus = "/api/ClaimStatus?api-version=1";

        public const string GetClaimStatusByID = "/api/ClaimStatus/{id}?api-version=1";

        public const string CreateClaimStatus = "/api/ClaimStatus?api-version=1";

        public const string UpdateClaimStatus = "/api/ClaimStatus/?api-version=1";

        public const string DeleteClaimStatus = "/api/ClaimStatus/{id}?api-version=1";
        #endregion
    }
}
