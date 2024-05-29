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
        public const string UpdateAdminUser = "/api/AdminUser?api-version=1";

        public const string DeleteAdminUser = "/api/AdminUser/{id}?api-version=1";
        #endregion

        #region - AdminROle
        public const string GetAllAdminRole = "/api/AdminRole?api-version=1";

        public const string CreateAdminRole = "/api/AdminRole/create?api-version=1";

        public const string GetAdminRoleById = "/api/AdminRole/{id}?api-version=1"; 

        public const string UpdateAdminRole = "/api/AdminRole?api-version=1";

        public const string DeleteAdminRole = "/api/AdminRole/{id}?api-version=1";
        #endregion




        public const string GetAllSysPrefGeneralBehaviour = "/api/SysPref_GeneralBehaviour/all?api-version=1";

        public const string CreatelSysPrefGeneralBehaviour = "/api/SysPref_GeneralBehaviour?api-version=1";

        public const string UpdateSysPrefGeneralBehaviour = "/api/SysPref_GeneralBehaviour?api-version=1";

        public const string DeleteSysPrefGeneralBehaviour = "/api/SysPref_GeneralBehaviour/{id}?api-version=1";

        public const string GetSysPrefGeneralBehaviourById = "/api/SysPref_GeneralBehaviour/{id}?api-version=1";


        public const string GetAllSysPrefFinancial = "/api/SysPrefFinancial/list?api-version=1";
        public const string CreateSysPrefFinancial = "/api/SysPrefFinancial/create?api-version=1";
        public const string UpdateSysPrefFinancial = "/api/SysPrefFinancial/update?api-version=1";
        public const string GetSysPrefFinancialById = "/api/SysPrefFinancial/{id}?api-version=1";
        public const string DeleteSysPrefFinancial = "/api/SysPrefFinancial/{id}?api-version=1";




    }
}
