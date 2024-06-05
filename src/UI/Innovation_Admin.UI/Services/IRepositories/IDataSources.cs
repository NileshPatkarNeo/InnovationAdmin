using Innovation_Admin.UI.Models.DataSource;
using Innovation_Admin.UI.Models.ResponsesModel.DataSource;

namespace Innovation_Admin.UI.Services.IRepositories
{
    public interface IDataSources
    {

        Task<GetAllDataSourceResponseModel> GetAllDataSource();

        Task<CreateDataSourceResponseModel> CreateDataSource(CreateDataSourceDto data);

        Task<UpdateDataSourceResponseModel> UpdateDataSource(DataSourceDto updatedDataSource);

        Task<GetDataSourceByIdResponseModel> GetDataSourceById(Guid dataSourceId);

        Task<bool> DeleteDataSource(Guid dataSourceId);
    }
}
