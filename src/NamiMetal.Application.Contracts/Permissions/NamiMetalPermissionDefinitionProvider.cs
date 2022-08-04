using NamiMetal.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace NamiMetal.Permissions;

public class NamiMetalPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(NamiMetalPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(NamiMetalPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<NamiMetalResource>(name);
    }
}
