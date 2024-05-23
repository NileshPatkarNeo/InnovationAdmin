namespace Innovation_Admin.UI.Helper
{
    public static class URLHelper
    {
        #region - SysPrefCompany
        public const string GetAllSysPrefCompany= "/api/SysPrefCompany?api-version=1";
        #endregion

        #region - AdminROle
        public const string GetAllAdminRole = "/api/AdminRole?api-version=1";

        public const string CreateAdminRole = "/api/AdminRole/create?api-version=1";

        public const string GetAdminRoleById = "/api/AdminRole/{id}?api-version=1"; 

        public const string UpdateAdminRole = "/api/AdminRole?api-version=1";

        public const string DeleteAdminRole = "/api/AdminRole/{id}?api-version=1";
        #endregion
    }
}
