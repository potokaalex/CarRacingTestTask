namespace Client.Code.Common.UI.Toggles.Settings
{
    public interface ISettingsToggleHandler
    {
        void Handle(SettingsToggleType type, bool isActive);
    }
}