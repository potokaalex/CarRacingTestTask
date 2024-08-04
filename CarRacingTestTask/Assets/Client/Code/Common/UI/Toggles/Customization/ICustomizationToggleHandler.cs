namespace Client.Code.Common.UI.Toggles.Customization
{
    public interface ICustomizationToggleHandler
    {
        void Handle(CustomizationToggleType type, bool isActive);
    }
}