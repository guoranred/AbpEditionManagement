using Volo.Abp.Authorization.Permissions;
using Volo.Abp.EditionManagement.Localization;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Volo.Abp.EditionManagement
{
    public class EditionManagementPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var editionManagementGroup = context.AddGroup(EditionManagementPermissionNames.GroupName, L("Permission:EditionManagement"));

            var editionsPermission = editionManagementGroup.AddPermission(EditionManagementPermissionNames.Editions.Default, L("Permission:EditionManagement"), multiTenancySide: MultiTenancySides.Host);
            editionsPermission.AddChild(EditionManagementPermissionNames.Editions.Create, L("Permission:Create"), multiTenancySide: MultiTenancySides.Host);
            editionsPermission.AddChild(EditionManagementPermissionNames.Editions.Update, L("Permission:Edit"), multiTenancySide: MultiTenancySides.Host);
            editionsPermission.AddChild(EditionManagementPermissionNames.Editions.Delete, L("Permission:Delete"), multiTenancySide: MultiTenancySides.Host);
            editionsPermission.AddChild(EditionManagementPermissionNames.Editions.ManageFeatures, L("Permission:ManageFeatures"), multiTenancySide: MultiTenancySides.Host);
            editionsPermission.AddChild(EditionManagementPermissionNames.Editions.ManagePrices, L("Permission:ManagePrices"), multiTenancySide: MultiTenancySides.Host);
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AbpEditionManagementResource>(name);
        }
    }
}