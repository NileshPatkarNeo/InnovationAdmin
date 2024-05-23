﻿namespace Innovation_Admin.UI.Helper
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




        public const string GetAllSysPrefGeneralBehaviour = "/api/SysPref_GeneralBehaviour/all?api-version=1";

        public const string CreatelSysPrefGeneralBehaviour = "/api/SysPref_GeneralBehaviour?api-version=1";

        public const string UpdateSysPrefGeneralBehaviour = "/api/SysPref_GeneralBehaviour?api-version=1";

        public const string DeleteSysPrefGeneralBehaviour = "/api/SysPref_GeneralBehaviour/{id}?api-version=1";

        public const string GetSysPrefGeneralBehaviourById = "/api/SysPref_GeneralBehaviour/{id}?api-version=1";



       
    }
}
