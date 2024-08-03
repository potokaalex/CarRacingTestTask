namespace Client.Code.UI.Toggles.Settings
{
    public interface ISettingsToggleHandler
    {
        void Handle(SettingsToggleType type, bool isActive);
    }
}