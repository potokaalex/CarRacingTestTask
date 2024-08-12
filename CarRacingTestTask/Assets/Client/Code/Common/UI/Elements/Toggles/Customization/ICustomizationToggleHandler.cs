namespace Client.Code.Common.UI.Elements.Toggles.Customization
{
    public interface ICustomizationToggleHandler
    {
        void Handle(CustomizationToggleType type, bool isActive);
    }
}