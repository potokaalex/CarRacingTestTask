namespace Client.Code.UI.Toggles
{
    public interface ICustomizationToggleHandler
    {
        void Handle(CustomizationToggleType type, bool isActive);
    }
}