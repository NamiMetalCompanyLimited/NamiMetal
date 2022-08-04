using Volo.Abp.Settings;

namespace NamiMetal.Settings;

public class NamiMetalSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(NamiMetalSettings.MySetting1));
    }
}
