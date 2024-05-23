namespace Innovation_Admin.UI.Helper
{
    public static class URLHelper
    {
        #region - SysPrefCompany
        public const string GetAllSysPrefCompany= "/api/SysPrefCompany?api-version=1";
        #endregion


        #region - AdminUser

        public const string GetAllAdminUser = "/api/AdminUser/all?api-version=1";

        public const string CreateAdminUser = "/api/AdminUser?api-version=1";

        public const string GetAdminUserById = "/api/AdminUser/{id}?api-version=1";
        public const string UpdateAdminUser = "/api/AdminUser?api-version=1";

        public const string DeleteAdminUser = "/api/AdminUser/{id}?api-version=1";
        #endregion
    }
}
