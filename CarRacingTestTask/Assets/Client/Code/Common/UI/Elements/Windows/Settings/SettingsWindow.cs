using Client.Code.Common.UI.Elements.Toggles.Settings;

namespace Client.Code.Common.UI.Elements.Windows.Settings
{
    public class SettingsWindow : WindowBase
    {
        public SettingsToggle MasterAudioToggle;

        public override WindowType GetBaseType() => WindowType.Settings;
    }
}