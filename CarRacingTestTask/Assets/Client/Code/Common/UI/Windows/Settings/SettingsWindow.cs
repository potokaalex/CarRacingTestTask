using Client.Code.Common.UI.Toggles.Settings;

namespace Client.Code.Common.UI.Windows.Settings
{
    public class SettingsWindow : WindowBase
    {
        public SettingsToggle MasterAudioToggle;

        public override WindowType GetBaseType() => WindowType.Settings;
    }
}