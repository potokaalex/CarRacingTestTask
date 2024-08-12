namespace Client.Code.Common.UI.Elements.Toggles.Settings
{
    public interface ISettingsToggleHandler
    {
        void Handle(SettingsToggleType type, bool isActive);
    }
}