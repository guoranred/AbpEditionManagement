using Volo.Abp.Application.Services;
using Volo.Abp.EditionManagement.Localization;

namespace Volo.Abp.EditionManagement
{
    public abstract class EditionManagementAppServiceBase : ApplicationService
    {
        protected EditionManagementAppServiceBase()
        {
            LocalizationResource = typeof(AbpEditionManagementResource);
            ObjectMapperContext = typeof(AbpEditionManagementApplicationModule);
        }
    }
}