using Client.Code.UI.Toggles.Settings;

namespace Client.Code.UI.Windows.Settings
{
    public class SettingsWindow : WindowBase
    {
        public SettingsToggle MasterAudioToggle;
        
        public override WindowType GetBaseType() => WindowType.Settings;
    }
}